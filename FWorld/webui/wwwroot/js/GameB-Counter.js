document.querySelector(".btn_start").addEventListener("click", function () {
  var counter = 20;
  var intervalId;
  function increaseCounter() {
    counter--;
    if (counter > -1) document.getElementById("counter").innerHTML = counter;
    else {
      clearInterval(intervalId);
      alert("süre bitti"); //son yapilan puanı local storage ile yaz ve süre bittiginde başla yazısında dön
      document.querySelector(".card.game_box").innerHTML = `
             <header class="card-header">
                <p class="title" style="text-align: center;">Word Game</p>
            </header>

            <div style="display: flex; justify-content: center;">
                <section class="card-body">
                    <div class="point" style="display: flex; justify-content: center; align-items: center;">
                        <p style="margin-right: 5px;"> puan: ${point} </p>
                    </div>
                    <div class="restart" style="display: flex; justify-content: center; align-items: center;">
                        <button id="restart">Restart Game</button>
                    </div>
                </section>
            </div>`;
      document.getElementById("restart").addEventListener("click", function () {
        location.reload();
      });
    }
  }

  intervalId = setInterval(increaseCounter, 1000);
});
