// 1 赋值一个对象---浅拷贝
// const obj={a:1};
// const copy=Object.assign({},obj);
// console.log(copy);

//深拷贝
// var obj1={a:0,b:{c:0}};
// let obj2=JSON.parse(JSON.stringify(obj1));
// obj1.a=4;
// obj2.b.c=4;
// console.log(obj2);//{ a: 0, b: { c: 4 } }

// 合并具有相同属性的对象
const o1={a:1,b:1,c:1};
const o2={b:2,c:2};
const o3={c:3};

const obj=Object.assign(o1,o2,o3);
console.log(obj);
console.log(o1);//注意目标对象自身也会变化