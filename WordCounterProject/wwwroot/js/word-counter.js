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
  if (notBlank && fieldsValid) {
    enableBtn('#count-word');
  } else {
    disableBtn('#count-word');
  }
}

function disableBtn(element) {
  $(element).prop('disabled', 'true').css('border', '1px solid #ccc');
}

function enableBtn(element) {
  $(element).removeAttr('disabled').css('border', '1px solid #00000061');
}

function getWordCount(word, phrase) {
  $.ajax({
    type: 'GET',
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
  $('.jumbotron').append(result);
}

function removeResults() {
  $('.results').remove();
}

$(document).ready(function() {
  disableBtn('#count-word');

  $('#word-input').keyup(function() {
    removeResults();
    onlyLetters(this);
    checkFormFields();
    checkInputFlags();
  });

  $('#phrase-input').keyup(function() {
    removeResults();
    checkFormFields();
    checkInputFlags();
  });

  $('#count-word').click(function(e) {
    e.preventDefault();

    var userWord = $('#word-input').val();
    var userPhrase = $('#phrase-input').val();
    getWordCount(userWord, userPhrase);
  });
});
