import 'package:rentacar/data/configuration.dart';
import 'package:rentacar/data/sp_helper.dart';

import '../models/user.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class UserService {
  final SPHelper helper = SPHelper();

  UserService() {
    helper.init();
  }

  Future<User> Register(User user) async {
    String path = '${Configuration().apiUrl}/api/Users';

    http.Response result =
        await http.post(Uri.parse('$path/register'), body: user);
    User registeredUser = User.fromJson(json.decode(result.body));

    if (registeredUser != null && registeredUser.userId != 0) {
      helper.writeUser(registeredUser);
    }

    return registeredUser;
  }

  Future<User?> SignIn(String username, String password) async {
    String path = '${Configuration().apiUrl}/api/Users/login';

    try {
      http.Response result = await http.post(Uri.parse(path),
          headers: <String, String>{
            'Content-Type': 'application/json; charset=UTF-8',
          },
          body: jsonEncode(
              <String, String>{'email': username, 'password': password}));

      User signedUser = User.fromJson(json.decode(result.body));

      if (signedUser != null && signedUser.userId != 0) {
        helper.writeUser(signedUser);
        return signedUser;
      } else {
        return null;
      }
    } catch (_) {
      return null;
    }
  }
}
