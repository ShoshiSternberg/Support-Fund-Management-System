


function AddReport() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var date = document.getElementById("date").value;
            var stringdate = date.split("-");
            var NewReport = [{
                SupportedID: parseInt(document.getElementById("SupportedName").value),
                ReportDate: null,
                Details: document.getElementsByName("Details")[0].value,
                ResponsibleID: parseInt(document.getElementById("responsible").value)
            }, stringdate]
            axios.post('https://localhost:44351/api/Reports/Post', NewReport).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("נוסף בהצלחה!");
                        window.location.href = "AllReports.html";
                    }
                    else
                        alert("לא הצלחנו להוסיף:(");

                },
                (error) => {
                    alert("שגיאה");
                }
            );
        }
    }
}

//מילוי תיבת נתמכים
function BuildSelectSupporteds() {
    axios.get('https://localhost:44351/api/Supporteds/Get').then(
        (Response) => {
            var Supporteds = (Response.data);
            var SelectsuppName = document.getElementById("SupportedName");
            for (var i = 0; i < Supporteds.length; i++) {
                var opt = document.createElement('option');
                opt.text = Supporteds[i].SupFirstName + " " + Supporteds[i].SupLastName + " | " + Supporteds[i].LayerID;
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
//אחראיים
function BuildSelectresponsibles() {
    axios.get('https://localhost:44351/api/Responsibles/GetAllResponsibles').then(
        (Response) => {
            var responsibles = (Response.data);
            var Selectresponsibles = document.getElementById('responsible');
            for (var i = 0; i < responsibles.length; i++) {
                var opt = document.createElement('option');
                opt.text = responsibles[i].ResponsibleName;
                opt.value = responsibles[i].ResponsibleID;
                Selectresponsibles.appendChild(opt);
            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}
function Load_Reports() {
    BuildSelectSupporteds();
    BuildSelectresponsibles();
}

//כל הדיווחים
function GetAllReports() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        var arrReports;
        axios.get('https://localhost:44351/api/Reports/Get').then(
            (response) => {
                console.log(response)
                arrReports = response.data;
                /*arrTransactions = arrSupporteds1;*///כשיהיו תוצאות- לשים בהערה
                var body = document.getElementsByClassName("body")[0];
                var table = document.createElement("table");
                table.className = "table table-hover";
                //כותרות לעמודות
                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");
                /*th.innerHTML = "קוד";*/
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "שם נתמך";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "תאריך דיווח";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "פירוט";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "גבאי";
                tr.appendChild(th);
                thead.appendChild(tr);
                tr.appendChild(th);
                thead.appendChild(tr);
                table.appendChild(thead);
                //גוף הטבלה
                var tbody = document.createElement("tbody");
                for (var i = 0; i < arrReports.length; i++) {
                    //שורות
                    var tr = document.createElement("tr");
                    //עמודות
                    var td = document.createElement("td");
                    td.innerHTML = arrReports[i].ReportID;
                    tr.setAttribute("data-supportedID", arrReports[i].SupportedID);
                    tr.id = arrReports[i].ReportID;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReports[i].SupportedName;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = formatDateDMY(arrReports[i].ReportDate);
                    td.setAttribute('data-date', formatDateYMD(arrReports[i].ReportDate))
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReports[i].Details;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReports[i].ResponsibleName;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    var button = document.createElement("button");
                    button.innerHTML = '<img class="editIcon" src="../images/edit.ico" />';
                    button.title = "עדכון";
                    button.id = arrReports[i].ReportID;
                    button.className = "editButton";
                    button.addEventListener("click", function (e) {
                        OpenUpdateReportPage(e.target.parentElement.id);
                    })
                    td.appendChild(button);
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    var button = document.createElement("button");
                    button.innerHTML = '<img class="editIcon" src="../images/delete.png" />';
                    button.title = "מחיקה";
                    button.id = arrReports[i].ReportID;
                    button.className = "editButton";
                    button.addEventListener("click", function (e) {
                        deleteReport(e.target.parentElement.id);
                    })
                    td.appendChild(button);
                    tr.appendChild(td);
                    tbody.appendChild(tr);
                }
                table.appendChild(tbody);
                body.appendChild(table);
                document.getElementById("headline").innerHTML = document.getElementById("headline").innerHTML + "(" + arrReports.length + ")";
            },
            (Error) => {
                console.log(Error);
            }
        );
    }
}
function deleteReport(id) {
    axios.delete('https://localhost:44351/api/Reports/Delete/' + id).then(
        (response) => {
            var report = response.data;
            if (report == true) {
                alert("דיווח נמחק בהצלחה");
                location.reload();
            }
            else
                alert("לא הצלחנו למחוק");

        },
        (error) => {
            console.log(error)
        })
}
//סינון הדיווחים
function FilterReports() {
    var fromDate = new Date(document.getElementById("fromdate").value);
    var untilDate = new Date(document.getElementById("untildate").value);
    var supported = document.getElementById("selectSupportedToFilter").value;

    var arrTrs = document.getElementsByTagName("table")[0].children[1].children;

    for (var i = 0; i < arrTrs.length; i++) {
        var d = new Date(formatDateYMD(arrTrs[i].children[2].getAttribute('data-date')));
        if (((parseInt(arrTrs[i].getAttribute("data-supportedID")) == supported) || (supported == 0)) && (((d > fromDate) || (fromDate == 'Invalid Date')) && ((d < untilDate) || (untilDate == 'Invalid Date')))) {

            arrTrs[i].style.display = "table-row";
        }
        else
            arrTrs[i].style.display = "none";

    }
}
//פתיחת דף עדכון דיווח
function OpenUpdateReportPage(id) {
    sessionStorage.reportForSupport = id;
    window.location.href = "UpdateReport.html";
}

//מילוי דף עדכון 
function FillReportUpdatePage() {
    axios.get('https://localhost:44351/api/Reports/GetByID/' + (sessionStorage.reportForSupport)).then(
        (response) => {
            var report = response.data;
            LoadReports();
            setTimeout(function () {
                document.getElementById("SupportedName").value = report.SupportedID;
                document.getElementById("date").value = formatDateYMD(report.ReportDate);
                document.getElementById("responsible").value = report.ResponsibleID;
                (document.getElementsByName("Details")[0]).value = report.Details;
            }, 1000);
        },
        (error) => {
            console.log(error)
        })
}
function LoadReports() {
    BuildSelectSupporteds();
    BuildSelectresponsibles();
}

//עדכון דיווח
function UpdateReport() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var date = document.getElementById("date").value;
            var stringdate = date.split("-");
            var NewReport = [{
                ReportID: parseInt((sessionStorage.reportForSupport).charAt(0)),
                SupportedID: parseInt(document.getElementById("SupportedName").value),
                ReportDate: null,
                Details: document.getElementsByName("Details")[0].value,
                ResponsibleID: parseInt(document.getElementById("responsible").value)
            }, stringdate]
            axios.put('https://localhost:44351/api/Reports/Put', NewReport).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("עודכן בהצלחה!");
                        window.location.href = "AllReports.html";
                    }
                    else
                        alert("לא הצלחנו לעדכן:(");

                },
                (error) => {
                    alert("שגיאה");
                }
            );
        }
    }
}