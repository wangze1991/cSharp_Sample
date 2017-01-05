
;
(function ($) {

    var win = window;

    var WZ = win.WZ = win.WZ || {};

    /*
    **设置全局ajax loding
    */
    //$().ajaxStart(function () {
    //    WZ.showLoading();
    //}).ajaxStop(function() {
    //    WZ.hideLoading();
    //}).ajaxError(function (a, b,c, d) {
    //    WZ.hideLoading();
    //    if (console) {
    //        console.log(a);
    //        console.log(b);
    //        console.log(c);
    //        console.log(d);
    //    }
    //});

    /*
	**url公共方法
	*/
    WZ.url = { //#URL
        //参数：变量名，url为空则表从当前页面的url中取
        getQuery: function (name, url) {
            var u = arguments[1] || window.location.search
				, reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)")
				, r = u.substr(u.indexOf("?") + 1).match(reg)
            ;
            return r != null ? r[2] : "";
        }
        //# 获取 hash值
        , getHash: function (name, url) {
            var u = arguments[1] || location.hash;
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = u.substr(u.indexOf("#") + 1).match(reg);
            if (r != null) {
                return r[2];
            }
            return "";
        }
        //# 解析URL
        , parse: function (url) {
            var a = document.createElement('a');
            url = url || document.location.href;
            a.href = url;
            return {
                source: url
				, protocol: a.protocol.replace(':', '')
				, host: a.hostname
				, port: a.port
				, query: a.search
				, file: (a.pathname.match(/([^\/?#]+)$/i) || [, ''])[1]
				, hash: a.hash.replace('#', '')
				, path: a.pathname.replace(/^([^\/])/, '/$1')
				, relative: (a.href.match(/tps?:\/\/[^\/]+(.+)/) || [, ''])[1]
				, segments: a.pathname.replace(/^\//, '').split('/')
            };
        }
    };

    /*
	**Iframe自适应高度
    */
    WZ.setIframeHeight = function (iframe) {
        if (iframe) {
            var iframeWin = iframe.contentWindow || iframe.contentDocument.parentWindow;
            if (iframeWin.document.body) {
                iframe.height = iframeWin.document.documentElement.scrollHeight || iframeWin.document.body.scrollHeight;
            }
        }
    };
    /*
    **右下角弹出框
    */
    WZ.tip = function (msg, title) {
        $.messager.show({
            'title': title,
            'msg': msg,
            'timeout': 3000
        });
    }

    /*
    **显示loading
    */
    WZ.showLoading = function (msg) {
        msg = msg || '正在处理，请稍候。。。';
        $("<div class=\"datagrid-mask\"></div>")
            .css({
                display: "block",
                width: "100%",
                height: '100%',
                position: 'absolute',
                left: 0,
                top: 0,
                opacity: 0.3,
                filter: 'alpha(opacity=30)',
                // 'background-color': 'gray',
                'z-index': '999999'
            }).appendTo("body");
        $("<div class=\"datagrid-mask-msg\"></div>").css({
            position: 'absolute',
            top: '50%',
            left: '0',
            'margin-top': '-20px',
            padding: '10px 5px 10px 30px',
            width: 'auto',
            height: '16px',
            'border-width': '2px',
            'border-style': 'solid'
        })
            .html(msg)
            .appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
    }


    /*
    **删除loading
    */
    WZ.hideLoading = function () {
        $('.datagrid-mask').remove();
        $('.datagrid-mask-msg').remove();
    }

    /*
    **Ajax
    */
    WZ.ajax = function (options) {
        WZ.showLoading();
        var opt = $.extend({}, {
            'data': {},
            'dataType': 'json',
            'url': '',
            'type': 'get',
            'beforeSend': function () {
              
            },
            'async': true,
            'success': function (data) { },
            'complete': function () {},
            'error': function (XMLHttpRequest, textStatus, errorThrown) {
                WZ.hideLoading();
                if (console) {
                    console.log(XMLHttpRequest);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            }
        }, options);


        $.ajax({
            data: opt.data,
            dataType: opt.dataType,
            url: opt.url,
            type: opt.type,
            beforeSend: opt.beforeSend,
            async:opt.async
        }).done(function(data) {
            opt.success(data);
            WZ.hideLoading();
        }).fail(opt.error).always();
    }


    /*
    **弹窗显示
    */
    WZ.showModalDialog = function (options) {
        var $panel = createPanel();
        var opt = $.extend({}, {
            iconCls: '',
            shadow: false,
            closed: true,
            resizable: true,
            width: $(window).width() * 0.6,
            height: $(window).height() * 0.5,
            border: true,
            fit: false,
            collapsible: true,
            closable: true,
            minimizable: false,
            maximizable: true,
            href: '',
            loadingMessage: '正在加载中，请稍后...',
            modal: true,
            draggable: true,
            title: '请添加标题', /*当没有设置标题的时候，最大最小等相关按钮和header都不显示*/
            onClose: function() {
                $(this).dialog('destroy').remove();
            },
            onLoad: function () { },
            onBeforeClose: function () {},
            onOpen: function () {}
        }, options);

        $panel.dialog(opt).dialog('open');

        resize($panel);
        return $panel;

        function createPanel() {
            var id = 'panel' + new Date().getTime();
            return $('<div id=' + id + '></div>').appendTo('body');
        }

        /*
        **dialog自适应页面大小
        */
        function resize(jq) {

            $(window).off('dialog.resize')
                     .on('dialog.resize', function () {
                         jq.panel('resize', {
                             width: $(window).width() * 0.6,
                             height: $(window).height() * 0.5
                         });
                     });

            $(window).on('resize', function () {
                $(this).trigger('dialog.resize');
            });
        }

    }




    /*
    **iframe弹窗
    */
    WZ.showIframeDialog = function (options) {

        var $panel = createPanel();
        var iframeId = 'frame' + new Date().getTime();
        var opt = $.extend({}, {
            width: $(window).width() * 0.9,
            height: $(window).height() * 0.8,
            title: '',
            formId: '#ff',
            iframeAddButton: '#btn-add',
            iframeCancelButton:'#btn-cancel',        
            content: '<iframe id="' + iframeId + '" src="' + options.src + '" width="100%" height="100%" scrolling="no" style="border:0"  onload="WZ.utility.method.setIframeHeight(this)"></iframe>',
            iconCls: '',
            shadow: false,
            closed: true,
            resizable: true,
            collapsible: true,
            closable: true,
            minimizable: false,
            maximizable: true,
            buttons: null,
            toolbar: null,
            loadingMessage: '正在加载中，请稍后...',
            onClose: function () {
                $(this).dialog('destroy').remove();
            },
            onBeforeOpen: function () {           
                var iframe = document.getElementById(iframeId);
                var self = $(this);
                iframe.onload = function () {
                    $('#dialogId', $(this).contents()).val($panel.attr('id'));
                    $(opt.iframeAddButton, $(this).contents()).on('click', function () {
                        return false;
                    });
                    $(this).contents().on('click', opt.iframeCancelButton,function () {
                        self.dialog('close');
                        return false;
                    });
                }

            },
            onLoad: function () {
            }
        }, options);

        $panel.dialog(opt).dialog('open');

        return $panel;


        function createPanel() {
            var id = 'panel' + new Date().getTime();
            return $('<div id=' + id + '></div>').appendTo('body');
        }
    }




})(jQuery);






/*
**原型公共方法
*/
;
(function () {
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
    stringBuffer.clear = function () {
        this._strings_ = new Array();
    };


    /*
    **string 原型方法
    */
    var stringProto = String.prototype;

    stringProto.trimEnd = function (str) {
        if (this.length == 0) return this;
        if (this.lastIndexOf(str) == this.length - 1) {
            return this.substr(0, this.length - 1);
        }
        return this;
    }

    /*
    **array 方法
    */

    var arrayProto = Array.prototype;
    arrayProto.toCSharpString = function () {
        var len = this.length;
        if (len === 0) {
            return '{}';
        } else {
            var builder = new stringBuffer();
            for (var i = 0; i < len; i++) {
                builder.append(this[i]);
            }
            return '{' + builder.toString(',') + '}';
        }

    }




    /*
    **Date 方法
    */
    Date.prototype.format = function (format) {
        var o = {
            "M+": this.getMonth() + 1, //month
            "d+": this.getDate(), //day
            "h+": this.getHours(), //hour
            "m+": this.getMinutes(), //minute
            "s+": this.getSeconds(), //second
            "q+": Math.floor((this.getMonth() + 3) / 3), //quarter
            "S": this.getMilliseconds() //millisecond
        }
        if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
        (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o) if (new RegExp("(" + k + ")").test(format))
            format = format.replace(RegExp.$1,
            RegExp.$1.length == 1 ? o[k] :
            ("00" + o[k]).substr(("" + o[k]).length));
        return format;
    }


})();
