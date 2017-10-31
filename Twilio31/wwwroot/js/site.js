$(document).ready(function() {
   
    $('#add-number').click(function(e) {
        console.log("test");
        e.preventDefault();
        $('<label for="newNumber">To:</label><input type="text" name="formNum" /> <br/>').appendTo('#output');

    });

    $('.contact-well').click(function(e) {
        e.preventDefault();
        var number = $(this).find('.contact-number').text();
        console.log(number);
        $.ajax({
            type: 'GET',
            data: {number},
            url: '/Contacts/ContactMessagePartial',
            success: function(result) {
                $('.output').html(result)
            }
        });
    });
});