
$(document).ready(function () {
    $("#txtPhone").mask('(000) 000-0000');
    $(function () {
        $("#datepicker").datepicker({
            minDate: 0,
            maxDate: "+1W"
        });

        var d = new Date();
        var chDate = d.getDate();
        var chMonth = d.getMonth() + 1;
        var chYear = d.getFullYear();
        var hour = d.getHours();
        var min = d.getMinutes();

        console.log(chMonth);

        if (chDate < 10)
            chDate = '0' + chDate;

        if (parseInt(chMonth + 1) < 10)
            chMonth = '0' + parseInt(chMonth + 1);
        var currentDate = chMonth + '/' + chDate + '/' + chYear;

        var modhr = (hour + 1);
        if (min < 10)
            var output = modhr + ':0' + min;
        else
            var output = modhr + ':' + min;

        //$("#timepicker").val(output); 
        $("#timepicker").timepicker({
            maxTime: "11:00 PM",
            minTime: output,
            step: "15"
        });

        $("#datepicker").on("change", function () {
            var datePicked = $(this).val();
            console.log("date picked " + datePicked)
            console.log("current date " + currentDate)

            if (datePicked === currentDate) {

                $('#timepicker').timepicker('option', { minTime: output });
            }
            else {
                $('#timepicker').val("");
                $('#timepicker').timepicker('option', { minTime: '10:00' });
            }
        });
    });
});

function validateInput() {
    var time = document.getElementById("timepicker").value;
    var dt = document.getElementById("datepicker").value;
    var name = document.getElementById("txtName").value;
    var phone = document.getElementById("txtPhone").value;

    if (dt.toString() == '') {
        swal("Error", "Please select a Pickup Date", "error");
        return false;
    }
    if (time.toString() == '') {
        swal("Error", "Please select a Pickup Time", "error");
        return false;
    }
    if (name.toString() == '') {
        swal("Error", "Please select a Pickup Name", "error");
        return false;
    }
    if (phone.toString() == '') {
        swal("Error", "Please enter your Phone Number", "error");
        return false;
    }
}