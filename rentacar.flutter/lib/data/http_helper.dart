import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:http/http.dart';
import 'package:rentacar/data/configuration.dart';

class HttpHelper {
  final String path = Configuration().apiUrl + "/api/Vehicles";
  static String? token;

  saveToken(String newToken) {
    token = newToken;
  }

  Future<String> getVehicles() async {
    http.Response result = await http.get(Uri.parse(path));
    return result.body;
  }

  Future<Response> get(String url) async {
    return http.get(Uri.parse(url), headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
      'Authorization': 'Bearer ${token}'
    });
  }

  Future<Response> getWithParams(String url, Map<String, String> params) async {
    Uri uri = Uri.parse(url);
    uri.queryParameters.addAll(params);

    return http.get(uri, headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
      'Authorization': 'Bearer ${token}'
    });
  }

  Future<Response> post(String url, dynamic body) async {
    var bod = jsonEncode(body);
    return http.post(Uri.parse(url),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization': 'Bearer ${token}'
        },
        body: jsonEncode(body));
  }
}
