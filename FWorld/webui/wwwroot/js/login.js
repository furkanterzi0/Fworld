if(localStorage.getItem("username") != null && localStorage.getItem("password") != null)
{
    document.querySelector("#inputUsername").value=localStorage.getItem("username");
    document.querySelector("#inputUsername").classList.add("remember");

    document.querySelector("#inputPassword").value=localStorage.getItem("password");
    document.querySelector("#inputPassword").classList.add("remember");

    document.querySelector("#forgetme").innerHTML=`<button id="forgetButton"> forget me </button>`
}
document.querySelector("#forgetButton").addEventListener("click",function(event){
    event.preventDefault();
    localStorage.removeItem("username");
    localStorage.removeItem("password");
    location.reload();
    
});