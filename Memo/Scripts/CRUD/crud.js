


function Insert()
{

    
    $.getScript("https://cdn.ckeditor.com/4.16.0/standard/ckeditor.js", function () {
    });
    var h_rno = $('#RNo').val();
    var h_to = $('#To').val();
    var h_date = $('#Date').val();
    var h_type = $('#Type').val();
    var encdate = new Date($.now());
    var h_address = $('#Address').val();
    var h_store = $('#Store').val();
    var h_text = CKEDITOR.instances.editor1.getData();
    var h_amount = $('#Amount').val();
    var h_pesos = $('#Pesos').val();
    var h_reference = $('#Reference').val();
 




    $.ajax({
        type: "POST",
        url: "/Home/InsertFields/",
        datatype: "json",
        contentType: "application/json: charset=utf-8",
        data: JSON.stringify({
            encdate: encdate,
            h_type: h_type,
            h_rno: h_rno,
            h_to: h_to,
            h_date: h_date,
            h_address: h_address,
            h_store: h_store,
            h_text: h_text,
            h_amount: h_amount,
            h_pesos: h_pesos,
            h_reference: h_reference
        }),
        
        success: function (json) {
            alert("success!");
        },
        failure: function (errMsg) {
            alert(errMsg);
        }
        
    })

    console.log(ss);
    
}
function firstValidate() {
    if ($('#Type').val() == "-Select-" || $('#To').val().length === 0 || $('#RNo').val().length === 0 || $('#Date').val().length === 0 || $('#Address').val().length === 0 || $('#Store').val().length === 0) {
        $('#divalert').css('display', 'block');
        
    }
    else if (!($('#Type').val() == "-Select-" || !$('#To').val().length === 0 || !$('#RNo').val().length === 0 || !$('#Date').val().length === 0 || !$('#Address').val().length === 0 || !$('#Store').val().length === 0)) {
        $('#divalert').css('display', 'none');
        $('#showModal').modal('show');
            
    }
}

function secondValidate() {   
    var textdata = CKEDITOR.instances.editor1.getData();
    if ($('.modal').hasClass('in')) {
        if ($('#Amount').val() == " ") {
            alert("Please enter complete details!");
        }
      

        else {

            Insert();
           }
    }
}
        

function convert() {
    var amount = $('#Amount').val();
    $('#Pesos').val(numberToWords(amount));
}

function numberToWords(number) {
    var digit = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
    var elevenSeries = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
    var countingByTens = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
    var shortScale = ['', 'thousand', 'million', 'billion', 'trillion'];
     
    number = number.toString(); number = number.replace(/[\, ]/g, ''); if (number != parseFloat(number)) return 'not a number'; var x = number.indexOf('.'); if (x == -1) x = number.length; if (x > 15) return 'too big'; var n = number.split(''); var str = ''; var sk = 0; for (var i = 0; i < x; i++) { if ((x - i) % 3 == 2) { if (n[i] == '1') { str += elevenSeries[Number(n[i + 1])] + ' '; i++; sk = 1; } else if (n[i] != 0) { str += countingByTens[n[i] - 2] + ' '; sk = 1; } } else if (n[i] != 0) { str += digit[n[i]] + ' '; if ((x - i) % 3 == 0) str += 'hundred '; sk = 1; } if ((x - i) % 3 == 1) { if (sk) str += shortScale[(x - i - 1) / 3] + ' '; sk = 0; } } if (x != number.length) { var y = number.length; str += 'point '; for (var i = x + 1; i < y; i++) str += digit[n[i]] + ' '; } str = str.replace(/\number+/g, ' '); return str.trim() + " pesos ONLY";

}

