import 'dart:ui';
import 'package:intl/intl.dart';
import 'package:date_time_picker/date_time_picker.dart';
import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';
import 'package:flutter/material.dart';
import 'package:rentacar/models/requests/book_vehicles_request.dart';
import 'package:rentacar/models/responses/vehicle_base.dart';
import 'package:rentacar/screens/vehicles_list.dart';
import 'package:rentacar/services/vehicle_service.dart';

import '../shared/app_bar.dart';
import '../shared/navigation.dart';

class SearchDates extends StatefulWidget {
  const SearchDates({Key? key}) : super(key: key);

  static String tag = 'searchDates';

  @override
  State<SearchDates> createState() => _SearchDatesState();
}

class _SearchDatesState extends State<SearchDates> {
  DateTime selectedPickUpDate = DateTime.now();
  TextEditingController _datePickUpController = TextEditingController();

  TimeOfDay selectedPickUpTime = TimeOfDay.now();
  TextEditingController _timePickUpController = TextEditingController();

  DateTime selectedReturnDate = DateTime.now();
  TextEditingController _dateReturnController = TextEditingController();

  TimeOfDay selectedReturnTime = TimeOfDay.now();
  TextEditingController _timeReturnController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    Future<Null> _selectPickUpDate(BuildContext context) async {
      final DateTime? picked = await showDatePicker(
          context: context,
          initialDate: selectedPickUpDate,
          initialDatePickerMode: DatePickerMode.day,
          firstDate: DateTime.now(),
          lastDate: DateTime(2100));

      if (picked != null) {
        setState(() {
          selectedPickUpDate = picked;
          _datePickUpController.text =
              DateFormat.yMd().format(selectedPickUpDate);
        });
      }
    }

    Future<Null> _selectPickUpTime(BuildContext context) async {
      final TimeOfDay? picked = await showTimePicker(
          context: context, initialTime: selectedPickUpTime);

      if (picked != null) {
        setState(() {
          selectedPickUpTime = picked;
          _timePickUpController.text = selectedPickUpTime.format(context);
        });
      }
    }

    Future<Null> _selectReturnDate(BuildContext context) async {
      final DateTime? picked = await showDatePicker(
          context: context,
          initialDate: selectedPickUpDate,
          initialDatePickerMode: DatePickerMode.day,
          firstDate: selectedPickUpDate,
          lastDate: DateTime(2100));

      if (picked != null) {
        setState(() {
          selectedReturnDate = picked;
          _dateReturnController.text =
              DateFormat.yMd().format(selectedReturnDate);
        });
      }
    }

    Future<Null> _selectReturnTime(BuildContext context) async {
      final TimeOfDay? picked = await showTimePicker(
          context: context, initialTime: selectedReturnTime);

      if (picked != null) {
        setState(() {
          selectedReturnTime = picked;
          _timeReturnController.text = selectedReturnTime.format(context);
        });
      }
    }

    onSearchPressed() async {
      VehicleService vehicleService = VehicleService();

      DateTime finalPickupDateTime = DateTime(
          selectedPickUpDate.year,
          selectedPickUpDate.month,
          selectedPickUpDate.day,
          selectedPickUpTime.hour,
          selectedPickUpTime.minute);

      DateTime finalReturnDateTime = DateTime(
          selectedReturnDate.year,
          selectedReturnDate.month,
          selectedReturnDate.day,
          selectedReturnTime.hour,
          selectedReturnTime.minute);

      BookVehiclesRequest request = BookVehiclesRequest(
          null, finalPickupDateTime, finalReturnDateTime, null, null, null);
      List<VehicleBase>? vehicles = await vehicleService.Filter(request);
      Navigator.of(context).push(MaterialPageRoute(
          builder: (context) => VehiclesList(
                vehicles: vehicles,
                selectedPickupDate: finalPickupDateTime,
                selectedReturnDate: finalReturnDateTime,
              )));
    }

