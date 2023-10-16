function callme() {
  if (document.getElementById('showme').innerHTML == 'Clicked') {
    document.getElementById('showme').innerHTML = 'Not Clicked';
  } else {
    document.getElementById('showme').innerHTML = 'Clicked';
  }
  console.log(document.getElementById('showme').innerHTML);
}
