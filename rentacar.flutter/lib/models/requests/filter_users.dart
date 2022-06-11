class FilterUsers {
  int? userId;
  String? firstName;
  String? lastName;
  String? email;

  FilterUsers(this.userId, this.firstName, this.lastName, this.email);

  FilterUsers.fromJson(Map<String, dynamic> filterUsersMap) {
    userId = filterUsersMap['userId'];
    firstName = filterUsersMap['firstName'];
    lastName = filterUsersMap['lastName'];
    email = filterUsersMap['email'];
  }

  Map<String, dynamic> toJson() {
    return {
      'userId': userId,
      'firstName': firstName,
      'lastName': lastName,
      'email': email,
    };
  }
}
