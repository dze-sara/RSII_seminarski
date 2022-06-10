import 'package:flutter/material.dart';
import 'package:rentacar/screens/login.dart';
import 'package:rentacar/screens/search_dates.dart';

class Register extends StatefulWidget {
  const Register({ Key? key }) : super(key: key);

  static String tag = 'register';

  @override
  _RegisterState createState() => _RegisterState();
}

class _RegisterState extends State<Register> {
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
                    style: const TextStyle(
                        fontSize: 40,
                        fontWeight: FontWeight.bold,
                        color: Colors.white))
              ]),
            )));

    final firstName = TextFormField(
      keyboardType: TextInputType.emailAddress,
      autofocus: false,
      initialValue: '',
      decoration: InputDecoration(
        fillColor: Colors.white,
        filled: true,
        hintText: 'first name',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
      ),
      style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20, color: Color.fromARGB(255, 216, 113, 29)),
    );

    final lastName = TextFormField(
      keyboardType: TextInputType.emailAddress,
      autofocus: false,
      initialValue: '',
      decoration: InputDecoration(
        fillColor: Colors.white,
        filled: true,
        hintText: 'last name',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
      ),
      style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20, color: Color.fromARGB(255, 216, 113, 29)),
    );

    final username = TextFormField(
      keyboardType: TextInputType.emailAddress,
      autofocus: false,
      initialValue: '',
      decoration: InputDecoration(
        fillColor: Colors.white,
        filled: true,
        hintText: 'username',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
      ),
      style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20, color: Color.fromARGB(255, 216, 113, 29)),
    );

    final password = TextFormField(
      autofocus: false,
      initialValue: '',
      obscureText: true,
      decoration: InputDecoration(
        fillColor: Colors.white,
        filled: true,
        hintText: 'password',
        contentPadding: const EdgeInsets.fromLTRB(20.0, 10.0, 20.0, 10.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        hintStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20)
      ),
      style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 20, color: Color.fromARGB(255, 216, 113, 29)),
    );

    final registerButton = Padding(
      padding: const EdgeInsets.symmetric(vertical: 16.0),
      child: SizedBox(
        height: 50,
        width: 20,
        child: FloatingActionButton(
        onPressed: () {
          Navigator.of(context).pushNamed(SearchDates.tag);
        },
        heroTag: 'btnRegister',
          backgroundColor: 
            const Color.fromARGB(255, 216, 113, 29),
          
          shape: 
            RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(32.0),
            ),
              
        
        child: const Text('Register', style: TextStyle(color: Colors.white, fontSize: 20, fontWeight: FontWeight.bold)),
        )
      )
    );

    final loginLink = FloatingActionButton(
      heroTag: 'btnLoginLink',
      backgroundColor: Colors.transparent,
      elevation: 0,
      onPressed: () {
        Navigator.of(context).pushNamed(Login.tag);
      },
      child: const Text("Already have an account?", style: TextStyle(color: Colors.white, fontSize: 20, fontWeight: FontWeight.bold, decoration: TextDecoration.underline)),
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
}