    final searchButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 200,
            child: ElevatedButton(
              onPressed: () {
                onSearchPressed();
              },
              style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(
                      const Color.fromARGB(255, 216, 113, 29)),
                  shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                      RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(32.0),
                  ))),
              child: const Text('search',
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                      fontWeight: FontWeight.bold)),
            )));

    return Scaffold(
      bottomNavigationBar: Navigation(),
      appBar: AppBar(
        title: const Text(
          'CarRental.com',
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
        ),
        toolbarHeight: 90,
        leading: IconButton(
            onPressed: () {},
            icon: const Icon(
              Icons.car_rental_outlined,
              color: Colors.white,
              size: 50,
            )),
        backgroundColor: const Color.fromARGB(255, 4, 28, 48),
      ),
      body: Column(children: [
        const SizedBox(height: 50, width: 0),
        const Text(
          'pick a perfect car for you',
          style: TextStyle(
              fontSize: 30,
              color: Color.fromARGB(255, 216, 113, 29),
              fontWeight: FontWeight.bold),
        ),
        Container(
          margin: EdgeInsets.fromLTRB(5, 50, 5, 50),
          padding: EdgeInsets.all(20),
          decoration: BoxDecoration(
              color: Color.fromARGB(84, 72, 255, 188),
              borderRadius: BorderRadius.circular(10)),
          child: Column(children: [
            const Text(
              'pick up date',
              textAlign: TextAlign.left,
              style: TextStyle(
                  fontSize: 20,
                  color: Color.fromARGB(255, 99, 99, 99),
                  fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 20, width: 0),
            Row(
              children: [
                SizedBox(
                    width: 200,
                    child: FloatingActionButton.extended(
                      heroTag: null,
                      onPressed: () {
                        _selectPickUpDate(context);
                      },
                      label:
                          Text("${selectedPickUpDate.toLocal()}".split(' ')[0]),
                      icon: const Icon(Icons.date_range),
                      shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10)),
                      foregroundColor: Color.fromARGB(255, 99, 99, 99),
                      backgroundColor: Colors.white,
                    )),
                const SizedBox(height: 0, width: 10),
                SizedBox(
                    width: 130,
                    child: FloatingActionButton.extended(
                      heroTag: null,
                      onPressed: () {
                        _selectPickUpTime(context);
                      },
                      label: Text("${selectedPickUpTime.format(context)}"),
                      icon: const Icon(Icons.access_time),
                      shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10)),
                      foregroundColor: Color.fromARGB(255, 99, 99, 99),
                      backgroundColor: Colors.white,
                    )),
              ],
            ),
            const SizedBox(height: 40, width: 0),
            const Text(
              'return date',
              style: TextStyle(
                  fontSize: 20,
                  color: Color.fromARGB(255, 99, 99, 99),
                  fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 20, width: 0),
            Row(
              children: [
                SizedBox(
                    width: 200,
                    child: FloatingActionButton.extended(
                      heroTag: null,
                      onPressed: () {
                        _selectReturnDate(context);
                      },
                      label:
                          Text("${selectedReturnDate.toLocal()}".split(' ')[0]),
                      icon: const Icon(Icons.date_range),
                      shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10)),
                      foregroundColor: Color.fromARGB(255, 99, 99, 99),
                      backgroundColor: Colors.white,
                    )),
                const SizedBox(height: 0, width: 10),
                SizedBox(
                    width: 130,
                    child: FloatingActionButton.extended(
                      heroTag: null,
                      onPressed: () {
                        _selectReturnTime(context);
                      },
                      label: Text("${selectedReturnTime.format(context)}"),
                      icon: const Icon(Icons.access_time),
                      shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10)),
                      foregroundColor: Color.fromARGB(255, 99, 99, 99),
                      backgroundColor: Colors.white,
                    )),
              ],
            ),
          ]),
        ),
        searchButton
      ]),
    );
  }
}
