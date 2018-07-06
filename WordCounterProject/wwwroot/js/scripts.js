function validateInput() {
  var userWord = $("#word-input").val();
  var userPhrase = $("#phrase-input").val();

  if (userWord !== "" && userPhrase !== "") {
    getWordCount(userWord, userPhrase);
  } else {
    displayError();
  }
}

function displayError() {
  $(".error-message").css("visibility", "visible").text("Invalid input");
}

function getWordCount(word, phrase) {
  $.ajax({
    type: 'GET',
    data: { word: word, phrase: phrase},
    url: '/WordCounter/Results',
    success: function(result) {
      console.log("Success!");
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

    validateInput();
  });
});
