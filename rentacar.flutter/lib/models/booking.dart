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
}
