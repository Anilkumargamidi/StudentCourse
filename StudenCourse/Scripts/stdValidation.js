//cdn.jsdelivr.net/jquery.validation/1.16.0/jquery.validate.min.js

$('form[id="stdForm"]').validate({
    rules: {
        FirstName: {
            required: true

        },
        SurName: {
            required: true
        }
    },
    messages: {
        FirstName: {
            required: "First Name is Mandatory."

        },
        SurName: {
            required: "Surname is mandatory."
        }
    },
    //},

    errorPlacement: function (error, element) {
        error.insertAfter(element);
        
    },
    //},
    submitHandler: function (form) {
        addstd($(form).serialize());
    }
});


function addstd(data) {

    var obj = {
        "FirstName": $("#FirstName").val(),
        "SurName": $("#SurName").val(),
        "Email": $("#Email").val(),
        "IDNumber": $("#IDNumber").val()
    };

    $.ajax(
        {
            type: 'POST',
            url: '/Student/Student',
            contentType: 'application/json',
            data: JSON.stringify({ "objstu": obj }),
            success: function (data) {

                alert("Student added succesfully.");

                $('form[id="stdForm"]')[0].reset();


            },
            error: function (e) {
                alert(e);
            }
        });

}