$(document).ready(function () {
  /* ----------------------- */
  /* Add/Remove team members */
  /* ----------------------- */

  var count = 0;
  $('#confirm').click(function () {
    count = count + 1;
    $('#badge').text(count);
    $('.response').show();
    $('#chat').append(
      "<li class='chatList'><strong>" + $('#data').val() + '</strong></li>'
    );
  });

  $('#cancel').click(function () {
    if (count == 0) {
      count = 0;
    } else {
      count = count - 1;
      $('#badge').text(count);
      $('#chat li:last-child').remove();
    }
  });

  /* ----------------------- */
  /*   Real time validation  */
  /* ----------------------- */

  var name = /^[a-zA-z ]{2,20}$/;
  $('#data').on('keypress keydown keyup', function () {
    if ($('#data').val().match(name)) {
      $('.emsg').addClass('hidden');
    } else {
      $('.emsg').removeClass('hidden');
    }
  });

  var email = /@/;
  $('#email').on('keypress keydown keyup', function () {
    if (!email.test($('#email').val())) {
      $('.emsg1').removeClass('hidden');
    } else {
      $('.emsg1').addClass('hidden');
    }
  });

  var phone = /^[0-9]{10}$/;
  $('#phone').on('keypress keydown keyup', function () {
    if ($('#phone').val().match(phone)) {
      $('.emsg2').addClass('hidden');
    } else {
      $('.emsg2').removeClass('hidden');
    }
  });
});
