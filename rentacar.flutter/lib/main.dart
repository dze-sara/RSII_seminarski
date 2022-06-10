import 'package:flutter/material.dart';
import 'package:rentacar/screens/login.dart';
import 'package:rentacar/screens/register.dart';
import 'package:rentacar/screens/search_dates.dart';
import 'package:rentacar/screens/vehicles_list.dart';

void main() => runApp(const RentACar());

final routes = <String, WidgetBuilder>{
  Login.tag: (context) => Login(),
  Register.tag: (context) => Register(),
  SearchDates.tag: (context) => SearchDates(),
  VehiclesList.tag: (context) => VehiclesList(),
};

class RentACar extends StatelessWidget {
  const RentACar({Key? key}) : super(key: key);

  static const String _title = 'CarRental.com';

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: _title,
      home: Scaffold(
        body: VehiclesList(),
      ),
      routes: routes,
    );
  }
}
// izmjena

