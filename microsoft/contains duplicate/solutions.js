
// const nums = [1,2,3,1]
const nums = [1,2,3,4]

function solution(){

    const st = new Set()
    
    for (let index = 0; index < nums.length; index++) {
        
        if(st.has(nums[index])) return true

        st.add(nums[index])
        
    }

    return false

}

console.log(solution(nums))