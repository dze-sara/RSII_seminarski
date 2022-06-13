import 'dart:convert';

import 'package:rentacar/models/cardInfo.dart';

class Booking {
  int bookingId = 0;
  DateTime? startDate;
  DateTime? endDate;
  DateTime? createdDate;
  DateTime? updatedDate;
  int userId = 0;
  int vehicleId = 0;
  double? totalPrice = 0;
  CardInfo? cardInfo;

  Booking(
      this.bookingId,
      this.startDate,
      this.endDate,
      this.createdDate,
      this.updatedDate,
      this.userId,
      this.vehicleId,
      this.totalPrice,
      this.cardInfo);

  Booking.fromJson(Map<String?, dynamic> bookingMap) {
    bookingId = bookingMap['bookingId'];
    startDate = DateTime.parse(bookingMap['startDate']);
    endDate = DateTime.parse(bookingMap['endDate']);
    createdDate = DateTime.parse(bookingMap['createdDate']);
    updatedDate = DateTime.parse(bookingMap['updatedDate']);
    userId = bookingMap['userId'];
    vehicleId = bookingMap['vehicleId'];
    totalPrice = bookingMap['totalPrice'];
    cardInfo = CardInfo?.fromJson(bookingMap['cardInfo']);
  }

  Map<String, dynamic> toJson() {
    return {
      'bookingId': bookingId,
      'startDate': startDate?.toIso8601String(),
      'endDate': endDate?.toIso8601String(),
      'createdDate': createdDate?.toIso8601String(),
      'updatedDate': updatedDate?.toIso8601String(),
      'userId': userId,
      'vehicleId': vehicleId,
      'totalPrice': totalPrice,
      'cardInfo': cardInfo?.toJson()
    };
  }
}
