
// פונקציה הממלאה את דף התמיכה לפי מה ששמו בסטורג
function fillSupportPage() {
    var ans = JSON.parse(sessionStorage.Support);
    document.getElementById('SupportedName').innerHTML = ans.SupportedName;
    document.getElementById('date').innerHTML = formatDateDMY(ans.SupportDate);
    document.getElementById('reason').innerHTML = ans.Reason;
    document.getElementById('supportedIdentity').innerHTML =ans.SupportedIdentity;
    document.getElementById('responsible').innerHTML = ans.ResponsibleName;
    document.getElementById('referrer').innerHTML = ans.Referrer;
    document.getElementById('details').innerHTML = ans.Details;
    fillProducts();
}
//בכל פעם שילחצו על שורה בטבלה יעברו לדף התמיכה הנבחרת
function OpenSupportPage(id) {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {

        axios.get('https://localhost:44351/api/Supports/GetSupportById/' + id).then(
            (response) => {
                ans = response.data;
                //כאן אמורים לקבל מערך אובייקטים שמכילים:
                //שם מוצר
                //קוד חנות
                //כמות
                //מחיר ליחידה
                //צורת תשלום- קוד
                //מס שק או קופון
                //התקבלה חשבונית
                //כלומר 2 מערכים- מערך מסוג מוצר  ומערך מסוג מוצר לתמיכה
                axios.get('https://localhost:44351/api/ProductsToSupports/GetAllProductsBySupport/' + id).then(
                    (response) => {
                        var arrProducts = response.data;
                        sessionStorage.arrProductsToSupport = JSON.stringify(arrProducts);
                        sessionStorage.supportID = id;
                        sessionStorage.Support = JSON.stringify(ans);
                        window.location.href = "SupportPage.html";
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
//הצגת טבלה של כל התמיכות
//מערך התמיכות הנוכחי
var arrSupports = [];
function fillSupportsTableFromDB() {
    axios.get('https://localhost:44351/api/Supporteds/Get').then(
        (response) => {
            arrSupporteds = response.data;
            /*arrSupports = arrSupports1;*///כשיהיו תוצאות- לשים בהערה
            BuildNewArr2();
        },
        (Error) => {
            console.log(Error);
        }
    );
}
//מילוי כל התמיכות
function GetAllSupports() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        //אם מערך התמיכות ריק- הוא מביא את כל התמיכות ממסד הנתונים
        if (arrSupports.length == 0) {
            axios.get('https://localhost:44351/api/Supports/Get').then(
                (response) => {
                    arrSupports = response.data;
                    arrSupports = arrSupports.sort(function (a, b) {
                        // Turn your strings into dates, and then subtract them
                        // to get a value that is either negative, positive, or zero.
                        return new Date(b.SupportDate) - new Date(a.SupportDate);
                    });
                    var body = document.getElementsByClassName("body")[0];
                    body.innerHTML = '<h4 id="headline">כל התמיכות<a class="button overbuttons" href="NewSupport.html">הוסף תמיכה</a></h4>';
                    var table = document.createElement("table");
                    table.className = "table table-hover tables";
                    table.id = "supportsAll";
                    //כותרות לעמודות
                    var thead = document.createElement("thead");
                    var tr = document.createElement("tr");
                    var th = document.createElement("th");
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "נתמך";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "תאריך תמיכה";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "סיבת תמיכה";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "סכום";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "פרוט";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "אחראי";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "מפנה";
                    tr.appendChild(th);
                    thead.appendChild(tr);
                    table.appendChild(thead);
                    //גוף הטבלה
                    var tbody = document.createElement("tbody");

                    for (var i = 0; i < arrSupports.length; i++) {
                        //שורות
                        var tr = document.createElement("tr");

                        tr.addEventListener("click", function (e) {
                            /*alert(e.target.parentElement.id)*/
                            // הפונקציה הזו אמורה להעביר לדף תמיכה המלא בפרטי התמיכה שהאיי די שלה הוא מה שנשלח  
                            OpenSupportPage(e.target.parentElement.id);
                        })
                        //עמודות
                        var td = document.createElement("td");
                        td.innerHTML = arrSupports[i].SupportID;
                        tr.id = arrSupports[i].SupportID;
                        tr.style.cursor = "pointer";
                        tr.appendChild(td);
                        tr.setAttribute("data-supportedID", arrSupports[i].SupportedID);
                        var td = document.createElement("td");
                        td.innerHTML = arrSupports[i].SupportedName;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = formatDateDMY(arrSupports[i].SupportDate);
                        td.setAttribute('data-date', formatDateYMD(arrSupports[i].SupportDate))
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = arrSupports[i].Reason;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = (arrSupports[i].SumOfSupport).toFixed(2);
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = arrSupports[i].Details;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = arrSupports[i].ResponsibleName;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = arrSupports[i].Referrer;
                        tr.appendChild(td);
                        tbody.appendChild(tr);
                    }
                    table.appendChild(tbody);
                    body.appendChild(table);
                    document.getElementById("headline").innerHTML = document.getElementById("headline").innerHTML + "(" + arrSupports.length + ")";
                },
                (error) => {
                    console.log(error);
                }
            );

        }
    }
}
 function LoadAllSupports() {
    fillSupporteds();
    BuildSelectsuppReasons();
    GetAllSupports();
}
//מילוי האפשרויות של נתמך./מוצר/ספק לבחירת הסינון
function fillSupporteds() {
    axios.get('https://localhost:44351/api/Supporteds/Get').then(
        (Response) => {
            var Supporteds = (Response.data);
            var SelectsuppName = document.getElementById("selectSupportedToFilter");
            for (var i = 0; i < Supporteds.length; i++) {
                var opt = document.createElement('option');
                opt.text = Supporteds[i].SupFirstName + " " + Supporteds[i].SupLastName + " | " + Supporteds[i].LayerName;
                opt.value = Supporteds[i].SupportedID;
                SelectsuppName.appendChild(opt);
            }

        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}






//סינון התמיכות
function FilterSupports() {
    var fromDate = new Date(document.getElementById("fromdate").value);
    var untilDate = new Date(document.getElementById("untildate").value);
    var supported = document.getElementById("selectSupportedToFilter").value;
    var reasonToFilter = document.getElementById("suppReason").options[document.getElementById("suppReason").value].text;
    var arrTrs = document.getElementsByTagName("table")[0].children[1].children;
    
    for (var i = 0; i < arrTrs.length; i++) {
        var d = new Date(formatDateYMD(arrTrs[i].children[2].getAttribute('data-date')));        
        if (((parseInt(arrTrs[i].getAttribute("data-supportedID")) == supported) || (supported == 0)) && ((arrTrs[i].children[3].innerHTML == reasonToFilter)
            || (reasonToFilter == "כל הסיבות")) && (((d > fromDate) || (fromDate == 'Invalid Date')) && ((d < untilDate) || (untilDate == 'Invalid Date')))) {
            
            arrTrs[i].style.display = "table-row";
        }            
        else
            arrTrs[i].style.display = "none";

    }
}

function CencelFilters() {
    var arrTrs = document.querySelectorAll("tr");
    for (var i = 0; i < arrTrs.length; i++) {
        arrTrs[i].style.display = "table-row";
    }
}

//כרטיס תמיכה: מילוי טבלת מוצרים+ אמצעי תשלום וכו
function fillProducts() {
    var arrProductsFull = JSON.parse(sessionStorage.arrProductsToSupport);
    var BigProductsArr = arrProductsFull[0];
    var smallProductsArr = arrProductsFull[1]
    var body = document.getElementById("products");
    var table = document.createElement("table");
    table.className = "table table-hover";
    table.id = "supportsAll";
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
        //עמודות
        var td = document.createElement("td");
        td.innerHTML = i + 1;
        tr.id = BigProductsArr[i].ProdsToSupportsID;
        
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = smallProductsArr[i].ProdName;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = smallProductsArr[i].ProviderName;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = BigProductsArr[i].Qty;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = (smallProductsArr[i].PricePerUnit).toFixed(2);
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = smallProductsArr[i].SupportWay;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = BigProductsArr[i].NumCheckOrCupon;
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = (BigProductsArr[i].InvoiceReceived) == true ? "כן" : "לא";
        tr.appendChild(td);
        var td = document.createElement("td");
        td.innerHTML = ((smallProductsArr[i].PricePerUnit) * (BigProductsArr[i].Qty)).toFixed(2);
        tr.appendChild(td);
        sum += (smallProductsArr[i].PricePerUnit) * (BigProductsArr[i].Qty);
        tr.appendChild(td);
        tbody.appendChild(tr);
    }
    table.appendChild(tbody);
    body.appendChild(table);
    cap.innerHTML = cap.innerHTML + "(" + BigProductsArr.length + ")";
    document.getElementById("total").innerHTML = document.getElementById("total").innerHTML + sum.toFixed(2) + ' ש"ח ';
    document.getElementById("total").style.borderColor = "#ff6a00";

}
