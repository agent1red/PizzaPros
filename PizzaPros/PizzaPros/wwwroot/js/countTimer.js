

var exp = document.getElementsByClassName('exp1');
x = document.getElementsByClassName("timer");
var progressTimer = document.getElementsByClassName("progressTimer");
var progress = document.getElementsByClassName("progress");
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
            x[i].className = "col-12 timer text-center text-wrap font-weight-bold mb-4";
            x[i].innerHTML = "<span style='color: red;'>Time Expired </span>";
            progress[i].style.visibility = "hidden";

        } else {
            clearInterval(countdown);
            if (minutes == 0) {
                x[i].innerHTML = seconds + "s";
            } else if (hours == 0) {
                progressTimer[i].style.cssText = "width: 25%";
                progressTimer[i].classList.toggle("bg-danger");
                x[i].innerHTML = minutes + "m " + seconds + "s";
            } else if (days == 0) {
                progressTimer[i].style.cssText = "width: 50%";
                progressTimer[i].classList.add("bg-success");
                progressTimer[i].classList.toggle("bg-warning");
                x[i].innerHTML = hours + "h " + minutes + "m " + seconds + "s";
            } else {
                progressTimer[i].style.cssText = "width: 100%";
                progressTimer[i].classList.add("bg-success");
                x[i].innerHTML = days + "d " + hours + "h " + minutes + "m " + seconds + "s";
            }
            
            
        }

      
    }

}
setInterval(function () { countdown(); }, 1000);

