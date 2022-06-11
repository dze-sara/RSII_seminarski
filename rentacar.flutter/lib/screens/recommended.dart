import 'package:flutter/material.dart';

import '../shared/navigation.dart';

class Recommended extends StatefulWidget {
  const Recommended({Key? key}) : super(key: key);

  static String tag = 'recommended';
  
  @override
  _RecommendedState createState() => _RecommendedState();
}

class _RecommendedState extends State<Recommended> {
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
                              // Navigator.of(context).pushNamed(BookingDetails.tag);
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
    final greetingMessage = const Text(
      'What we recommend based on your previous rentals:',
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
          ListView(
            shrinkWrap: true,
            padding: const EdgeInsets.only(left: 24.0, right: 24.0),
            children: [
              const SizedBox(height: 20.0),
              greetingMessage,
              vehicleListItem
            ],
          )
        ]),
      ),
    );
  }
}
