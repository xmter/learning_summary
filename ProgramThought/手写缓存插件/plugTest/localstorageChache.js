  // 安装一个新的缓存引擎
  NetEaseCaches.getInstance().install('LOCAL_STORAGE', {
    __init__: function () { 
        console.log(localStorage);
    },//此方法不想让外面人访问

    set: function (options) {
        console.log('自己安装的LOCAL_STORAGE的set');
    },
    get: function (options) {
        console.log('自己安装的LOCAL_STORAGE的get');
    }
});