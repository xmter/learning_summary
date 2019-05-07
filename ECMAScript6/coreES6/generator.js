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

// generator
function * gen(){
    yield readFile("data/a.txt");
    yield readFile("data/b.txt");
    yield readFile("data/c.txt");
}

let g1=gen();

g1.next().value.then(res=>{
    console.log(res.toString());
    return g1.next().value;
}).then(res=>{
    console.log(res.toString());
    return g1.next().value;
}).then(res=>{
    console.log(res.toString());
    console.log(res.toString());
    console.log(res.toString());
})