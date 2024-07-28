


function GetAllResponsibles() {
    if (IsAllowingAccess(false) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        //התחברות לשרת
        var arrReponsibles;
        axios.get('https://localhost:44351/api/Responsibles/GetAllResponsibles').then(
            (response) => {
                console.log(response)
                arrReponsibles = response.data;
                
                var body = document.getElementsByClassName("body")[0];
                var table = document.createElement("table");
                table.className = "table table-hover tables";
                //כותרות לעמודות
                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");
                /*th.innerHTML = "קוד";*/
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "שם אחראי";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "הרשאת גישה";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "סיסמה";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "פלאפון";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "אימייל";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "משתתף";
                tr.appendChild(th);
                th = document.createElement("th");
                
                tr.appendChild(th);

                thead.appendChild(tr);
                table.appendChild(thead);
                //גוף הטבלה
                var tbody = document.createElement("tbody");

                for (var i = 0; i < arrReponsibles.length; i++) {
                    //שורות
                    var tr = document.createElement("tr");
                    //עמודות
                    var td = document.createElement("td");
                    td.innerHTML = arrReponsibles[i].ResponsibleID;
                    tr.id = arrReponsibles[i].ResponsibleID;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = String(arrReponsibles[i].ResponsibleName);
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReponsibles[i].AllowingAccess;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReponsibles[i].LoginPassword;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReponsibles[i].ResponsibleTelephone;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReponsibles[i].ResponsibleEmail;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReponsibles[i].Participant;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    var button = document.createElement("button");
                    button.innerHTML = '<img class="editIcon" src="../images/edit.ico" />';
                    button.title = "עדכון";
                    button.id = arrReponsibles[i].ResponsibleID + " button";
                    button.className = "editButton";
                    button.addEventListener("click", function (e) {
                        OpenUpdateResponsiblePage(e.target.parentElement.id);
                    })
                    td.appendChild(button);
                    tr.appendChild(td);
                    tbody.appendChild(tr);
                }
                table.appendChild(tbody);
                body.appendChild(table);
                document.getElementById("headline2").innerHTML = document.getElementById("headline2").innerHTML + "(" + arrReponsibles.length + ")";
            },
            (error) => {
                console.log(error);
            }
        );
    }

}

//פתיחת דף עדכון אחראי
function OpenUpdateResponsiblePage(id) {
    sessionStorage.responsibleToUpdate = id;
    window.location.href = "UpdateResponsible.html";
}

//מוצרים- כל המוצרים
function GetAllProducts() {
    //התחברות לשרת
    var arrProducts;
    axios.get('https://localhost:44351/api/Products/GetAllProducts').then(
        (response) => {
            console.log(response)
            arrProducts = response.data;            
            var body = document.getElementsByClassName("body")[0];
            var table = document.createElement("table");
            table.className = "table table-hover tables";
            //כותרות לעמודות
            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            var th = document.createElement("th");
            /*th.innerHTML = "קוד";*/
            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = "שם מוצר";
            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = "ספק";
            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = "מחיר ליחידה";
            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = "צורת תשלום";
            tr.appendChild(th);
            th = document.createElement("th");
            tr.appendChild(th);
            thead.appendChild(tr);
            table.appendChild(thead);
            //גוף הטבלה
            var tbody = document.createElement("tbody");

            for (var i = 0; i < arrProducts.length; i++) {
                //שורות
                var tr = document.createElement("tr");
                //עמודות
                var td = document.createElement("td");
                td.innerHTML = arrProducts[i].ProdID;
                tr.id = arrProducts[i].ProdID;
                tr.appendChild(td);
                var td = document.createElement("td");
                td.innerHTML = arrProducts[i].ProdName;
                tr.appendChild(td);
                var td = document.createElement("td");
                td.innerHTML = arrProducts[i].ProviderName;
                tr.appendChild(td);
                var td = document.createElement("td");
                td.innerHTML = arrProducts[i].PricePerUnit;
                tr.appendChild(td);
                var td = document.createElement("td");
                td.innerHTML = arrProducts[i].SupportWay;
                tr.appendChild(td);
                var td = document.createElement("td");
                var button = document.createElement("button");
                button.innerHTML = '<img class="editIcon" src="../images/edit.ico" />';
                button.title = "עדכון";
                button.id = arrProducts[i].ProdID + " button";
                button.className = "editButton";
                button.addEventListener("click", function (e) {
                    OpenUpdateProductPage(e.target.parentElement.id);
                })
                td.appendChild(button);
                tr.appendChild(td);
                tbody.appendChild(tr);
            }
            table.appendChild(tbody);
            body.appendChild(table);
            document.getElementById("headline2").innerHTML = document.getElementById("headline2").innerHTML + "(" + arrProducts.length + ")";
        },
        (error) => {
            console.log(error);
        }
    );
}
//פתיחת דף עדכון מוצר
function OpenUpdateProductPage(id) {
    sessionStorage.productToUpdate = id;
    window.location.href = "UpdateProduct.html";
}
var lowerSlider;
var upperSlider;
var lowerVal;
var upperVal;
function loadProducts() {
    lowerSlider = document.querySelector("#lower");
    upperSlider = document.querySelector("#upper");
    lowerVal = parseInt(lowerSlider.value);
    upperVal = parseInt(upperSlider.value);

    upperSlider.oninput = function () {
        lowerVal = parseInt(lowerSlider.value);
        upperVal = parseInt(upperSlider.value);

        if (upperVal < lowerVal + 4) {
            lowerSlider.value = upperVal - 4;
            if (lowerVal == lowerSlider.min) {
                upperSlider.value = 4;
            }
        }
        document.querySelector("#two").value = this.value;
    };

    lowerSlider.oninput = function () {
        lowerVal = parseInt(lowerSlider.value);
        upperVal = parseInt(upperSlider.value);
        if (lowerVal > upperVal - 4) {
            upperSlider.value = lowerVal + 4;
            if (upperVal == upperSlider.max) {
                lowerSlider.value = parseInt(upperSlider.max) - 4;
            }
        }
        document.querySelector("#one").value = this.value;
    };
}
//סינון מוצרים
//סינון לפי טווח מחיר





//var lowerVal = parseInt(lowerSlider.value);
//var upperVal = parseInt(upperSlider.value);

//upperSlider.oninput = function () {
//    lowerVal = parseInt(lowerSlider.value);
//    upperVal = parseInt(upperSlider.value);

//    if (upperVal < lowerVal + 4) {
//        lowerSlider.value = upperVal - 4;
//        if (lowerVal == lowerSlider.min) {
//            upperSlider.value = 4;
//        }
//    }
//    document.querySelector("#two").value = this.value;
//};

//lowerSlider.oninput = function () {
//    lowerVal = parseInt(lowerSlider.value);
//    upperVal = parseInt(upperSlider.value);
//    if (lowerVal > upperVal - 4) {
//        upperSlider.value = lowerVal + 4;
//        if (upperVal == upperSlider.max) {
//            lowerSlider.value = parseInt(upperSlider.max) - 4;
//        }
//    }
//    document.querySelector("#one").value = this.value;
//};




