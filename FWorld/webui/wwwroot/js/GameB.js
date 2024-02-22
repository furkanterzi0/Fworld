document.querySelector(".btn_start").addEventListener("click", function () {
  document.querySelector(".game_box").classList.add("active");
});
let point = 0;
document.querySelector("#point").innerHTML = point;
const array = [
  "merhaba",
  "selam",
  "iyi",
  "günler",
  "kedi",
  "köpek",
  "masa",
  "sandalye",
  "kitap",
  "bilgisayar",
  "ev",
  "okul",
  "arkadaş",
  "ağaç",
  "güzel",
  "gökyüzü",
  "mavi",
  "turuncu",
  "bilim",
  "sanat",
  "spor",
  "tatil",
  "yazılım",
  "gezegen",
  "öğrenmek",
  "geliştirmek",
  "başarı",
  "sevgi",
  "huzur",
  "başlangıç",
  "bitiş",
  "mutlu",
  "sağlıklı",
  "başarılar",
  "başarısızlık",
  "deneyim",
  "macera",
];
let firstIndex = 0;
let lastIndex = 18;

function input() {
  for (let i = firstIndex; i < lastIndex; i++) {
    document
      .querySelector(".container")
      .insertAdjacentHTML("beforeend", `<p class="word-${i}">${array[i]}</p>`);
  }
}
input();

document.querySelector(`.word-${0}`).classList.add("class", "marker");

document.querySelector("#input").addEventListener("keydown", function (event) {
  if (event.key === " ") {
    event.preventDefault();
    control();
  }
});

let count = -1;
function control() {
  count++;
  let inputElement = document.querySelector("#input");

  if (array[count] === inputElement.value) {
    document.querySelector(`.word-${count}`).classList.add("true");
    document.querySelector(`.word-${count}`).classList.remove("marker");
    point++;
    document.querySelector("#point").innerHTML = point;
  } else {
    document.querySelector(`.word-${count}`).classList.add("false");
    document.querySelector(`.word-${count}`).classList.remove("marker");
  }

  inputElement.value = "";

  if (count === lastIndex - 1) {
    firstIndex = 18;
    lastIndex = 36;
    document.querySelector(".container").innerHTML = "";
    input();

    document
      .querySelector(`.word-${firstIndex}`)
      .classList.add("class", "marker");
  } else
    document
      .querySelector(`.word-${count + 1}`)
      .classList.add("class", "marker");
}
