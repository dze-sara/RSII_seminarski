import 'dart:convert';

import 'package:rentacar/models/booking.dart';

import '../data/configuration.dart';
import '../data/http_helper.dart';
import '../data/sp_helper.dart';
import 'package:http/http.dart' as http;

class BookingService {
  final SPHelper helper = SPHelper();
  final HttpHelper httpHelper = HttpHelper();

  BookingService() {
    helper.init();
  }

  Future<Booking?> BookVehicle(Booking booking) async {
    String path = '${Configuration().apiUrl}/api/Bookings';
    try {
      http.Response result = await httpHelper.post(path, booking);

      var decoded = json.decode(result.body);

      Booking createdBooking = Booking.fromJson(decoded);
      return createdBooking;
    } catch (_) {
      return null;
    }
  }

  Future<List<Booking>?> GetBookingHistory(int userId) async {
    String path = '${Configuration().apiUrl}/api/Bookings/${userId}';
    try {
      http.Response result = await httpHelper.get(path);

      var decoded = json.decode(result.body);

      List<Booking> bookings =
          List<Booking>.from(decoded.map((model) => Booking.fromJson(model)));
      return bookings;
    } catch (_) {
      return null;
    }
  }
}
