// l 利用字面量
var a=[],b={},c=/abc/g;
console.log(typeof c)//object
// 2 利用dom api
// var d=document.createElement('div');
// 3利用JavaScript内置对象的api
var e=Object.create(null);
console.log(e);//{}
var f=Object.assign({k1:3,k2:8},{k3:9});
console.log(f);//{ k1: 3, k2: 8, k3: 9 }
var g=JSON.parse('{}');
console.log(g);

// 4.利用装箱转换
var h=Object(undefined);
console.log(typeof h);
var i=Object(null);
console.log(typeof i);
var k=Object(1);
console.log(typeof k);
var l=Object('abc');
console.log(typeof l);
var m=Object(true);
console.log(typeof m);