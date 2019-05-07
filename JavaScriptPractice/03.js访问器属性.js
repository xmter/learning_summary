var o={
    get a(){
        return 1;
    },
    set a(num){
        // console.log(this.a);
        // console.log(num);
        this.a=num;
    }
};
console.log(o.a+'get');
o.a=5;
console.log(o.a+'set');
// get和set关键字创建的precent属性的getter和setter函数-----------------------------------------------
// var o={
//     num:10,
//     // 通过get和set关键字创建的precent属性的getter和setter函数。
//     get precent(){
//         return this.num+'%';
//     },
//     set precent(value){
//         console.log('update_num:'+value);
//         this.num=value;
//     }
// }
// console.log(o.precent);
// o.precent=60;
// console.log(o.precent);

//对已有的对象上添加getter和setter----------------------------------------------------------------------------
// var o={
//     num:10
// }
// // 添加
// Object.defineProperty(o,'precent',{
//     // 可读
//     get:function(){
//         return this.num+'%';
//     },
//     // 可写
//     set:function(value){
//         console.log('update_num:'+value);
//         this.num=value;
//     }
// });

// console.log(o.precent);
// o.precent=60;
// console.log(o.precent);

// ES6 类中的getter和setter----------------------------------------------------------------------
// class O{
//     constructor(num){
//         this.num=num;
//     };
//     get precent(){
//        return this.num+'%';
//     };
//     set precent(value){
//         console.log('update_num:'+value);
//         this.num=value;
//     }
// }
// var o=new O(30); 
// console.log(o.precent);
// o.precent=60;
// console.log(o.precent);