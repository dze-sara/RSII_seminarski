import 'package:flutter/material.dart';
import 'package:rentacar/screens/register.dart';
import 'package:rentacar/screens/search_dates.dart';
import 'package:rentacar/services/user_service.dart';
import 'package:rentacar/services/vehicle_service.dart';

import '../models/user.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  static String tag = 'login';

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final TextEditingController txtUsername = TextEditingController();
  final TextEditingController txtPassword = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final logo = Hero(
        tag: 'logo',
        child: CircleAvatar(
            backgroundColor: Colors.transparent,
            radius: 100,
            child: Container(
              child: Row(children: [
                const Icon(Icons.car_rental_outlined,
                    color: Colors.white, size: 50),
                const Text('CarRental.com',
                    style: TextStyle(
                        fontSize: 40,
                        fontWeight: FontWeight.bold,
                        color: Colors.white))
              ]),
            )));

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

    final loginButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 20,
            child: FloatingActionButton(
              heroTag: 'btnLogin',
              onPressed: () {
                onLoginPressed(context);
              },
              backgroundColor: const Color.fromARGB(255, 216, 113, 29),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
              ),
              child: const Text('Log In',
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                      fontWeight: FontWeight.bold)),
            )));

    final registerLink = FloatingActionButton(
      heroTag: 'btnRegisterLink',
      backgroundColor: Colors.transparent,
      elevation: 0,
      onPressed: () {
        Navigator.of(context).pushNamed(Register.tag);
      },
      child: const Text("Don't have an account?",
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
            username,
            const SizedBox(height: 8.0),
            password,
            const SizedBox(height: 24.0),
            loginButton,
            registerLink
          ],
        ),
      ),
    );
  }

  onLoginPressed(BuildContext context) async {
    if (txtUsername.text.isEmpty || txtPassword.text.isEmpty) {
      showAlertDialog(context, 'Username and password cant be empty',
          'Please correct the data and try again');
      return;
    }
    UserService userService = UserService();
    User? user = await userService.signIn(txtUsername.text, txtPassword.text);
    if (user != null) {
      Navigator.of(context).pushNamed(SearchDates.tag);
    } else {
      showAlertDialog(context);
    }
  }

  showAlertDialog(BuildContext context, [String? title, String? content]) {
    // set up the button
    Widget okButton = TextButton(
      child: Text("OK"),
      onPressed: () {
        Navigator.pop(context);
      },
    );

    // set up the AlertDialog
    AlertDialog alert = AlertDialog(
      title: Text(title ?? "Incorrect credentials"),
      content: Text(content ?? "Please try again."),
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
