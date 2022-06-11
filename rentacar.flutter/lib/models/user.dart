import 'package:flutter_datetime_picker/flutter_datetime_picker.dart';

class User {
  int userId = 0;
  String email = '';
  String firstName = '';
  String lastName = '';
  String password = '';
  DateTime? dateCreated;
  DateTime? dateUpdated;
  int? roleId;

  User(this.userId, this.email, this.firstName, this.lastName, this.password,
      this.dateCreated, this.dateUpdated, this.roleId);

  User.fromJson(Map<String, dynamic> userMap) {
    userId = userMap['userId'] ?? 0;
    roleId = userMap['roleId'] ?? 0;
    email = userMap['email'] ?? 0;
    firstName = userMap['firstName'] ?? '';
    lastName = userMap['lastName'] ?? '';
    password = userMap['password'] ?? '';
    dateCreated = userMap['dateCreated'];
    dateUpdated = userMap['dateUpdated'];
  }

  Map<String, dynamic> toJson() {
    return {
      'userId': userId,
      'roleId': roleId,
      'email': email,
      'firstName': firstName,
      'lastName': lastName,
      'password': password,
      'dateCreated': dateCreated,
      'dateUpdated': dateUpdated
    };
  }
}
