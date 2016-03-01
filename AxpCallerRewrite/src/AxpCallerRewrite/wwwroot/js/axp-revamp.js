//        $('#btnActivateFeatureAction').click(function () {
//            $.post('@Url.Action("ActivateFeature", "Home")', $('#activate-feature-form').serialize(), function (data) {
//                if (data.indexOf("Error") >= 0) {
//                    $('#activate-feature-message').html(data);

//                }
//                else {
//                    $('#activate-feature-partial').html(data);

//                }

//            });
//        });

//$('#btnDeactivateFeatureAction').click(function () {
//    $.post('@Url.Action("DeactivateFeature", "Home")', $('#deactivate-feature-form').serialize(), function (data) {
//        if (data.indexOf("Error") >= 0) {
//            $('#deactivate-feature-message').html(data);

//        }
//        else {
//            $('#deactivate-feature-partial').html(data);

//        }
//    });
//});

var Url = {
    Action: function (action, controller, values) {
        var base = ['', controller, action].join("/"),
            query = [];
        for (var key in values) {
            query.push(key + "=" + values[key]);
        }
        return base + (query.length ? ("?" + query.join("&")) : "");
    }
};

$('#btnCreateCompanyAction').click(function () {
    $('.field-validation-error').empty();
    $('#company-types-select option').each(function () {
        $(this).prop('selected', true);
    });
    var selectedValues = []
    $('#company-types-select option:selected').each(function () {
        selectedValues.push($(this).val());
    })
    $.post(Url.Action("CreateCompany", "Home"), $('#company-form').serialize(), function (data) {
        if (data.indexOf("Error") >= 0) {
            $('#create-company-message').html(data);

        }
        else if (data.indexOf("Company ID") >= 0) {
            $('#create-company-message-success').html(data);

        }
        else {
            $('#create-company-partial').html(data);

            for(var i = 0; i<selectedValues.length; i++)
            {
                $('#company-types-options option[value=' + selectedValues[i] + ']').prop('selected', true);
            }
            Select();
        }
    });
});

$('#btnActivateProductAction').click(function () {
    $('.field-validation-error').empty();
    $.post(Url.Action("ActivateProduct", "Home"), $('#activate-product-form').serialize(), function (data) {
        if (data.indexOf("Error") >= 0) {
            $('#activate-product-message').html(data);

        }
        else if (data.indexOf("Activate Successful") >= 0) {
            $('#activate-product-message-success').html(data);

        }
        else {
            $('#activate-product-partial').html(data);
        }
    });
});

$('#company-close').click(function () {
    CloseCompany();

});

//$('.feature-close').click(function () {
//    $('#CompanyIds').val('');
//    $('#activate-feature-message').empty();
//    $('.field-validation-error').empty();

//});

$('.product-close').click(function () {
    CloseProduct();

});

function Select() {
    var list = $('#company-types-select option');
    $('#company-types-select option').remove();

    $('#company-types-options option:selected').each(function () {
        $(this).prop('selected', false);
        list.push($(this));

    });
    list.sort(function (a, b) {
        return $(a).val() - $(b).val()
    });


    list.each(function () {
        $('#company-types-select').append($(this));
    });

}

function Deselect() {
    var list = $('#company-types-options option');
    $('#company-types-options option').remove();

    $('#company-types-select option:selected').each(function () {
        $(this).prop('selected', false);
        list.push($(this));

    });

    list.sort(function (a, b) {
        return $(a).val() - $(b).val()
    });
    list.each(function () {
        $('#company-types-options').append($(this));
    });

}



function check() {
    if ($('#Country').val() !== 'US') {
        $('#State').attr('disabled', 'disabled');
        $('#State option:selected').prop('selected', false);
    }
    else
        $('#State').removeAttr('disabled');
}