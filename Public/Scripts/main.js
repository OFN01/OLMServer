function replaceNavBar() {
    var navbar = $("nav-bar");
    $(navbar).css("left", ((window.innerWidth - parseFloat($(navbar).css("width"))) / 2) + "px");
}

function search(text) {
    window.location = "/search?q=" + text;
}

$(document).ready(function () {
    if ($("input") === Array) {
        for (var i in $("input")) {
            console.log("a");
            if ($(i).val() == null) {
                console.log("s");
                $(i).attr("value", "");
            } else {
                console.log("d");
                $(i).attr("value", $(i).val());
            }
        }
    }
    else {
        $("input").attr("value", $("input").val());
    }
    setTimeout(function () { $("*").css("transition", "200ms"); }, 20);
    replaceNavBar();
    setInterval(replaceNavBar, 10);
});

$(document).scroll(function (pos) {
    console.log(pos.X + ":" + pos[1]);
});