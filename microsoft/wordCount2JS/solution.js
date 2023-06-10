const board = [
  ["o", "a", "a", "n"],
  ["e", "t", "a", "e"],
  ["i", "h", "k", "r"],
  ["i", "f", "l", "v"],
];

const words = ["oath", "pea", "eat", "rain"];

/**
 * @param {character[][]} board
 * @param {string[]} words
 * @return {string[]}
 */
var findWords = function (board, words) {
  // for each word search the first element posiction, that element can be at several row column values
  let solution;
  solution = searchFirstLetter(board, "i");
  console.log(solution)
//   console.log(`row: ${solution[0]?.row}, column: ${solution[0]?.column}`);

};

function searchFirstLetter(board, letter) {
  let result = [];
  // iterate row
  for (let row = 0; row < board.length; row++) {
    // iterate column
    for (let column = 0; column < board.length; column++) {
      // const element = array[colum];
      if (board[row][column] === letter) result.push({ row, column });
    }
  }
  return result; //did not find the first letter
}

findWords(board, words);
