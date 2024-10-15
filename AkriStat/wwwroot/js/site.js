function goBack() {
    let previousUrl = document.referrer;
    if (previousUrl.includes('akristat') || previousUrl.includes('localhost')) {
        window.history.back();
    }
}

function setBackButton(title, path) {
    $('#backNav > a').html('<i class="fas fa-arrow-left" style="padding-right:10px"></i>' + title);
    $('#backNav > a').click(function () { window.location.href = path });
    $('#backNav').css('display', 'block');
}

let defaultSelectSettings = {
    style: 'selectpicker-white',
    size: 10,
    dropupAuto: false
}