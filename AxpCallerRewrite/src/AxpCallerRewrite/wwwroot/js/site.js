
// Changes environment level on acivate page
$(function () {
    $('#EnvironmentLevel').on('change', function () {
        var environmentLevel = $('option:selected', this).val(),
            label = $('#labelEnvironment');

        label.val(environmentLevel);
    });

    
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
    function FileSelectHandler(e) {

        // cancel event and hover styling
        FileDragHover(e);

        // fetch FileList object
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
        debugger;
        // Submit File JQUERY
        $("#fileForm").submit(function(event) {
            alert("Handler for .submit() called.");
        });

        function ParseFile(file) {

            $("#fileForm").submit(function (event) {
                alert("Handler for .submit() called.");
                event.preventDefault();
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




