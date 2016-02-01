
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
        alert(response.template);


    });

    //$('#fileUploadForm').submit(function () {
    //    var fileUploadForm = $(this);
    //    $.ajax({
    //        url: fileUploadForm.attr('action'),
    //        type: "POST",
    //        data: fileUploadForm.serialize(),
    //        success: function (data) {
    //            alert('here');
    //        }
    //    }).done(function(data) {
    //        alert(data);
    //    });
    //    return false;
    //});
});


// Begin DRAG AND DROP


// Get ElementByID
function $id(id) {
    return document.getElementById(id);
}

// output information
function Output(msg) {
    var m = $id("messages");
    m.innerHTML = msg + m.innerHTML;
}

// We’ll now check if the File API is available and call an Init() function:
// call initialization file
if (window.File && window.FileList && window.FileReader) {
    Init();
}

//
// initialize
function Init() {


    var filedrag = $id("filedrag");


    // is XHR2 available?
    var xhr = new XMLHttpRequest();
    if (xhr.upload) {

        // file drop
        filedrag.addEventListener("dragover", FileDragHover, false);
        filedrag.addEventListener("dragleave", FileDragHover, false);
        filedrag.addEventListener("drop", FileSelectHandler, false);
        filedrag.style.display = "block";

    }

    // file drag hover
    function FileDragHover(e) {
        e.stopPropagation();
        e.preventDefault();
        e.target.className = (e.type == "dragover" ? "hover" : "");
    }

    // file selection
    debugger;
    function FileSelectHandler(e) {

        // cancel event and hover styling
        FileDragHover(e);

        // fetch FileList object
        debugger;
        var files = e.target.files || e.dataTransfer.files;

        // process all File objects
        for (var i = 0, f; f = files[i]; i++) {
            ParseFile(f);
        }

        // Sending File to C#
        //$.ajax({
        //    type: 'POST',
        //    data: JSON.stringify(file),
        //    url: '/Home/ParseData',
        //    contentType: 'application/json',
        //    dataType: 'json',
        //    success: alert('Youhou'),
        //    error: alert('not good')
        //});

        var $whatsDropped = $('#filedrag');
        $whatsDropped.dragDrop(true);
      

        debugger;
        $.ajax({
            type: "POST",
            url: "ParseHelper/ParseData", // the method we are calling
            contentType: "application/json; charset=utf-8",
            data: {filename: file.name, fileType: file.type, fileSize: file.size},
            dataType: "json",
            success: function (result) {
                alert('Yay! It worked!');
                // Or if you are returning something
                alert('I returned... ' + result.WhateverIsReturning);                    
            },
            error: function (result) { 
                alert('Oh no :(');
            }
        });


        function ParseFile(file) {

            debugger;
            $.ajax({
                type: "POST",
                url: "HomeController/Index", // the method we are calling
                contentType: "application/json; charset=utf-8",
                data: { fileName: file.name, fileType: file.type, fileSize: file.size},
                dataType: "json",
                success: function(result) {
                    alert('Yay! It worked!');
                    // Or if you are returning something
                    alert('I returned... ' + result.WhateverIsReturning);
                },
                error: function(result) {
                    alert('Oh no :(');
                }
            });

            Output(
                "<p>File information: <strong>" + file.name +
                "</strong> type: <strong>" + file.type +
                "</strong> size: <strong>" + file.size +
                "</strong> bytes</p>"
            );

        }
}
        // Send file to C# object
    }




