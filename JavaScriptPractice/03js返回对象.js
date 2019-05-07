
function cls(){
    this.a=100;
    return {
        getValue:()=>this.a
    }
}
// cls构造器返回了一个新的对象，而不是this，所以在外面访问不到o.a----即私有
var o=new cls;
console.log(o.getValue());//100
console.log(o.a);//undefined