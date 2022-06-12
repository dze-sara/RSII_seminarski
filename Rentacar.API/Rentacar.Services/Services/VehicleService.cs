using AutoMapper;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Enums;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using Rentacar.Entities;
using Rentacar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Services.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<VehicleBaseDto> AddVehicle(NewVehicleRequest newVehicle)
        {
            var vehicle = await _vehicleRepository.AddVehicle(newVehicle);
            var vehicleDto = new VehicleBaseDto()
            {
                IsActive = vehicle.IsActive,
                Make = vehicle.Model.Make?.MakeName,
                Model = vehicle.Model.ModelName,
                NumberOfSeats = vehicle.Model.NoOfSeats,
                RatePerDay = vehicle.RatePerDay,
                TransmissionType = (TransmissionTypeEnum)vehicle.TransmissionType,
                VehicleId = vehicle.VehicleId,
                VehicleType = vehicle.Model.VehicleType?.VehicleTypeName
            };
            return vehicleDto;
        }

        public async Task<VehicleBaseDto> UpdateVehicle(int vehicleId, NewVehicleRequest request)
        {
            var vehicle = await _vehicleRepository.UpdateVehicle(vehicleId, request);

            var vehicleDto = new VehicleBaseDto()
            {
                IsActive = vehicle.IsActive,
                Make = vehicle.Model.Make?.MakeName,
                Model = vehicle.Model.ModelName,
                NumberOfSeats = vehicle.Model.NoOfSeats,
                RatePerDay = vehicle.RatePerDay,
                TransmissionType = (TransmissionTypeEnum)vehicle.TransmissionType,
                VehicleId = vehicle.VehicleId,
                VehicleType = vehicle.Model.VehicleType?.VehicleTypeName
            };

            return vehicleDto;
        }

        public async Task<ICollection<VehicleBaseDto>> FilterVehicles(TransmissionTypeEnum? transmissionType, DateTime? bookingStartTime, DateTime? bookingEndTime, int? vehicleType)
        {
            var vehicles = _mapper.Map<List<VehicleBaseDto>>(await _vehicleRepository.FilterVehicles((int?)transmissionType, bookingStartTime, bookingEndTime, vehicleType));

            int numberOfDays = (bookingEndTime - bookingStartTime).GetValueOrDefault().Days;

            foreach(VehicleBaseDto v in vehicles)
            {
                v.TotalPrice = v.RatePerDay * numberOfDays;
            }

            return vehicles;
        }

        public async Task<ICollection<VehicleBaseDto>> FilterVehicles(VehicleRequestDto request)
        {
             return await _vehicleRepository.FilterVehicles(request);
        }

        public async Task<ICollection<VehicleBaseDto>> GetRecommendationsForUser(int userId)
        {
            List<Review> userReviews = await _vehicleRepository.GetReviewsForUser(userId);

            List<Model> modelsUserRated = userReviews.Select(x => x.Model).ToList();
            List<Model> modelsUserDidNotRate = await _vehicleRepository.GetOtherModelsReviews(modelsUserRated, userId);

            List<Review> otherReviews = new List<Review>();
            List<int> modelsToRecommend = new List<int>();
            foreach (var ratedModel in modelsUserRated)
            {
                if (userReviews.Where(x => x.ModelId == ratedModel.ModelId).First().Score > 3)
                {
                    foreach (var unratedModel in modelsUserDidNotRate)
                    {
                        if (ratedModel.VehicleTypeId == unratedModel.VehicleTypeId)
                            otherReviews = unratedModel.Reviews.ToList();

                        double similarity = ComputeSimilarityPearson(ratedModel.Reviews.ToList(), otherReviews);

                        if (similarity > 0.5)
                        {
                            modelsToRecommend.Add(unratedModel.ModelId);
                        }
                    }
                }
            }

            var vehiclesEf = await _vehicleRepository.GetVehiclesByModelsId(modelsToRecommend);
            return _mapper.Map<List<VehicleBaseDto>>(vehiclesEf);
        }

        public async Task<ICollection<VehicleBaseDto>> GetRecommendedVehicles(int userId)
        {
            // Get user's last vehicle model
            Vehicle lastVehicle = await _vehicleRepository.GetVehicleByUserId(userId);

            // Get other vehicle models
            ICollection<Vehicle> availableVehicles = await _vehicleRepository.GetVehicles();

            // Calculate vehicle with lowest hamming distance
            List<Model> recommendations = CalculateLowestDistance(lastVehicle, availableVehicles);

            // Retrieve vehicle with recommended model and return data
            var recommendedVehicles = await _vehicleRepository.GetVehicles(recommendations);

            return _mapper.Map<List<VehicleBaseDto>>(recommendedVehicles);
        }

        private List<Model> CalculateLowestDistance(Vehicle lastVehicle, ICollection<Vehicle> availableVehicles)
        {
            var recommendations = availableVehicles.OrderByDescending(x => CalculateDistance(lastVehicle, x));
            return recommendations.Select(x => x.Model).ToList();
        }

        private decimal CalculateDistance(Vehicle vehicle1, Vehicle vehicle2)
        {
            decimal distance = 0;
            distance += Math.Abs(vehicle1.Model.VehicleTypeId - vehicle2.Model.VehicleTypeId);
            distance += Math.Abs(vehicle1.Model.MakeId - vehicle2.Model.MakeId);
            distance += Math.Abs(vehicle1.Model.ModelId - vehicle2.Model.ModelId);
            distance += Math.Abs(vehicle1.RatePerDay - vehicle2.RatePerDay);
            return distance;
        }

        public async Task<VehicleDto> GetVehicleById(int vehicleId)
        {
            AssertionHelper.AssertInt(vehicleId);

            return _mapper.Map<VehicleDto>(await _vehicleRepository.GetVehicleById(vehicleId));
        }

        public async Task<ICollection<VehicleDto>> GetVehicles()
        {
            return _mapper.Map<List<VehicleDto>>(await _vehicleRepository.GetVehicles());
        }

        public async Task<bool> DeleteVehicle(int vehicleId)
        {
            return await _vehicleRepository.DeleteVehicle(vehicleId);
        }

        public async Task<List<VehiclesReportResponseDto>> VehiclesReport()
        {
            return await _vehicleRepository.VehiclesReport();
        }

        private double ComputeSimilarityPearson(List<Review> model1Reviews, List<Review> model2Reviews)
        {
            if(model1Reviews.Count != model2Reviews.Count)
            {
                return 0;
            }

            double modelsProduct = 0;
            double model1DotProduct = 0;
            double model2DotProduct = 0;

            for (int i = 0; i < model1Reviews.Count; i++)
            {
                modelsProduct += model1Reviews[i].Score * model2Reviews[i].Score;
                model1DotProduct += model1Reviews[i].Score * model1Reviews[i].Score;
                model2DotProduct += model2Reviews[i].Score * model2Reviews[i].Score;
            }

            model1DotProduct = Math.Sqrt(model1DotProduct);
            model2DotProduct = Math.Sqrt(model2DotProduct);

            if(model1DotProduct * model2DotProduct == 0)
            {
                return 0;
            }
            else
            {
                return modelsProduct/(model1DotProduct * model2DotProduct);
            }
        }

        public async Task<ICollection<VehicleBaseDto>> FilterVehiclesForBooking(BookVehiclesRequest bookVehiclesRequest)
        {
            var queriedVehicles = await _vehicleRepository.FilterVehiclesForBooking(bookVehiclesRequest);
            List<VehicleBaseDto> vehicles =  _mapper.Map<List<VehicleBaseDto>>(queriedVehicles);

            double numberOfHours = (bookVehiclesRequest.EndDate - bookVehiclesRequest.StartDate).TotalHours;

            foreach (VehicleBaseDto v in vehicles)
            {
                v.TotalPrice = v.RatePerDay * (decimal)numberOfHours;
            }

            return vehicles;
        }

    }
}
