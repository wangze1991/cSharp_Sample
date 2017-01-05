//add by wangze
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
        this.form = opt.form;
        this.params = opt.params;
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
        $('textarea', self.form).each(function () {
            $(this).val(self.params[this.name]);
        });
        $('label', self.form).each(function () {
            $(this).html(self.params[$(this).attr("name")]);
        });

    }

})();

/**stringify
*/
; (function ($) {

    $.extend({
        stringify: function (value) {
            if (typeof JSON.stringify === 'function')
                return JSON.stringify(str, replacer, space);
            return jsonToStr(value);
        }
    });

    function jsonToStr(json) {
        var s='';
        $.each(json, function (i, n) {
            if (typeof this === 'object') {
                s += jsonToStr(this);
            } else {
                s += "," + i + ":" + n;
            }

        });

        if (s != "") {
            s = s.substring(1);
        }

        return "{" + s + "}";
    }

})(jQuery);

//格式化时间格式
function timeFormatter(value) {
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