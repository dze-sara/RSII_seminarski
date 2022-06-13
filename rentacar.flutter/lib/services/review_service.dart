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

  Future<List<Review>?> getReview(int modelId) async {
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

  Future<Review?> addReview(Review review) async {
    String path = '${Configuration().apiUrl}/api/Reviews';
    try {
      http.Response result = await httpHelper.post(path, review);

      var decoded = json.decode(result.body);

      Review reviews = Review.fromJson(decoded);
      return reviews;
    } catch (_) {
      return null;
    }
  }
}
