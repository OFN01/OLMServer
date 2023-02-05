var language;
function getLanguage() {
    (localStorage.language == null) ? setLanguage('en') : false;
    $.ajax({
        url: '/api/languages/' + localStorage.language,
        dataType: 'json', async: false, dataType: 'json',
        success: function (lang) { language = lang }
    });
}

function setLanguage(lang) {
    localStorage.language = lang;
    refreshLanguage();
}

function refreshLanguage() {
    if (language == null || language.languageCode != localStorage.language) {
        getLanguage();
    }
    for (var i = 0; i < $('.multiLanguage').length; i++) {
        if ($('.multiLanguage')[i].getAttribute("textid").toString().split(":").length == 2) {
            $($('.multiLanguage')[i]).attr($('.multiLanguage')[i].getAttribute("textid").toString().split(":")[0], language[$('.multiLanguage')[i].getAttribute("textid").toString().split(":")[1]]);
        } else {
            if ($('.multiLanguage')[i].innerHTML != language[$('.multiLanguage')[i].getAttribute("textid")]) {
                $('.multiLanguage')[i].innerHTML = language[$('.multiLanguage')[i].getAttribute("textid")];
            }
        }
    }
}

$(document).ready(function () {
    refreshLanguage();
    setInterval(refreshLanguage, 500);
});