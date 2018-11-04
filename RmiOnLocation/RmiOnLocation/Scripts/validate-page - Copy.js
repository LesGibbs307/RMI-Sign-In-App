$(document).ready(function () {
    var btn = $('.btn-cls');
    var form = $("form");
    var visitorNames = $(".SignOutInfo li");
    var signInSignOut = $(".signInBtn");
    var signInForm = $(".signInForm");
    var signOut = $(".SignOutInfo");
    var req = $(".required");

    form.validate();

    $(btn).on("click", function () {
    	var $this = $(this).val();

    	if ($this == "Sign In") {
    		$(signInSignOut).hide();
    		$(signInForm).show();
    		return;
    	}
    	if ($this == "Sign Out") {
    		$(signInSignOut).hide();
    		$(signOut).show();
    		return;
    	}
    	if ($this == "Submit") {
    		for (var i in req) {
    			if (req[i].value == "") {
    				$(req).addClass('input-validation-error');
    				alert("Please Enter a Value");
      				return;
    			}
    		}

    		$.ajax({
    			type: 'POST',
    			url: form.attr('data'),
    			async: false,
    			data: form.serialize(),
    			success: function (response) {
    				var signOutUl = $(signOut);
    				var signOutLi = $($("<li/>")).appendTo(signOutUl);
    				var fname = "FirstName";
    				var lname = "LastName";

    				for (var i in response) {
    					if (i == fname || i == lname) {
    						var name = i == fname ? response[fname] : response[lname];
    						signOutLi.append($('<span/>').text(name).append(response[name]));
    					}
    				}
    				window.setTimeout(function () {
    					e.preventDefault();
    					alert();
    					$(signInForm).hide();
    					$(signInSignOut).show();
    				}, 3000);
    			},
    			error: function () {
    				//
    			}
    		});
    	}
    });

    $(visitorNames).on("click", function () {
    	$(this).remove();
    	setTimeout(function () {
    		$(signOut).hide();
    		$(signInSignOut).show();
    	}, 3000)
    });
});