import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:rentacar/data/sp_helper.dart';
import 'package:rentacar/screens/booking_details.dart';
import 'package:rentacar/screens/booking_history.dart';
import 'package:rentacar/services/booking_service.dart';

import '../models/booking.dart';
import '../models/cardInfo.dart';
import '../models/responses/vehicle_base.dart';
import '../shared/navigation.dart';

class Payment extends StatefulWidget {
  final Booking? bookingRequest;
  final VehicleBase? vehicle;
  const Payment({Key? key, this.bookingRequest, this.vehicle})
      : super(key: key);

  static String tag = 'payment';

  @override
  _PaymentState createState() => _PaymentState();
}

class _PaymentState extends State<Payment> {
  TextEditingController txtCardNumber = TextEditingController();
  TextEditingController txtExpiryDateMonth = TextEditingController();
  TextEditingController txtExpiryDateYear = TextEditingController();
  TextEditingController txtCVV = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final cardNumber = TextFormField(
      keyboardType: TextInputType.number,
      autofocus: false,
      controller: txtCardNumber,
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      maxLength: 16,
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
      controller: txtCVV,
      keyboardType: TextInputType.number,
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      maxLength: 3,
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

    final expiryDateMonth = TextFormField(
      autofocus: false,
      controller: txtExpiryDateMonth,
      maxLength: 2,
      keyboardType: TextInputType.number,
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      obscureText: false,
      decoration: InputDecoration(
          fillColor: Color.fromARGB(39, 99, 99, 99),
          filled: true,
          hintText: 'MM',
          contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
          border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
          hintStyle:
              const TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final expiryDateYear = TextFormField(
      autofocus: false,
      controller: txtExpiryDateYear,
      keyboardType: TextInputType.number,
      obscureText: false,
      maxLength: 2,
      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
      decoration: InputDecoration(
          fillColor: Color.fromARGB(39, 99, 99, 99),
          filled: true,
          hintText: 'YY',
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

    final expiryLabelMonthYear = Text(
      '',
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
                onConfirmPaymentPressed(context);
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
                    width: 110,
                    child: Column(children: [
                      expiryLabel,
                      expiryDateMonth,
                    ])),
                SizedBox(width: 10),
                SizedBox(
                    width: 100,
                    child: Column(
                        children: [expiryLabelMonthYear, expiryDateYear])),
                SizedBox(width: 10),
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

  onConfirmPaymentPressed(BuildContext context) async {
    if (!validateCardInfo(context)) {
      showValidationError(context);
      return;
    }
    String expiryDate = "${txtExpiryDateMonth.text}/${txtExpiryDateYear.text}";
    CardInfo cardInfo = CardInfo(txtCardNumber.text, expiryDate, txtCVV.text);
    SPHelper spHelper = SPHelper();
    int userId = spHelper.getUser().userId;
    Booking booking = Booking(
        0,
        widget.bookingRequest?.startDate,
        widget.bookingRequest?.endDate,
        DateTime.now(),
        DateTime.now(),
        userId,
        widget.vehicle?.vehicleId ?? 0,
        widget.bookingRequest?.totalPrice,
        cardInfo);
    BookingService bookingService = BookingService();
    Booking? createdBooking = await bookingService.BookVehicle(booking);
    if (createdBooking != null) {
      Navigator.of(context).pushNamed(BookingHistory.tag);
    } else {
      showAlertDialog(context);
    }
  }

  bool validateCardInfo(BuildContext context) {
    return txtCardNumber.text.length == 16 ||
        txtCVV.text.length == 3 ||
        txtExpiryDateMonth.text.length == 2 ||
        txtExpiryDateYear.text.length == 2;
  }

  showValidationError(BuildContext context) {
    // set up the button
    Widget okButton = TextButton(
      child: Text("OK"),
      onPressed: () {
        Navigator.pop(context);
      },
    );

    // set up the AlertDialog
    AlertDialog alert = AlertDialog(
      title: Text("Data input incorrect"),
      content: Text(
          "Please correct the input and try again. \nNote: Card Number can be exactly 16 numbers long, Expiry date 4 numbers long, and CVV 3 numbers long"),
      actions: [
        okButton,
      ],
    );

    // show the dialog
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return alert;
      },
    );
  }

  showAlertDialog(BuildContext context) {
    // set up the button
    Widget okButton = TextButton(
      child: Text("OK"),
      onPressed: () {
        Navigator.pop(context);
      },
    );

    // set up the AlertDialog
    AlertDialog alert = AlertDialog(
      title: Text("Something went wrong"),
      content: Text("Please try later."),
      actions: [
        okButton,
      ],
    );

    // show the dialog
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return alert;
      },
    );
  }
}
