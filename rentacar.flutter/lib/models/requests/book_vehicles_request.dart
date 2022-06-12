class BookVehiclesRequest {
  int? transmissionType;
  DateTime? startDate;
  DateTime? endDate;
  int? minPrice;
  int? maxPrice;
  List<String>? vehicleTypes;

  BookVehiclesRequest(this.transmissionType, this.startDate, this.endDate,
      this.maxPrice, this.minPrice, this.vehicleTypes);

  BookVehiclesRequest.fromJson(Map<String, dynamic> bookVehiclesMap) {
    transmissionType = bookVehiclesMap['transmissionType'];
    startDate = DateTime.parse(bookVehiclesMap['startDate']);
    endDate = DateTime.parse(bookVehiclesMap['endDate']);
    minPrice = bookVehiclesMap['minPrice'];
    maxPrice = bookVehiclesMap['maxPrice'];
    vehicleTypes = bookVehiclesMap['vehicleTypes'];
  }

  Map<String, dynamic> toJson() {
    return {
      'transmissionType': transmissionType,
      'startDate': startDate?.toIso8601String(),
      'endDate': endDate?.toIso8601String(),
      'minPrice': minPrice,
      'maxPrice': maxPrice,
      'vehicleTypes': vehicleTypes,
    };
  }
}
