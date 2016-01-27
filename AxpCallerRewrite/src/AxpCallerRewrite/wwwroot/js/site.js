// Write your Javascript code.
$('#form1').submit(function(){
    var formdata = ''; //add the form data here
    $.ajax({
        url: "foo.php",
        type: "POST",
        data: formdata,
        success : function(filename){
            //php script returns filename
            //we apply this filename as the value for the hidden field in form2
            $('#form2 #filename').val(filename);
        }
    });
}); 
