import '../data/configuration.dart';
import '../data/http_helper.dart';
import '../data/sp_helper.dart';
import 'package:flutter/material.dart';
import 'dart:convert';

import 'package:http/http.dart' as http;

import '../models/review.dart';

class ReviewService {
  final SPHelper helper = SPHelper();
  final HttpHelper httpHelper = HttpHelper();

  ReviewService() {
    helper.init();
  }

  Future<List<Review>?> GetReview(int modelId) async {
    String path = '${Configuration().apiUrl}/api/Reviews/${modelId}';
    try {
      http.Response result = await httpHelper.get(path);

      var decoded = json.decode(result.body);

      List<Review> reviews =
          List<Review>.from(decoded.map((model) => Review.fromJson(model)));
      return reviews;
    } catch (_) {
      return null;
    }
  }
}
