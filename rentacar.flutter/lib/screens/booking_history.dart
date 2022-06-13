import 'package:flutter/material.dart';
import 'package:rentacar/models/vehicle_booking.dart';
import 'package:intl/intl.dart';
import 'package:rentacar/screens/vehicles_list.dart';
import 'package:rentacar/services/booking_service.dart';

import '../data/sp_helper.dart';
import '../models/booking.dart';
import '../models/responses/vehicle_base.dart';
import '../models/review.dart';
import '../models/user.dart';
import '../services/review_service.dart';
import '../services/vehicle_service.dart';
import '../shared/navigation.dart';

class BookingHistory extends StatefulWidget {
  const BookingHistory({Key? key}) : super(key: key);

  static String tag = 'booking-history';

  @override
  _BookingHistoryState createState() => _BookingHistoryState();
}

class _BookingHistoryState extends State<BookingHistory> {
  List<Booking>? bookings;
  List<VehicleBooking>? vehicleBookings;
  SPHelper spHelper = SPHelper();
  User? currentUser;

  @override
  void initState() {
    super.initState();
    currentUser = spHelper.getUser();
    _getBookinghistory(currentUser?.userId);
  }

  _getBookinghistory(userId) async {
    BookingService bookingService = BookingService();
    var result =
        await bookingService.GetBookingHistory(currentUser?.userId ?? 2);
    setState(() {
      bookings = result;
      _getVehicleBookings(bookings);
    });
  }

  _getVehicleBookings(List<Booking>? bookings) async {
    VehicleService vehicleService = VehicleService();
    List<VehicleBooking>? vehicleBookingsMap = [];
    var len = bookings?.length ?? 0;
    for (var i = 0; i < len; i++) {
      var vehicle = await vehicleService.GetById(bookings?[i].vehicleId ?? 0);
      var vehicleBooking = VehicleBooking(
          vehicle?.vehicleId ?? 0,
          vehicle?.ratePerDay,
          vehicle?.transmissionType,
          vehicle?.modelId,
          vehicle?.model,
          vehicle?.make,
          vehicle?.vehicleType,
          vehicle?.numberOfSeats,
          vehicle?.imageUrl,
          bookings?[i].totalPrice,
          vehicle?.score,
          bookings?[i].bookingId ?? 0,
          bookings?[i].endDate,
          bookings?[i].startDate);
      vehicleBookingsMap.add(vehicleBooking);
    }
    setState(() {
      vehicleBookings = vehicleBookingsMap;
    });
  }

