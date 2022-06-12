import 'package:rentacar/models/responses/vehicle_base.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

import '../data/configuration.dart';
import '../data/http_helper.dart';
import '../data/sp_helper.dart';
import '../models/requests/book_vehicles_request.dart';

class VehicleService {
  final SPHelper helper = SPHelper();
  final HttpHelper httpHelper = HttpHelper();

  VehicleService() {
    helper.init();
  }

  Future<List<VehicleBase>?> Filter(BookVehiclesRequest request) async {
    String path = '${Configuration().apiUrl}/api/Vehicles/filter2book';
    try {
      http.Response result = await httpHelper.post(path, request);
      var decoded = json.decode(result.body);

      List<VehicleBase> vehicles = List<VehicleBase>.from(
          decoded.map((model) => VehicleBase.fromJson(model)));
      return vehicles;
    } catch (_) {
      return null;
    }
  }

  Future<List<VehicleBase>?> Recommended(int userId) async {
    String path =
        '${Configuration().apiUrl}/api/Vehicles/recommended/${userId}';
    try {
      http.Response result = await httpHelper.get(path);
      var decoded = json.decode(result.body);

      List<VehicleBase> vehicles = List<VehicleBase>.from(
          decoded.map((model) => VehicleBase.fromJson(model)));
      return vehicles;
    } catch (_) {
      return null;
    }
  }

  Future<VehicleBase?> GetById(int vehicleId) async {
    String path = '${Configuration().apiUrl}/api/Vehicles/filter';
    try {
      http.Response result =
          await httpHelper.post(path, {'vehicleId': vehicleId});
      var decoded = json.decode(result.body);

      List<VehicleBase> vehicles = List<VehicleBase>.from(
          decoded.map((model) => VehicleBase.fromJson(model)));

      return vehicles[0];
    } catch (_) {
      return null;
    }
  }
}
