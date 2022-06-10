import 'package:flutter/material.dart';
import 'package:rentacar/data/http_helper.dart';
import 'package:intl/intl.dart';

class VehiclesList extends StatefulWidget {
  const VehiclesList({Key? key}) : super(key: key);

  static String tag = 'vehiclesList';

  @override
  _VehiclesListState createState() => _VehiclesListState();
}

var formattedDateTime = DateFormat('yyyy-MM-dd , kk:mm').format(DateTime.now());
var sortButtonDropdownItems = <String>[
  'name asc',
  'name desc',
  'price asc',
  'price desc'
];
var dropdownValue = sortButtonDropdownItems[0];

class _VehiclesListState extends State<VehiclesList> {
  String result = '';

  Future getData() async {
    HttpHelper helper = HttpHelper();
    result = await helper.getVehicles();
    setState(() {});
  }

  var dateTime = DateTime.now();

  final pickUpDate = SizedBox(
    width: 150,
    child: Column(children: [
      Align(
          alignment: Alignment.centerLeft,
          child: Text('Pick up date',
              style: TextStyle(
                  fontSize: 15, color: Color.fromARGB(255, 99, 99, 99)))),
      Align(
          alignment: Alignment.centerLeft,
          child: Text(formattedDateTime,
              style: TextStyle(
                  fontSize: 15,
                  fontWeight: FontWeight.bold,
                  color: Color.fromARGB(255, 99, 99, 99))))
    ]),
  );

  final returnDate = SizedBox(
    width: 150,
    child: Column(children: [
      Align(
          alignment: Alignment.centerRight,
          child: Text('Return date',
              style: TextStyle(
                  fontSize: 15, color: Color.fromARGB(255, 99, 99, 99)))),
      Align(
          alignment: Alignment.centerRight,
          child: Text(formattedDateTime,
              style: TextStyle(
                  fontSize: 15,
                  fontWeight: FontWeight.bold,
                  color: Color.fromARGB(255, 99, 99, 99))))
    ]),
  );

  var sortButton = DropdownButton<String>(
    value: dropdownValue,
    icon: const Icon(Icons.arrow_downward),
    elevation: 16,
    style: const TextStyle(color: Color.fromARGB(255, 99, 99, 99)),
    underline: Container(
      height: 2,
      width: 20,
      color: Color.fromARGB(255, 216, 113, 29),
    ),
    onChanged: (String? newValue) {
      // setState(() {
      dropdownValue = newValue!;
      // });
    },
    items:
        sortButtonDropdownItems.map<DropdownMenuItem<String>>((String value) {
      return DropdownMenuItem<String>(
        value: value,
        child: Text(value),
      );
    }).toList(),
  );

