$(function () {
	//超链接按钮处理
	$(".btnText").click(function () {
		var $this = $(this);
		var href = $this.attr("href");
		if (href) {
			window.location = href;
		}
	});

	$("#roller").click(function () {
		var className = $(".sidebar").attr("class"),
			a = className.split(" "),
			len = className.split(" ").length;
		if (a[len - 1] == "hide") {
			$(".sidebar").removeClass("hide");
			$(".wrapper").css("background", "url(/images/admin/bg_lefter.jpg) 150px 0 repeat-y");
			$(".container").css({
				"background": "url(/images/admin/bg_lefter.jpg) 150px 0 repeat-y",
				"margin-left": "-160px"
			});
			$(".content").css("margin-left", "160px");
			$(this).css("left", "150px");
		} else {
			$(".sidebar").addClass("hide");
			$(".wrapper").css("background", "url(/images/admin/bg_lefter.jpg) 0 0 repeat-y");
			$(".container").css({
				"background": "url(/images/admin/bg_lefter.jpg) 0 0 repeat-y",
				"margin-left": "-10px"
			});
			$(".content").css("margin-left", "10px");
			$(this).css("left", "0");
		}
	});
});