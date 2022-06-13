import 'package:flutter/material.dart';
import 'package:rentacar/data/http_helper.dart';
import 'package:intl/intl.dart';
import 'package:rentacar/screens/booking_details.dart';
import 'package:rentacar/screens/register.dart';
import 'package:rentacar/screens/search_dates.dart';
import 'package:rentacar/services/review_service.dart';

import '../models/booking.dart';
import '../models/requests/book_vehicles_request.dart';
import '../models/responses/vehicle_base.dart';
import '../models/review.dart';
import '../models/transmission_type.dart';
import '../services/vehicle_service.dart';
import '../shared/navigation.dart';
import 'filters.dart';

class VehiclesList extends StatefulWidget {
  final List<VehicleBase>? vehicles;
  final DateTime? selectedPickupDate;
  final DateTime? selectedReturnDate;
  const VehiclesList(
      {Key? key,
      this.vehicles,
      this.selectedPickupDate,
      this.selectedReturnDate})
      : super(key: key);

  static String tag = 'vehiclesList';

  @override
  _VehiclesListState createState() => _VehiclesListState();
}

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
double _startValue = 30.0;
double _endValue = 130.0;
//End filters variables

class _VehiclesListState extends State<VehiclesList> {
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
            child: Text(
                DateFormat('yyyy-MM-dd , kk:mm')
                    .format(widget.selectedPickupDate ?? DateTime.now()),
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
            child: Text(
                DateFormat('yyyy-MM-dd , kk:mm')
                    .format(widget.selectedReturnDate ?? DateTime.now()),
                style: TextStyle(
                    fontSize: 15,
                    fontWeight: FontWeight.bold,
                    color: Color.fromARGB(255, 99, 99, 99))))
      ]),
    );

    final transmissionLabel = Text(
      'Transmission',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final vehicleTypeLabel = Text(
      'Vehicle type',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final priceRangeLabel = Text(
      'Price range',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    //End of filter widgets

    //Reviews:
    final reviewIcons = Icon(
      Icons.star,
      size: 40,
      color: Color.fromARGB(255, 216, 113, 29),
    );

    List<Icon> _displayIcons(int number) {
      List<Icon> icons = [];
      for (var i = 0; i < number; i++) {
        icons.add(reviewIcons);
      }
      return icons;
    }

    List<Row> _displayReviews(List<Review>? reviews) {
      List<Review> vehicleReviews = reviews ?? [];
      List<Row> result = [];
      if (vehicleReviews.length != null && vehicleReviews.length != 0) {
        for (var i = 0; i < vehicleReviews.length; i++) {
          var review = vehicleReviews[i];
          var newRow = Row(
            children: [
              Container(
                margin: EdgeInsets.only(bottom: 5),
                padding: EdgeInsets.all(3),
                decoration: BoxDecoration(
                    color: Color.fromARGB(84, 72, 255, 188),
                    borderRadius: BorderRadius.circular(10)),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Row(
                      children: [
                        Text('${review.authorName}, score: ${review.score}/5',
                            style: TextStyle(
                                fontStyle: FontStyle.italic,
                                fontSize: 12,
                                color: Color.fromARGB(255, 99, 99, 99))),
                        SizedBox(
                          width: 10,
                        ),
                        Row(
                          children: _displayIcons(review.score),
                        ),
                      ],
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        Container(
                          width: MediaQuery.of(context).size.width * 0.8,
                          child: Flexible(
                            child: Text(review.content,
                                textAlign: TextAlign.start,
                                style: TextStyle(
                                    fontSize: 20,
                                    color: Color.fromARGB(255, 99, 99, 99))),
                          ),
                        ),
                      ],
                    )
                  ],
                ),
              )
            ],
          );
          result.add(newRow);
        }
      }
      return result;
    }

    List<Row> reviewList = [];
    Future<Null> _showReviewsDialog(BuildContext context, int? modelId) async {
      ReviewService reviewService = ReviewService();
      List<Review>? reviews = await reviewService.getReview(modelId ?? 0);
      reviewList = _displayReviews(reviews);
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
                  child: Container(
                    height: (MediaQuery.of(context).size.height / 3) + 140,
                    child: ListView(
                      shrinkWrap: true,
                      children: reviewList.isNotEmpty
                          ? reviewList
                          : [
                              Center(
                                  child: Text(
                                      'Unfortunately, this vehicle does not have reviews. Be the first to add one.',
                                      textAlign: TextAlign.center,
                                      style: TextStyle(
                                          fontSize: 18,
                                          fontWeight: FontWeight.bold,
                                          color:
                                              Color.fromARGB(255, 99, 99, 99))))
                            ],
                    ),
                  ));
            });
          });
    }

    _openBookingDetails(VehicleBase vehicle) {
      Booking request = Booking(
          0,
          widget.selectedPickupDate,
          widget.selectedReturnDate,
          DateTime.now(),
          DateTime.now(),
          2,
          vehicle.vehicleId,
          vehicle.totalPrice,
          null);

      Navigator.of(context).push(MaterialPageRoute(
          builder: (context) =>
              BookingDetails(bookingRequest: request, vehicle: vehicle)));
    }

    List<Container> listitems = [];

    List<Container> _createListItems([List<VehicleBase>? vehicles = null]) {
      var listOfVehicles = widget.vehicles ?? [];
      if (vehicles?.length != null && vehicles?.length != 0) {
        listOfVehicles = vehicles ?? [];
      }

      for (var i = 0; i < listOfVehicles.length; i++) {
        var listItem = Container(
            margin: EdgeInsets.fromLTRB(5, 25, 5, 25),
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
                      child: Center(
                          child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Center(
                              child: Image.network(
                                  '${listOfVehicles[i].imageUrl}')),
                          Center(
                              child: Row(
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: _displayIcons(
                                      listOfVehicles[i].score ?? 0))),
                          Padding(
                              padding:
                                  const EdgeInsets.symmetric(vertical: 2.0),
                              child: SizedBox(
                                  height: 23,
                                  width: 60,
                                  child: FloatingActionButton(
                                    heroTag: null,
                                    onPressed: () {
                                      _showReviewsDialog(
                                          context, listOfVehicles[i].modelId);
                                    },
                                    backgroundColor:
                                        const Color.fromARGB(255, 216, 113, 29),
                                    shape: RoundedRectangleBorder(
                                      borderRadius: BorderRadius.circular(32.0),
                                    ),
                                    child: const Text('Reviews',
                                        style: TextStyle(
                                            color: Colors.white,
                                            fontSize: 12,
                                            fontWeight: FontWeight.bold)),
                                  )))
                        ],
                      ))),
                  SizedBox(
                    width: 5,
                  ),
                  SizedBox(
                    width: 100,
                    height: 250,
                    child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Row(children: [
                            Flexible(
                              child: Text(
                                  listOfVehicles[i].make?.toUpperCase() ?? '',
                                  style: TextStyle(
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold,
                                      color: Color.fromARGB(255, 99, 99, 99))),
                            )
                          ]),
                          SizedBox(width: 5),
                          Row(children: [
                            Text(listOfVehicles[i].model?.toLowerCase() ?? '',
                                style: TextStyle(
                                    fontSize: 20,
                                    fontWeight: FontWeight.bold,
                                    color: Color.fromARGB(255, 99, 99, 99)))
                          ]),
                          SizedBox(height: 15),
                          Row(
                            children: [
                              Icon(Icons.directions_car),
                              Text(
                                  listOfVehicles[i]
                                          .vehicleType
                                          ?.toLowerCase() ??
                                      '',
                                  style: TextStyle(
                                      fontSize: 15,
                                      fontWeight: FontWeight.bold,
                                      color: Color.fromARGB(255, 99, 99, 99)))
                            ],
                          ),
                          Row(
                            children: [
                              Icon(Icons.person),
                              Text(
                                  '${listOfVehicles[i].numberOfSeats?.toString() ?? ''} seats',
                                  style: TextStyle(
                                      fontSize: 15,
                                      fontWeight: FontWeight.bold,
                                      color: Color.fromARGB(255, 99, 99, 99)))
                            ],
                          ),
                          Row(
                            children: [
                              Icon(Icons.car_rental),
                              Text(
                                  TransmissionType
                                      .values[
                                          (listOfVehicles[i].transmissionType ??
                                                  1) -
                                              1]
                                      .name,
                                  style: TextStyle(
                                      fontSize: 15,
                                      fontWeight: FontWeight.bold,
                                      color: Color.fromARGB(255, 99, 99, 99)))
                            ],
                          ),
                          SizedBox(height: 15),
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
                              Text(
                                  '${listOfVehicles[i].ratePerDay?.toString() ?? ''}€',
                                  style: TextStyle(
                                      fontSize: 25,
                                      fontWeight: FontWeight.bold,
                                      color: Color.fromARGB(255, 99, 99, 99)))
                            ],
                          ),
                          Flexible(
                            child: Padding(
                                padding: const EdgeInsets.only(top: 15),
                                child: SizedBox(
                                    height: 30,
                                    width: 130,
                                    child: FloatingActionButton(
                                      heroTag: null,
                                      onPressed: () {
                                        _openBookingDetails(listOfVehicles[i]);
                                      },
                                      backgroundColor: const Color.fromARGB(
                                          255, 216, 113, 29),
                                      shape: RoundedRectangleBorder(
                                        borderRadius:
                                            BorderRadius.circular(32.0),
                                      ),
                                      child: const Text('rent now',
                                          style: TextStyle(
                                              color: Colors.white,
                                              fontSize: 15,
                                              fontWeight: FontWeight.bold)),
                                    ))),
                          )
                        ]),
                  )
                ]));
        listitems.add(listItem);
      }
      return listitems;
    }

    _filterVehicles() async {
      VehicleService service = VehicleService();
      List<String> carTypes = [];
      carTypes.add(selectedValueCarType);

      BookVehiclesRequest request = BookVehiclesRequest(
          int.tryParse(selectedValueTransmission) ?? null,
          widget.selectedPickupDate,
          widget.selectedReturnDate,
          _endValue.round(),
          _startValue.round(),
          carTypes);

      List<VehicleBase>? vehicles = await service.Filter(request);
      Navigator.of(context).push(MaterialPageRoute(
          builder: (context) => VehiclesList(
                vehicles: vehicles,
                selectedPickupDate: widget.selectedPickupDate,
                selectedReturnDate: widget.selectedReturnDate,
              )));
    }

    final searchButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 35,
            width: 100,
            child: FloatingActionButton(
              heroTag: null,
              onPressed: () {
                _filterVehicles();
              },
              backgroundColor: const Color.fromARGB(255, 216, 113, 29),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
              ),
              child: const Text('search',
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                      fontWeight: FontWeight.bold)),
            )));

    final appBar = AppBar(
        title: const Text(
          'CarRental.com',
          style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
        ),
        toolbarHeight: 90,
        leading: IconButton(
            onPressed: () {Navigator.of(context).pushNamed(SearchDates.tag);},
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
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        crossAxisAlignment: CrossAxisAlignment.center,
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
                          DropdownButton(
                            value: selectedValueTransmission,
                            items: transmissionItems,
                            style: const TextStyle(
                                color: Color.fromARGB(255, 99, 99, 99),
                                fontSize: 20),
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
                          ),
                        ],
                      ),
                      SizedBox(height: 20),
                      Row(
                        children: [
                          vehicleTypeLabel,
                          SizedBox(width: 20),
                          DropdownButton(
                            value: selectedValueCarType,
                            items: vehicleTypeitems,
                            style: const TextStyle(
                                color: Color.fromARGB(255, 99, 99, 99),
                                fontSize: 20),
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
                          ),
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
                            child: Text(
                              'Min price ${_startValue.round().toString()}€',
                              style: TextStyle(
                                  fontSize: 15,
                                  fontWeight: FontWeight.normal,
                                  color: Color.fromARGB(255, 99, 99, 99)),
                            ),
                          ),
                          Align(
                            alignment: Alignment.bottomRight,
                            child: Text(
                              'Max price ${_endValue.round().toString()}€',
                              style: TextStyle(
                                  fontSize: 15,
                                  fontWeight: FontWeight.normal,
                                  color: Color.fromARGB(255, 99, 99, 99)),
                            ),
                          )
                        ],
                      ),
                      searchButton
                    ],
                  ));
            });
          });
    }

    final filterButtonSizedBox = SizedBox(
      width: 150,
      height: 30,
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
      width: 100,
      child: DropdownButton<String>(
        value: dropdownValue,
        alignment: AlignmentDirectional.centerEnd,
        icon: const Icon(Icons.arrow_downward),
        elevation: 16,
        style: const TextStyle(
          color: Color.fromARGB(255, 99, 99, 99),
        ),
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

    var listItems = _createListItems();
    return Scaffold(
        bottomNavigationBar: Navigation(),
        appBar: appBar,
        body: Column(
          children: [
            datesContainer,
            Container(
              margin: EdgeInsets.all(5),
              child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    filterButtonSizedBox,
                    SizedBox(
                      height: 0,
                      width: 20,
                    ),
                    sortDropdownSizedBox
                  ]),
            ),
            Expanded(
              child: ListView(
                shrinkWrap: true,
                padding: EdgeInsets.only(left: 24, right: 24),
                children: listItems.isNotEmpty
                    ? listItems
                    : [
                        Center(
                            child: Text(
                                'Unfortunately, no vehicles found to match the current filter',
                                textAlign: TextAlign.center,
                                style: TextStyle(
                                    fontSize: 18,
                                    fontWeight: FontWeight.bold,
                                    color: Color.fromARGB(255, 99, 99, 99))))
                      ],
              ),
            ),
          ],
        ));
  }
}
