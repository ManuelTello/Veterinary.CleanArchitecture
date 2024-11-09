$(document).ready(function () {
    $("[id^='error-']").map(function (index) {
        const id = $(this).attr("id").replace("error-","");
        if(this.textContent === "") {
            $("input[name="+id+"]").removeClass("is-invalid");
        }else{
            $("input[name="+id+"]").addClass("is-invalid");
        }
    })
})