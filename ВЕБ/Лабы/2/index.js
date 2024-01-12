const student1 = {
    "Ivan" : ["5/5", "50/50", "10/10", "10/10"],
    "Olga" : ["4/8", "50/57", "7/10", "10/18"],
    "Alexey" : ["8/10", "22/25", "3/5", "5/5"],
    "Boris" : ["3/3", "20/20"]
}
const student2 = {
    "Zinaida" : ["10/10"],
    "Kristina" : ["30/30"],
    "Ivan" : ["100/100"],
    "Alexey" : ["1/1"]
}
const student3 = {
    "Zinainda" : ["10/10", "2/4"],
    "Fedor" : ["7/9", "2/3"]
}

function points100(student) {
    const result = [];
    for (const key in student) {
        const element = student[key];
        let check = true;
        for (const item of element) {
            const array = item.split('/');
            if(array[0] != array[1]){
                check = false;
                break;
            }
        }
        if(check) {
            result.push(key);
        }
    }
    return result.sort();
}

const res1 = points100(student1);
const res2 = points100(student2);
const res3 = points100(student3);
console.log(res1);
console.log(res2);
console.log(res3);