  @override
  Widget build(BuildContext context) {
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
                        Text(review.content,
                            textAlign: TextAlign.start,
                            style: TextStyle(
                                fontSize: 20,
                                color: Color.fromARGB(255, 99, 99, 99))),
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

    Future<Null> _showReviewsDialog(BuildContext context, int? modelId) async {
      ReviewService reviewService = ReviewService();
      List<Review>? reviews = await reviewService.getReview(modelId ?? 0);

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
                    children: _displayReviews(reviews),
                  ));
            });
          });
    }

    List<Container> listitems = [];
    List<Container> _createListItems() {
      var listOfVehicles = vehicleBookings ?? [];
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
                  Column(
                    children: [
                      Row(
                        children: [
                          Container(
                            padding: EdgeInsets.all(10),
                            foregroundDecoration: BoxDecoration(
                                border: Border.all(
                                    color: Color.fromARGB(255, 216, 113, 29)),
                                borderRadius: BorderRadius.circular(10)),
                            child: Row(
                              children: [
                                Align(
                                  alignment: Alignment.centerLeft,
                                  child: SizedBox(
                                      width: 145,
                                      child: Column(children: [
                                        Align(
                                            alignment: Alignment.centerLeft,
                                            child: Text('Pick up date',
                                                style: TextStyle(
                                                    fontSize: 15,
                                                    color: Color.fromARGB(
                                                        255, 99, 99, 99)))),
                                        Align(
                                            alignment: Alignment.centerLeft,
                                            child: Text(
                                                DateFormat('yyyy-MM-dd , kk:mm')
                                                    .format(listOfVehicles[i]
                                                            .startDate ??
                                                        DateTime.now()),
                                                style: TextStyle(
                                                    fontSize: 15,
                                                    fontWeight: FontWeight.bold,
                                                    color: Color.fromARGB(
                                                        255, 99, 99, 99))))
                                      ])),
                                ),
                                Align(
                                  alignment: Alignment.centerRight,
                                  child: SizedBox(
                                    width: 145,
                                    child: Column(children: [
                                      Align(
                                          alignment: Alignment.centerRight,
                                          child: Text('Return date',
                                              style: TextStyle(
                                                  fontSize: 15,
                                                  color: Color.fromARGB(
                                                      255, 99, 99, 99)))),
                                      Align(
                                          alignment: Alignment.centerRight,
                                          child: Text(
                                              DateFormat('yyyy-MM-dd , kk:mm')
                                                  .format(listOfVehicles[i]
                                                          .endDate ??
                                                      DateTime.now()),
                                              style: TextStyle(
                                                  fontSize: 15,
                                                  fontWeight: FontWeight.bold,
                                                  color: Color.fromARGB(
                                                      255, 99, 99, 99))))
                                    ]),
                                  ),
                                )
                              ],
                            ),
                          )
                        ],
                      ),
                      Row(
                        children: [
                          SizedBox(
                              width: 200,
                              height: 230,
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
                                          mainAxisAlignment:
                                              MainAxisAlignment.center,
                                          children: _displayIcons(
                                              listOfVehicles[i].score ?? 0))),
                                  Padding(
                                      padding: const EdgeInsets.symmetric(
                                          vertical: 2.0),
                                      child: SizedBox(
                                          height: 23,
                                          width: 60,
                                          child: FloatingActionButton(
                                            heroTag: null,
                                            onPressed: () {
                                              _showReviewsDialog(context,
                                                  listOfVehicles[i].modelId);
                                            },
                                            backgroundColor:
                                                const Color.fromARGB(
                                                    255, 216, 113, 29),
                                            shape: RoundedRectangleBorder(
                                              borderRadius:
                                                  BorderRadius.circular(32.0),
                                            ),
                                            child: const Text('Reviews',
                                                style: TextStyle(
                                                    color: Colors.white,
                                                    fontSize: 12,
                                                    fontWeight:
                                                        FontWeight.bold)),
                                          )))
                                ],
                              ))),
                          SizedBox(
                            width: 5,
                          ),
                          SizedBox(
                            width: 100,
                            height: 230,
                            child: Column(
                                mainAxisAlignment: MainAxisAlignment.center,
                                crossAxisAlignment: CrossAxisAlignment.center,
                                children: [
                                  Row(children: [
                                    Text(
                                        listOfVehicles[i].make?.toUpperCase() ??
                                            '',
                                        style: TextStyle(
                                            fontSize: 20,
                                            fontWeight: FontWeight.bold,
                                            color: Color.fromARGB(
                                                255, 99, 99, 99)))
                                  ]),
                                  SizedBox(width: 5),
                                  Row(children: [
                                    Text(
                                        listOfVehicles[i]
                                                .model
                                                ?.toLowerCase() ??
                                            '',
                                        style: TextStyle(
                                            fontSize: 20,
                                            fontWeight: FontWeight.bold,
                                            color: Color.fromARGB(
                                                255, 99, 99, 99)))
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
                                              color: Color.fromARGB(
                                                  255, 99, 99, 99)))
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
                                              color: Color.fromARGB(
                                                  255, 99, 99, 99)))
                                    ],
                                  ),
                                  Row(
                                    children: [
                                      Icon(Icons.car_rental),
                                      Text(
                                          listOfVehicles[i]
                                                  .transmissionType
                                                  ?.toString() ??
                                              '',
                                          style: TextStyle(
                                              fontSize: 15,
                                              fontWeight: FontWeight.bold,
                                              color: Color.fromARGB(
                                                  255, 99, 99, 99)))
                                    ],
                                  ),
                                  SizedBox(height: 15),
                                  Row(
                                    children: [
                                      Text('total price',
                                          style: TextStyle(
                                              fontSize: 15,
                                              fontWeight: FontWeight.normal,
                                              color: Color.fromARGB(
                                                  255, 99, 99, 99)))
                                    ],
                                  ),
                                  Row(
                                    children: [
                                      Text(
                                          '${listOfVehicles[i].totalPrice?.toString() ?? ''}€',
                                          style: TextStyle(
                                              fontSize: 20,
                                              fontWeight: FontWeight.bold,
                                              color: Color.fromARGB(
                                                  255, 99, 99, 99)))
                                    ],
                                  )
                                ]),
                          )
                        ],
                      )
                    ],
                  )
                ]));
        listitems.add(listItem);
      }
      return listitems;
    }

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

    final greetingMessage = Text(
      'Hi, ${currentUser?.firstName}!\nThis is your car rental history.',
      style: TextStyle(
          fontSize: 25,
          color: Color.fromARGB(255, 216, 113, 29),
          fontWeight: FontWeight.normal),
    );

    return Scaffold(
      bottomNavigationBar: Navigation(),
      appBar: appBar,
      body: Center(
        child: Column(children: [
          Container(
              padding: EdgeInsets.only(left: 24.0, right: 24.0, top: 24.0),
              child: greetingMessage),
          Expanded(
            child: ListView(
              shrinkWrap: true,
              padding: EdgeInsets.only(left: 24, right: 24),
              children: _createListItems(),
            ),
          )
        ]),
      ),
    );
  }
}
