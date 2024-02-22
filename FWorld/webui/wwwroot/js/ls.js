let username = document.querySelector("#username").innerText;
let password = document.querySelector("#password").innerText;

if(username != "" && password != ""){
    localStorage.setItem("username", username);
    localStorage.setItem("password", password);
}



