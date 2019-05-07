// 单对象编程
var drawingBoard = {
    cavs: document.getElementById('cavs'),
    ctx: document.getElementById('cavs').getContext("2d"),
    btn_container: document.getElementsByTagName('ul')[0],
    colorBtn: document.getElementById('colorChange'),
    lineRuler: document.getElementById('lineRuler'),
    imgsArr: [],
    // 入口函数
    init: function () {
        console.log(this.cavs);
        this.drawing();//绘画函数
        this.bthsAllfn();
    },
    drawing: function () {
        var self = this;
        var cavs = this.cavs;
        var c_left = cavs.offsetLeft;
        var c_top = cavs.offsetTop;

        this.cavs.onmousedown = function (e) {
            self.ctx.beginPath();
            self.ctx.moveTo(e.pageX - c_left, e.pageY - c_top);


            var img = self.ctx.getImageData(0, 0, self.cavs.offsetWidth, self.cavs.offsetHeight);
            self.imgsArr.push(img);
            console.log(self.imgsArr);



            this.onmousemove = function (e) {
                self.ctx.lineTo(e.pageX - c_left, e.pageY - c_top);
                self.ctx.stroke();
            }
            this.onmouseup = function (e) {

                self.ctx.closePath();
                this.onmousemove = null;
            }
            this.onmouseleave = function (e) {
                self.ctx.closePath();
                this.onmousemove = null;
            }
        }
    },
    bthsAllfn: function () {
        var self = this;
        this.btn_container.onclick = function (e) {
            switch (e.target.id) {
                case 'cleanBoard':
                    //清屏
                    self.ctx.clearRect(0, 0, self.cavs.offsetWidth, self.cavs.offsetHeight);
                    break
                case 'eraser':
                    //橡皮
                    self.ctx.strokeStyle = '#ffffff';
                    break
                case 'rescind':
                    //撤销
                    if (self.imgsArr.length > 0) {
                        self.ctx.putImageData(self.imgsArr.pop(), 0, 0);
                    }
                    break
            }
        }
        this.colorBtn.onchange = function () {//颜色改变
            console.log(this.value+"颜色改变")
            self.ctx.strokeStyle = this.value;
        }
        this.lineRuler.onchange = function () {//粗细改变
            console.log(this.value+"粗细改变")
            self.ctx.lineWidth = this.value;
        }
    }

}
drawingBoard.init();