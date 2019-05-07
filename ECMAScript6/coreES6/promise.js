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

// promise
readFile("data/a.txt").then(res=>{
    console.log(res.toString());
    return readFile("data/b.txt");
}).then(res=>{
    console.log(res.toString());
    return readFile("data/c.txt");
}).then(res=>{
    console.log(res.toString());
})