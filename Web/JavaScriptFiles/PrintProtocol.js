function printf() {
    
    document.getElementById("aTag").style.display = "none";
    document.getElementById("form").style.border = "none";
    var arr = document.querySelectorAll("input");
    for (var i = 0; i < arr.length; i++) {
        arr[i].style.border = "none";
    }       
    window.print();
    
}

function load() {
    const el = document.getElementById("aTag");
    el.addEventListener("click", () => { window.print(); });
    fillFile();
    
}

function fillSign(idIn,idOut) {
    document.getElementById(idIn).innerHTML = document.getElementById(idOut).value;
}