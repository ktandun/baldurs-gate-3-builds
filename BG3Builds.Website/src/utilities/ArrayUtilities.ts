export const crossProduct = <T>(arrayOne: T[], arrayTwo: T[]) => {
  let result: T[][] = [];
  arrayOne.forEach(function (a) {
    arrayTwo.forEach(function (b) {
      result.push([a, b]);
    });
  });
  return result;
};
