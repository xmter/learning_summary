// for(var i=0;i<=5;i++){
//     setTimeout(function timer() {
//         console.log(i);
//     },i*1000);
// }
// for(var i=0;i<=5;i++){
//     (function(j){
//         setTimeout(function timer(){
//             console.log(j);
//         },j*1000);
//     })(i);
// }

for(var i=0;i<=5;i++){
    // setTimeout的第三个参数是回调函数的形参
    setTimeout(function timer(j){
        console.log(j);
    },i*1000,i)
}

// for(let i=0;i<=5;i++){
//     setTimeout(function timer(){
//         console.log(i);
//     },i*1000);
// }