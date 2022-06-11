class VehicleType {
  int vehicleTypeId = 0;
  String vehicleTypeName = '';

  VehicleType.fromJson(Map<String, dynamic> vehicleTypeMap) {
    vehicleTypeId = vehicleTypeMap['vehicleTypeId'] ?? 0;
    vehicleTypeName = vehicleTypeMap['vehicleTypeName'] ?? '';
  }
}
