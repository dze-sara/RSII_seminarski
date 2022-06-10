import 'package:flutter/material.dart';

class Filters extends StatefulWidget {
  const Filters({Key? key}) : super(key: key);

  static String tag = 'filters';

  @override
  _FiltersState createState() => _FiltersState();
}

List<DropdownMenuItem<String>> get transmissionItems {
  List<DropdownMenuItem<String>> menuItems = [
    DropdownMenuItem(child: Text("Manual"), value: "1"),
    DropdownMenuItem(child: Text("Automatic"), value: "2")
  ];
  return menuItems;
}

List<DropdownMenuItem<String>> get vehicleTypeitems {
  List<DropdownMenuItem<String>> menuItems = [
    DropdownMenuItem(child: Text("Small car"), value: "Small car"),
    DropdownMenuItem(child: Text("Sedan"), value: "Sedan"),
    DropdownMenuItem(child: Text("SUV"), value: "SUV"),
    DropdownMenuItem(child: Text("Sports car"), value: "Sports car"),
  ];
  return menuItems;
}

var selectedValueTransmission = "1";
var selectedValueCarType = "Small car";

RangeValues _priceRangeValues = const RangeValues(10, 250);

class _FiltersState extends State<Filters> {
  @override
  Widget build(BuildContext context) {
    final transmissionDropdown = DropdownButton(
      value: selectedValueTransmission,
      items: transmissionItems,
      style:
          const TextStyle(color: Color.fromARGB(255, 99, 99, 99), fontSize: 20),
      underline: Container(
        height: 2,
        width: 20,
        color: Color.fromARGB(255, 216, 113, 29),
      ),
      onChanged: (String? newValue) {
        setState(() {
          selectedValueTransmission = newValue!;
        });
      },
    );

    final transmissionLabel = Text(
      'Transmission',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final vehicleTypeDropdown = DropdownButton(
      value: selectedValueCarType,
      items: vehicleTypeitems,
      style:
          const TextStyle(color: Color.fromARGB(255, 99, 99, 99), fontSize: 20),
      underline: Container(
        height: 2,
        width: 20,
        color: Color.fromARGB(255, 216, 113, 29),
      ),
      onChanged: (String? newValue) {
        setState(() {
          selectedValueCarType = newValue!;
        });
      },
    );

    final vehicleTypeLabel = Text(
      'Vehicle type',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final priceRange = RangeSlider(
      values: _priceRangeValues,
      max: 500,
      divisions: 20,
      labels: RangeLabels(
        _priceRangeValues.start.round().toString(),
        _priceRangeValues.end.round().toString(),
      ),
      onChanged: (RangeValues values) {
        setState(() {
          _priceRangeValues = values;
        });
      },
    );

    final priceRangeLabel = Text(
      'Price range',
      style: TextStyle(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final minPriceLabel = Text(
      'Min price ${_priceRangeValues.start.round().toString()}€',
      style: TextStyle(
          fontSize: 15,
          fontWeight: FontWeight.normal,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final maxPriceLabel = Text(
      'Max price ${_priceRangeValues.end.round().toString()}€',
      style: TextStyle(
          fontSize: 15,
          fontWeight: FontWeight.normal,
          color: Color.fromARGB(255, 99, 99, 99)),
    );

    final loginButton = Padding(
      padding: const EdgeInsets.symmetric(vertical: 16.0),
      child: SizedBox(
        height: 35,
        width: 100,
        child: ElevatedButton(
        onPressed: () {
          // Navigator.of(context).pushNamed(SearchDates.tag);
        },
        style: ButtonStyle(
          backgroundColor: MaterialStateProperty.all<Color>(
            const Color.fromARGB(255, 216, 113, 29)
          ),
          shape: MaterialStateProperty.all<RoundedRectangleBorder>(
            RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(32.0),
            )
          )          
        ),
        child: const Text('search', style: TextStyle(color: Colors.white, fontSize: 20, fontWeight: FontWeight.bold)),
        )
      )
    );

    Future<Null> _showModalBottomSheet(BuildContext context) async {
      await showModalBottomSheet(
          shape:
              RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
          elevation: 15,
          context: context,
          builder: (context) {
            return Container(
                padding: EdgeInsets.all(15),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: <Widget>[
                    Row(
                      children: [
                        transmissionLabel,
                        SizedBox(width: 20),
                        transmissionDropdown,
                      ],
                    ),
                    SizedBox(height: 20),
                    Row(
                      children: [
                        vehicleTypeLabel,
                        SizedBox(width: 20),
                        vehicleTypeDropdown,
                      ],
                    ),
                    SizedBox(height: 20),
                    priceRangeLabel,
                    priceRange,
                    Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Align(
                          alignment: Alignment.bottomLeft,
                          child: minPriceLabel,
                        ),
                        Align(
                          alignment: Alignment.bottomRight,
                          child: maxPriceLabel,
                        )
                      ],
                    ),
                    loginButton
                  ],
                ));
          });
    }

    return Scaffold(
        body: ElevatedButton(
      onPressed: () {
        _showModalBottomSheet(context);
      },
      child: Text(
        'Click Me',
        style: TextStyle(
            color: Colors.white,
            fontWeight: FontWeight.w600,
            letterSpacing: 0.6),
      ),
    ));
  }
}
