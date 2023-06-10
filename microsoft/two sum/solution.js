// let nums = [3, 2, 4];
// const target = 6;

const nums = [2,7,11,15] 
const target = 9

function solution() {
  let mp = new Map();

  for (let index = 0; index < nums.length; index++) {
    let diff = target - nums[index];

    if (mp.has(diff)) return [mp.get(diff), index];

    if (!mp.has(nums[index])) mp.set(nums[index], index);
  }
}

const result = solution()
console.log(result)