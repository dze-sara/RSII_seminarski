import '../transmission_type.dart';

class BaseBooking {
  int bookingId = 0;
  DateTime? startDate;
  DateTime? endDate;
  DateTime? createdDate;
  DateTime? updatedDate;
  int? userId;
  String? bookedBy;
  int? vehicleId;
  String? vehicleModel;
  int? numberOfSeats;
  String? vehicleType;
  double? totalPrice;
  String? imageUrl;
  TransmissionType? transmissionType;
  bool canAddReview = true;
  int? modelId;

  BaseBooking.fromJson(Map<String, dynamic> baseBookingMap) {
    bookingId = baseBookingMap['bookingId'];
    startDate = baseBookingMap['startDate'];
    endDate = baseBookingMap['endDate'];
    createdDate = baseBookingMap['createdDate'];
    updatedDate = baseBookingMap['updatedDate'];
    userId = baseBookingMap['userId'];
    bookedBy = baseBookingMap['bookedBy'];
    vehicleId = baseBookingMap['vehicleId'];
    vehicleModel = baseBookingMap['vehicleModel'];
    numberOfSeats = baseBookingMap['numberOfSeats'];
    vehicleType = baseBookingMap['vehicleType'];
    totalPrice = baseBookingMap['totalPrice'];
    imageUrl = baseBookingMap['imageUrl'];
    transmissionType = baseBookingMap['transmissionType'];
    canAddReview = baseBookingMap['canAddReview'];
    modelId = baseBookingMap['modelId'];
  }
}
