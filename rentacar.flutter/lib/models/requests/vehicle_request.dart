class VehicleRequest {
  int? vehicleId;
  String? make;
  String? model;
  int? minPrice;
  int? maxPrice;
  int? transmission;
  String? vehicleType;
  int? numberOfSeats;

  VehicleRequest(this.vehicleId, this.make, this.model, this.minPrice,
      this.maxPrice, this.transmission, this.vehicleType, this.numberOfSeats);

  VehicleRequest.fromJson(Map<String, dynamic> vehicleRequestMap) {
    vehicleId = vehicleRequestMap['vehicleId'];
    make = vehicleRequestMap['make'];
    model = vehicleRequestMap['model'];
    minPrice = vehicleRequestMap['minPrice'];
    maxPrice = vehicleRequestMap['maxPrice'];
    transmission = vehicleRequestMap['transmission'];
    vehicleType = vehicleRequestMap['vehicleType'];
    numberOfSeats = vehicleRequestMap['numberOfSeats'];
  }

  Map<String, dynamic> toJson() {
    return {
      'vehicleId': vehicleId,
      'make': make,
      'model': model,
      'minPrice': minPrice,
      'maxPrice': maxPrice,
      'transmission': transmission,
      'vehicleType': vehicleType,
      'numberOfSeats': numberOfSeats,
    };
  }
}
