import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:rentacar/screens/payment.dart';
import 'package:rentacar/screens/vehicles_list.dart';

import '../shared/navigation.dart';

class BookingDetails extends StatefulWidget {
  const BookingDetails({Key? key}) : super(key: key);

  static String tag = 'booking-details';

  @override
  _BookingDetailsState createState() => _BookingDetailsState();
}

var formattedDateTime = DateFormat('yyyy-MM-dd , kk:mm').format(DateTime.now());

class _BookingDetailsState extends State<BookingDetails> {
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
        Row(
          children: _displayIcons(number),
        ),
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

    final vehicleListItem = Container(
        margin: EdgeInsets.only(top: 5, bottom: 5),
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
                child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
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
                          Text('total price',
                              style: TextStyle(
                                  fontSize: 15,
                                  fontWeight: FontWeight.normal,
                                  color: Color.fromARGB(255, 99, 99, 99)))
                        ],
                      ),
                      Row(
                        children: [
                          Text('500€',
                              style: TextStyle(
                                  fontSize: 20,
                                  fontWeight: FontWeight.bold,
                                  color: Color.fromARGB(255, 99, 99, 99)))
                        ],
                      ),
                      SizedBox(height: 5),
                    ]),
              )
            ]));

    final continueButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 250,
            child: FloatingActionButton(
              heroTag: 'btnContinue',
              onPressed: () {
                Navigator.of(context).pushNamed(Payment.tag);
              },
              backgroundColor: const Color.fromARGB(255, 216, 113, 29),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
              ),
              child: const Text('continue to payment',
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 15,
                      fontWeight: FontWeight.bold)),
            )));

    final messageName = const Text(
      'Hi, Sara!',
      style: TextStyle(
          fontSize: 30,
          color: Color.fromARGB(255, 216, 113, 29),
          fontWeight: FontWeight.bold),
    );
    final greetingMessage = const Text(
      'These are your booking details.',
      style: TextStyle(
          fontSize: 30,
          color: Color.fromARGB(255, 216, 113, 29),
          fontWeight: FontWeight.normal),
    );

    final greetingMessageContainer = Container(
        padding: EdgeInsets.all(20),
        alignment: Alignment.centerLeft,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Align(alignment: Alignment.centerLeft, child: messageName),
            Align(alignment: Alignment.centerLeft, child: greetingMessage)
          ],
        ));

    final cancelButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 150,
            child: FloatingActionButton(
              heroTag: 'btnCancel1',
              onPressed: () {
                Navigator.pop(context);
              },
              backgroundColor: Colors.transparent,
              elevation: 0,
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(32.0),
                  side: BorderSide(
                      color: const Color.fromARGB(255, 216, 113, 29),
                      width: 1.5)),
              child: const Text('back to search',
                  style: TextStyle(
                      color: Color.fromARGB(255, 216, 113, 29),
                      fontSize: 15,
                      fontWeight: FontWeight.bold)),
            )));
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
      backgroundColor: const Color.fromARGB(255, 4, 28, 48),
    );

    return Scaffold(
        appBar: appBar,
        bottomNavigationBar: Navigation(),
        body: Center(
            child: ListView(
          shrinkWrap: false,
          padding: EdgeInsets.only(left: 24, right: 24),
          children: <Widget>[
            messageName,
            greetingMessage,
            datesContainer,
            vehicleListItem,
            continueButton,
            cancelButton
          ],
        )));
  }
}
