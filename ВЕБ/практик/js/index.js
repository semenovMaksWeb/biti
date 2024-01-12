const queryString = location.search
const params = new URLSearchParams(queryString)

const name = params.get("name");
const checkBxodOne = params.get("checkBxodOne");
const pol = params.get("pol");
const comment = params.get("comment");
const about = params.get("about");


function createDiv(text, val) {
    const div = document.createElement("div");
    div.innerHTML = `${text}: <b>${val}<b>`;
    document.querySelector("main").append(div);
}

if (name) {
    createDiv("Ваше имя", name);
}

if (checkBxodOne) {
    createDiv("Вы зашли в 1 раз", checkBxodOne);
}

if (pol) {
    createDiv("Ваш пол", pol);
}

if (comment) {
    createDiv("Ваше комментарии", comment);
}

if (about) {
    createDiv("Вы узнали о нас", about);
}