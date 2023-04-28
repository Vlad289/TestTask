function validSolution(board){

    //кожна строчка провіряється
    for(let i = 0;i<9;i++){
        for(let j = 0;j<9;j++){
            if(!board[i].includes(j+1)){
                return false;
            }
        }
    }

    //кожен столбік провіряється
    for(let i = 0;i<9;i++){
        const tempArr = new Array();
        for(let j = 0;j<9;j++){
            tempArr.push(board[j][i]);
        }
        for(let j = 0;j<9;j++){
            if(!tempArr.includes(j+1)){
                return false;
            }
        }
        
    }

    //провірити по полям чи є всі числа в кожному блоці
    for(let y = 1;y<=7;y += 3){

        for(let x = 1;x<=7;x += 3){

            const arr = new Array();
            
            for(let i = x;  (i - x) < 3;    i++){
                for(let j = y;  (j - y) < 3;    j++){
                    arr.push(board[i-1][j-1]);
                }
            }

            for(let c = 0;c<9;c++){
                if(!arr.includes(c+1)){
                    return false;
                }
            }
        }
    }

    
    return true;
    
}


  console.log(validSolution([
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 5, 3, 4, 8],
    [1, 9, 8, 3, 4, 2, 5, 6, 7],
    [8, 5, 9, 7, 6, 1, 4, 2, 3],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 6, 1, 5, 3, 7, 2, 8, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 4, 5, 2, 8, 6, 1, 7, 9]
  ])
  );  