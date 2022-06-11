import 'package:flutter/material.dart';
import 'package:rentacar/screens/booking_history.dart';
import 'package:rentacar/screens/recommended.dart';
import 'package:rentacar/screens/search_dates.dart';
import 'package:rentacar/screens/user_details.dart';

class Navigation extends StatefulWidget {
  const Navigation({Key? key}) : super(key: key);

  @override
  _NavigationState createState() => _NavigationState();
}

class _NavigationState extends State<Navigation> {
  @override
  Widget build(BuildContext context) {

    final items = <BottomNavigationBarItem>[
      BottomNavigationBarItem(
        icon: Icon(Icons.search),
        label: 'search',
      ),
      BottomNavigationBarItem(
        icon: Icon(Icons.flash_on),
        label: 'recommended',
      ),
      BottomNavigationBarItem(
        icon: Icon(Icons.directions_car),
        label: 'rental history',
      ),
      BottomNavigationBarItem(
        icon: Icon(Icons.person),
        label: 'profile',
      ),
    ];

    int _selectedIndex = 0;

    void _onItemTapped(int index) {

      setState(() {
        _selectedIndex = index;
      });
      switch (index) {
        case 0:
          Navigator.of(context).pushNamed(SearchDates.tag);
          break;
        case 1:
          Navigator.of(context).pushNamed(Recommended.tag);
          break;
        case 2:
          Navigator.of(context).pushNamed(BookingHistory.tag);
          break;
        case 3:
          Navigator.of(context).pushNamed(UserDetails.tag);
          break;
      };
    }

    return BottomNavigationBar(
      items: items,
      type: BottomNavigationBarType.fixed,
      backgroundColor: const Color.fromARGB(255, 4, 28, 48),
      unselectedIconTheme: IconThemeData(color: Colors.white, size: 30),
      unselectedItemColor: Colors.white,
      selectedIconTheme:
          IconThemeData(color: Colors.white, size: 30),
      selectedItemColor: Colors.white,
      currentIndex: _selectedIndex,
      onTap: _onItemTapped,
    );
  }
}
