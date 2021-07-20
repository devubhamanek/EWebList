// Data Table
$(document).ready(function() {
	/* $('#materlist, #dbtableone, #dbtabletwo').DataTable( {
		searching: true,
		paging: true,
		ordering: true,
		info: true,
		columnDefs: [
		{ orderable: false, targets: -1 }
		]
	}); */

/* 	$(".glyphicon-eye-open").on("click", function () {
    $(this).toggleClass("glyphicon-eye-close");
    var type = $("#password").attr("type");
    if (type == "text") {
      $("#password").prop('type', 'password');
    }
    else {
      $("#password").prop('type', 'text');
    }
	}); */

	
 /*  $(".create-pass-eye").on("click", function () {
    $(this).toggleClass("glyphicon-eye-close");
    var type = $("#create_password").attr("type");
    if (type == "text") {
      $("#create_password").prop('type', 'password');
    }
    else {
      $("#create_password").prop('type', 'text');
    }
	}); */
	
/* 	$(".create-pass-eye-conf").on("click", function () {
    $(this).toggleClass("glyphicon-eye-close");
    var type = $("#confirm_password").attr("type");
    if (type == "text") {
      $("#confirm_password").prop('type', 'password');
    }
    else {
      $("#confirm_password").prop('type', 'text');
    }
  }); */


} );


$(document).ready(function(){
	$('[data-toggle="tooltip"]').tooltip();

	
});

function equalheight(){
	var maxHeight = 0; 
	$(".task_detail_inner").each(function(){ 
		if ($(this).height() > maxHeight) 
		{ 
			maxHeight = $(this).height(); 
		} }); 
	$(".task_detail_inner").height(maxHeight);

}
$(document).ready(function(){
	equalheight();
});

$(window).resize(function() {
	equalheight();
});



// Returns width of browser viewport
/* function menu_manipulation(){
	var wd = $(window).width();
	
	if(wd > 767 & wd < 992){
		$('.sidebar-mini').addClass('sidebar-collapse');	
	}
}

$(document).ready(function(){
	menu_manipulation();
});

$(window).resize(function() {
	menu_manipulation();
}); */
