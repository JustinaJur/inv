export const getCurrrentDate = () => {
  const dateObj = new Date();
  const month = dateObj.getUTCMonth() + 1;
  const day = dateObj.getUTCDate();
  const year = dateObj.getUTCFullYear();

  const pMonth = month.toString().padStart(2, "0");
  const pDay = day.toString().padStart(2, "0");
  const currentPaddedDate = `${year}-${pMonth}-${pDay}`;
  return currentPaddedDate;
};

export const getPreviousMonth = () => {
  const currentDate = new Date();
  currentDate.setMonth(currentDate.getMonth() - 1);

  const year = currentDate.getUTCFullYear();
  const month = (currentDate.getUTCMonth() + 1).toString().padStart(2, "0");

  return `${year}-${month}`;
};
