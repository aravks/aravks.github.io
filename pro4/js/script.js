$(document).ready(function () {
  var count = 0;
  $('#confirm').click(function () {
    count = count + 1;
    $('.response').show();
    $('#badge').text(count);
    $('#chat').append(
      "<li class='chatList'><strong>" + $('#data').val() + '</strong></li>'
    );
  });

  $('#cancel').click(function () {
    if (!count) {
        count = 0;
    } else {
      count = count - 1;
      $('#chat li:last-child').remove();
    }
  });
});
