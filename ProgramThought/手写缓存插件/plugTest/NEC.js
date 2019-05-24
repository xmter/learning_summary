     // 缓存架构应该满足一下几点：
        //1.兼容性（原生js）
        //2.开闭原则（设计模式）----不大
        //3.扩展性（无论资源还是数据缓存，无论内存还是文件或者是数据库）---插件多
        //4.应用起来简单
        //5.面向接口的设计

        // 开始写

        // 闭包

        (function (global, factory, name) {
            // 函数体

            return global[name] = factory.call(global);
        })(this, function () {
            // 闭包环境
            var __E_TYPES__ = {
                MEMORY: 'MEMORY',
            }
            // 缓存引擎 
            var __ENGINES__ = {
                // 默认引擎--支持内存引擎
                [__E_TYPES__.MEMORY]: {
                    __init__: function () {
                        this.pools = this.pools || {};
                    },//此方法不想让外面人访问

                    set: function (options) {
                        this.pools || this.__init__();
                        this.pools[options.key] = options.data;
                        console.log('默认的内存缓存引擎的set');
                    },
                    get: function (options) {
                        this.pools || this.__init__();
                        console.log('默认的内存缓存引擎的get');
                        return this.pools[options.key];
                    },
                    remove:function(){
                        delete this.pools[options.key];
                    }
                },
            };

            // 保护架构的核心功能---用单例模式
            var __CACHE__ = {
                // 需求
                // 一类人
                install: function (type, object) {
                    __E_TYPES__[type] = type;
                    __ENGINES__[type] = object;
                    __ENGINES__[type].__init__();
                },//安装某一个缓存机制
                uninstall: function () { },//卸载某一个缓存机制
                //另一类人    
                set: function (type, ops) {
                    __ENGINES__[type || __E_TYPES__.MEMORY].set(ops);
                },//存
                get: function (type, ops) {
                    return __ENGINES__[type || __E_TYPES__.MEMORY].get(ops);
                },//取
                remove:function(type, ops){
                    return __ENGINES__[type || __E_TYPES__.MEMORY].remove(ops);
                }//移除
            };
            // __CACHE__.install(__ENGINES__.MEMORY);
            // __ENGINES__[type].init();
            // return  __CACHE__;
            return {
                TYPES: __E_TYPES__,
                getInstance: function () {
                    return __CACHE__;
                }
            }
        }, 'NetEaseCaches');
        // this 随着环境的改变，也不同
        // BOM环境下运行这个js this===window
        // nodejs环境下运行这个js this===modules
        // seajs环境下运行这个js  this===define