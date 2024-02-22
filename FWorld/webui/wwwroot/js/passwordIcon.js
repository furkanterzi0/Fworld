/* Show Password */
document.querySelector("#icon").addEventListener("mouseover", function () {
  document.querySelector("#icon").setAttribute("class", "fa-solid fa-eye");
  document.querySelector("#inputPassword").removeAttribute("type");
});
document.querySelector("#icon").addEventListener("mouseout", function () {
  document.querySelector("#icon").setAttribute("class", "fa-solid fa-eye-slash");
  document.querySelector("#inputPassword").setAttribute("type", "password");
});
