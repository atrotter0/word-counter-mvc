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
    url: '/word-counter/' + word + '/' + phrase + '/',
    success: function(result) {
      console.log("Success!");
      displayResult('.jumbotron', '.container', result);
    },
    error: function(err) {
      console.log("Error, not working: " + JSON.stringify(err));
    }
  });
}

function displayResult(removeElement, appendTo, result) {
  $(removeElement).remove();
  $(appendTo).append(result);
}

$(document).ready(function() {
  $("#count-word").click(function(e) {
    e.preventDefault();

    validateInput();
  });
});
