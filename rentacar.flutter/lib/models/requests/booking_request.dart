class BookingRequest {
  int bookingId = 0;
  DateTime? startDate;
  DateTime? startTime;
  DateTime? endDate;
  DateTime? endTime;
  int? userId;
  int? vehicleId;
  String? model;
  String? make;
  int? minPrice;
  int? maxPrice;
  String? vehicleType;

  BookingRequest(
      this.bookingId,
      this.startDate,
      this.startTime,
      this.endDate,
      this.endTime,
      this.userId,
      this.vehicleId,
      this.model,
      this.make,
      this.minPrice,
      this.maxPrice,
      this.vehicleType);

  BookingRequest.fromJson(Map<String, dynamic> bookingRequestMap) {
    bookingId = bookingRequestMap['bookingId'] ?? 0;
    startDate = bookingRequestMap['startDate'];
    startTime = bookingRequestMap['startTime'];
    endDate = bookingRequestMap['endDate'];
    endTime = bookingRequestMap['endTime'];
    userId = bookingRequestMap['userId'];
    vehicleId = bookingRequestMap['vehicleId'];
    model = bookingRequestMap['model'];
    make = bookingRequestMap['make'];
    minPrice = bookingRequestMap['minPrice'];
    maxPrice = bookingRequestMap['maxPrice'];
    vehicleType = bookingRequestMap['vehicleType'];
  }

  Map<String, dynamic> toJson() {
    return {
      'bookingId': bookingId,
      'startDate': startDate,
      'startTime': startTime,
      'endDate': endDate,
      'endTime': endTime,
      'userId': userId,
      'vehicleId': vehicleId,
      'model': model,
      'make': make,
      'minPrice': minPrice,
      'maxPrice': maxPrice,
      'vehicleType': vehicleType,
    };
  }
}
