$(document).ready(function () {
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
});
