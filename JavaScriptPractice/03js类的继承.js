class Animal{
    constructor(name){
        this.name=name;
    };
    speak(){
        console.log(this.name+' makes a noise');
    }
}
class Dog extends Animal{
    constructor(name){
        super(name);
    };
    speak(){
        console.log(this.name+' braks');
    }
}

let d=new Dog('Mitzie');
d.speak();