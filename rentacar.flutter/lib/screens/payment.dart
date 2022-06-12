import 'package:flutter/material.dart';
import 'package:rentacar/screens/booking_details.dart';
import 'package:rentacar/screens/booking_history.dart';

import '../shared/navigation.dart';

class Payment extends StatefulWidget {
  const Payment({Key? key}) : super(key: key);

  static String tag = 'payment';

  @override
  _PaymentState createState() => _PaymentState();
}

class _PaymentState extends State<Payment> {
  @override
  Widget build(BuildContext context) {
    final cardNumber = TextFormField(
      keyboardType: TextInputType.number,
      autofocus: false,
      initialValue: '',
      decoration: InputDecoration(
        fillColor: Color.fromARGB(39, 99, 99, 99),
        filled: true,
        hintText: 'xxxx-xxxx-xxxx-xxxx',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
      ),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final ccv = TextFormField(
      autofocus: false,
      initialValue: '',
      obscureText: true,
      decoration: InputDecoration(
          fillColor: Color.fromARGB(39, 99, 99, 99),
          filled: true,
          hintText: 'CVV',
          contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
          border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
          hintStyle:
              const TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final expiryDate = TextFormField(
      autofocus: false,
      initialValue: '',
      obscureText: false,
      decoration: InputDecoration(
          fillColor: Color.fromARGB(39, 99, 99, 99),
          filled: true,
          hintText: 'MM/YY',
          contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
          border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
          hintStyle:
              const TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final cardLabel = Text(
      'Card number',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final expiryLabel = Text(
      'Expiry date',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final cvvLabel = Text(
      'CVV',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final paymentMessage = const Text(
      'Please enter your credit card details.',
      style: TextStyle(
          fontSize: 25,
          color: Color.fromARGB(255, 216, 113, 29),
          fontWeight: FontWeight.normal),
    );

    final paymentButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 150,
            child: FloatingActionButton(
              heroTag: 'btnPayment',
              onPressed: () {
                Navigator.of(context).pushNamed(BookingHistory.tag);
              },
              backgroundColor: const Color.fromARGB(255, 216, 113, 29),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
              ),
              child: const Text('confirm payment',
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 15,
                      fontWeight: FontWeight.bold)),
            )));

    final cancelButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 150,
            child: FloatingActionButton(
              heroTag: 'btnCancel',
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
              child: const Text('back to booking details',
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
        backgroundColor: const Color.fromARGB(255, 4, 28, 48));

    return Scaffold(
      bottomNavigationBar: Navigation(),
      appBar: appBar,
      body: Center(
        child: ListView(
          shrinkWrap: true,
          padding: const EdgeInsets.only(left: 24.0, right: 24.0),
          children: <Widget>[
            paymentMessage,
            const SizedBox(height: 48.0),
            cardLabel,
            cardNumber,
            const SizedBox(height: 48.0),
            Row(
              children: [
                SizedBox(
                    width: 150,
                    child: Column(children: [expiryLabel, expiryDate])),
                SizedBox(width: 20),
                SizedBox(width: 100, child: Column(children: [cvvLabel, ccv]))
              ],
            ),
            const SizedBox(height: 48.0),
            paymentButton,
            cancelButton
          ],
        ),
      ),
    );
  }
}
