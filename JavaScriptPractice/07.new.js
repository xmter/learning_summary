function create(){
    //1 创建一个空的对象
    let obj=new Object();
    // console.log(obj);//{}-------------------观察
    // console.log(typeof obj);//object

    // console.log(arguments);//{ '0': [Function: A], '1': [Function: B] }
    //2 获得构造函数
    let Con=[].shift.call(arguments);//shift()从数组中删除第一个元素，并返回删除的元素，该方法更改数组长度
    // console.log(arguments);//{ '0': [Function: B] }
    // console.log(Con);//[Function: A]
    // console.log(typeof Con);//function
    // console.log(Con.prototype);//A {}
    // console.log(typeof Con.prototype);//object
    
    //3 链接到原型上
     obj.__proto__=Con.prototype;
    //console.log( obj.__proto__);//A {}
    console.log(obj);//------------------链接到原型上后变化
    //4 绑定this，执行构造函数
    let result=Con.apply(obj,arguments);
    // console.log(result);//A {}


    // console.log(obj);//A{}------------------观察
    // 确保new出来的是个对象
    return (typeof result)==='object'?result:obj;
}
                            
console.log(create(function A() {var a=1},function B(){}));//A {}