  final vehicleListItem = Container(
      margin: EdgeInsets.fromLTRB(5, 50, 5, 50),
      padding: EdgeInsets.all(10),
      decoration: BoxDecoration(
          color: Color.fromARGB(84, 72, 255, 188),
          borderRadius: BorderRadius.circular(10)),
      child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            SizedBox(
                width: 200,
                height: 250,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Image.asset('assets/papi.jpg'),
                  ],
                )),
            SizedBox(
              width: 5,
            ),
            SizedBox(
              width: 100,
              height: 250,
              child: Column(children: [
                Row(children: [
                  Text('SKODA',
                      style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                          color: Color.fromARGB(255, 99, 99, 99)))
                ]),
                SizedBox(width: 5),
                Row(children: [
                  Text('fabia',
                      style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                          color: Color.fromARGB(255, 99, 99, 99)))
                ]),
                SizedBox(height: 5),
                Row(
                  children: [
                    Icon(Icons.directions_car),
                    Text('small car',
                        style: TextStyle(
                            fontSize: 15,
                            fontWeight: FontWeight.bold,
                            color: Color.fromARGB(255, 99, 99, 99)))
                  ],
                ),
                Row(
                  children: [
                    Icon(Icons.person),
                    Text('5 seats',
                        style: TextStyle(
                            fontSize: 15,
                            fontWeight: FontWeight.bold,
                            color: Color.fromARGB(255, 99, 99, 99)))
                  ],
                ),
                Row(
                  children: [
                    Icon(Icons.car_rental),
                    Text('manual',
                        style: TextStyle(
                            fontSize: 15,
                            fontWeight: FontWeight.bold,
                            color: Color.fromARGB(255, 99, 99, 99)))
                  ],
                ),
                SizedBox(height: 5),
                Row(
                  children: [
                    Text('price per day',
                        style: TextStyle(
                            fontSize: 15,
                            fontWeight: FontWeight.normal,
                            color: Color.fromARGB(255, 99, 99, 99)))
                  ],
                ),
                Row(
                  children: [
                    Text('100€',
                        style: TextStyle(
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                            color: Color.fromARGB(255, 99, 99, 99)))
                  ],
                ),
                SizedBox(height: 5),
                Padding(
                    padding: const EdgeInsets.symmetric(vertical: 16.0),
                    child: SizedBox(
                        height: 30,
                        width: 130,
                        child: ElevatedButton(
                          onPressed: () {},
                          style: ButtonStyle(
                              backgroundColor: MaterialStateProperty.all<Color>(
                                  const Color.fromARGB(255, 216, 113, 29)),
                              shape: MaterialStateProperty.all<
                                      RoundedRectangleBorder>(
                                  RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(32.0),
                              ))),
                          child: const Text('rent now',
                              style: TextStyle(
                                  color: Colors.white,
                                  fontSize: 15,
                                  fontWeight: FontWeight.bold)),
                        )))
              ]),
            )
          ]));

  @override
  Widget build(BuildContext context) {
    return Scaffold(
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
        body: Column(
          children: [
            Container(
              margin: EdgeInsets.all(5),
              padding: EdgeInsets.all(10),
              foregroundDecoration: BoxDecoration(
                  border: Border.all(color: Color.fromARGB(255, 216, 113, 29)),
                  borderRadius: BorderRadius.circular(10)),
              child: Row(
                children: [
                  Align(
                    alignment: Alignment.centerLeft,
                    child: pickUpDate,
                  ),
                  Align(
                    alignment: Alignment.centerRight,
                    child: returnDate,
                  )
                ],
              ),
            ),
            Container(
              margin: EdgeInsets.all(5),
              child: Row(children: [
                SizedBox(
                  width: 150,
                  child: ElevatedButton(
                    onPressed: () {},
                    child: Text('Filters'),
                    style: ButtonStyle(
                      backgroundColor:
                          MaterialStateProperty.all<Color>(Colors.transparent),
                      shadowColor:
                          MaterialStateProperty.all<Color>(Colors.transparent),
                      elevation: MaterialStateProperty.all<double>(0),
                      foregroundColor: MaterialStateProperty.all<Color>(
                          Color.fromARGB(255, 99, 99, 99)),
                      shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                        RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0),
                          side: BorderSide(
                            color: Color.fromARGB(255, 216, 113, 29),
                            width: 1.0,
                          ),
                        ),
                      ),
                    ),
                  ),
                ),
                SizedBox(
                  height: 0,
                  width: 20,
                ),
                SizedBox(
                  width: 150,
                  child: DropdownButton<String>(
                    value: dropdownValue,
                    icon: const Icon(Icons.arrow_downward),
                    elevation: 16,
                    style:
                        const TextStyle(color: Color.fromARGB(255, 99, 99, 99)),
                    underline: Container(
                      height: 2,
                      width: 20,
                      color: Color.fromARGB(255, 216, 113, 29),
                    ),
                    onChanged: (String? newValue) {
                      setState(() {
                        dropdownValue = newValue!;
                      });
                    },
                    items: sortButtonDropdownItems
                        .map<DropdownMenuItem<String>>((String value) {
                      return DropdownMenuItem<String>(
                        value: value,
                        child: Text(value),
                      );
                    }).toList(),
                  ),
                )
              ]),
            ),
            vehicleListItem
          ],
        ));
  }
}
