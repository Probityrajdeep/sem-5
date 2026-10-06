//rajdeep_842
const matrix = [[10, 45, 2], [8, 99, 14], [5, 23, 76]];
const arr = matrix.flat();
console.log("Sum:", arr.reduce((sum, val) => sum + val, 0));
console.log("Min:", Math.min(...arr));
console.log("Max:", Math.max(...arr));
