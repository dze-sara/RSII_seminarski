import 'package:flutter/material.dart';
import 'package:rentacar/models/user.dart';
import 'package:rentacar/screens/login.dart';
import 'package:rentacar/screens/search_dates.dart';

import '../services/user_service.dart';

class Register extends StatefulWidget {
  const Register({Key? key}) : super(key: key);

  static String tag = 'register';

  @override
  _RegisterState createState() => _RegisterState();
}

class _RegisterState extends State<Register> {
  final TextEditingController txtUsername = TextEditingController();
  final TextEditingController txtFirstName = TextEditingController();
  final TextEditingController txtLastName = TextEditingController();
  final TextEditingController txtPassword = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final logo = Hero(
        tag: '123',
        child: CircleAvatar(
            backgroundColor: Colors.transparent,
            radius: 100,
            child: Container(
              child: Row(children: [
                const Icon(Icons.car_rental_outlined,
                    color: Colors.white, size: 50),
                const Text('CarRental.com',
                    style: const TextStyle(
                        fontSize: 40,
                        fontWeight: FontWeight.bold,
                        color: Colors.white))
              ]),
            )));

    final firstName = TextFormField(
      keyboardType: TextInputType.text,
      autofocus: false,
      controller: txtFirstName,
      decoration: InputDecoration(
        fillColor: Colors.white,
        filled: true,
        hintText: 'first name',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
      ),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final lastName = TextFormField(
      keyboardType: TextInputType.text,
      autofocus: false,
      controller: txtLastName,
      decoration: InputDecoration(
        fillColor: Colors.white,
        filled: true,
        hintText: 'last name',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
      ),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final username = TextFormField(
      keyboardType: TextInputType.emailAddress,
      autofocus: false,
      controller: txtUsername,
      decoration: InputDecoration(
        fillColor: Colors.white,
        filled: true,
        hintText: 'username',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
      ),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final password = TextFormField(
      autofocus: false,
      controller: txtPassword,
      obscureText: true,
      decoration: InputDecoration(
          fillColor: Colors.white,
          filled: true,
          hintText: 'password',
          contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
          border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
          hintStyle:
              const TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
      style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 20,
          color: Color.fromARGB(255, 216, 113, 29)),
    );

    final registerButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 20,
            child: FloatingActionButton(
              onPressed: () {
                onRegisterPressed();
              },
              heroTag: 'btnRegister',
              backgroundColor: const Color.fromARGB(255, 216, 113, 29),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
              ),
              child: const Text('Register',
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                      fontWeight: FontWeight.bold)),
            )));

    final loginLink = FloatingActionButton(
      heroTag: 'btnLoginLink',
      backgroundColor: Colors.transparent,
      elevation: 0,
      onPressed: () {
        Navigator.of(context).pushNamed(Login.tag);
      },
      child: const Text("Already have an account?",
          style: TextStyle(
              color: Colors.white,
              fontSize: 20,
              fontWeight: FontWeight.bold,
              decoration: TextDecoration.underline)),
    );

    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 4, 28, 48),
      body: Center(
        child: ListView(
          shrinkWrap: true,
          padding: const EdgeInsets.only(left: 24.0, right: 24.0),
          children: <Widget>[
            logo,
            const SizedBox(height: 48.0),
            firstName,
            const SizedBox(height: 8.0),
            lastName,
            const SizedBox(height: 8.0),
            username,
            const SizedBox(height: 8.0),
            password,
            const SizedBox(height: 24.0),
            registerButton,
            loginLink
          ],
        ),
      ),
    );
  }

  onRegisterPressed() async {
    UserService userService = UserService();
    User newUserData = User(0, txtUsername.text, txtFirstName.text,
        txtLastName.text, txtPassword.text, null, null, 0, null);
    User? user = await userService.register(newUserData);
    if (user != null) {
      Navigator.of(context).pushNamed(SearchDates.tag);
    } else {
      showAlertDialog(context);
    }
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
      title: Text("Invalid data provided"),
      content: Text("Please check the input and try again."),
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
