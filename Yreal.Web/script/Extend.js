jQuery.fn.extend({
    isPhone: function (str) {
        if (typeof (str) != "string") return false;
        var p = /^(\d{3}-)(\d{8})$|(\d{4}-)(\d{7})$|(\d{3})(\d{8})$|(\d{4})(\d{7})$/;
        return p.test($.trim(str));
    },
    isInt: function (str) {
        if (typeof (str) != "string") return false;
        str = $.trim(str);
        var p = /^[-\+]?\d+$/;
        return p.test(str);
    },
    isIntNotSymbol: function (str) {// 无符号正整数,1到9的数字。
        if (typeof (str) != "string") return false;
        str = $.trim(str);
        var p = /^[1-9]?[0-9]+$/;
        return p.test(str);
    },
    len: function (str) {
        str = str.replace(" ", "");
        return str.length;
    },
    isEmail: function (str) {
        var reg = /^(([0-9a-zA-Z_.]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z_.]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|NET|com|COM|gov|GOV|mil|MIL|org|ORG|edu|EDU|INT)$/;
        return reg.test($.trim(str));

    },
    isCharAndNumber: function (str) {
        if (typeof (str) != "string") return false;
        var p = /^\w+$/;
        return p.test($.trim(str));
    },

    isHaveNum: function (str) {
        if (typeof (str) != "string") return false;
        var p = /\d+/;
        return p.test($.trim(str));
    },
    isHaveLetter: function (str) {
        if (typeof (str) != "string") return false;
        var p = /[a-zA-Z]+/;
        return p.test($.trim(str));
    },
    isSpecial: function (str) {
        if (typeof (str) != "string") return false;
        var p = /[_\W]+/;
        return p.test($.trim(str));
    },

    isCharAndNumberOrPoint: function (str) {
        if (typeof (str) != "string") return false;
        var p = /^[\w\.]+$/;
        return p.test($.trim(str));
    },
    isChinese: function (str) {
        if (typeof (str) != "string") return false;
        str = $.trim(str);
        var reg = /[u00-uFF]/;
        return !reg.test(str);
    },
    isChineseAndChar: function (str) {
        if (typeof (str) != "string") return false;
        str = $.trim(str);
        var reg = /^[-\w\u4E00-\u9FA5]+$/;
        return reg.test(str);
    },
    isMobile: function (str) {
        str = str.trim();
        //var reg = /^[1-9][0-9]{10}$/;
        var reg = /^[0,1][0-9]{9,10}$/;
        return reg.test(str);
    },

    isSeriate: function (str) {
        str = str.trim();
        var reg = /([\s\S])\1{3,}/;
        return reg.test(str);

    },
    isPassword: function (str) {
        if (typeof (str) != "string") return false;
        var p = /^\w{6,16}$/;
        return p.test($.trim(str));
    },
    isEmpty: function (str1) {
        if (str1 && str1.length > 0) {
            return false;
        } else {
            return true;
        }
    },
    isUrl: function (str) {
        var patrn = /^(http(s)?:\/\/)?([\w-]+\.)+[\w-]+(\/[\w-_, .\/?%&=]*)?$/;

        if (!patrn.exec($.trim(str)))
            return false;
        return true;
    },
    isUrls: function (str) {
        var patrn = new RegExp("((?:http|https|ftp|mms|rtsp)://(&(?=amp;)|[A-Za-z0-9\./=\?%_~@&#:;\+\-])+)", "ig");
        if (!patrn.exec($.trim(str)))
            return false;
        return true;
    },
    isAllNumber: function (str) {
        str = str.trim();
        var reg = /^\d+$/g;
        return reg.test(str);
    },
    isMoney: function (str) {
        str = str.trim();
        var reg = /^\d{1,9}(\.\d{1,2})?$/;
        return reg.test(str);
    },
    isDecimal: function (str) {
        str = str.trim();
        var reg = /^([1-9]|[1-9]|(0[.])|(-(0[.])))[0-9]{0,}(([.]*\d{1,2})|[0-9]{0,})$/;
        return reg.test(str);
    },
    isUserName: function (str) {
        str = str.trim();
        var reg = /^[\w\u4E00-\u9FA5]{4,30}$/;
        return reg.test(str);
    },
    isQQ: function (str) {
        str = str.trim();
        var reg = /^[1-9][0-9]{4,11}$/;
        return reg.test(str);
    },
    isZipcode: function (str) {
        str = str.trim();
        var reg = /^[1-9][0-9]{5}$/;
        return reg.test(str);
    },
    isCard: function (str) {
        str = str.trim();
        var reg = /^[1-9](\d{13}|\d{16})[0-9|xX]$/;
        return reg.test(str);
    },
    isScriptOrIframe: function (str) {
        str = str.trim();
        var reg = /^.*<\/?(script|iframe)(\s{1}.*)?>.*$/gi;
        return str.match(reg) == null ? false : true;
    },
    isLink: function (str) {
        str = str.trim();
        var reg = /^.*<a.+href=.+>.*$/gi;
        return str.match(reg) == null ? false : true;
    }
});

