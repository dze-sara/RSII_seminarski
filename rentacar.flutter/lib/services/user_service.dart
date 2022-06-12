import 'package:rentacar/data/configuration.dart';
import 'package:rentacar/data/http_helper.dart';
import 'package:rentacar/data/sp_helper.dart';

import '../models/user.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class UserService {
  final SPHelper helper = SPHelper();
  final HttpHelper httpHelper = HttpHelper();

  UserService() {
    helper.init();
  }

  Future<User?> Register(User user) async {
    String path = '${Configuration().apiUrl}/api/Users/register';
    try {
      http.Response result = await httpHelper.post(path, user);

      User registeredUser = User.fromJson(json.decode(result.body));

      if (registeredUser != null && registeredUser.userId != 0) {
        helper.writeUser(registeredUser);
        httpHelper.saveToken(registeredUser.token ?? '');
        return registeredUser;
      } else {
        return null;
      }
    } catch (_) {
      return null;
    }
  }

  Future<User?> SignIn(String username, String password) async {
    String path = '${Configuration().apiUrl}/api/Users/login';
    try {
      http.Response result = await httpHelper
          .post(path, {'username': username, 'password': password});

      User signedUser = User.fromJson(json.decode(result.body));

      if (signedUser != null && signedUser.userId != 0) {
        helper.writeUser(signedUser);
        httpHelper.saveToken(signedUser.token ?? '');
        return signedUser;
      } else {
        return null;
      }
    } catch (_) {
      return null;
    }
  }
}
