var x =0;
var y = "";

console.log("Hello World");

var theForm = document.getElementById("theForm");
theForm.hidden=true;

var buyButton = document.getElementById("buyButton");
buyButton.addEventListener("click", function ()  {
    console.log("Buying item");
})