class VehicleBase {
  int vehicleId = 0;
  int? ratePerDay;
  bool? isActive;
  int? transmissionType;
  int? modelId;
  String? model;
  String? make;
  String? vehicleType;
  int? numberOfSeats;
  String? imageUrl;
  double? totalPrice;
  int? score;

  VehicleBase(
      this.vehicleId,
      this.ratePerDay,
      this.isActive,
      this.transmissionType,
      this.modelId,
      this.model,
      this.make,
      this.vehicleType,
      this.numberOfSeats,
      this.imageUrl,
      this.totalPrice,
      this.score);

  VehicleBase.fromJson(Map<String, dynamic> vehicleBaseMap) {
    vehicleId = vehicleBaseMap['vehicleId'];
    ratePerDay = vehicleBaseMap['ratePerDay'];
    isActive = vehicleBaseMap['isActive'];
    transmissionType = vehicleBaseMap['transmissionType'];
    modelId = vehicleBaseMap['modelId'];
    model = vehicleBaseMap['model'];
    make = vehicleBaseMap['make'];
    vehicleType = vehicleBaseMap['vehicleType'];
    numberOfSeats = vehicleBaseMap['numberOfSeats'];
    imageUrl = vehicleBaseMap['imageUrl'];
    totalPrice = double.tryParse(vehicleBaseMap['totalPrice'].toString());
    score = vehicleBaseMap['score'];
  }

  Map<String, dynamic> toJson() {
    return {
      'vehicleId': vehicleId,
      'ratePerDay': ratePerDay,
      'isActive': isActive,
      'transmissionType': transmissionType,
      'modelId': modelId,
      'model': model,
      'make': make,
      'vehicleType': vehicleType,
      'numberOfSeats': numberOfSeats,
      'imageUrl': imageUrl,
      'totalPrice': totalPrice,
      'score': score
    };
  }
}
