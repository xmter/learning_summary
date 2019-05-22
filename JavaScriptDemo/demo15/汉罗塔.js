
// 获取每根柱子
var c1 = document.getElementById("c1");
var c2 = document.getElementById("c2");
var c3 = document.getElementById("c3");

var minWidth = 50; //最小汉诺塔宽度
var step = 30; //递增宽度

// 每根柱子上的方块编号数组---当前汉罗塔的摆放
var columns = {
    c1: [3, 2, 1],
    c2: [],
    c3: []
}

// this.dataset.from,

/**
 * 初始化函数
 */
function show() {
    // 创建汉罗塔
    showColumn(c1,columns.c1);
    showColumn(c2,columns.c2);
    showColumn(c3,columns.c3);
    function showColumn(columnDom,nums){
        // 先清空
        columnDom.innerHTML = "";
        //创建
        for(const n of nums){
            console.log(n);
            var div=document.createElement("div");
            div.style.width=minWidth+(n - 1) * step + "px";
            columnDom.appendChild(div);
        }
    }
}
function eventForBtns() {
    var btns = document.querySelector(".buttons").querySelectorAll("button")
    for (const btn of btns) {
        // console.log(btn);
        eventForBtn(btn);
    }

    function eventForBtn(btn) {
        var fromArr = columns[btn.dataset.from];
        var toArr = columns[btn.dataset.to];
        btn.onclick = function () {
            if (fromArr.length === 0) {
                return;
            }
            if (toArr.length === 0) {
                change(fromArr, toArr);
            }
            else {
                var fromLast = fromArr[fromArr.length - 1];
                var toLast = toArr[toArr.length - 1];
                if (fromLast < toLast) {
                    change(fromArr, toArr);
                }
            }
        }
    }

    function change(fromArr, toArr) {
        toArr.push(fromArr.pop());
        show();
        if (columns.c1.length === 0 && columns.c2.length === 0) {
        //    console.log('成功');
        document.querySelector(".gameover").style.display="block";
        isOver = true;
        }
    }
}





show();
eventForBtns();