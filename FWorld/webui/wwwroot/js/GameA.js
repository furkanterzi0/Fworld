document.querySelector("#strButton").addEventListener("click", startGame);

let count = 0;
let intervalId;
let total = 0;

function startGame() {
  intervalId = setInterval(changeNumber, 1000);
  document.querySelector("#strButton").disabled = true;
}

function changeNumber() {
  let min = 1;
  let max = 50;
  let randomInteger = Math.floor(Math.random() * (max - min + 1)) + min;
  total += randomInteger;
  document.querySelector(
    "#gamePlace"
  ).innerHTML = `<p style="color:white;"> ${randomInteger} </p>`;
  count++;
  console.log(randomInteger);
  if (count > 5) {
    clearInterval(intervalId);
    document.querySelector(
      "#gamePlace"
    ).innerHTML = `<button id="showTotal"> Sonucu Göster </button>`;
  }
  document.querySelector("#showTotal").addEventListener("click", function () {
    document.querySelector("#gamePlace").innerHTML = `<p style="color:red;"> ${total - randomInteger}`;
    document.querySelector("#restart").innerHTML = `<button id="restart-button">Restart Game</button>`;
    
      document.querySelector("#restart-button").addEventListener("click", function () {
          console.log("la havle");
          location.reload();
      });

    total = 0;
  });
}

