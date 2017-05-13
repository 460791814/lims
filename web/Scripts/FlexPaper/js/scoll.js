var isFF = navigator.userAgent.toLowerCase().indexOf('firefox');
var mousewheel = function (event) {
    var event = event ? event : window.event;
    var obj = event.srcElement;
    if (!obj) {
        obj = event.target;
    }
    //此处可以加入判断，来实现类似百度文库的效果，先把浏览器滚动条移至可以完全显示flash的位置，然后再操作flash内部滚动条<br>　　
    if (obj.type == "application/x-shockwave-flash" || obj.type == "") {
        if (isFF > 0) {
            event.preventDefault();
            event.stopPropagation();
        }
        else {
            return false;
        }
    }
}
function onloaded() {

    if (isFF > 0)
        document.body.addEventListener("DOMMouseScroll", mousewheel, false);
    else
        document.body.onmousewheel = mousewheel;
}
//window.onload = function () {
//    onloaded();
//}

window.onload = function(){  
//    if (window.addEventListener) {  
//        window.addEventListener('DOMMouseScroll', deltaDispatcher, false);  
//    }
    document.body.onmousewheel = deltaDispatcher;
    onloaded();
}
function deltaDispatcher(event) {  
    var event = window.event || event;  
    var delta = 0;  
    if (event.wheelDelta) {  
        delta = event.wheelDelta/120;  
        if (window.opera){  
            delta = -delta;  
        }  
    } else if (event.detail) {  
        delta = -event.detail;  
    }  
    if (event.preventDefault){  
        event.preventDefault();  
    }
    var obj = swfobject.getObjectById("_FlexPaperView");
    alert(obj);
    if(typeof( obj.externalMouseEvent ) == 'function'){   
        obj.externalMouseEvent(delta);  
    }
}
 
 
