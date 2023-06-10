
const nums = [1,2,3,4]
// const nums = [-1,1,0,-3,3]
// const nums = [4,3,2,1,2]

function solution(nums){
    let results = prePass(nums)
    results = postPass(nums, results)

    return results
}

// fills the results array with pre-position acumulated results
function prePass(nums){
    
    let results = [ 1 ]
    let acumulated = 1

    for (let index = 1; index < nums.length; index++) {
        acumulated *= nums[index-1]
        results.push(acumulated)
    }

    return results
}

// updates the results array with post-position acumulated results
function postPass(nums, preResults){
    
    let acumulated = nums[nums.length - 1]

    for (let index = nums.length - 2; index >= 0; index--) {
        preResults[index] *= acumulated 
        acumulated *= nums[index]
    }

    return preResults
}


console.log(solution(nums))