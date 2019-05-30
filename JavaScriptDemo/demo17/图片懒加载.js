// 开始图片懒加载
// defaultImg：默认图片
function startLazy(defaultImg) {
    // 0.想得到所有需要懒加载的图片---学会使用'img[data-src]'
    var imgs = document.querySelectorAll('img[data-src]');

    // 将其转换为真实的数组---因为imgs是一个类数组
    // var arr=[].slice.call(imgs)
    imgs = Array.from(imgs);

    // 1.设置默认图片
    setDefaultImgs();
    // 2.加载所有图片
    loadAllImgs();
    // 3.滚动事件
    // document.body.onscroll=function(){
    //     loadAllImgs();
    // } 改进---加上防抖-减少触发的频率
    var timer = null;
    document.body.onscroll = function () {
        if (timer) {
            clearTimeout(timer);
        }
        timer = setTimeout(function () {
            loadAllImgs();
        }, 500)
    }


    // 函数区

    //设置默认图片
    function setDefaultImgs() {
        if (!defaultImg) {
            // 没有默认图片
            return;
        }
        // 得到所有需要懒加载的图片-有data-src的图片
        for (var i = 0; i < imgs.length; i++) {
            var img = imgs[i];
            img.src = defaultImg;

        }
    }

    // 懒加载所有图片
    function loadAllImgs() {
        // console.log('loadAllImgs');测试
        for (var i = 0; i < imgs.length; i++) {
            var img = imgs[i];
            // loadImg(img);优化
            if (loadImg(img)) {
                // 加载了图片
                // 去除掉已经加载的图片
                imgs.splice(i, 1);
                // 同时
                i--;
            }

        }
    }
    // 懒加载一张图片
    // img：图片的dom对象
    function loadImg(img) {
        // 判断该图片是否能够加载----也就是判断图片是否在可视区域viewport
        // 每个dom对象都有一个函数 getBoundingClientRect()
        // getBoundingClientRect用于获取某个元素相对于视窗的位置集合。集合中有top, right, bottom, left等属性。 
        var rect = img.getBoundingClientRect();
        if (rect.bottom <= 0) {
            return false;
        }
        if (rect.top >= document.documentElement.clientHeight) {
            return false;
        }

        //加载图片
        img.src = img.dataset.src;//自定义data-src属性的获取
        // 加载图片优化--判断是否有原图
        if (img.dataset.original) {
            // 等待图片加载完成 图片也要onload事件
            img.onload = function () {
                // 为了看出测试效果加的计时器
                // setTimeout(function(){
                //     img.src = img.dataset.original;
                // }, 1000);
                img.src = img.dataset.original;
                img.onload = null;
            }
        }

        return true;
    }

}