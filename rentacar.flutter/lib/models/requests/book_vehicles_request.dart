class BookVehiclesRequest {
  int transmissionType = 0;
  DateTime? startDate;
  DateTime? endDate;
  int? minPrice;
  int? maxPrice;
  List<String>? vehicleTypes;

  BookVehiclesRequest(this.transmissionType, this.startDate, this.endDate,
      this.maxPrice, this.minPrice, this.vehicleTypes);

  BookVehiclesRequest.fromJson(Map<String, dynamic> bookVehiclesMap) {
    transmissionType = bookVehiclesMap['transmissionType'] ?? 0;
    startDate = bookVehiclesMap['startDate'];
    endDate = bookVehiclesMap['endDate'];
    minPrice = bookVehiclesMap['minPrice'];
    maxPrice = bookVehiclesMap['maxPrice'];
    vehicleTypes = bookVehiclesMap['vehicleTypes'];
  }

  Map<String, dynamic> toJson() {
    return {
      'transmissionType': transmissionType,
      'startDate': startDate,
      'endDate': endDate,
      'minPrice': minPrice,
      'maxPrice': maxPrice,
      'vehicleTypes': vehicleTypes,
    };
  }
}
