$(function(){
document.oncontextmenu=function(){return false;}//屏蔽右键
document.onmousemove=mouseMove;//记录鼠标位置
});
var mx=0,my=0;
function mouseMove(ev){Ev=ev||window.event;var mousePos=mouseCoords(Ev);mx=mousePos.x;my=mousePos.y;} 
function mouseCoords(ev){
	if(ev.pageX||ev.pageY){return{x:ev.pageX,y:ev.pageY};}
	return{x:ev.clientX,y:ev.clientY+$(document).scrollTop()};
}

$.fn.extend({RightMenu: function(id,options){options = $.extend({menuList:[]},options);var menuCount=options.menuList.length;
	if (!$("#"+id)[0]){
		var divMenuList="<div id=\""+id+"\" class=\"div_RightMenu\"><div><ul class='ico'>";
		for(var i=0;i<menuCount;i++){
			divMenuList+="<li class=\"RMli_"+options.menuList[i].menuclass+"\" onclick=\""+options.menuList[i].clickEvent+"\">"+options.menuList[i].menuName+"</li>";
		}
		divMenuList += "</ul></div><div>";
		$("body").append(divMenuList).find("#"+id).hide().find("li")
		.bind("mouseover",function(){$(this).addClass("RM_mouseover");})
		.bind("mouseout",function(){$(this).removeClass("RM_mouseover");});
		$(document).click(function(){$("#"+id).hide();});
	}
	return this.each(function(){
		this.oncontextmenu=function(){
			var mw=$('body').width(),mhh=$('html').height(),mbh=$('body').height(),
				w=$('#'+id).width(),h=$('#'+id).height(),
				mh=(mhh>mbh)?mhh:mbh;//最大高度 比较html与body的高度
			if(mh<h+my){my=mh-h;}//超 高
			if(mw<w+mx){mx=mw-w;}//超 宽
			$("#"+id).hide().css({top:my,left:mx}).show();
		}
	});
    }
});