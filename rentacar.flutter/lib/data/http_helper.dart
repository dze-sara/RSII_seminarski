import 'package:http/http.dart' as http;

class HttpHelper {
  final String path = "http://localhost:5000/api/Vehicles";

  Future<String> getVehicles() async {
    Uri uri = Uri(path: path);
    http.Response result = await http.get(Uri.parse('http://192.168.0.12:5000/api/Vehicles'));
    return result.body;
  }
}
