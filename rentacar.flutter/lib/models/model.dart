class Model {
  int modelId = 0;
  String modelName = '';
  String modelDescription = '';
  String year = '';
  int noOfSeats = 0;
  int makeId = 0;

  Model.fromJson(Map<String, dynamic> modelMap) {
    modelId = modelMap['modelId'] ?? 0;
    modelName = modelMap['modelName'] ?? '';
    modelDescription = modelMap['modelDescription'] ?? '';
    year = modelMap['year'] ?? '';
    makeId = modelMap['makeId'] ?? 0;
    noOfSeats = modelMap['noOfSeats'] ?? 0;
  }
}
