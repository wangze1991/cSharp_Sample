/// <reference path="../../lib/jquery-1.10.2.min.js" />

/*
**easyui dialog 遮罩
*/
; (function () {
    $.fn.eMask = function (opt) {
      return  this.each(function (i) {
            var self = $(this);
            var m = new mask(self);
            m.init();
        });
    };
    function mask(ele, opt) {
        this.ele = ele;
    }
    var maskProto = mask.prototype;
    maskProto.init = function () {
        console.log(1);
        var div = $('<div></div>');
        var position = this._getPostion();
        div.css({
            position: 'absolute',
            width: '100%',
            height: '100%',
            left: 0,
            top: 0,
            'background-color': '#fff',
            'z-index':100000
        });
        div.text("正在加载中，请稍等");
        $('body').append(div);
        return this;
    }
    maskProto._getPostion = function () {
        var ele = this.ele;
        var position = {};
        position['left'] = ele.offset().left;
        position['top'] = ele.offset().top;
        position['width'] = ele.width();
        position['height'] = ele.height();
        return position;
    };

})();