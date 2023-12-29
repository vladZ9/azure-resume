window.addEventListener("DOMContentLoaded", (event) => {
  getVisitCount();
});

const functionAPI = "http://localhost:7071/api/GetResumeCounter";

const getVisitCount = async () => {
  let count = 30;
  await fetch(functionAPI)
    .then((response) => {
      return response.json();
    })
    .then((response) => {
      console.log("Website called function API.");
      count = response.count;
      document.getElementById("counter").innerText = count;
    })
    .catch(function (error) {
      console.log(error);
    });
  return count;
};
