class Review {
  int reviewId = 0;
  String content = '';
  int score = 0;
  int modelId = 0;
  int userId = 0;
  String authorName = '';
  int bookingId = 0;

  Review(this.reviewId, this.content, this.score, this.modelId, this.userId,
      this.authorName, this.bookingId);

  Review.fromJson(Map<String, dynamic> reviewMap) {
    reviewId = reviewMap['reviewId'];
    content = reviewMap['content'];
    score = reviewMap['score'];
    modelId = reviewMap['modelId'];
    userId = reviewMap['userId'];
    authorName = reviewMap['authorName'];
    bookingId = reviewMap['bookingId'];
  }

  Map<String, dynamic> toJson() {
    return {
      'reviewId': reviewId,
      'content': content,
      'score': score,
      'modelId': modelId,
      'userId': userId,
      'authorName': authorName,
      'bookingId': bookingId
    };
  }
}
