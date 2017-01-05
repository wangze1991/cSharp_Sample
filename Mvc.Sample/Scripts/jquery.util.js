/**
 *author wangze
 *dependency jQuery
 *date 2015-12-22
*/

; (function (win) {
    var exports = win.utils || {};
    exports.getParam = function (selector) {
        var obj = {};
        exports.jquery(selector).each(function () {
            var self = this;
            var value = $.trim($(self).val());
            if (value || value == '0') {
                obj[self.name] = value;
                return true;
            }
        });
        return obj;
    };
    /**获取url hash
    *@param name 名称
    *@param url  地址
    */
    exports.getQuery = function (name, url) {
        var u = arguments[1] || window.location.search
            , reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)")
            , r = u.substr(u.indexOf("?") + 1).match(reg);
        return r != null ? r[2] : "";
    }
    /**
     * 转换成jquery对象
     * @param obj jquery对象或jquery选择器
     * @returns {$object}
     */
    exports.jquery = function (obj, $content) {
        var $obj = null;
        if (obj instanceof jQuery) {
            $obj = obj;
        } else {
            if ($content) {
                $obj = $(obj, $content);
            } else {
                $obj = $(obj);
            }
        }
        return $obj;
    };

    /**日期格式化
     *@params value 日期字符串
     */
    exports.timeFormatter = function (value) {
        if (value == null || value == "") return value;
        var date;
        if (value.toString().indexOf("Date") > -1) {
            date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
        }
        else
            date = new Date(value);
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        var t = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d) + ' ';

        var hh = date.getHours();
        var mm = date.getMinutes();
        var ss = date.getSeconds();
        t += (hh < 10 ? ('0' + hh) : hh) + ':' + (mm < 10 ? ('0' + mm) : mm) + ':' + (ss < 10 ? ('0' + ss) : ss);
        return t;
    }

    /**字符串格式化
     @param format "我是{0},身高{1}"
     @param value  wangze ,175
     */
    exports.stringFormat = function (format, value) {
        if (!value || !format) return "";
        for (var i = 0; i < arguments.length; i++) {
            var j = i + 1;
            if (arguments[j] != undefined) {
                var reg = new RegExp("({)" + i + "(})", "g");
                format = format.replace(reg, arguments[j]);
            }
        }
        return format;
    }

    win.utils = exports;
})(window);

/**绑定参数
*/
; (function () {
    $.fn.formBind = function (params) {
        var me = this;
        return me.each(function () {
            var self = this;
            new FormBind({ 'form': $(self), 'params': params }).bind();
        });
    }
    function FormBind(opt) {
        this.form = opt.form;//表单
        this.params = opt.params;//json返回值
    }
    FormBind.prototype.bind = function () {
        var self = this;
        $('input', self.form).each(function () {
            var val = self.params[this.name];
            if (this.type == "text" || this.type == "hidden") {
                $(this).val(val);
            }
            else if (this.type == "checkbox") {
                $(this).attr("checked", val == "True" || val == true);
            }
            else if ((this.type == "radio")) {
                $("input[name=" + this.name + "][value=" + val + "]").attr("checked", true);
            }
        });
        $('textarea,label', self.form).each(function () {
            $(this).val(self.params[this.name]);
        });
    }
})();

/**Jquery stringify
*/
; (function ($) {
    $.extend({
        stringify: function (value) {
            if (typeof JSON.stringify === 'function')
                return JSON.stringify(value);
            throw new Error('当前浏览器还没有实现stringify');
        }
    });
    //TODO
    function jsonToStr(json) {
        var arry = [];
        $.each(json, function (key, value) {
            arry.push('"{0}"'.format(key) + ":" + '"{0}"'.format(value));
        });
        return '{' + arry.join(',') + '}';
    }

})(jQuery);

; (function () {
    function stringBuffer() {
        this._strings_ = new Array();
    };
    var builderProto = stringBuffer.prototype;
    builderProto.append = function (str) {
        this._strings_.push(str);
    };

    builderProto.toString = function (str) {
        return this._strings_.join(str ? str : '');
    };
    builderProto.clear = function () {
        this._strings_ = new Array();
    };
    window.stringBuffer = stringBuffer;
})();

/**原型链扩展方法
*/
; (function () {
    /**string 扩展方法  字符串格式化
    */
    String.prototype.format = function (args) {
        var result = this;
        if (arguments.length > 0) {
            if (arguments.length == 1 && typeof (args) == "object") {
                for (var key in args) {
                    if (args[key] != undefined) {
                        var reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, args[key]);
                    }
                }
            }//example   var template2="我是{name}，今年{age}了";var result2=template2.format({name:"loogn",age:22});
            else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] != undefined) {
                        var reg = new RegExp("({)" + i + "(})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }//expample var template1="我是{0}，今年{1}了"; var result1=template1.format("loogn",22);
            }
        }
        return result;
    }

    String.prototype.trim = function () {
        return $.trim(this);
    }

    String.prototype.trimEnd = function (str) {
        if (this.length == 0) return this;
        if (this.lastIndexOf(str) == this.length - 1) {
            return this.substr(0, this.length - 1);
        }
        return this;
    }

    // 对Date的扩展，将 Date 转化为指定格式的String 
    // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
    // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
    // 例子： 
    // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
    // (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
    Date.prototype.Format = function (fmt) { //author: meizz 
        var o = {
            "M+": this.getMonth() + 1,                 //月份 
            "d+": this.getDate(),                    //日 
            "h+": this.getHours(),                   //小时 
            "m+": this.getMinutes(),                 //分 
            "s+": this.getSeconds(),                 //秒 
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
            "S": this.getMilliseconds()             //毫秒 
        };
        if (/(y+)/.test(fmt))
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt))
                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    }

})();

//TODO
//easyUi扩展方法


