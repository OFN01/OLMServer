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
            if ($(i).attr("type") == "text" || $(i).attr("type") == undefined || $(i).attr("type") == null || $(i).attr("type") == "") {
                continue;
            }
            if ($(i).val() == null) {
                $(i).attr("value", "");
            } else {
                $(i).attr("value", $(i).val());
            }
        }
    }
    else if ($("input").attr("type") == "text" || $("input").attr("type") == undefined || $("input").attr("type") == null || $("input").attr("type") == "") {
        $("input").attr("value", $("input").val());
    }
    setTimeout(function () { $("*").css("transition", "200ms"); }, 20);
    replaceNavBar();
    setInterval(replaceNavBar, 10);
});

$(document).scroll(function (pos) {
    console.log(pos.X + ":" + pos[1]);
});