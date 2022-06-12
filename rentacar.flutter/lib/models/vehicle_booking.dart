class VehicleBooking {
  int vehicleId = 0;
  int? ratePerDay;
  int? transmissionType;
  int? modelId;
  String? model;
  String? make;
  String? vehicleType;
  int? numberOfSeats;
  String? imageUrl;
  double? totalPrice;
  int? score;
  int bookingId = 0;
  DateTime? startDate;
  DateTime? endDate;

  VehicleBooking(
      this.vehicleId,
      this.ratePerDay,
      this.transmissionType,
      this.modelId,
      this.model,
      this.make,
      this.vehicleType,
      this.numberOfSeats,
      this.imageUrl,
      this.totalPrice,
      this.score,
      this.bookingId,
      this.endDate,
      this.startDate);
}
