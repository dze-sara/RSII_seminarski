class FilterUsers {
  int? userId;
  String? firstName;
  String? lastName;
  String? username;

  FilterUsers(this.userId, this.firstName, this.lastName, this.username);

  FilterUsers.fromJson(Map<String, dynamic> filterUsersMap) {
    userId = filterUsersMap['userId'];
    firstName = filterUsersMap['firstName'];
    lastName = filterUsersMap['lastName'];
    username = filterUsersMap['username'];
  }

  Map<String, dynamic> toJson() {
    return {
      'userId': userId,
      'firstName': firstName,
      'lastName': lastName,
      'username': username,
    };
  }
}
