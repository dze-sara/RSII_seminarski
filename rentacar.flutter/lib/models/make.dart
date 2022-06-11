class Make {
  int makeId = 0;
  String makeName = '';
  String makeDescription = '';

  Make.fromJson(Map<String, dynamic> makeMap) {
    makeId = makeMap['makeId'] ?? 0;
    makeName = makeMap['makeName'] ?? '';
    makeDescription = makeMap['makeDescription'] ?? '';
  }
}
