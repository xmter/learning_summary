// 污染全局变量---解决办法

// 单对象方法

/**
 * 创建一个瀑布流
 * @param {*} areaDom 容器
 * @param {*} urls 图片的url地址数组
 * @param {*} everyWidth 每张图片的宽度
 */
function createWaterFall(areaDom, urls, everyWidth) {
    4
    var colNumber = 0;//有多少列
    var gap = 0;//每一列的间隙
    // 1.
    createImgDoms();
    // 2.
    setImgPosition();

    // 窗口改变事件
    window.onresize = function () {
        // setImgPosition();
        // console.log('aaaa');


        //有些事件触发太频繁---用函数防抖
        var timer = null;
        if (timer) {
            clearTimeout(timer);
        }
        timer = setTimeout(function () {
            setImgPosition();
        }, 500);

    }

    // 函数区---写里面是减少污染全局变量
    /**
     * 创建图片的dom对象
     */
    function createImgDoms() {
        for (let i = 0; i < 200; i++) {
            var num=Math.floor(Math.random()*10);
            var url='../demo6/pic1/'+num+'.jpg';            
            console.log(url);
            var img = document.createElement('img');
            img.src = url;
            img.style.width = everyWidth + "px";
            img.style.position = 'absolute';

            img.onload = function () {
                setImgPosition();
            };
            // 横纵坐标
            // img.style.left='';
            // img.style.top='';
            areaDom.appendChild(img);
        }
    }
    /**
     * 设置每张图片的坐标
     */
    function setImgPosition() {
        // 有多少列？
        cal();
        //找每一列最短的，添加
        var colY = new Array(colNumber);//存放的是每一列的下一个图片的Y坐标


        // 初始是colY=[0,0,0,0,0,0];
        // 找最小--摆放图片 ，此时 colY=[70,0,0,0,0,0];
        //......到 colY=[70,20,50,30,70,60];
        // ....到找最下是20 --摆放图片 更改colY=[70,92,50,30,70,60];
        // 横坐标通过列数算



        colY.fill(0);//初始化数组
        for (var i = 0; i < areaDom.children.length; i++) {
            console.log(areaDom.children.length)
            var img = areaDom.children[i];
            //找到colY中的最小值
            var y = Math.min(...colY);//...展开运算符，展开数据
            // x坐标
            // 第几列
            var index = colY.indexOf(y);
            var x = (index + 1) * gap + index * everyWidth;

            // 设置图片坐标
            img.style.left = x + 'px';
            img.style.top = y + 'px';

            // 更新数组
            // img.height是异步，解决办法用onload事件
            colY[index] += parseInt(img.height) + gap;
        }
        //找到数组中最大的数字
        var height = Math.max(...colY);
        areaDom.style.height = height + 'px';
    }

    /**
     * 计算有多少列
     */
    function cal() {
        var containerWidth = parseInt(areaDom.clientWidth);
        console.log(containerWidth);
        // 多少列
        colNumber = Math.floor(containerWidth / everyWidth);
        //剩余空间
        var space = containerWidth - colNumber * everyWidth
        //每列间隙
        gap = space / (colNumber + 1);

    }
}