// var o=new Object();
// // 添加属性
// o[Symbol.iterator]=function(){
//     var v=0;
//     return {
//         next:function(){
//             return {value:v++,done:v>10}
//         }
//     }
// };
// // for..of
// for(var value of o){
//     console.log(value);
// }


var a = {
    x: 10,
    y: 20,
  };
  
  for (var [name, value] in Iterator(a)) {
    console.log(name, value);   
  }


//除了字符串做key，Symbol也可以做
// var sym=Symbol('a');
// var o={
//     sym:5
// }
// console.log(typeof sym);
// console.log(typeof o.sym);
// console.log(typeof o['sym']);
// console.log(o.sym);