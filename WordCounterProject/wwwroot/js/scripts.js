function validateInput() {
  // use regex to parse input
  getWordCount(userWord, userPhrase);
}

function getWordCount(word, phrase) {
  $.ajax({
    type: 'GET',
    data: { word: word, phrase: phrase},
    url: '/WordCounter/Results',
    success: function(result) {
      displayResult(".jumbotron");
    },
    error: function(err) {
      console.log("Error, not working: " + JSON.stringify(err));
    }
  });
}

function displayResult(element) {
  $(element).append(result);
}

$(document).ready(function() {
  $("#word-count").click(function(e) {
    e.preventDefault();

    var userWord = $("#word-input").val();
    var userPhrase = $("#phrase-input").val();
    validateInput();
  });
});
