// изменить на свою маг матрицу
const matrix = [
  [28, 19, 10, 1, 48, 39, 30],
  [29, 27, 18, 9, 7, 47, 38],
  [37, 35, 26, 17, 8, 6, 46],
  [45, 36, 34, 25, 16, 14, 5],
  [4, 44, 42, 33, 24, 15, 13],
  [12, 3, 43, 41, 32, 23, 21],
  [20, 11, 2, 49, 40, 31, 22],
];
// изменить на свою строчку
const str = "Прохладная вода хорошо освежила уставших ребят";

const result = [];

const findIndex = (index, chart) => {
  for (const [rowIndex, rowValue] of matrix.entries()) {
    for (const [colIndex, colValue] of rowValue.entries()) {
      if (colValue == index) {
        if (!result[rowIndex]) {
          result[rowIndex] = [];
        }
        result[rowIndex][colIndex] = chart;
      }
    }
  }
};

 
let index = 0;
for (const chart of str) {
  index++;
  findIndex(index, chart);
}
console.log(result);
