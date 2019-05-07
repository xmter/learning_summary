function init(){
    addImg();
}
init();

var img,len;
var flag=true;

// 添加图片
function addImg(){
    var imgBox=document.getElementsByClassName('imgBox')[0];
    for(var i=0;i<50;i++){
        var num=Math.floor(Math.random()*10);
        var src='./pic1/'+num+'.jpg';
        var dom=document.createElement('img');
        dom.setAttribute('src',src);
        imgBox.appendChild(dom);   
    }
    // 动画
    bindEvent();
}

function bindEvent(){
    img=document.getElementsByTagName('img');
    len=img.length;
    console.log(len);
    var btn=document.getElementsByClassName('btn')[0];
    btn.addEventListener('click',function(){
        if(!flag){
            return;
        }
        flag=false;
        var endNum=0;
        for(var i=0;i<len;i++){
            (function(i){
                setTimeout(function(){
                    // 每一张图片调用运动函数
                    monition(img[i],'1s',function(){
                       // 第一个运动缩小
                    this.style.transform='scale(0)';
                        
                    },function(){
                        //每一张图片缩小后 回调函数 放大回到原位置
                        monition(this,'1s',function(){
                            this.style.transform='scale(1)';
                            this.style.opacity=0;
                        },function(){
                            // 记录所有图片的完成个数
                            endNum++;
                            // 如果所有的图片都完成前两个阶段运动 执行最后图片展示
                            if(endNum==len){
                                show();
                            }
                        }); 
                    })

                },Math.random()*1000);
            })(i)
        }
    });
}


// 封装运动函数
function monition(dom,time,doFun,cb){
    dom.style.transition=time;
    doFun.call(dom);
    var called=true;
    // 当所有图片运动完之后将锁打开
    dom.addEventListener('transitionend',function(){
        if(called){
            cb&&cb.call(dom);//如果cb存在，就执行cb
            called=false;
        }
    })
}

// 最后图片展示
function show(){
    var allEnd=0;
    for(var i=0;i<len;i++){
        img[i].style.transition='';
        // 先将图片向后移动一段距离作为旋转半径
        img[i].style.transform='rotateY(0deg) translateZ(-'+Math.random()*500+'px)';

        (function(i){
            setTimeout(function(){
                monition(img[i],'2s',function(){
                    this.style.opacity=1;
                    this.style.transform='rotateY(-360deg) translate(0)';

                },function(){
                    allEnd++;
                    // 记录完成图片数量 设置flag
                    if(allEnd==len){
                        flag=true;
                    }
                })   
            },Math.random()*1000);
        })(i)
    }
}