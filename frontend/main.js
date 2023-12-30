window.addEventListener("DOMContentLoaded", (event) => {
  getVisitCount();
});

const functionApiUrl =
  "https://getresumecountervlad.azurewebsites.net/api/GetResumeCounter?code=ye9F15j7zzvPc8Gu1wbG73GeaGwMgMJwBqHJuEwORB_oAzFuczNZDA==";
const localfunctionApi = "http://localhost:7071/api/GetResumeCounter";

const getVisitCount = async () => {
  let count = 30;
  await fetch(functionApiUrl)
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
