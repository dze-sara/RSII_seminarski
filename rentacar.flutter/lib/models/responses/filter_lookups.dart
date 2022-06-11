import 'package:rentacar/models/location.dart';
import 'package:rentacar/models/make.dart';
import 'package:rentacar/models/model.dart';
import 'package:rentacar/models/vehicleType.dart';

class FilterLookups {
  List<Model>? models;
  List<Make>? makes;
  List<VehicleType>? vehicleTypes;
  List<Location>? locations;

  FilterLookups(this.models, this.makes, this.vehicleTypes, this.locations);

  FilterLookups.fromJson(Map<String, dynamic> lookupsMap) {
    models = lookupsMap['models']
        .map<Model>((json) => Model.fromJson(json))
        .toLlist();

    makes =
        lookupsMap['makes'].map<Make>((json) => Make.fromJson(json)).toLlist();

    vehicleTypes = lookupsMap['vehicleTypes']
        .map<VehicleType>((json) => VehicleType.fromJson(json))
        .toLlist();

    locations = lookupsMap['locations']
        .map<Location>((json) => Location.fromJson(json))
        .toLlist();
  }
}
