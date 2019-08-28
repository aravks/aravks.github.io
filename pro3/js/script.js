$(document).ready(function() {

    /* Mobile nav */
    $('.js--mob-nav').click(function(){
        
        let nav = $('.js--main-nav');
        
        nav.slideToggle(200);
        
    });

    /* Navigation scroll */
    $(function() {
        $('a[href*="#"]:not([href="#"])').click(function() {
          if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
            if (target.length) {
              $('html, body').animate({
                scrollTop: target.offset().top
              }, 1000);
              return false;
            }
          }
        });
      });

} );