import 'package:flutter/material.dart';
import 'package:rentacar/data/http_helper.dart';
import 'package:intl/intl.dart';
import 'package:rentacar/screens/booking_details.dart';
import 'package:rentacar/screens/register.dart';

import '../shared/navigation.dart';
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

RangeValues _priceRangeValues = RangeValues(10, 250);
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

    double _startValue = 30.0;
    double _endValue = 130.0;

    final priceRange = RangeSlider(
      values: RangeValues(_startValue, _endValue),
      min: 10,
      max: 300,
      divisions: 50,
      labels: RangeLabels(
        _startValue.round().toString(),
        _endValue.round().toString(),
      ),
      onChanged: (values) {
        setState(() {
          _startValue = values.start;
          _endValue = values.end;
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
      'Min price ${_startValue.round().toString()}€',
      style: TextStyle(
          fontSize: 15,
          fontWeight: FontWeight.normal,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final maxPriceLabel = Text(
      'Max price ${_endValue.round().toString()}€',
      style: TextStyle(
          fontSize: 15,
          fontWeight: FontWeight.normal,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final searchButton = Padding(
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
            return StatefulBuilder(builder: (BuildContext context,
                void Function(void Function()) setState) {
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
                      RangeSlider(
                        values: RangeValues(_startValue, _endValue),
                        min: 10,
                        max: 300,
                        divisions: 50,
                        labels: RangeLabels(
                          _startValue.round().toString(),
                          _endValue.round().toString(),
                        ),
                        onChanged: (values) {
                          setState(() {
                            _startValue = values.start;
                            _endValue = values.end;
                          });
                        },
                      ),
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
                      searchButton
                    ],
                  ));
            });
          });
    }
    //End of filter widgets

    //Reviews:
    final reviewIcons = Icon(
      Icons.star,
      size: 40,
      color: Color.fromARGB(255, 216, 113, 29),
    );

    int number = 3;

    List<Icon> _displayIcons(int number) {
      List<Icon> icons = [];
      for (var i = 0; i < number; i++) {
        icons.add(reviewIcons);
      }
      return icons;
    }

    final review = Row(
      children: [
        Row(children: _displayIcons(number),),
        SizedBox(width: 30),
        Text('Great car.')
      ],
    );

    List<Row> _displayReviews(int number) {
      List<Row> reviews = [];
      for (var i = 0; i < number; i++) {
        reviews.add(review);
      }
      return reviews;
    }

    Future<Null> _showReviewsDialog(BuildContext context) async {
      await showModalBottomSheet(
          shape:
              RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
          elevation: 15,
          isScrollControlled: false,
          context: context,
          builder: (context) {
            return StatefulBuilder(builder: (BuildContext context,
                void Function(void Function()) setState) {
              return Container(
                  padding: EdgeInsets.all(15),
                  child: Column(
                    children: _displayReviews(number),
                  ));
            });
          });
    }
    

    final reviewsLabel = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 23,
            width: 60,
            child: FloatingActionButton(
              heroTag: 'btnReviews',
              onPressed: () {
                _showReviewsDialog(context);
              },
              backgroundColor: const Color.fromARGB(255, 216, 113, 29),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
              ),
              child: const Text('Reviews',
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 12,
                      fontWeight: FontWeight.bold)),
            )));

      //End of reviews

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
                  height: 300,
                  child: Center(
                      child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Center(child: Image.asset('assets/papi.jpg')),
                      Center(
                          child: Row(
                              mainAxisAlignment: MainAxisAlignment.center,
                              children: _displayIcons(number))),
                      reviewsLabel
                    ],
                  ))),
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

    final appBar = AppBar(
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
        backgroundColor: const Color.fromARGB(255, 4, 28, 48));

    final datesContainer = Container(
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
    );

    final filterButtonSizedBox = SizedBox(
      width: 150,
      child: FloatingActionButton(
        heroTag: 'btnFilters1',
        onPressed: () {
          _showModalBottomSheet(context);
        },
        child: Text('Filters'),
        backgroundColor: Colors.transparent,
        elevation: 0,
        foregroundColor: Color.fromARGB(255, 99, 99, 99),
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(10.0),
          side: BorderSide(
            color: Color.fromARGB(255, 216, 113, 29),
            width: 1.0,
          ),
        ),
      ),
    );

    final sortDropdownSizedBox = SizedBox(
      width: 150,
      child: DropdownButton<String>(
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
    );

    return Scaffold(
        bottomNavigationBar: Navigation(),
        appBar: appBar,
        body: Center(
            child: Column(
          children: [
            datesContainer,
            Container(
              margin: EdgeInsets.all(5),
              child: Row(children: [
                filterButtonSizedBox,
                SizedBox(
                  height: 0,
                  width: 20,
                ),
                sortDropdownSizedBox
              ]),
            ),
            ListView(
              shrinkWrap: true,
              padding: EdgeInsets.only(left: 24, right: 24),
              children: <Widget>[vehicleListItem],
            ),
          ],
        )));
  }
}
