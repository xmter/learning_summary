// 只暴露一个全局函数createBannerArea
function createBannerArea(areaDom, options) {
    var imgArea = document.createElement("div");//图片区域的div
    var numberArea = document.createElement("div");//角标区域的div
    
    var curIndex=0;//当前显示的第几张轮播图
    var changeTimer=null;//自动切换的计时器
    var changeDuration=3000;//3毫秒是间隔时间
    var timer=null;//动画计时器

    // 1.创建一个区域，用于显示图片
    initImgs();
    // 2.创建一个区域，用于显示角标
    initNumbers();
    // 3.设置状态
    setStatus();
    // 4.自动切换
    autoChange();

    // 下面的都是局部函数
    /**
       * 初始化图片区域
    */
    function initImgs() {
        imgArea.style.width="100%";
        imgArea.style.height="100%";
        imgArea.style.display="flex";
        imgArea.style.cursor="pointer";
        imgArea.style.overflow="hidden";
        for(let i=0;i<options.length;i++){
            var obj=options[i];
            var img=document.createElement("img");
            img.src=obj.imgUrl;
            img.style.width="100%";
            img.style.height="100%";
            img.style.marginLeft='0';//初始化为0 因为默认是auto
            img.addEventListener("click",function(){
               location.href=options[i].link; 
            })
            imgArea.appendChild(img);
        }
        areaDom.addEventListener("mouseenter",function(){
            clearInterval(changeTimer);
            changeTimer=null;
        })
        areaDom.addEventListener("mouseleave",function(){
            autoChange();
        })
        areaDom.appendChild(imgArea);
    }
    /**
     * 初始化角标
     */
    function initNumbers(){
        numberArea.style.textAlign="center";
        numberArea.style.marginTop="-25px";
        for(var i=0;i<options.length;i++){
            var sp=document.createElement("span");
            sp.style.width="12px";
            sp.style.height="12px";
            sp.style.backgroundColor="black";
            sp.style.display='inline-block';
            sp.style.margin="0 7px";
            sp.style.borderRadius="50%";
            sp.style.cursor="pointer";
            (function(index){
                sp.addEventListener("click",function(){
                    curIndex=index;
                    setStatus();
                })
            })(i)
            numberArea.appendChild(sp);
        }
        areaDom.appendChild(numberArea);
    }

    /**
     * 设置整个区域的状态
     */
    function setStatus(){
        //1.设置圆圈的背景颜色
        for(let i=0;i<options.length;i++){
            if(i===curIndex){
                // 当前要显示轮播图
                // 设置背景状态为选中状态
                numberArea.children[i].style.backgroundColor="red";
            }else{
                //设置背景状态为普通状态 
                numberArea.children[i].style.backgroundColor="black";
            }
        }

        // 显示图片---不平滑不匀速
        // var targetMarginLeft=curIndex*-100;
        // imgArea.children[0].style.marginLeft=targetMarginLeft+"%";
        // 显示图片---平滑处理
        var start=parseInt(imgArea.children[0].style.marginLeft);
        var end=curIndex*-100;
        var dis=end-start;
        var duration=500;
        var speed=dis/duration;

        timer=setInterval(function(){
            start+=speed*20;
            imgArea.children[0].style.marginLeft=start+'%';
            if(Math.abs(end-start)<1){
                imgArea.children[0].style.marginLeft=end+'%';
                clearInterval(timer);
            }
        },20);
    }
    /**
     * 自动切换图片
     * 
     */
    function autoChange(){
        if(changeTimer){
            return;
        }
        changeTimer=setInterval(function(){
            if(curIndex===options.length-1){
                curIndex=0;
            }else{
                curIndex++;
            }
            setStatus();
        },changeDuration);
    }
}

