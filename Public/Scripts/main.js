function replaceNavBar() {
    var navbar = $("nav-bar");
    $(navbar).css("left", ((window.innerWidth - parseFloat($(navbar).css("width"))) / 2) + "px");
}

$(document).ready(function () {
    replaceNavBar();
    setInterval(replaceNavBar, 10);
});

$(document).scroll(function (pos) {
    console.log(pos.X + ":" + pos[1]);
});