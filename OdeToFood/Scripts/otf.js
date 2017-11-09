//$(document).ready(function () {
//    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);    
//});

$(function () {
    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
});

var ajaxFormSubmit = function () {
    var form = $(this);

    var options = {
        url: form.attr("action"),
        method: form.attr("method"),
        data: form.serialize()            
    };

    $.ajax(options).done(function (data) {
        var target = form.attr("data-otf-target");
        $(target).html(data);        
    });

    //To prevent the default action of loading the whole page again.
    return false;
    
};
