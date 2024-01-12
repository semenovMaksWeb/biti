const position = [0,0];

//s - север
//v - восток
//u - юг
// z - запад
function move(s, v, u, z) {
    
    if(s && typeof s == "number"){
        position[1] += s;
    }

    if(v && typeof v == "number"){
        position[0] += v;
    }

    if(u && typeof u == "number"){
        position[1] -= u;
    }

    if(z && typeof z == "number"){
        position[0] -= z;
    }
    document.body.innerHTML = `Позиция робота: ${position}`;
}

// move(20, 30, 10, 40);
// move();
// move(-10, 20, 10);

move(10,10);
move(0,0,5);