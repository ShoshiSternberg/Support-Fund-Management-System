



var arrSupporteds = null;
function fillSupportedsTableFromDB() {
    axios.get('https://localhost:44351/api/Supporteds/Get').then(
        (response) => {
            console.log(response)
            arrSupporteds = response.data;            
            GetAllSupporteds();
        },
        (Error) => {
            alert(Error);
        }
    );

}

//הצגת טבלה של כל הנתמכים
function GetAllSupporteds() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        var body = document.getElementsByClassName("body")[0];
        body.innerHTML = '<h4 id="headline">כל הנתמכים<a class="button overbuttons" href="NewSupported.html">הוסף נתמך</a></h4>';

        var table = document.createElement("table");
        table.id = "AllSupporteds";
        table.className = "table table-hover tables";
        //כותרות לעמודות
        var thead = document.createElement("thead");
        var tr = document.createElement("tr");
        var th = document.createElement("th");
        /*th.innerHTML = "קוד";*/
        tr.appendChild(th);
        th = document.createElement("th");
        th.innerHTML = "שם פרטי";
        tr.appendChild(th);
        th = document.createElement("th");
        th.innerHTML = "שם משפחה";
        tr.appendChild(th);
        th = document.createElement("th");
        th.innerHTML = "מס' זהות";
        tr.appendChild(th);
        th = document.createElement("th");
        th.innerHTML = "פלאפון";
        tr.appendChild(th);
        th = document.createElement("th");
        th.innerHTML = "שכבה";
        tr.appendChild(th);
        th = document.createElement("th");
        th.innerHTML = "סטטוס";
        tr.appendChild(th);
        th = document.createElement("th");
        th.innerHTML = "תמונה";
        tr.appendChild(th);
        thead.appendChild(tr);
        table.appendChild(thead);
        //גוף הטבלה
        var tbody = document.createElement("tbody");
        for (var i = 0; i < arrSupporteds.length; i++) {
            //שורות
            var tr = document.createElement("tr");
            tr.id = arrSupporteds[i].id;
            tr.style.cursor = "pointer";
            tr.addEventListener("click", function (e) {
                /*alert(e.target.parentElement.id)*/
                // הפונקציה הזו אמורה להעביר לדף נתמך המלא בפרטי הנתמך שהאיי די שלו הוא מה שנשלח  
                OpenSupportedPage(e.target.parentElement.id);
            })
            //עמודות
            var td = document.createElement("td");
            td.innerHTML = arrSupporteds[i].SupportedID;
            tr.id = arrSupporteds[i].SupportedID;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = arrSupporteds[i].SupFirstName;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = arrSupporteds[i].SupLastName;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = arrSupporteds[i].SupportedIdentity;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = arrSupporteds[i].SupTelephone;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = arrSupporteds[i].LayerName;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = arrSupporteds[i].StatusName;
            tr.appendChild(td);
            var td = document.createElement("td");
            var img = document.createElement("img");
            img.className = "imgesInTable";
            img.src =' data: image / png; base64,'+ arrSupporteds[i].Gambar;
            td.appendChild(img);
            tr.appendChild(td);
            tbody.appendChild(tr);
        }
        table.appendChild(tbody);
        body.appendChild(table);
        document.getElementById("headline").innerHTML = document.getElementById("headline").innerHTML + "(" + arrSupporteds.length + ")";
    }
}

//סינון הנתמכים לפי שכבה/סטטוס 
function FilterByStatus(status1) {
    statuss = status1;
    fillSupportedsTableFromDB();
}
function CencelFilters() {
    arrSupports = null;
    GetAllSupports();
}

//סינון הנתמכים לפי שכבה או סטטוס
function FilterSupporteds() {
    var statusNow = document.getElementById("statusFilter").value;
    var layerNow = document.getElementById("LayerFilter").value;
    //כשיהיה תרגום של הסטטוס והשכבה לשים את התרגום וכן אם זה שווה סטטוס או שכבה ולא 0
    //var statusNow = document.getElementById("statusFilter").selectedIndex;
    //var layerNow = document.getElementById("LayerFilter").selectedIndex;
    var arrTrs = document.getElementsByTagName("table")[0].children[1].children;
    for (var i = 0; i < arrTrs.length; i++) {
        if (((arrTrs[i].children[5].innerHTML == layerNow)||(layerNow == "שכבה")) && ((arrTrs[i].children[6].innerHTML == statusNow)||(statusNow == "סטטוס")))
            arrTrs[i].style.display = "table-row";

        else
            arrTrs[i].style.display = "none";
    }
}

function FilterByLayer(layer1) {
    layer = layer1;
    fillSupportedsTableFromDB();
}
//פתיחת דף נתמך- מילוי הסטורג' בפרטי הנתמך
function OpenSupportedPage(id) {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        
        axios.get('https://localhost:44351/api/Supporteds/GetSupportedById/' + id).then(
            (response) => {
                console.log(response)
                ans = response.data;
                sessionStorage.id = id;
                sessionStorage.Supported = JSON.stringify(ans);
                window.location.href = "SupportedPage.html";                
            },
            (error) => {
                console.log(error);
            }
        );

    }
}

