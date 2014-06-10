var webpart_range = { x: 0, y: 0 }; //鼠标在被拖元素偏移量
var webpart_lastPos = { x: 0, y: 0, x1: 0, y1: 0 }; //拖拽对象的四个坐标 
var webpart_tarPos = { x: 0, y: 0, x1: 0, y1: 0 }; //目标元素对象的坐标初始化 
var webpart_theDiv = null, webpart_move = false; //拖拽对象 拖拽状态
var webpart_drag = false;
var webpart_tempDiv = null; //占位DIV
var webpart_tarDiv = null; //目标位置DIV
var webpart_title = $("<div class='title'>可拖动</div>");
function bindWebpart() {
	$(".webpart .part").unbind("mouseenter");
	$(".webpart .part").each(function () {
		$(this).mouseenter(function () {
			if (!webpart_move) {
				webpart_theDiv = $(this); //拖拽对象 
				webpart_title.prependTo(webpart_theDiv);
				webpart_title.mousedown(function (event) {
					//鼠标在被拖元素偏移量 
					webpart_range.x = event.pageX - webpart_theDiv.offset().left;
					webpart_range.y = event.pageY - webpart_theDiv.offset().top;
					webpart_move = true;
				});
			}
//			if (e && e.stopPropagation) e.stopPropagation();
//			else window.event.cancelBubble = true;
		}).mouseleave(function () {
			webpart_title.remove();
		});
	});
}
$(function () {
	bindWebpart();
	$(document).mousemove(function (event) {
		if (webpart_move) {
			if (!webpart_drag) {
				webpart_tempDiv = $("<div class='dashred'></div>");
				webpart_tempDiv.insertBefore(webpart_theDiv);
				//置为拖动状态
				webpart_theDiv.addClass("dashblue");
				webpart_drag = true;
			}
			webpart_lastPos.x = event.pageX - webpart_range.x;
			webpart_lastPos.y = event.pageY - webpart_range.y;
			webpart_theDiv.css({ left: webpart_lastPos.x + 'px', top: webpart_lastPos.y + 'px' });
			var $tarColl = $(".webpart .part");
			$tarColl.each(function () {
				webpart_tarDiv = $(this);
				if ($(webpart_tarDiv).attr("class").indexOf("dashblue") == -1) {
					webpart_tarPos.x = webpart_tarDiv.offset().left;
					webpart_tarPos.y = webpart_tarDiv.offset().top;
					if (Math.abs(webpart_tarPos.x - webpart_lastPos.x) < 20) {
						var tmpPos = webpart_lastPos.y - webpart_tarPos.y;
						if (tmpPos > 0 && tmpPos < 20)
							webpart_tempDiv.insertAfter(webpart_tarDiv);
						else if (tmpPos < 0 && tmpPos > -20)
							webpart_tempDiv.insertBefore(webpart_tarDiv);
					}
				}
			});
		}
	}).mouseup(function (event) {
		if (webpart_tempDiv) {
			webpart_theDiv.insertBefore(webpart_tempDiv); // 拖拽元素插入到 虚线div的位置上 
			webpart_theDiv.removeClass("dashblue");
			webpart_tempDiv.remove(); // 删除新建的虚线div 
			webpart_move = false;
			webpart_drag = false;
			webpart_tempDiv = null;
		}
	});
})