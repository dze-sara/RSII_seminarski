class CardInfo {
  String? cardNumber = '';
  String? expiryDate = '';
  String? cVV = '';

  CardInfo(this.cardNumber, this.expiryDate, this.cVV);

  CardInfo.fromJson(Map<String, dynamic>? reviewMap) {
    cardNumber = reviewMap?['cardNumber'];
    expiryDate = reviewMap?['expiryDate'];
    cVV = reviewMap?['cVV'];
  }

  Map<String, dynamic> toJson() {
    return {
      'cardNumber': cardNumber,
      'expiryDate': expiryDate,
      'cVV': cVV,
    };
  }
}
