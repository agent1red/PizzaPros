

var exp = document.getElementsByClassName('exp1');
x = document.getElementsByClassName("timer");
countdown();
function countdown() {
    var now = new Date();
    for (i = 0; i < exp.length; i++) {
        var e = new Date(exp[i].innerHTML);
        var distance = e - now;
        var timeDiff = e.getTime() - now.getTime();
        var seconds = Math.floor(timeDiff / 1000);
        var minutes = Math.floor(seconds / 60);
        var hours = Math.floor(minutes / 60);
        var days = Math.floor(hours / 24);
        hours %= 24;
        minutes %= 60;
        seconds %= 60;

        if (distance < 0) {
            clearInterval(countdown);
            x[i].className = "col-12 timer text-center text-wrap font-weight-bold mb-4"
            x[i].innerHTML = "<span style='color: red;'>Time Expired </span>"

        } else {
            x[i].innerHTML = days + "d " + hours + "h " + minutes + "m " + seconds + "s";
        }
    }

}
setInterval(function () { countdown();; }, 1000);