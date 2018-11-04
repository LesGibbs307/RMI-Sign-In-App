var timedInput = function () {
    var getBtn = setTimeout(toggleBtn, 100);
};

var toggleBtn = function () {
    $(".btn-container").children().toggleClass("hidden");
};
(function ($) {
	var ajaxRequest = function (path, data, success, options) {

		options = $.extend({
			url: '/visitor/' + path,
			type: 'POST',
			data: JSON.stringify(data || {}),
			contentType: 'application/json',
			dataType: 'json',
			success: success,
			error: function () {
                alert('Something went wrong.');
			}
		}, options);
        $.ajax(options);
	};

	$(document).ready(function () {
		var id;

        window.formSuccess = function (resp) {
            window.location.replace("../thank-you/");
		};

        window.formFails = function (resp) {
            var requiredInputs = $(".required");
            for (var i = requiredInputs.length; i > 0; i--) {
                var j = i - 1;
                var thisInput = requiredInputs.eq(j);
                var inputVal = thisInput.val();

                if (inputVal == "" || inputVal == "Who are you visiting?") {
                    thisInput.addClass("input-validation-error");
                }                
            }
            alert("Please fill out required inputs");
            toggleBtn();
		};
	}).on('click', '.btn-cls', function () {
		var $this = $(this);
		var signIn = $('.SignIn');
		var signOut = $('.SignOut');
		var signInBtn = $(".signInBtn");
		var signInForm = $(".signInForm");
		var signOutInfo = $('.SignOutInfo');
        var headerText = $(".top h2");
        var popUp = $(".pop-up");
		var overlay = $(".overlay");
		var visitorList = $("#signout-list li");
		var popSignoutBtn = $(".pop-signout");
		var thisId = $this.attr('id');
	

		if ($this.is(signIn)) {
			signInBtn.hide();
            signInForm.removeClass("hidden");
			headerText.html("Who are you visiting today?");
        } else if ($this.is(signOut)) {
			signInBtn.hide();
			$.get('/visitor/signoutlist/', function (data) {
				signOutInfo.html(data);
            });
            signOutInfo.removeClass("hidden");
			headerText.html("Thank you for stopping by today!");
        } else if ($this.is(visitorList) || $this.is(popSignoutBtn)) {
			if (thisId != undefined) {
				id = thisId;
			} 

			if ($this.is(visitorList)) {
				popUp.removeClass("hidden");
				overlay.removeClass("hidden");
				return;
			} else {
				$("#signout-list > li:nth-child(odd)").css({ "background": "#5d83a7", "color": "#ccc" }).prop("disabled", true);
				$("#signout-list > li:nth-child(even)").css({ "background": "#ccc", "color": "#5d83a7" }).prop("disabled", true);
			}
            ajaxRequest("signout/", { id: id }, function (resp) {
				if (resp.Success) {
					$this.remove();
					popUp.addClass("hidden");
					overlay.addClass("hidden");
                    setTimeout(function () {
                        signOutInfo.empty().addClass("hidden");
                        signInForm.addClass('hidden');
						signInBtn.show();
						headerText.html("Welcome to Response Mine Interactive");
					}, 100);
				} else {
					alert('An error occured');
				}
			});
		}
	}).on('click', '.btn-cls', function () {
		var popUp = $(".pop-up");
		var overlay = $(".overlay");
		var $this = $(this);
		var backBtn = $(".back-btn");

		if ($this.is(overlay)) {
			popUp.addClass("hidden");
			overlay.addClass("hidden");
			backBtn.removeClass("hidden");
		}
	});
})(jQuery);