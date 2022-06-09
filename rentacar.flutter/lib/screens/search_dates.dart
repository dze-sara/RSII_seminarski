import 'package:flutter/material.dart';
import 'package:rentacar/shared/navigation.dart';

class SearchDates extends StatelessWidget {
  const SearchDates({Key? key}) : super(key: key);

  static String tag = 'searchDates';

  @override
  Widget build(BuildContext context) {
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
      body: Column(children: [
        Text(
          'pick a perfect car for you',
          style: TextStyle(
              fontSize: 30,
              color: Color.fromARGB(255, 216, 113, 29),
              fontWeight: FontWeight.bold),
        ),
        SizedBox(
          width: 100,
          child: InputChip(label: Text('')),
        )
      ]),
    );
  }
}
