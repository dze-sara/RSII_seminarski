import 'package:flutter/material.dart';
import 'package:rentacar/data/sp_helper.dart';
import 'package:rentacar/services/user_service.dart';

import '../models/user.dart';
import '../shared/navigation.dart';

class UserDetails extends StatefulWidget {
  const UserDetails({Key? key}) : super(key: key);

  static String tag = 'user-details';

  @override
  _UserDetailsState createState() => _UserDetailsState();
}

class _UserDetailsState extends State<UserDetails> {
  User? currentUser;
  SPHelper spHelper = SPHelper();
  TextEditingController txtFirstName = TextEditingController();
  TextEditingController txtLastName = TextEditingController();
  TextEditingController txtUsername = TextEditingController();
  TextEditingController txtPassword = TextEditingController();

  @override
  Widget build(BuildContext context) {
    currentUser = spHelper.getUser();
    txtFirstName.text = currentUser?.firstName ?? '';
    txtLastName.text = currentUser?.lastName ?? '';
    txtUsername.text = currentUser?.username ?? '';
    txtPassword.text = currentUser?.password ?? '';

    final firstName = TextFormField(
      keyboardType: TextInputType.emailAddress,
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
      keyboardType: TextInputType.emailAddress,
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

    final saveButton = Padding(
        padding: const EdgeInsets.symmetric(vertical: 16.0),
        child: SizedBox(
            height: 50,
            width: 20,
            child: FloatingActionButton(
              onPressed: () {
                onSavePressed(context);
              },
              heroTag: 'btnSave',
              backgroundColor: const Color.fromARGB(255, 216, 113, 29),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
              ),
              child: const Text('Save',
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
            onPressed: () {},
            icon: const Icon(
              Icons.car_rental_outlined,
              color: Colors.white,
              size: 50,
            )),
        backgroundColor: const Color.fromARGB(255, 4, 28, 48));

    final greetingMessage = Text(
      'Hi, ${currentUser?.firstName}\nModify your profile details here.',
      style: TextStyle(
          fontSize: 25,
          color: Color.fromARGB(255, 216, 113, 29),
          fontWeight: FontWeight.normal),
    );

    return Scaffold(
      appBar: appBar,
      bottomNavigationBar: Navigation(),
      body: Center(
        child: ListView(
          shrinkWrap: true,
          padding: const EdgeInsets.only(left: 24.0, right: 24.0),
          children: <Widget>[
            // const SizedBox(height: 20.0),
            greetingMessage,
            const SizedBox(height: 48.0),
            firstName,
            const SizedBox(height: 8.0),
            lastName,
            const SizedBox(height: 8.0),
            username,
            const SizedBox(height: 8.0),
            password,
            const SizedBox(height: 24.0),
            saveButton,
          ],
        ),
      ),
    );
  }

  onSavePressed(BuildContext context) async {
    if (isInvalidData()) {
      showAlert(context, 'Data can not be empty',
          'Please check all the values and try again');
      return;
    }
    currentUser?.firstName = txtFirstName.text;
    currentUser?.lastName = txtLastName.text;
    currentUser?.username = txtUsername.text;
    currentUser?.password = txtPassword.text;

    UserService userService = UserService();
    User? updatedUser = await userService.update(currentUser!);
    if (updatedUser != null) {
      setState(() {
        currentUser = updatedUser;
      });
      showSuccesDialog(context);
    } else {
      showErrorDialog(context);
    }
  }

  bool isInvalidData() {
    return txtFirstName.text.isEmpty ||
        txtLastName.text.isEmpty ||
        txtUsername.text.isEmpty ||
        txtPassword.text.isEmpty;
  }

  showSuccesDialog(BuildContext context) {
    showAlert(context, 'Data updated', 'User data was updated succesfully');
  }

  showErrorDialog(BuildContext context) {
    showAlert(
        context, 'Something went wrong', 'Please check the data and try again');
  }

  showAlert(BuildContext context, String title, String content) {
// set up the button
    Widget okButton = TextButton(
      child: Text("OK"),
      onPressed: () {
        Navigator.pop(context);
      },
    );

    // set up the AlertDialog
    AlertDialog alert = AlertDialog(
      title: Text(title),
      content: Text(content),
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