//מילוי דף הנתמך בפרטים מהסטורג
function fillSupportedPage() {
    var supp = JSON.parse(sessionStorage.Supported);
    document.getElementById("FirstName").innerHTML = supp.SupFirstName;
    document.getElementById("LastName").innerHTML = supp.SupLastName;
    document.getElementById("Identity").innerHTML = supp.SupportedIdentity;
    document.getElementById("Layer").innerHTML = supp.LayerName;
    document.getElementById("Telephone").innerHTML = supp.SupTelephone;
    document.getElementById("Status").innerHTML = supp.StatusName;
    document.getElementById("gambarPicture").src = ' data: image / png; base64,' + supp.Gambar;
}

//כרטיס נתמך
function GetSupportedByID() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        var supported = this.id;//זה אמור להיות המזהה של התא בטבלה
        
        fillSupportedPage();//מילוי הפרטים הכלליים- זהה לעדכון תמיכה 
        //טבלת תמיכות
        axios.get('https://localhost:44351/api/Supports/GetSupportsBySupported/' + sessionStorage.id).then(
            (response) => {
                var arrSupports = response.data;
                var sumOfSupportedSupports = 0;
                var Supports = document.getElementById("Supports");
                var table = document.createElement("table");
                table.className = "table table-hover";
                var cap = document.createElement("caption");
                cap.innerHTML = "תמיכות";
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
                th.innerHTML = "תאריך תמיכה";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "סכום";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "סיבת תמיכה";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "אחראי";
                tr.appendChild(th);
                thead.appendChild(tr);
                table.appendChild(thead);
                //גוף הטבלה
                var tbody = document.createElement("tbody");

                for (var i = 0; i < arrSupports.length; i++) {
                    //שורות
                    var tr = document.createElement("tr");
                    //עמודות
                    var td = document.createElement("td");
                    td.innerHTML = arrSupports[i].SupportID;
                    tr.id = arrSupports[i].SupportID;
                    tr.style.cursor = "pointer";
                    tr.addEventListener("click", function (e) {
                        /*alert(e.target.parentElement.id)*/
                        // הפונקציה הזו אמורה להעביר לדף תמיכה המלא בפרטי התמיכה שהאיי די שלה הוא מה שנשלח  
                        OpenSupportPage(e.target.parentElement.id);
                    })
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrSupports[i].SupportDate;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = (arrSupports[i].SumOfSupport).toFixed(2);
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrSupports[i].Reason;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrSupports[i].ResponsibleName;
                    tr.appendChild(td);
                    sumOfSupportedSupports += parseInt(arrSupports[i].SumOfSupport);
                    tbody.appendChild(tr);
                }
                table.appendChild(tbody);
                Supports.appendChild(table);
                cap.innerHTML = cap.innerHTML + "(" + arrSupports.length + ")" + '<a href="NewSupport.html" onclick=" sessionStorage.idSupportedToNewItem = sessionStorage.id " class="alink">הוסף תמיכה</a>';
                document.getElementById("sum").innerHTML = sumOfSupportedSupports;
                document.getElementById("count").innerHTML = arrSupports.length;
            },
            (Error) => {
                alert(Error);
            }
        );
        //טבלת דיווחים
        setTimeout(function () {
            axios.get('https://localhost:44351/api/Reports/GetReportsBySupported/' + sessionStorage.id).then(
                (response) => {
                    var ArrReports = response.data;
                    var reportsDiv = document.getElementById("Reports");
                    var table = document.createElement("table");
                    table.className = "table table-hover";
                    var cap = document.createElement("caption");
                    cap.innerHTML = "דיווחים";
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
                    th.innerHTML = "תאריך";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "פירוט";
                    tr.appendChild(th);
                    th = document.createElement("th");
                    th.innerHTML = "אחראי";
                    tr.appendChild(th);

                    thead.appendChild(tr);
                    table.appendChild(thead);
                    //גוף הטבלה
                    var tbody = document.createElement("tbody");
                    for (var i = 0; i < ArrReports.length; i++) {
                        //שורות
                        var tr = document.createElement("tr");
                        //עמודות
                        var td = document.createElement("td");
                        td.innerHTML = ArrReports[i].ReportID;
                        tr.id = ArrReports[i].ReportID;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = ArrReports[i].ReportDate;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = ArrReports[i].Details;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        td.innerHTML = ArrReports[i].ResponsibleName;
                        tr.appendChild(td);
                        var td = document.createElement("td");
                        var button = document.createElement("button");
                        button.innerHTML = '<img class="editIcon" src="../images/edit.ico" />';
                        button.title = "עדכון";
                        button.id = ArrReports[i].ReportID + " button";
                        button.className = "editButton";
                        button.addEventListener("click", function (e) {
                            OpenUpdateReportPage(e.target.parentElement.id);
                        })
                        td.appendChild(button);
                        tr.appendChild(td);
                        tbody.appendChild(tr);
                    }
                    table.appendChild(tbody);
                    reportsDiv.appendChild(table);
                    cap.innerHTML = cap.innerHTML + "(" + ArrReports.length + ")" + '<a href="NewReport.html" class="alink" >הוסף דיווח</a>';

                },
                (Error) => {
                    alert(Error);
                }
            );
        }, 500);
    }
}
