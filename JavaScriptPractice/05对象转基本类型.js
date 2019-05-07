// 首先清楚一点，对象转基本类型，根据  [Symbol.toPrimitive](),valueOf(),toString()调用优先级决定
let  a={
    // 优先级次之2
    valueOf(){
        return 0;
    },
    // 优先级最低3
    toString(){
        return 1;
    },
    // 优先级最高1
    [Symbol.toPrimitive](){
        return 2;
    }
};
console.log(a);
console.log(a+1);
console.log(typeof (a+1));
console.log('1'+a);