jQuery.fn.extend({
    len: function() {
        var str = $.trim(this.val());
        return str.length;
    },
    getRealLength: function() {
        var str = $.trim(this.val());
        return str.replace(/[^x00-xff]/g, "--").length;
    },
    isQQ: function() {
        var str = $.trim(this.val());
        return /^[1-9][0-9]{4,10}$/g.test(str);
    },
    trim: function() {
        return $.trim($(this).val());
    }
});

String.prototype.trim = function() {
    return this.replace(/(^\str*)|(\str*$)/g, "");
};

String.prototype.getRealLength = function() {
    return this.replace(/[^x00-xff]/g, "--").length;
};
String.prototype.isAllNumber = function() {
    var str = this.replace(/^\d+$/g, "");
    str = str.trim();
    return 0 == str.length;
};
String.prototype.toInt = function() {
    return parseInt(this);
};
String.prototype.toFloat = function() {
    return parseFloat(this);
};

String.prototype.clean = function() {
    return this.replace(/\s+/g, ' ').trim();
};

String.prototype.isAllChar = function() {
    var str = this.replace(/[a-zA-Z]/g, "");
    str = str.trim();
    return 0 == str.length;
};
String.prototype.len = function() {
    var str = this.replace(" ", "");
    return str.length;
};


function inputInt() {
    if (event.keyCode < 48 || event.keyCode > 57)
        event.returnValue = false;
}


function inputMoneyNew(money) {
    var decOk = true;
    var strOk = true;
    var dotIndex = money.indexOf(".");
    if (dotIndex != -1) {
        var dec = money.substr(dotIndex + 1, money.length - dotIndex - 1);
        if (dec.length >= 2) {
            decOk = false;
            // event.returnValue=false;
        }
    }

    if (event.keyCode != 46 && (event.keyCode < 48 || event.keyCode > 57)) {
        strOk = false;
        //event.returnValue=false
    }
    if (!(decOk && strOk)) {
        event.returnValue = false;
    }
}

function isValidPayPassWord(str) {
    if (str == null) return false;
    if (str == "") return false;
    var reg = /^[^\u4E00-\u9FA5]{6,19}$/;
    return reg.test(str);

}

// 转换金额
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + //',' +
       num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num + '.' + cents);
}

// 复制
function Copy(content, msg) {
    if (document.all) { //判断IE
        window.clipboardData.setData('text', content);
        alert(msg);
    }
    else {
        alert("您的浏览器不支持剪贴板操作，请自行复制！");
    }
}

/*
// js 控制input框的长度；包括中英文字符
    一个中文相当于两个字符
//按照设置的最大长度，控制对象的输入中英文长度
   //maxlength="24" onKeyPress="subObjMaxlength(this)" onBlur="subObjMaxlength(this)"
*/
function subObjMaxlength(obj) {
    var maxlen = obj.maxLength;
    var strValue = obj.value;
    var strTemp = "";
    var i, sum;
    sum = 0;
    for (i = 0; i < strValue.length; i++) {
        if ((strValue.charCodeAt(i) >= 0) && (strValue.charCodeAt(i) <= 255)) {
            sum = sum + 1;
        }
        else {
            sum = sum + 2;
        }
        
        if (sum <= maxlen) {
            strTemp += strValue.charAt(i);
        }
        else {
            obj.value = strTemp;
            break;
        }
    }
}

/*
// 获取和设置光标位置
    // 示例：
    var cursorIndexOf = Position(obj);      // 获得光标所在位置
    Position(obj, cursorIndexOf);       // 设置光标所在位置
*/
function Position(obj, value) {
    var elem = obj;
    if (elem && (elem.tagName == "TEXTAREA" || elem.type.toLowerCase() == "text")) {
        if ($.browser.msie) {
            var rng;
            if (elem.tagName == "TEXTAREA") {
                rng = event.srcElement.createTextRange();
                rng.moveToPoint(event.x, event.y);
            } else {
                rng = document.selection.createRange();
            }
            if (value === undefined) {
                rng.moveStart("character", -event.srcElement.value.length);
                return rng.text.length;
            } else if (typeof value === "number") {
                var index = this.Position(obj);
                index > value ? (rng.moveEnd("character", value - index)) : (rng.moveStart("character", value - index))
                rng.select();
            }
        } else {
            if (value === undefined) {
                return elem.selectionStart;
            } else if (typeof value === "number") {
                elem.selectionEnd = value;
                elem.selectionStart = value;
            }
        }
    } else {
        if (value === undefined)
            return undefined;
    }
}


//获取Url参数信息
function GetParam(paramName) {
    var paramList = location.search.replace('?', '').split('&');
    for (var i = 0; i < paramList.length; i++) {
        if (paramList[i].split('=')[0] == paramName)
            return paramList[i].substring(paramList[i].indexOf('=') + 1, paramList[i].length);
    }
    return "";
}