if(localStorage.getItem("thema") == "light" || localStorage.getItem("thema") == null){
    applyLightMode();
    localStorage.setItem("isLightMode", "true");
}
else{
    applyDarkMode();
    localStorage.setItem("isLightMode", "false");
}

document.querySelector("#icon-button").addEventListener("click", toggleMode);

function toggleMode(){
    if(localStorage.getItem("isLightMode")=="true")
    {
        applyDarkMode();
        localStorage.setItem("isLightMode", "false");
    }
    else
    {
        applyLightMode();
        localStorage.setItem("isLightMode", "true");
    }
   
}

function applyDarkMode() {
    localStorage.setItem("thema", "dark");

    document.querySelector("#navbar").setAttribute("class","navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark border-bottom box-shadow mb-3")
    document.querySelector("#navbar").setAttribute("style","transition: 2s ease");

    document.querySelector("#thema-link").setAttribute("href","/css/darkMode.css?v=toad1JILcEQCTHxxHofGTQT1y36jAqnu31zakaQogWk");

}

function applyLightMode() {
    localStorage.setItem("thema","light");
    
    document.querySelector("#navbar").setAttribute("class","navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-light border-bottom box-shadow mb-3")

    document.querySelector("#thema-link").setAttribute("href","/css/lightMode.css?v=toad1JILcEQCTHxxHofGTQT1y36jAqnu31zakaQogWk");

}
