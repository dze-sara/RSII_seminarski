import 'package:flutter/material.dart';
import 'package:rentacar/data/http_helper.dart';
import 'package:intl/intl.dart';
import 'package:rentacar/screens/booking_details.dart';
import 'package:rentacar/screens/register.dart';

import 'filters.dart';

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

//Filters variables
List<DropdownMenuItem<String>> get transmissionItems {
  List<DropdownMenuItem<String>> menuItems = [
    DropdownMenuItem(child: Text("Manual"), value: "1"),
    DropdownMenuItem(child: Text("Automatic"), value: "2")
  ];
  return menuItems;
}

List<DropdownMenuItem<String>> get vehicleTypeitems {
  List<DropdownMenuItem<String>> menuItems = [
    DropdownMenuItem(child: Text("Small car"), value: "Small car"),
    DropdownMenuItem(child: Text("Sedan"), value: "Sedan"),
    DropdownMenuItem(child: Text("SUV"), value: "SUV"),
    DropdownMenuItem(child: Text("Sports car"), value: "Sports car"),
  ];
  return menuItems;
}

var selectedValueTransmission = "1";
var selectedValueCarType = "Small car";

RangeValues _priceRangeValues = const RangeValues(10, 250);
//End filters variables

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

  @override
  Widget build(BuildContext context) {
    //Filters widgets
    final transmissionDropdown = DropdownButton(
      value: selectedValueTransmission,
      items: transmissionItems,
      style:
          const TextStyle(color: Color.fromARGB(255, 99, 99, 99), fontSize: 20),
      underline: Container(
        height: 2,
        width: 20,
        color: Color.fromARGB(255, 216, 113, 29),
      ),
      onChanged: (String? newValue) {
        setState(() {
          selectedValueTransmission = newValue!;
        });
      },
    );

    final transmissionLabel = Text(
      'Transmission',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final vehicleTypeDropdown = DropdownButton(
      value: selectedValueCarType,
      items: vehicleTypeitems,
      style:
          const TextStyle(color: Color.fromARGB(255, 99, 99, 99), fontSize: 20),
      underline: Container(
        height: 2,
        width: 20,
        color: Color.fromARGB(255, 216, 113, 29),
      ),
      onChanged: (String? newValue) {
        setState(() {
          selectedValueCarType = newValue!;
        });
      },
    );

    final vehicleTypeLabel = Text(
      'Vehicle type',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final priceRange = RangeSlider(
      values: _priceRangeValues,
      max: 500,
      divisions: 20,
      labels: RangeLabels(
        _priceRangeValues.start.round().toString(),
        _priceRangeValues.end.round().toString(),
      ),
      onChanged: (RangeValues values) {
        setState(() {
          _priceRangeValues = values;
        });
      },
    );

    final priceRangeLabel = Text(
      'Price range',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final minPriceLabel = Text(
      'Min price ${_priceRangeValues.start.round().toString()}€',
      style: TextStyle(
          fontSize: 15,
          fontWeight: FontWeight.normal,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final maxPriceLabel = Text(
      'Max price ${_priceRangeValues.end.round().toString()}€',
      style: TextStyle(
          fontSize: 15,
          fontWeight: FontWeight.normal,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final loginButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 35,
            width: 100,
            child: ElevatedButton(
              onPressed: () {
                // Navigator.of(context).pushNamed(SearchDates.tag);
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

    Future<Null> _showModalBottomSheet(BuildContext context) async {
      await showModalBottomSheet(
          shape:
              RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
          elevation: 15,
          context: context,
          builder: (context) {
            return Container(
                padding: EdgeInsets.all(15),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: <Widget>[
                    Row(
                      children: [
                        transmissionLabel,
                        SizedBox(width: 20),
                        transmissionDropdown,
                      ],
                    ),
                    SizedBox(height: 20),
                    Row(
                      children: [
                        vehicleTypeLabel,
                        SizedBox(width: 20),
                        vehicleTypeDropdown,
                      ],
                    ),
                    SizedBox(height: 20),
                    priceRangeLabel,
                    priceRange,
                    Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Align(
                          alignment: Alignment.bottomLeft,
                          child: minPriceLabel,
                        ),
                        Align(
                          alignment: Alignment.bottomRight,
                          child: maxPriceLabel,
                        )
                      ],
                    ),
                    loginButton
                  ],
                ));
          });
    }
    //End of filter widgets

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
                          child: FloatingActionButton(
                            heroTag: 'btnRentNow',
                            onPressed: () {
                              Navigator.of(context)
                                  .pushNamed(BookingDetails.tag);
                            },
                            backgroundColor:
                                const Color.fromARGB(255, 216, 113, 29),
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(32.0),
                            ),
                            child: const Text('rent now',
                                style: TextStyle(
                                    color: Colors.white,
                                    fontSize: 15,
                                    fontWeight: FontWeight.bold)),
                          )))
                ]),
              )
            ]));

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
                    onPressed: () {
                      _showModalBottomSheet(context);
                    },
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
