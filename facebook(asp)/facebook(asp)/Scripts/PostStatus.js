
function chckd(id,idstu){
    var x = document.getElementById(id);
    if (x.checked == true) {
        makeprivet(x.value);
    }else if(x.checked == false){
        makepublic(x.value);
    }
}

function makeprivet(id,idstu,stust){
    var x = document.getElementById(id);
    var fa = new FormData();
    fa.append("idpost", x.id);
    fa.append("role", stust);
    fa.append("idstu", idstu)
    $.ajax({
        url: 'https://localhost:44378/api/PostRole',
        type: 'POST',
        data: fa,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data);
            x.value = "";
            console.log(x.value);
        }
    });
}

function makepublic(id, idstu,stust){
    var x = document.getElementById(id);
    var fa = new FormData();
    fa.append("idpost", x.id);
    fa.append("role", stust);
    fa.append("idstu", idstu)
    $.ajax({
        url: 'https://localhost:44378/api/PostRole',
        type: 'DELETE',
        data: fa,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data);
            x.value = "";
            console.log(x.value);
        }
    });
}