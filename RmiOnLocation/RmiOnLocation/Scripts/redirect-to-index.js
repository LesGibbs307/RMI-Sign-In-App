var startCountdown = function (seconds, elem) {
    var content = $(elem).text("Will go back to home page in " + seconds + " seconds.");

    if (seconds == 0) {
        clearTimeout(timer);
        window.location.replace("../");
    }

    seconds--;
    //var timer = setTimeout(startCountdown, 1000);
    var timer = setTimeout('startCountdown('+seconds+',"'+elem+'")', 1000);
};