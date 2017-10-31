$(document).ready(function() {
   
    $('#add-number').click(function(e) {
        console.log("test");
        e.preventDefault();
        $('<label for="newNumber">To:</label><input type="text" name="formNum" /> <br/>').appendTo('#output');

    });

    $('.show-messages').click(function() {
        var number = $(this).siblings().children('.contact-number').text();
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

    $('.create-contact-form').submit(function(e) {
    console.log("TEST");
        e.preventDefault();
        $.ajax({
            type:'POST',
            data: $(this).serialize(),
            dataType: 'json',
            url: '/Contacts/Create',
            success: function(result) {
            var validation = `New contact confirmation code is ` + result;
            $('#val-output').html(validation)
            }
        });
    });

});