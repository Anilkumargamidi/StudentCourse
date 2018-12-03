function Test() {

    $.ajax(
        {
            type: 'POST',
            url: $("#hdncururl").val(),
            contentType: 'text/html',
            success: function (data) {

                $("#ddlcourse").html('');

                for (var i = 0; i <= data.length - 1; i++) {

                    $("#ddlcourse").append('<option value="' + data[i].CourseId + '">' + data[i].CourseName + '</option>');
                }


            },
            error: function (e) {
                alert(e);
            }
        });
    $.ajax(
        {
            type: 'POST',
            url: $("#hdnStdurl").val(),
            contentType: 'text/html',
            success: function (data) {

                $("#ddlstd").html('');

                for (var i = 0; i <= data.length - 1; i++) {

                    $("#ddlstd").append('<option value="' + data[i].StudentId + '">' + data[i].FirstName + '</option>');
                }


            },
            error: function (e) {
                alert(e);
            }
        });
}

function Addlink() {

    var studentID = $("#ddlstd").val();
    var CourseId = $("#ddlcourse").val();

    var obj = {
        "StudentId": studentID,
        "CourseId": CourseId
    };


    $.ajax(
        {
            type: 'POST',
            url: "/Student/AddSC",
            contentType: 'application/json',
            data: JSON.stringify({ "obj": obj }),
            success: function (data) {

                if (data == "already") {

                    alert("Course already taken by student.");
                }
                else {

                    alert("Student and course linked succesfully.");

                    window.location.href = "/Student/Index";
                }


            },
            error: function (e) {
                alert(e);
            }
        });


}
//function Addlink() {

//    var studentID = $("#ddlstd").val();
//    var CourseId = $("#ddlcourse").val();

//    var obj = {
//        "StudentId": studentID,
//        "CourseId": CourseId
//    };


//    $.ajax(
//        {
//            type: 'POST',
//            url: "/Student/AddSC",
//            contentType: 'application/json',
//            data: JSON.stringify({ "obj": obj }),
//            success: function (data) {

//                alert("Student and course linked succesfully.");

//                window.location.href = "/Student/Index";


//            },
//            error: function (e) {
//                alert(e);
//            }
//        });


//}




