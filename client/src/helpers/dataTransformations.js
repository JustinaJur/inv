// creates array of objects from one one dimentinal array and one 2d arrays
export const createObjectsFromTwoArrays = (array, TwoDArray) => {
    let result = [];

    for (let i = 0; i < TwoDArray.length; i++) {
      let obj = {};

      for (let j = 0; j < array.length; j++) {
        obj[array[j]] = TwoDArray[i][j];
      }

      result.push(obj);
    }

    return result;
  }