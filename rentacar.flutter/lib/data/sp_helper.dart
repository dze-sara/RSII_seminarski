import 'package:shared_preferences/shared_preferences.dart';
import 'dart:convert';

import '../models/user.dart';

class SPHelper {
  static late SharedPreferences prefs;

  Future init() async {
    prefs = await SharedPreferences.getInstance();
  }

  Future writeUser(User user) async {
    prefs.setString('user', json.encode(user.toJson()));
  }

  User getUser() {
    return User.fromJson(json.decode(prefs.getString('user') ?? ''));
  }
}
