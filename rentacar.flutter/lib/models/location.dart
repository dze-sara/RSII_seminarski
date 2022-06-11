class Location {
  int locationId = 0;
  String locationName = '';
  String locationDescription = '';
  String address = '';

  Location.fromJson(Map<String, dynamic> locationMap) {
    locationId = locationMap['locationId'] ?? 0;
    locationName = locationMap['locationName'] ?? '';
    locationDescription = locationMap['locationDescription'] ?? '';
    address = locationMap['address'] ?? '';
  }
}
