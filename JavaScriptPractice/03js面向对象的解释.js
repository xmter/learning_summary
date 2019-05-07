// js对象的特征 ：具有唯一标识、有状态和行为即属性、动态性即可添加属性
var o={
    // 状态属性
    a:1,
    // 行为属性
    b(){
        console.log(2);
    }
};
// 动态性
o.c=3;
// 改变属性的特性
Object.defineProperty(o,"d",{value:4,writable:false,enumerable:false,configurable:true});
// 查看
Object.getOwnPropertyDescriptor(o,'a');
console.log(Object.getOwnPropertyDescriptor(o,'b'));
Object.getOwnPropertyDescriptor(o,'c');
Object.getOwnPropertyDescriptor(o,'d');//{ value: 4,writable: false,enumerable: false,configurable: true }
o.d=444;
console.log(o.d);//4，因为writable:false
