
// Changes environment level on acivate page
$(function () {
    $('#EnvironmentLevel').on('change', function () {
        var environmentLevel = $('option:selected', this).val(),
            label = $('#labelEnvironment');

        label.val(environmentLevel);
    });

    $('#uploadButton').on('click', function (e) {
        e.preventDefault();
        $('#fileUploadForm').submit();
    });

    $('#uploadTarget').on('load', function () {
        var response = JSON.parse($(this).contents().find('body pre').text());

        $('#textAreaCompanyIDs').val(response.companyIds);
        $('#textAreaAXPTemplate').val(response.template);
        $('#EnvironmentLevel').val(response.environment);
        $('#labelEnvironment').val(response.environment);



    });

    $('#sendAxpTemplate').on('click', function () {
        var sendButton = $(this);
        alert('here');
        $.ajax({
            url: sendButton.data('target'),
            type: "POST",
            data: {
                companyIds: $('#textAreaCompanyIDs').val(),
                axpTemplate: $('#textAreaAXPTemplate').val(),
                environmentLevel: $('#EnvironmentLevel').val()
            },
            success: function (data) {
                alert('here');
            }
        }).done(function (data) {
            alert(data);
        });
        return false;
    });
});

// Popup Form Windows
$(document).ready(function () {
    $("#btnCreateCompany").click(function () {
        $("#modalCreateCompany").modal();
    });

    $("#btnActivateFeature").click(function () {
        $("#modalActivateFeature").modal()
    });

    $("#btnDeactivateFeature").click(function () {
        $("#modalDeactivateFeature").modal()
    });

    $("#btnActivateProduct").click(function () {
        $("#modalActivateProduct").modal()
    });
});

$('#modalCreateCompany').on('hidden.bs.modal', function () {
    CloseCompany();
});

$('#modalActivateProduct').on('hidden.bs.modal', function () {
    CloseProduct();
});

function CloseCompany() {
    $('#CompanyName').val('');
    $('#Address1').val('');
    $('#Address2').val('');
    $('#City').val('');
    $('#Zip').val('');
    $('#Email').val('');
    $('#Phone').val('');
    $('#Fax').val('');
    $('#create-company-message').empty();
    $('#create-company-message-success').empty();
    $('.field-validation-error').empty();
    $('#Demo').attr('checked', false);
    Select();
    $('#company-types-select option').each(function () {
        $(this).prop('selected', true);
    });
    Deselect();


}

function CloseProduct() {
    $('#CompanyId').val('');
    $('.field-validation-error').empty();
    $('#activate-product-message').empty();
    $('#activate-product-message-success').empty();

}