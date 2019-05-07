const fs=require("fs");

// 简单封装，fs封装完成一个promise
const readFile=function(fileName){
    return new Promise((resolve,reject)=>{
        fs.readFile(fileName,(err,data)=>{
            if(err){
                reject(err);
            } 
            resolve(data);
        })
    });
}

// async 
// 配合await使用
async function fn(){
    let f1=await readFile('data/a.txt');
    console.log(f1.toString());
    let f2=await readFile('data/b.txt');
    console.log(f2.toString());
    let f3=await readFile('data/c.txt');
    console.log(f3.toString());
}

console.log(fn()); //直接调用就行