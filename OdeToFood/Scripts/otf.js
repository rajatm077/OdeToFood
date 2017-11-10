//$(document).ready(function () {
//    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);    
//});

$(function () {
    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);
    $(".main-content").on("click", ".pagedList a", getPage);
});

var getPage = function () {
    var a = $(this);
      
    var options = {
        url: a.attr("href"),
        type: "get"
    };

    $.ajax(options).done(function (data) {
        var target = a.parents("div.pagedLists").attr("data-otf-target");
        $(target).replaceWith(data);
    });

    return false;
};

var ajaxFormSubmit = function () {
    var form = $(this);

    var options = {
        url: form.attr("action"),
        method: form.attr("method"),
        data: form.serialize()            
    };

    $.ajax(options).done(function (data) {
        var target = form.attr("data-otf-target");
        $(target).replaceWith(data);
    });

    //To prevent the default action of loading the whole page again.
    return false;    
};

var createAutocomplete = function () {
    var input = $(this);

    var options = {
        source: input.attr("data-otf-autocomplete")
    };

    input.autocomplete(options);
};
