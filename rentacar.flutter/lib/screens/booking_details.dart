import 'package:flutter/material.dart';

class BookingDetails extends StatefulWidget {
  const BookingDetails({Key? key}) : super(key: key);

  static String tag = 'booking-details';

  @override
  _BookingDetailsState createState() => _BookingDetailsState();
}

class _BookingDetailsState extends State<BookingDetails> {
  @override
  Widget build(BuildContext context) {
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
                            heroTag: 'btnConfirm',
                            onPressed: () {},
                            backgroundColor:
                                const Color.fromARGB(255, 216, 113, 29),
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(32.0),
                            ),
                            child: const Text('confirm',
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
        body: vehicleListItem,
    );
  }
}
