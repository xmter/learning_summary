// 原型即照猫画虎中的猫，
// JavaScript中的原型系统采用浅拷贝，即原型的引用
// 用原型来实现抽象和复用
// 实例.[[prototype]]=构造函数.prototype;
// 任何对象都有[[prototype]]这个私有属性，所以构造函数.prototype.[[prototype]]=两一个构造函数.prototype;
// 两一个构造函数.prototype.[[prototype]]=Object.prototype;Object.prototype.[[prototype]]=null;
// 构造函数.prototype.constractor=构造函数

// 绝大多数对象的最终都会继承自Object.Prototype,除了Object.create(指定的原型/null,[新对象]);

var cat={
    say(){
        console.log('meow-');
    },
    jump(){
        console.log('jump');
    }
}
var tiger=Object.create(cat,{
    say:{
        Writable:true,
        configurable:true,
        enumerable:true,
        value:function () {
            console.log('roar!');
        }
    }
});

var anotherCat=Object.create(cat);
anotherCat.say();
var anotherTiger=Object.create(tiger);
anotherTiger.say();