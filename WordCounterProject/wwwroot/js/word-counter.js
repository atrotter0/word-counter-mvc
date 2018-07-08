var notBlank = false;
var fieldsValid = false;

function onlyLetters(element) {
  if ($(element).val().match(/[^a-zA-Z]/)) {
    var msg = '* Only letters are allowed.';
    displayInputError(element, msg);
    fieldsValid = false;
  } else {
    resetInputError(element);
    fieldsValid = true;
  }
}

function displayInputError(element, msg) {
  $(element).css('border', '1px solid red');
  $('.error-display').css('visibility', 'visible').text(msg);
}

function resetInputError(element) {
  $(element).css('border', '1px solid #ccc');
  $('.error-display').css('visibility', 'hidden').text('');
}

function checkFormFields() {
  if (emptyInput('#word-input') && emptyInput('#phrase-input')) {
    notBlank = true;
  } else {
    notBlank = false;
  }
}

function emptyInput(element) {
  return $(element).val() !== "";
}

function checkInputFlags() {
  (flagValues()) ? enableBtn('#count-word') : disableBtn('#count-word');
}

function flagValues() {
  return (notBlank && fieldsValid);
}

function disableBtn(element) {
  $(element).prop('disabled', 'true').css('border', '1px solid #ccc');
}

function enableBtn(element) {
  $(element).removeAttr('disabled').css('border', '1px solid #00000061');
}

function runValidation() {
  (flagValues()) ? runWordCount() : displayError();
}

function displayError() {
  displayMatches("<div class='well validation-error'><p>Stop trying to break things...</p></div>");
}

function runWordCount() {
  var userWord = $('#word-input').val();
  var userPhrase = $('#phrase-input').val();
  getWordCount(userWord, userPhrase);
}

function getWordCount(word, phrase) {
  if (word == "" || phrase == "") return displayError();

  $.ajax({
    type: 'POST',
    data: { word: word, phrase: phrase},
    url: '/word-counter/' + word + '/' + phrase + '/',
    success: function(result) {
      displayMatches(result);
    },
    error: function(err) {
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function displayMatches(result) {
  removeResultsAndError();
  $('.jumbotron').append(result);
}

function enterKeyPressed(event) {
  return event.keyCode == 13;
}

function removeResultsAndError() {
  $('.validation-error').remove();
  $('.results').remove();
}

$(document).ready(function() {
  disableBtn('#count-word');

  $('#word-input').keyup(function(e) {
    if (enterKeyPressed(e)) return;

    removeResultsAndError();
    onlyLetters(this);
    checkFormFields();
    checkInputFlags();
  });

  $('#phrase-input').keyup(function(e) {
    if (enterKeyPressed(e)) return;

    removeResultsAndError();
    checkFormFields();
    checkInputFlags();
  });

  $('#count-word').click(function(e) {
    e.preventDefault();

    runValidation();
  });
});
