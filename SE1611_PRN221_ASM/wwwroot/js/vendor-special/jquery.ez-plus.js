"function"!=typeof Object.create&&(Object.create=function(o){function i(){}return i.prototype=o,new i}),function(o,i,t){var e={init:function(i,t){var e=this;if(e.elem=t,e.$elem=o(t),e.options=o.extend({},o.fn.ezPlus.options,e.responsiveConfig(i||{})),e.imageSrc=e.$elem.attr("data-"+e.options.attrImageZoomSrc)?e.$elem.attr("data-"+e.options.attrImageZoomSrc):e.$elem.attr("src"),e.options.enabled){var n;e.options.tint&&(e.options.lensColour="transparent",e.options.lensOpacity="1"),"inner"===e.options.zoomType&&(e.options.showLens=!1),"lens"===e.options.zoomType&&(e.options.zoomWindowWidth=0),-1===e.options.zoomId&&(e.options.zoomId=(n=(new Date).getTime(),"xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g,function(o){var i=(n+16*Math.random())%16|0;return n=Math.floor(n/16),("x"===o?i:3&i|8).toString(16)}))),e.$elem.parent().removeAttr("title").removeAttr("alt"),e.zoomImage=e.imageSrc,e.refresh(1);var s=e.options.galleryEvent+".ezpspace";s+=e.options.touchEnabled?" touchend.ezpspace":"",e.$galleries=o(e.options.gallery?"#"+e.options.gallery:e.options.gallerySelector),e.$galleries.on(s,e.options.galleryItem,function(i){if(e.options.galleryActiveClass&&(o(e.options.galleryItem,e.$galleries).removeClass(e.options.galleryActiveClass),o(this).addClass(e.options.galleryActiveClass)),"A"===this.tagName&&i.preventDefault(),o(this).data(e.options.attrImageZoomSrc)?e.zoomImagePre=o(this).data(e.options.attrImageZoomSrc):e.zoomImagePre=o(this).data("image"),e.swaptheimage(o(this).data("image"),e.zoomImagePre),"A"===this.tagName)return!1})}},refresh:function(o){var i=this;setTimeout(function(){i.fetch(i.imageSrc,i.$elem,i.options.minZoomLevel)},o||i.options.refresh)},fetch:function(o,i,t){var e=this,n=new Image;n.onload=function(){n.width/i.width()<=t?e.largeWidth=i.width()*t:e.largeWidth=n.width,n.height/i.height()<=t?e.largeHeight=i.height()*t:e.largeHeight=n.height,e.startZoom(),e.currentImage=e.imageSrc,e.options.onZoomedImageLoaded(e.$elem)},e.setImageSource(n,o)},setImageSource:function(o,i){o.src=i},startZoom:function(){var i,t=this;if(t.nzWidth=t.$elem.width(),t.nzHeight=t.$elem.height(),t.isWindowActive=!1,t.isLensActive=!1,t.isTintActive=!1,t.overWindow=!1,t.options.imageCrossfade){var e=o('<div class="zoomWrapper"/>').css({height:t.nzHeight,width:t.nzWidth});t.$elem.parent().hasClass("zoomWrapper")&&t.$elem.unwrap(),t.zoomWrap=t.$elem.wrap(e),t.$elem.css({position:"absolute"})}t.zoomLock=1,t.scrollingLock=!1,t.changeBgSize=!1,t.currentZoomLevel=t.options.zoomLevel,t.updateOffset(t),t.widthRatio=t.largeWidth/t.currentZoomLevel/t.nzWidth,t.heightRatio=t.largeHeight/t.currentZoomLevel/t.nzHeight,"window"===t.options.zoomType&&(t.zoomWindowStyle={display:"none",position:"absolute",height:t.options.zoomWindowHeight,width:t.options.zoomWindowWidth,border:t.options.borderSize+"px solid "+t.options.borderColour,backgroundSize:t.largeWidth/t.currentZoomLevel+"px "+t.largeHeight/t.currentZoomLevel+"px",backgroundPosition:"0px 0px",backgroundRepeat:"no-repeat",backgroundColor:""+t.options.zoomWindowBgColour,overflow:"hidden",zIndex:100}),"inner"===t.options.zoomType&&(t.zoomWindowStyle=(i=t.$elem.css("border-left-width"),t.options.scrollZoom&&(t.zoomLens=o('<div class="zoomLens"/>')),{display:"none",position:"absolute",height:t.nzHeight,width:t.nzWidth,marginTop:i,marginLeft:i,border:t.options.borderSize+"px solid "+t.options.borderColour,backgroundPosition:"0px 0px",backgroundRepeat:"no-repeat",cursor:t.options.cursor,overflow:"hidden",zIndex:t.options.zIndex})),"window"===t.options.zoomType&&(t.lensStyle=(t.nzHeight<t.options.zoomWindowHeight/t.heightRatio?t.lensHeight=t.nzHeight:t.lensHeight=t.options.zoomWindowHeight/t.heightRatio,t.largeWidth<t.options.zoomWindowWidth?t.lensWidth=t.nzWidth:t.lensWidth=t.options.zoomWindowWidth/t.widthRatio,{display:"none",position:"absolute",height:t.lensHeight,width:t.lensWidth,border:t.options.lensBorderSize+"px solid "+t.options.lensBorderColour,backgroundPosition:"0px 0px",backgroundRepeat:"no-repeat",backgroundColor:t.options.lensColour,opacity:t.options.lensOpacity,cursor:t.options.cursor,zIndex:999,overflow:"hidden"})),t.tintStyle={display:"block",position:"absolute",height:t.nzHeight,width:t.nzWidth,backgroundColor:t.options.tintColour,opacity:0},t.lensRound={},"lens"===t.options.zoomType&&(t.lensStyle={display:"none",position:"absolute",float:"left",height:t.options.lensSize,width:t.options.lensSize,border:t.options.borderSize+"px solid "+t.options.borderColour,backgroundPosition:"0px 0px",backgroundRepeat:"no-repeat",backgroundColor:t.options.lensColour,cursor:t.options.cursor}),"round"===t.options.lensShape&&(t.lensRound={borderRadius:t.options.lensSize/2+t.options.borderSize}),t.zoomContainer=o('<div class="'+t.options.container+'" uuid="'+t.options.zoomId+'"/>'),t.zoomContainer.css({position:"absolute",top:t.nzOffset.top,left:t.nzOffset.left,height:t.nzHeight,width:t.nzWidth,zIndex:t.options.zIndex}),t.$elem.attr("id")&&t.zoomContainer.attr("id",t.$elem.attr("id")+"-"+t.options.container),o("."+t.options.container).remove(),o(t.options.zoomContainerAppendTo).append(t.zoomContainer),t.options.containLensZoom&&"lens"===t.options.zoomType&&t.zoomContainer.css("overflow","hidden"),"inner"!==t.options.zoomType&&(t.zoomLens=o('<div class="zoomLens"/>').css(o.extend({},t.lensStyle,t.lensRound)).appendTo(t.zoomContainer).click(function(){t.$elem.trigger("click")}),t.options.tint&&(t.tintContainer=o('<div class="tintContainer"/>'),t.zoomTint=o('<div class="zoomTint"/>').css(t.tintStyle),t.zoomLens.wrap(t.tintContainer),t.zoomTintcss=t.zoomLens.after(t.zoomTint),t.zoomTintImage=o('<img src="'+t.$elem.attr("src")+'">').css({position:"absolute",top:0,left:0,height:t.nzHeight,width:t.nzWidth,maxWidth:"none"}).appendTo(t.zoomLens).click(function(){t.$elem.trigger("click")})));var n=isNaN(t.options.zoomWindowPosition)?"body":t.zoomContainer;function s(o){t.lastX===o.clientX&&t.lastY===o.clientY||(t.setPosition(o),t.currentLoc=o),t.lastX=o.clientX,t.lastY=o.clientY}t.zoomWindow=o('<div class="zoomWindow"/>').css(o.extend({zIndex:999,top:t.windowOffsetTop,left:t.windowOffsetLeft},t.zoomWindowStyle)).appendTo(n).click(function(){t.$elem.trigger("click")}),t.zoomWindowContainer=o('<div class="zoomWindowContainer" />').css({width:t.options.zoomWindowWidth}),t.zoomWindow.wrap(t.zoomWindowContainer),"lens"===t.options.zoomType&&(t.zoomContainer.css("display","none"),t.zoomLens.css({backgroundImage:'url("'+t.imageSrc+'")'})),"window"===t.options.zoomType&&t.zoomWindow.css({backgroundImage:'url("'+t.imageSrc+'")'}),"inner"===t.options.zoomType&&t.zoomWindow.css({backgroundImage:'url("'+t.imageSrc+'")'}),t.options.touchEnabled&&(t.$elem.on("touchmove.ezpspace",function(o){o.preventDefault();var i=o.originalEvent.touches[0]||o.originalEvent.changedTouches[0];t.setPosition(i)}),t.zoomContainer.on("touchmove.ezpspace",function(o){t.setElements("show"),o.preventDefault();var i=o.originalEvent.touches[0]||o.originalEvent.changedTouches[0];t.setPosition(i)}),t.zoomContainer.add(t.$elem).on("touchend.ezpspace",function(o){t.showHideWindow("hide"),t.options.showLens&&t.showHideLens("hide"),t.options.tint&&"inner"!==t.options.zoomType&&t.showHideTint("hide")}),t.options.showLens&&(t.zoomLens.on("touchmove.ezpspace",function(o){o.preventDefault();var i=o.originalEvent.touches[0]||o.originalEvent.changedTouches[0];t.setPosition(i)}),t.zoomLens.on("touchend.ezpspace",function(o){t.showHideWindow("hide"),t.options.showLens&&t.showHideLens("hide"),t.options.tint&&"inner"!==t.options.zoomType&&t.showHideTint("hide")}))),t.zoomContainer.on("click.ezpspace touchstart.ezpspace",t.options.onImageClick),t.zoomContainer.add(t.$elem).on("mousemove.ezpspace",function(o){!1===t.overWindow&&t.setElements("show"),s(o)});var h=null;"inner"!==t.options.zoomType&&(h=t.zoomLens),t.options.tint&&"inner"!==t.options.zoomType&&(h=t.zoomTint),"inner"===t.options.zoomType&&(h=t.zoomWindow),h&&h.on("mousemove.ezpspace",s),t.zoomContainer.add(t.$elem).hover(function(){!1===t.overWindow&&t.setElements("show")},function(){t.scrollLock||(t.setElements("hide"),t.options.onDestroy(t.$elem))}),"inner"!==t.options.zoomType&&t.zoomWindow.hover(function(){t.overWindow=!0,t.setElements("hide")},function(){t.overWindow=!1}),t.options.minZoomLevel?t.minZoomLevel=t.options.minZoomLevel:t.minZoomLevel=2*t.options.scrollZoomIncrement,t.options.scrollZoom&&t.zoomContainer.add(t.$elem).on("wheel DOMMouseScroll MozMousePixelScroll",function(i){t.scrollLock=!0,clearTimeout(o.data(this,"timer")),o.data(this,"timer",setTimeout(function(){t.scrollLock=!1},250));var e,n=i.originalEvent.deltaY||-1*i.originalEvent.detail;return i.stopImmediatePropagation(),i.stopPropagation(),i.preventDefault(),0!==n&&(n/120>0?(e=parseFloat(t.currentZoomLevel)-t.options.scrollZoomIncrement)>=parseFloat(t.minZoomLevel)&&t.changeZoomLevel(e):(t.fullheight||t.fullwidth)&&t.options.mantainZoomAspectRatio||(e=parseFloat(t.currentZoomLevel)+t.options.scrollZoomIncrement,t.options.maxZoomLevel?e<=t.options.maxZoomLevel&&t.changeZoomLevel(e):t.changeZoomLevel(e)),!1)})},destroy:function(){this.$elem.off(".ezpspace"),this.$galleries.off(".ezpspace"),o(this.zoomContainer).remove(),this.options.loadingIcon&&this.spinner&&this.spinner.length&&(this.spinner.remove(),delete this.spinner)},getIdentifier:function(){return this.options.zoomId},setElements:function(o){if(!this.options.zoomEnabled)return!1;"show"===o&&this.isWindowSet&&("inner"===this.options.zoomType&&this.showHideWindow("show"),"window"===this.options.zoomType&&this.showHideWindow("show"),this.options.showLens&&(this.showHideZoomContainer("show"),this.showHideLens("show")),this.options.tint&&"inner"!==this.options.zoomType&&this.showHideTint("show")),"hide"===o&&("window"===this.options.zoomType&&this.showHideWindow("hide"),this.options.tint||this.showHideWindow("hide"),this.options.showLens&&(this.showHideZoomContainer("hide"),this.showHideLens("hide")),this.options.tint&&this.showHideTint("hide"))},setPosition:function(o){if(!this.options.zoomEnabled||void 0===o)return!1;(this.nzHeight=this.$elem.height(),this.nzWidth=this.$elem.width(),this.updateOffset(this),this.options.tint&&"inner"!==this.options.zoomType&&this.zoomTint.css({top:0,left:0}),this.options.responsive&&!this.options.scrollZoom)&&(this.options.showLens&&(this.nzHeight<this.options.zoomWindowWidth/this.widthRatio?this.lensHeight=this.nzHeight:this.lensHeight=this.options.zoomWindowHeight/this.heightRatio,this.largeWidth<this.options.zoomWindowWidth?this.lensWidth=this.nzWidth:this.lensWidth=this.options.zoomWindowWidth/this.widthRatio,this.widthRatio=this.largeWidth/this.nzWidth,this.heightRatio=this.largeHeight/this.nzHeight,"lens"!==this.options.zoomType&&(this.nzHeight<this.options.zoomWindowWidth/this.widthRatio?this.lensHeight=this.nzHeight:this.lensHeight=this.options.zoomWindowHeight/this.heightRatio,this.nzWidth<this.options.zoomWindowHeight/this.heightRatio?this.lensWidth=this.nzWidth:this.lensWidth=this.options.zoomWindowWidth/this.widthRatio,this.zoomLens.css({width:this.lensWidth,height:this.lensHeight}),this.options.tint&&this.zoomTintImage.css({width:this.nzWidth,height:this.nzHeight})),"lens"===this.options.zoomType&&this.zoomLens.css({width:this.options.lensSize,height:this.options.lensSize})));if(this.zoomContainer.css({top:this.nzOffset.top,left:this.nzOffset.left,width:this.nzWidth,height:this.nzHeight}),this.mouseLeft=parseInt(o.pageX-this.pageOffsetX-this.nzOffset.left),this.mouseTop=parseInt(o.pageY-this.pageOffsetY-this.nzOffset.top),"window"===this.options.zoomType){var i=this.zoomLens.height()/2,t=this.zoomLens.width()/2;this.Etoppos=this.mouseTop<0+i,this.Eboppos=this.mouseTop>this.nzHeight-i-2*this.options.lensBorderSize,this.Eloppos=this.mouseLeft<0+t,this.Eroppos=this.mouseLeft>this.nzWidth-t-2*this.options.lensBorderSize}"inner"===this.options.zoomType&&(this.Etoppos=this.mouseTop<this.nzHeight/2/this.heightRatio,this.Eboppos=this.mouseTop>this.nzHeight-this.nzHeight/2/this.heightRatio,this.Eloppos=this.mouseLeft<0+this.nzWidth/2/this.widthRatio,this.Eroppos=this.mouseLeft>this.nzWidth-this.nzWidth/2/this.widthRatio-2*this.options.lensBorderSize),this.mouseLeft<0||this.mouseTop<0||this.mouseLeft>this.nzWidth||this.mouseTop>this.nzHeight?this.setElements("hide"):(this.options.showLens&&(this.lensLeftPos=Math.floor(this.mouseLeft-this.zoomLens.width()/2),this.lensTopPos=Math.floor(this.mouseTop-this.zoomLens.height()/2)),this.Etoppos&&(this.lensTopPos=0),this.Eloppos&&(this.windowLeftPos=0,this.lensLeftPos=0,this.tintpos=0),"window"===this.options.zoomType&&(this.Eboppos&&(this.lensTopPos=Math.max(this.nzHeight-this.zoomLens.height()-2*this.options.lensBorderSize,0)),this.Eroppos&&(this.lensLeftPos=this.nzWidth-this.zoomLens.width()-2*this.options.lensBorderSize)),"inner"===this.options.zoomType&&(this.Eboppos&&(this.lensTopPos=Math.max(this.nzHeight-2*this.options.lensBorderSize,0)),this.Eroppos&&(this.lensLeftPos=this.nzWidth-this.nzWidth-2*this.options.lensBorderSize)),"lens"===this.options.zoomType&&(this.windowLeftPos=-1*((o.pageX-this.pageOffsetX-this.nzOffset.left)*this.widthRatio-this.zoomLens.width()/2),this.windowTopPos=-1*((o.pageY-this.pageOffsetY-this.nzOffset.top)*this.heightRatio-this.zoomLens.height()/2),this.zoomLens.css({backgroundPosition:this.windowLeftPos+"px "+this.windowTopPos+"px"}),this.changeBgSize&&(this.nzHeight>this.nzWidth?("lens"===this.options.zoomType&&this.zoomLens.css({backgroundSize:this.largeWidth/this.newvalueheight+"px "+this.largeHeight/this.newvalueheight+"px"}),this.zoomWindow.css({backgroundSize:this.largeWidth/this.newvalueheight+"px "+this.largeHeight/this.newvalueheight+"px"})):("lens"===this.options.zoomType&&this.zoomLens.css({backgroundSize:this.largeWidth/this.newvaluewidth+"px "+this.largeHeight/this.newvaluewidth+"px"}),this.zoomWindow.css({backgroundSize:this.largeWidth/this.newvaluewidth+"px "+this.largeHeight/this.newvaluewidth+"px"})),this.changeBgSize=!1),this.setWindowPosition(o)),this.options.tint&&"inner"!==this.options.zoomType&&this.setTintPosition(o),"window"===this.options.zoomType&&this.setWindowPosition(o),"inner"===this.options.zoomType&&this.setWindowPosition(o),this.options.showLens&&(this.fullwidth&&"lens"!==this.options.zoomType&&(this.lensLeftPos=0),this.zoomLens.css({left:this.lensLeftPos,top:this.lensTopPos})))},showHideZoomContainer:function(o){"show"===o&&this.zoomContainer&&this.zoomContainer.show(),"hide"===o&&this.zoomContainer&&this.zoomContainer.hide()},showHideWindow:function(o){var i=this;"show"===o&&!i.isWindowActive&&i.zoomWindow&&(i.options.onShow(i),i.options.zoomWindowFadeIn?i.zoomWindow.stop(!0,!0,!1).fadeIn(i.options.zoomWindowFadeIn):i.zoomWindow.show(),i.isWindowActive=!0),"hide"===o&&i.isWindowActive&&(i.options.zoomWindowFadeOut?i.zoomWindow.stop(!0,!0).fadeOut(i.options.zoomWindowFadeOut,function(){i.loop&&(clearInterval(i.loop),i.loop=!1)}):i.zoomWindow.hide(),i.options.onHide(i),i.isWindowActive=!1)},showHideLens:function(o){"show"===o&&(this.isLensActive||(this.zoomLens&&(this.options.lensFadeIn?this.zoomLens.stop(!0,!0,!1).fadeIn(this.options.lensFadeIn):this.zoomLens.show()),this.isLensActive=!0)),"hide"===o&&this.isLensActive&&(this.zoomLens&&(this.options.lensFadeOut?this.zoomLens.stop(!0,!0).fadeOut(this.options.lensFadeOut):this.zoomLens.hide()),this.isLensActive=!1)},showHideTint:function(o){"show"===o&&!this.isTintActive&&this.zoomTint&&(this.options.zoomTintFadeIn?this.zoomTint.css("opacity",this.options.tintOpacity).animate().stop(!0,!0).fadeIn("slow"):(this.zoomTint.css("opacity",this.options.tintOpacity).animate(),this.zoomTint.show()),this.isTintActive=!0),"hide"===o&&this.isTintActive&&(this.options.zoomTintFadeOut?this.zoomTint.stop(!0,!0).fadeOut(this.options.zoomTintFadeOut):this.zoomTint.hide(),this.isTintActive=!1)},setLensPosition:function(o){},setWindowPosition:function(i){var t=this;if(isNaN(t.options.zoomWindowPosition))t.externalContainer=o(t.options.zoomWindowPosition),t.externalContainer.length||(t.externalContainer=o("#"+t.options.zoomWindowPosition)),t.externalContainerWidth=t.externalContainer.width(),t.externalContainerHeight=t.externalContainer.height(),t.externalContainerOffset=t.externalContainer.offset(),t.windowOffsetTop=t.externalContainerOffset.top,t.windowOffsetLeft=t.externalContainerOffset.left;else switch(t.options.zoomWindowPosition){case 1:t.windowOffsetTop=t.options.zoomWindowOffsetY,t.windowOffsetLeft=+t.nzWidth;break;case 2:t.options.zoomWindowHeight>t.nzHeight?(t.windowOffsetTop=-1*(t.options.zoomWindowHeight/2-t.nzHeight/2),t.windowOffsetLeft=t.nzWidth):o.noop();break;case 3:t.windowOffsetTop=t.nzHeight-t.zoomWindow.height()-2*t.options.borderSize,t.windowOffsetLeft=t.nzWidth;break;case 4:t.windowOffsetTop=t.nzHeight,t.windowOffsetLeft=t.nzWidth;break;case 5:t.windowOffsetTop=t.nzHeight,t.windowOffsetLeft=t.nzWidth-t.zoomWindow.width()-2*t.options.borderSize;break;case 6:t.options.zoomWindowHeight>t.nzHeight?(t.windowOffsetTop=t.nzHeight,t.windowOffsetLeft=-1*(t.options.zoomWindowWidth/2-t.nzWidth/2+2*t.options.borderSize)):o.noop();break;case 7:t.windowOffsetTop=t.nzHeight,t.windowOffsetLeft=0;break;case 8:t.windowOffsetTop=t.nzHeight,t.windowOffsetLeft=-1*(t.zoomWindow.width()+2*t.options.borderSize);break;case 9:t.windowOffsetTop=t.nzHeight-t.zoomWindow.height()-2*t.options.borderSize,t.windowOffsetLeft=-1*(t.zoomWindow.width()+2*t.options.borderSize);break;case 10:t.options.zoomWindowHeight>t.nzHeight?(t.windowOffsetTop=-1*(t.options.zoomWindowHeight/2-t.nzHeight/2),t.windowOffsetLeft=-1*(t.zoomWindow.width()+2*t.options.borderSize)):o.noop();break;case 11:t.windowOffsetTop=t.options.zoomWindowOffsetY,t.windowOffsetLeft=-1*(t.zoomWindow.width()+2*t.options.borderSize);break;case 12:t.windowOffsetTop=-1*(t.zoomWindow.height()+2*t.options.borderSize),t.windowOffsetLeft=-1*(t.zoomWindow.width()+2*t.options.borderSize);break;case 13:t.windowOffsetTop=-1*(t.zoomWindow.height()+2*t.options.borderSize),t.windowOffsetLeft=0;break;case 14:t.options.zoomWindowHeight>t.nzHeight?(t.windowOffsetTop=-1*(t.zoomWindow.height()+2*t.options.borderSize),t.windowOffsetLeft=-1*(t.options.zoomWindowWidth/2-t.nzWidth/2+2*t.options.borderSize)):o.noop();break;case 15:t.windowOffsetTop=-1*(t.zoomWindow.height()+2*t.options.borderSize),t.windowOffsetLeft=t.nzWidth-t.zoomWindow.width()-2*t.options.borderSize;break;case 16:t.windowOffsetTop=-1*(t.zoomWindow.height()+2*t.options.borderSize),t.windowOffsetLeft=t.nzWidth;break;default:t.windowOffsetTop=t.options.zoomWindowOffsetY,t.windowOffsetLeft=t.nzWidth}if(t.isWindowSet=!0,t.windowOffsetTop=t.windowOffsetTop+t.options.zoomWindowOffsetY,t.windowOffsetLeft=t.windowOffsetLeft+t.options.zoomWindowOffsetX,t.zoomWindow.css({top:t.windowOffsetTop,left:t.windowOffsetLeft}),"inner"===t.options.zoomType&&t.zoomWindow.css({top:0,left:0}),t.windowLeftPos=-1*((i.pageX-t.pageOffsetX-t.nzOffset.left)*t.widthRatio-t.zoomWindow.width()/2),t.windowTopPos=-1*((i.pageY-t.pageOffsetY-t.nzOffset.top)*t.heightRatio-t.zoomWindow.height()/2),t.Etoppos&&(t.windowTopPos=0),t.Eloppos&&(t.windowLeftPos=0),t.Eboppos&&(t.windowTopPos=-1*(t.largeHeight/t.currentZoomLevel-t.zoomWindow.height())),t.Eroppos&&(t.windowLeftPos=-1*(t.largeWidth/t.currentZoomLevel-t.zoomWindow.width())),t.fullheight&&(t.windowTopPos=0),t.fullwidth&&(t.windowLeftPos=0),"window"===t.options.zoomType||"inner"===t.options.zoomType)if(1===t.zoomLock&&(t.widthRatio<=1&&(t.windowLeftPos=0),t.heightRatio<=1&&(t.windowTopPos=0)),"window"===t.options.zoomType&&(t.largeHeight<t.options.zoomWindowHeight&&(t.windowTopPos=0),t.largeWidth<t.options.zoomWindowWidth&&(t.windowLeftPos=0)),t.options.easing){t.xp||(t.xp=0),t.yp||(t.yp=0);var e=16,n=parseInt(t.options.easing);"number"==typeof n&&isFinite(n)&&Math.floor(n)===n&&(e=n),t.loop||(t.loop=setInterval(function(){t.xp+=(t.windowLeftPos-t.xp)/t.options.easingAmount,t.yp+=(t.windowTopPos-t.yp)/t.options.easingAmount,t.scrollingLock?(clearInterval(t.loop),t.xp=t.windowLeftPos,t.yp=t.windowTopPos,t.xp=-1*((i.pageX-t.pageOffsetX-t.nzOffset.left)*t.widthRatio-t.zoomWindow.width()/2),t.yp=-1*((i.pageY-t.pageOffsetY-t.nzOffset.top)*t.heightRatio-t.zoomWindow.height()/2),t.changeBgSize&&(t.nzHeight>t.nzWidth?("lens"===t.options.zoomType&&t.zoomLens.css({backgroundSize:t.largeWidth/t.newvalueheight+"px "+t.largeHeight/t.newvalueheight+"px"}),t.zoomWindow.css({backgroundSize:t.largeWidth/t.newvalueheight+"px "+t.largeHeight/t.newvalueheight+"px"})):("lens"!==t.options.zoomType&&t.zoomLens.css({backgroundSize:t.largeWidth/t.newvaluewidth+"px "+t.largeHeight/t.newvalueheight+"px"}),t.zoomWindow.css({backgroundSize:t.largeWidth/t.newvaluewidth+"px "+t.largeHeight/t.newvaluewidth+"px"})),t.changeBgSize=!1),t.zoomWindow.css({backgroundPosition:t.windowLeftPos+"px "+t.windowTopPos+"px"}),t.scrollingLock=!1,t.loop=!1):Math.round(Math.abs(t.xp-t.windowLeftPos)+Math.abs(t.yp-t.windowTopPos))<1?(clearInterval(t.loop),t.zoomWindow.css({backgroundPosition:t.windowLeftPos+"px "+t.windowTopPos+"px"}),t.loop=!1):(t.changeBgSize&&(t.nzHeight>t.nzWidth?("lens"===t.options.zoomType&&t.zoomLens.css({backgroundSize:t.largeWidth/t.newvalueheight+"px "+t.largeHeight/t.newvalueheight+"px"}),t.zoomWindow.css({backgroundSize:t.largeWidth/t.newvalueheight+"px "+t.largeHeight/t.newvalueheight+"px"})):("lens"!==t.options.zoomType&&t.zoomLens.css({backgroundSize:t.largeWidth/t.newvaluewidth+"px "+t.largeHeight/t.newvaluewidth+"px"}),t.zoomWindow.css({backgroundSize:t.largeWidth/t.newvaluewidth+"px "+t.largeHeight/t.newvaluewidth+"px"})),t.changeBgSize=!1),t.zoomWindow.css({backgroundPosition:t.xp+"px "+t.yp+"px"}))},e))}else t.changeBgSize&&(t.nzHeight>t.nzWidth?("lens"===t.options.zoomType&&t.zoomLens.css({backgroundSize:t.largeWidth/t.newvalueheight+"px "+t.largeHeight/t.newvalueheight+"px"}),t.zoomWindow.css({backgroundSize:t.largeWidth/t.newvalueheight+"px "+t.largeHeight/t.newvalueheight+"px"})):("lens"===t.options.zoomType&&t.zoomLens.css({backgroundSize:t.largeWidth/t.newvaluewidth+"px "+t.largeHeight/t.newvaluewidth+"px"}),t.largeHeight/t.newvaluewidth<t.options.zoomWindowHeight?t.zoomWindow.css({backgroundSize:t.largeWidth/t.newvaluewidth+"px "+t.largeHeight/t.newvaluewidth+"px"}):t.zoomWindow.css({backgroundSize:t.largeWidth/t.newvalueheight+"px "+t.largeHeight/t.newvalueheight+"px"})),t.changeBgSize=!1),t.zoomWindow.css({backgroundPosition:t.windowLeftPos+"px "+t.windowTopPos+"px"})},setTintPosition:function(o){var i=this.zoomLens.width(),t=this.zoomLens.height();this.updateOffset(this),this.tintpos=-1*(o.pageX-this.pageOffsetX-this.nzOffset.left-i/2),this.tintposy=-1*(o.pageY-this.pageOffsetY-this.nzOffset.top-t/2),this.Etoppos&&(this.tintposy=0),this.Eloppos&&(this.tintpos=0),this.Eboppos&&(this.tintposy=-1*(this.nzHeight-t-2*this.options.lensBorderSize)),this.Eroppos&&(this.tintpos=-1*(this.nzWidth-i-2*this.options.lensBorderSize)),this.options.tint&&(this.fullheight&&(this.tintposy=0),this.fullwidth&&(this.tintpos=0),this.zoomTintImage.css({left:this.tintpos,top:this.tintposy}))},swaptheimage:function(i,t){var e=this,n=new Image;if(e.options.loadingIcon&&!e.spinner){var s={background:'url("'+e.options.loadingIcon+'") no-repeat',height:e.nzHeight,width:e.nzWidth,zIndex:2e3,position:"absolute",backgroundPosition:"center center"};"inner"===e.options.zoomType&&s.setProperty("top",0),e.spinner=o('<div class="ezp-spinner"></div>').css(s),e.$elem.after(e.spinner)}else e.spinner&&e.spinner.show();e.options.onImageSwap(e.$elem),n.onload=function(){e.largeWidth=n.width,e.largeHeight=n.height,e.zoomImage=t,e.zoomWindow.css({backgroundSize:e.largeWidth+"px "+e.largeHeight+"px"}),e.swapAction(i,t)},e.setImageSource(n,t)},swapAction:function(i,t){var e=this,n=e.$elem.width(),s=e.$elem.height(),h=new Image;if(h.onload=function(){e.nzHeight=h.height,e.nzWidth=h.width,e.options.onImageSwapComplete(e.$elem),e.doneCallback()},e.setImageSource(h,i),e.currentZoomLevel=e.options.zoomLevel,e.options.maxZoomLevel=!1,"lens"===e.options.zoomType&&e.zoomLens.css("background-image",'url("'+t+'")'),"window"===e.options.zoomType&&e.zoomWindow.css("background-image",'url("'+t+'")'),"inner"===e.options.zoomType&&e.zoomWindow.css("background-image",'url("'+t+'")'),e.currentImage=t,e.options.imageCrossfade){var a=e.$elem,d=a.clone();if(e.$elem.attr("src",i),e.$elem.after(d),d.stop(!0).fadeOut(e.options.imageCrossfade,function(){o(this).remove()}),e.$elem.width("auto").removeAttr("width"),e.$elem.height("auto").removeAttr("height"),a.fadeIn(e.options.imageCrossfade),e.options.tint&&"inner"!==e.options.zoomType){var p=e.zoomTintImage,r=p.clone();e.zoomTintImage.attr("src",t),e.zoomTintImage.after(r),r.stop(!0).fadeOut(e.options.imageCrossfade,function(){o(this).remove()}),p.fadeIn(e.options.imageCrossfade),e.zoomTint.css({height:s,width:n})}e.zoomContainer.css({height:s,width:n}),"inner"===e.options.zoomType&&(e.options.constrainType||(e.zoomWrap.parent().css({height:s,width:n}),e.zoomWindow.css({height:s,width:n}))),e.options.imageCrossfade&&e.zoomWrap.css({height:s,width:n})}else e.$elem.attr("src",i),e.options.tint&&(e.zoomTintImage.attr("src",t),e.zoomTintImage.attr("height",s),e.zoomTintImage.css("height",s),e.zoomTint.css("height",s)),e.zoomContainer.css({height:s,width:n}),e.options.imageCrossfade&&e.zoomWrap.css({height:s,width:n});if(e.options.constrainType){if("height"===e.options.constrainType){var l={height:e.options.constrainSize,width:"auto"};e.zoomContainer.css(l),e.options.imageCrossfade?(e.zoomWrap.css(l),e.constwidth=e.zoomWrap.width()):(e.$elem.css(l),e.constwidth=n);var m={height:e.options.constrainSize,width:e.constwidth};"inner"===e.options.zoomType&&(e.zoomWrap.parent().css(m),e.zoomWindow.css(m)),e.options.tint&&(e.tintContainer.css(m),e.zoomTint.css(m),e.zoomTintImage.css(m))}if("width"===e.options.constrainType){var z={height:"auto",width:e.options.constrainSize};e.zoomContainer.css(z),e.options.imageCrossfade?(e.zoomWrap.css(z),e.constheight=e.zoomWrap.height()):(e.$elem.css(z),e.constheight=s);var g={height:e.constheight,width:e.options.constrainSize};"inner"===e.options.zoomType&&(e.zoomWrap.parent().css(g),e.zoomWindow.css(g)),e.options.tint&&(e.tintContainer.css(g),e.zoomTint.css(g),e.zoomTintImage.css(g))}}},doneCallback:function(){this.options.loadingIcon&&this.spinner&&this.spinner.length&&this.spinner.hide(),this.updateOffset(this),this.nzWidth=this.$elem.width(),this.nzHeight=this.$elem.height(),this.currentZoomLevel=this.options.zoomLevel,this.widthRatio=this.largeWidth/this.nzWidth,this.heightRatio=this.largeHeight/this.nzHeight,"window"===this.options.zoomType&&(this.nzHeight<this.options.zoomWindowHeight/this.heightRatio?this.lensHeight=this.nzHeight:this.lensHeight=this.options.zoomWindowHeight/this.heightRatio,this.nzWidth<this.options.zoomWindowWidth?this.lensWidth=this.nzWidth:this.lensWidth=this.options.zoomWindowWidth/this.widthRatio,this.zoomLens&&this.zoomLens.css({width:this.lensWidth,height:this.lensHeight}))},getCurrentImage:function(){return this.zoomImage},getGalleryList:function(){var i=this;return i.gallerylist=[],i.options.gallery?o("#"+i.options.gallery+" a").each(function(){var t="";o(this).data(i.options.attrImageZoomSrc)?t=o(this).data(i.options.attrImageZoomSrc):o(this).data("image")&&(t=o(this).data("image")),t===i.zoomImage?i.gallerylist.unshift({href:""+t,title:o(this).find("img").attr("title")}):i.gallerylist.push({href:""+t,title:o(this).find("img").attr("title")})}):i.gallerylist.push({href:""+i.zoomImage,title:o(this).find("img").attr("title")}),i.gallerylist},changeZoomLevel:function(o){this.scrollingLock=!0,this.newvalue=parseFloat(o).toFixed(2);var i=this.newvalue,t=this.largeHeight/(this.options.zoomWindowHeight/this.nzHeight*this.nzHeight),e=this.largeWidth/(this.options.zoomWindowWidth/this.nzWidth*this.nzWidth);"inner"!==this.options.zoomType&&(t<=i?(this.heightRatio=this.largeHeight/t/this.nzHeight,this.newvalueheight=t,this.fullheight=!0):(this.heightRatio=this.largeHeight/i/this.nzHeight,this.newvalueheight=i,this.fullheight=!1),e<=i?(this.widthRatio=this.largeWidth/e/this.nzWidth,this.newvaluewidth=e,this.fullwidth=!0):(this.widthRatio=this.largeWidth/i/this.nzWidth,this.newvaluewidth=i,this.fullwidth=!1),"lens"===this.options.zoomType&&(t<=i?(this.fullwidth=!0,this.newvaluewidth=t):(this.widthRatio=this.largeWidth/i/this.nzWidth,this.newvaluewidth=i,this.fullwidth=!1))),"inner"===this.options.zoomType&&(i>(t=parseFloat(this.largeHeight/this.nzHeight).toFixed(2))&&(i=t),i>(e=parseFloat(this.largeWidth/this.nzWidth).toFixed(2))&&(i=e),t<=i?(this.heightRatio=this.largeHeight/i/this.nzHeight,this.newvalueheight=i>t?t:i,this.fullheight=!0):(this.heightRatio=this.largeHeight/i/this.nzHeight,this.newvalueheight=i>t?t:i,this.fullheight=!1),e<=i?(this.widthRatio=this.largeWidth/i/this.nzWidth,this.newvaluewidth=i>e?e:i,this.fullwidth=!0):(this.widthRatio=this.largeWidth/i/this.nzWidth,this.newvaluewidth=i,this.fullwidth=!1));var n=!1;"inner"===this.options.zoomType&&(this.nzWidth>=this.nzHeight&&(this.newvaluewidth<=e?n=!0:(n=!1,this.fullheight=!0,this.fullwidth=!0)),this.nzHeight>this.nzWidth&&(this.newvaluewidth<=e?n=!0:(n=!1,this.fullheight=!0,this.fullwidth=!0))),"inner"!==this.options.zoomType&&(n=!0),n&&(this.zoomLock=0,this.changeZoom=!0,this.options.zoomWindowHeight/this.heightRatio<=this.nzHeight&&(this.currentZoomLevel=this.newvalueheight,"lens"!==this.options.zoomType&&"inner"!==this.options.zoomType&&(this.changeBgSize=!0,this.zoomLens.css({height:this.options.zoomWindowHeight/this.heightRatio})),"lens"!==this.options.zoomType&&"inner"!==this.options.zoomType||(this.changeBgSize=!0)),this.options.zoomWindowWidth/this.widthRatio<=this.nzWidth&&("inner"!==this.options.zoomType&&this.newvaluewidth>this.newvalueheight&&(this.currentZoomLevel=this.newvaluewidth),"lens"!==this.options.zoomType&&"inner"!==this.options.zoomType&&(this.changeBgSize=!0,this.zoomLens.css({width:this.options.zoomWindowWidth/this.widthRatio})),"lens"!==this.options.zoomType&&"inner"!==this.options.zoomType||(this.changeBgSize=!0)),"inner"===this.options.zoomType&&(this.changeBgSize=!0,this.nzWidth>this.nzHeight?this.currentZoomLevel=this.newvaluewidth:this.nzHeight>=this.nzWidth&&(this.currentZoomLevel=this.newvaluewidth))),this.setPosition(this.currentLoc)},closeAll:function(){this.zoomWindow&&this.zoomWindow.hide(),this.zoomLens&&this.zoomLens.hide(),this.zoomTint&&this.zoomTint.hide()},updateOffset:function(i){if("body"!==i.options.zoomContainerAppendTo){i.nzOffset=i.$elem.offset();var t=o(i.options.zoomContainerAppendTo).offset();i.nzOffset.top=i.$elem.offset().top-t.top,i.nzOffset.left=i.$elem.offset().left-t.left,i.pageOffsetX=t.left,i.pageOffsetY=t.top}else i.nzOffset=i.$elem.offset(),i.pageOffsetX=0,i.pageOffsetY=0},changeState:function(o){"enable"===o&&(this.options.zoomEnabled=!0),"disable"===o&&(this.options.zoomEnabled=!1)},responsiveConfig:function(i){return i.respond&&i.respond.length>0?o.extend({},i,this.configByScreenWidth(i)):i},configByScreenWidth:function(t){var e=o(i).width(),n=o.grep(t.respond,function(o){var i=o.range.split("-");return e>=i[0]&&e<=i[1]});return n.length>0?n[0]:t}};o.fn.ezPlus=function(i){return this.each(function(){var t=Object.create(e);t.init(i,this),o.data(this,"ezPlus",t)})},o.fn.ezPlus.options={container:"ZoomContainer",attrImageZoomSrc:"zoom-image",borderColour:"#888",borderSize:4,constrainSize:!1,constrainType:!1,containLensZoom:!1,cursor:"inherit",debug:!1,easing:!1,easingAmount:12,enabled:!0,gallery:!1,galleryActiveClass:"zoomGalleryActive",gallerySelector:!1,galleryItem:"a",galleryEvent:"click",imageCrossfade:!1,lensBorderColour:"#000",lensBorderSize:1,lensColour:"white",lensFadeIn:!1,lensFadeOut:!1,lensOpacity:.4,lensShape:"square",lensSize:200,lenszoom:!1,loadingIcon:!1,mantainZoomAspectRatio:!1,maxZoomLevel:!1,minZoomLevel:1.01,onComplete:o.noop,onDestroy:o.noop,onImageClick:o.noop,onImageSwap:o.noop,onImageSwapComplete:o.noop,onShow:o.noop,onHide:o.noop,onZoomedImageLoaded:o.noop,preloading:1,respond:[],responsive:!0,scrollZoom:!1,scrollZoomIncrement:.1,showLens:!0,tint:!1,tintColour:"#333",tintOpacity:.4,touchEnabled:!0,zoomActivation:"hover",zoomContainerAppendTo:"body",zoomId:-1,zoomLevel:1,zoomTintFadeIn:!1,zoomTintFadeOut:!1,zoomType:"window",zoomWindowAlwaysShow:!1,zoomWindowBgColour:"#fff",zoomWindowFadeIn:!1,zoomWindowFadeOut:!1,zoomWindowHeight:400,zoomWindowOffsetX:0,zoomWindowOffsetY:0,zoomWindowPosition:1,zoomWindowWidth:400,zoomEnabled:!0,zIndex:999}}(window.jQuery,window,document);