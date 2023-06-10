// sliding window is l and r two pointers which update by conditions, within a loop

// const prices = [7,1,5,3,6,4] // stock prices
// const prices = [7,1,5,3,6,4] // stock prices
const prices = [7,6,4,3,1] // stock prices

// left is buy, right is sell, looking for lowest buy and highest sell


function solution(prices){

    let maxProfit = 0
    let left = 0 
    let right = 0

    for (let index = 0; index < prices.length - 1; index++) {

        right = index + 1
        if(prices[index] < prices[left]) left = index

        if(prices[right] > prices[left]){
            profit = prices[right] - prices[left]
            maxProfit = Math.max(maxProfit, profit)          
        }

    }

    return maxProfit
}

console.log(solution(prices))

