// ---------------------------------------------------------------------------
//基本上所有函数都有prototype属性
function A(){

}
console.log(A.prototype);//A {}
 
//例外
let fun=Function.prototype.bind();
console.log(fun.prototype);//undefind
// ------------------------------------------------------------------------------
