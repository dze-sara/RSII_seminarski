import 'package:flutter/material.dart';

class AppBarCustom extends StatefulWidget {
  const AppBarCustom({Key? key}) : super(key: key);

  @override
  State<AppBarCustom> createState() => _AppBarCustomState();
}

class _AppBarCustomState extends State<AppBarCustom> {
  @override
  Widget build(BuildContext context) {
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
    return appBar;
  }
}
