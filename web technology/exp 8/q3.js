//rajdeep_842
let n = 20, i = 2;
do {
    let isPrime = true;
    for (let j = 2; j < i; j++) {
        if (i % j === 0) isPrime = false;
    }
    if (isPrime) console.log(i);
    i++;
} while (i <= n);
