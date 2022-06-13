import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';

class User {
  int userId = 0;
  String username = '';
  String firstName = '';
  String lastName = '';
  String password = '';
  DateTime? dateCreated;
  DateTime? dateUpdated;
  int? roleId;
  String? token;

  User(this.userId, this.username, this.firstName, this.lastName, this.password,
      this.dateCreated, this.dateUpdated, this.roleId, this.token);

  User.fromJson(Map<String, dynamic> userMap) {
    userId = userMap['userId'] ?? 0;
    roleId = userMap['roleId'] ?? 0;
    username = userMap['username'] ?? '';
    firstName = userMap['firstName'] ?? '';
    lastName = userMap['lastName'] ?? '';
    password = userMap['password'] ?? '';
    dateCreated = DateTime.parse(userMap['dateCreated']);
    dateUpdated = DateTime.parse(userMap['dateUpdated']);
    token = userMap['token'];
  }

  Map<String, dynamic> toJson() {
    return {
      'userId': userId,
      'roleId': roleId,
      'username': username,
      'firstName': firstName,
      'lastName': lastName,
      'password': password,
      'dateCreated': dateCreated?.toIso8601String(),
      'dateUpdated': dateUpdated?.toIso8601String(),
      'token': token
    };
  }
}
