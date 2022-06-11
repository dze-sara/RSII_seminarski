import 'package:http/http.dart' as http;
import 'package:rentacar/data/configuration.dart';

class HttpHelper {
  final String path = Configuration().apiUrl + "/api/Vehicles";

  Future<String> getVehicles() async {
    http.Response result = await http.get(Uri.parse(path));
    return result.body;
  }
}
