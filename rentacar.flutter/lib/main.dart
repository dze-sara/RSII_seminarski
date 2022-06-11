import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:rentacar/screens/booking_details.dart';
import 'package:rentacar/screens/booking_history.dart';
import 'package:rentacar/screens/filters.dart';
import 'package:rentacar/screens/login.dart';
import 'package:rentacar/screens/payment.dart';
import 'package:rentacar/screens/recommended.dart';
import 'package:rentacar/screens/register.dart';
import 'package:rentacar/screens/search_dates.dart';
import 'package:rentacar/screens/user_details.dart';
import 'package:rentacar/screens/vehicles_list.dart';
import 'package:rentacar/shared/navigation.dart';

void main() => runApp(const RentACar());

final routes = <String, WidgetBuilder>{
  Login.tag: (context) => Login(),
  Register.tag: (context) => Register(),
  SearchDates.tag: (context) => SearchDates(),
  VehiclesList.tag: (context) => VehiclesList(),
  Filters.tag: (context) => Filters(),
  BookingDetails.tag: (context) => BookingDetails(),
  Payment.tag: (context) => Payment(),
  BookingHistory.tag: (context) => BookingHistory(),
  UserDetails.tag: (context) => UserDetails(),
  Recommended.tag: (context) => Recommended(),
};

class RentACar extends StatelessWidget {
  const RentACar({Key? key}) : super(key: key);

  static const String _title = 'CarRental.com';

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: _title,
      home: Scaffold(
        body: Login(),
      ),
      routes: routes,
    );
  }
}
