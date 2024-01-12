const str1 = "РФкЙЦКоЙЦАФЫшЙАФкФЫВАФаЖЛДО";
const str2 = "ФАЖШЙсПЛЙеТЬИВдФАПлЙАоЙАП";
function searchWord(str) {
    const result = [];
    for (const symbol of str) {
        if(symbol != symbol.toUpperCase()){
            result.push(symbol);
        }
    }
    return result.join("");
}
const res1 = searchWord(str1);
console.log(res1);
const res2 = searchWord(str2);
console.log(res2);