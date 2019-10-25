class BinarySearch {
    doBinary(arr, lb, ub, elem) {
        let index = parseInt((lb + ub) / 2);
        if(arr[index] === elem) return index;
        else if(ub <= lb) return -1;
        else if(elem > arr[index]) return doBinary(arr, index, arr.length, elem);
        else return doBinary(arr, 0, index, elem);
    }

    binarySearch(arr, elem) {
        return doBinary(arr, 0, arr.length - 1, elem);
    }
}

const arr = [-2, 0, 2,  6, 8, 12, 17, 54];
console.log(new BinarySearch().binarySearch(arr, 12));

function linearSearch(arr, elem) {
    for(let i = 0; i < arr.length; i++) {
        if(arr[i] == elem) return i;
    }
    return -1;
}

console.log(linearSearch(arr, -3));
