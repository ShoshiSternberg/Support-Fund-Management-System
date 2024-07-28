function LoadAllProtocols() {
    fillSupporteds();
    BuildSelectsuppReasons();
    GetAllProtocols();
}

//מילוי כל הפרוטוקולים
function GetAllProtocols() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {       
            axios.get('https://localhost:44351/api/Protocols/Get').then(
                (response) => {
                    var arrProtocols = response.data;/* arrProtocols = arrProtocols1;//כשיהיו תוצאות- לשים בהערה*/
                    var body = document.getElementsByClassName("body")[0];
                    body.innerHTML = '<h4 id="headline">כל הפרוטוקולים</h4>';
                    var table = document.createElement("table");
                    table.className = "table table-hover";
                    table.id = "protocolsAll";
                    //כותרות לעמודות
                    var thead = document.createElement("thead");
                    var tr = document.createElement("tr");
                    var th = document.createElement("th");
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "נתמך";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "תאריך הנפקה";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "סיבת תמיכה";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "קוד תמיכה";
                    tr.appendChild(th);
                    thead.appendChild(tr);
                    table.appendChild(thead);
                    //גוף הטבלה
                    var tbody = document.createElement("tbody");

                    for (var i = 0; i < arrProtocols.length; i++) {
                        //שורות
                        var tr = document.createElement("tr");
                        tr.style.cursor = "pointer";
                        tr.addEventListener("click", function (e) {
                            /*alert(e.target.parentElement.id)*/
                            // הפונקציה הזו אמורה להעביר לדף פרוטוקול המלא בפרטי הפרוטוקול שהאיי די שלו הוא מה שנשלח  
                            OpenProtocolPage(e.target.parentElement.id);
                        })
                        //עמודות
                        var td = document.createElement("td");
                        td.innerHTML = arrProtocols[i].ProtocolID;
                        tr.setAttribute("data-supportedID", arrProtocols[i].SupportedToProtocolID);
                        tr.id = arrProtocols[i].ProtocolID;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = arrProtocols[i].SupportedToProtocolName;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = formatDateDMY(arrProtocols[i].IssueDate);
                        td.setAttribute('data-date', formatDateYMD(arrProtocols[i].IssueDate))
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = arrProtocols[i].ReasonForProtocol.ReasonForSupport;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = arrProtocols[i].SupportID;
                        tr.appendChild(td);
                        
                        tbody.appendChild(tr);
                    }
                    table.appendChild(tbody);
                    body.appendChild(table);
                    document.getElementById("headline").innerHTML = document.getElementById("headline").innerHTML + "(" + arrProtocols.length + ")";
                },
                (error) => {
                    console.log(error);
                }
            );        
    }
}

//פתיחת דף פרוטוקול
function OpenProtocolPage(id) {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        //הפרוטוקול
        axios.get('https://localhost:44351/api/Protocols/GetProtocolById/' + id).then(
            (response) => {                
                var ans = response.data;
                //המוצרים הלבנים של התמיכה
                axios.get('https://localhost:44351/api/ProductsToSupports/GetWhiteProductsBySupport/' + ans.SupportID).then(
                    (response) => {
                        var arrProducts = response.data;  
                        sessionStorage.arrProductsToProtocol = JSON.stringify(arrProducts);
                        sessionStorage.ProtocolID = id;
                        sessionStorage.Protocol = JSON.stringify(ans);
                        window.location.href = "ProtocolPage.html";
                    }, (error) => {
                        console.log(error);
                    }
                )
            },
            (error) => {
                console.log(error);
            }
        );

    }
}
//מילוי דף פרוטוקול לפי מה ששמנו בסטורג 
function FillProtocolPage() {
    var ans = JSON.parse(sessionStorage.Protocol);
    document.getElementById('SupportedName').innerHTML = ans.SupportedToProtocolName;
    document.getElementById('date').innerHTML =formatDateDMY(ans.IssueDate);
    document.getElementById('reason').innerHTML = ans.ReasonForProtocol.ReasonForSupport;
    document.getElementById('supportID').innerHTML = ans.SupportID;        
    fillProducts1();
}
//זה הפונקציה שממלאת את המוצרים של דף הפרוטוקול ופרוטוקול חדש
function fillProducts1() {    
    var arrProductsFull = JSON.parse(sessionStorage.arrProductsToProtocol);
    var BigProductsArr = arrProductsFull[0];
    var smallProductsArr = arrProductsFull[1];
    var body = document.getElementById("products");
    var table = document.createElement("table");
    table.className = "table table-hover";
    table.id = "protocolsAll";
    var cap = document.createElement("caption");
    cap.innerHTML = "מוצרים";
    cap.align = "top";
    cap.className = "container-fluid,navbar-nav";
    table.appendChild(cap);
    //כותרות לעמודות
    var thead = document.createElement("thead");
    var tr = document.createElement("tr");
    var th = document.createElement("th");
    /*th.innerHTML = "קוד";*/
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "מוצר";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "חנות";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "כמות";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "מחיר ליחידה";
    tr.appendChild(th)
    th = document.createElement("th");
    th.innerHTML = "אמצעי תשלום";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "מס' צ'ק /קופון";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "התקבלה חשבונית";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "סך הכל";
    tr.appendChild(th);
    thead.appendChild(tr);
    table.appendChild(thead);
    //גוף הטבלה
    var tbody = document.createElement("tbody");
    var sum = 0;
    for (var i = 0; i < BigProductsArr.length; i++) {
        //שורות
        var tr = document.createElement("tr");
        tr.id = "i";
        tr.style.backgroundColor = 'rgb(255, 255, 255)';
        tr.addEventListener("click", function (e) {
            //צביעת השורה שבחרו אותה להדפסה
            if (document.getElementById(e.target.parentElement.id).style.backgroundColor == 'rgb(255, 255, 255)')
                document.getElementById(e.target.parentElement.id).style.backgroundColor = 'rgb(231, 234, 237)';
            else
                document.getElementById(e.target.parentElement.id).style.backgroundColor = 'rgb(255, 255, 255)';
        })
        
        //עמודות
        var td = document.createElement("td");
        td.innerHTML = i + 1;
        tr.id = BigProductsArr[i].ProdsToSupportsID;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = smallProductsArr[i].ProdName;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = smallProductsArr[i].ProviderID;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = BigProductsArr[i].Qty;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = smallProductsArr[i].PricePerUnit;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = smallProductsArr[i].SupportWayID;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = BigProductsArr[i].NumCheckOrCupon;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = BigProductsArr[i].InvoiceReceived==true?"כן":"לא";
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = BigProductsArr[i].Qty * smallProductsArr[i].PricePerUnit;
        tr.appendChild(td);
        sum +=( BigProductsArr[i].Qty * smallProductsArr[i].PricePerUnit);
        tr.appendChild(td);
        tbody.appendChild(tr);
    }
    table.appendChild(tbody);
    body.appendChild(table);
    cap.innerHTML = cap.innerHTML + "(" + BigProductsArr.length + ")";
    document.getElementById("total").innerHTML = document.getElementById("total").innerHTML + sum + ' ש"ח ';
    document.getElementById("total").style.borderColor = "#ff6a00";

}
