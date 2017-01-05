/// <reference path="D:\团队项目\Sample\Mvc.Sample\Scripts/jquery-1.10.2.intellisense.js" />
/// <reference path="D:\团队项目\Sample\Mvc.Sample\Scripts/jquery-1.10.2.min.js" />

; (function () {

    $.fn.dropDownList = function (opt) {
        return this.each(function () {
            var self = $(this);
            var _opt = $.extend({},$.fn.dropDownList.defaults, opt)
            var ddl = new dropDownList(self, _opt);
        });
    };
    $.fn.dropDownList.defaults = {
        url: '',
        textField: 'Text',
        valueField: 'Id',
        queryParam: null,
        isAsync:true,
        onSelect: null,
        selectId: '',
        loading:'--请选择--'
    };
    function dropDownList(ele, opt) {
        this.ele = ele;
        this.opt = opt,
        this.init();

    }

    var ddlProto = dropDownList.prototype;

    ddlProto.init = function () {
        this.getHtml();
        this.bindChangeEvent();
    }

    ddlProto.getHtml = function () {
        var self = this;
        var opt = self.opt;
        var ele = self.ele;
        $.ajax({
            'dataType': 'json',
            'type': 'get',
            'async':opt.isAsync,
            'url': opt.url,
            'data': opt.queryParam,
            'success': function (data) {
                if (!data) {
                    console.log("没有数据");
                    return;
                }
              self._splice(data);
            },
            'error': function () {
                console.log("加载数据失败");
            }
        });
    };

    ddlProto._splice = function (obj) {
        var self = this;
        var opt = self.opt;
        var ele = self.ele;
        var html = '<option value="">' + self.opt.loading + '</option>';
        $.each(obj, function (i, item) {
            html += '<option value=' + item[opt.valueField] + '>' + item[opt.textField] + '</option>';
        });
        ele.html(html);
        if (opt.selectId) {
            ele.val(opt.selectId);
            ele.trigger('change');
            opt.selectId = '';
        }
    };

    ddlProto.bindChangeEvent = function () {
        if (this.opt.onSelect) {
            this.ele.on('change', this.opt.onSelect);
        }
    };
    // $.fn.dropDownList.constructor = dropDownList;
})();
; (function () {
    $.fn.remoteDll = function (opt) {
        return this.each(function () {
            var self = $(this);
            //var _opt = $.extend($.fn.remoteDll.defaults, opt);
            //console.log(_opt);
            var ddl = new remoteDllFun(self, $.extend({},$.fn.remoteDll.defaults, opt));
        });

    };
    $.fn.remoteDll.defaults = {
        url: '',
        textField: 'Text',
        valueField: 'Id',
        queryParam: 'parentId',
        //onSelect: null,
        parent: "",
        loading: "--请选择--",
        selectId:''
    };

   function remoteDllFun(ele, options) {
        this.ele = ele;
        this.opt = options;
        this.parentChange();
        //console.log(this.opt);
    };

    remoteDllProto = remoteDllFun.prototype;

    /*上级select 变化
    **/
    remoteDllProto.parentChange =function() {
        var self = this;
        var opt = this.opt;
        var ele = this.ele;
        console.log(opt.parent);
        $(opt.parent).on('change', function (e) {
            //ele.html('');
            var parentSelf = $(this);
            if (!parentSelf.val()) return;
            var data = {};
            data[opt.queryParam] = parentSelf.val();
            self.getJson(data);
        });
    }
   
    /**获取json数据
    */
    remoteDllProto.getJson = function(queryParam) {
        var self = this;
        var opt = this.opt;
        var ele = this.ele;
        $.ajax({
            'dataType': 'json',
            'type': 'get',
            'url': self.opt.url,
            'data': queryParam,
            'success': function (data) {
                if (!data) {
                    console.log("没有数据");
                    return;
                }
                ele.html(build.call(self, data));
                console.log(opt.selectId);
                if (opt.selectId) {
                    ele.val(self.opt.selectId);
                    ele.trigger('change');
                    opt.selectId = "";
                }
            },
            'error': function () {
                console.log("加载数据失败");
            }
        });

    }
    /**拼接html字符串
    */
    function build(obj) {
        var self=this;
        var html = '<option value="" selected="selected">' + self.opt.loading + '</option>';
        $.each(obj, function (i, item) {
            html += '<option value=' + item[self.opt.valueField] + '>' + item[self.opt.textField] + '</option>';
        });
        return html;
    }
})();


; (function () {
    $(function () {
        $('#region').remoteDll({
            url: '/Attribute/GetJsonList',
            parent: '#city',
            selectId: '9'
        });
        $('#city').remoteDll({
            url: '/Attribute/GetJsonList',
            parent: '#sel',
            selectId: '5'
        });
        $('#sel').dropDownList({
            url: '/Attribute/GetJsonList',
            isAsync: false,
            selectId: '1'
        });
        $('#btn-add').click(function () {
            $('#select-contaier').clone(true).appendTo($('body'));
        });

    });
})();

