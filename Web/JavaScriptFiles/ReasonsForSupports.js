//מילוי כל הסיבות
function LoadReasons() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {

        axios.get('https://localhost:44351/api/ReasonsForSupports/Get').then(
            (response) => {
                arrReasons = response.data;/* arrSupports = arrSupports1;//כשיהיו תוצאות- לשים בהערה*/
                var body = document.getElementsByClassName("body")[0];
                body.innerHTML = '<h4 id="headline"> כל הסיבות <a href = "NewReason.html" class="button"> הוסף סיבה</a ></h4 ><br/>';
                var table = document.createElement("table");
                table.className = "table table-bordered";
                table.id = "reasonsAll";
                var col = document.createElement("col");
                col.style.width = "25%";
                table.appendChild(col);
                var col = document.createElement("col");
                col.style.width = "55%";
                table.appendChild(col);
                var col = document.createElement("col");
                col.style.width = "10%";
                table.appendChild(col);
                //כותרות לעמודות
                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");
                th = document.createElement("th");
                th.innerHTML = "סיבה";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "ניסוח לפרוטקול";
                tr.appendChild(th);
                th = document.createElement("th");

                tr.appendChild(th);
                thead.appendChild(tr);
                table.appendChild(thead);
                //גוף הטבלה
                var tbody = document.createElement("tbody");

                for (var i = 0; i < arrReasons.length; i++) {
                    //שורות
                    var tr = document.createElement("tr");
                    //עמודות

                    var td = document.createElement("td");
                    td.innerHTML = arrReasons[i].ReasonForSupport;
                    tr.id = arrReasons[i].ReasonID;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrReasons[i].ReasonText;
                    tr.id = arrReasons[i].ReasonID;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    var button = document.createElement("button");
                    button.innerHTML = '<img class="editIcon" src="../images/edit.ico" />';
                    button.title = "עדכון";
                    button.id = arrReasons[i].ReasonID + " button";
                    button.className = "editButton";
                    button.addEventListener("click", function (e) {
                        UpdateReason(e.target.parentElement.id);
                    })
                    td.appendChild(button);
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

//פתיחת דף עדכון סיבה
function UpdateReason(id) {
    sessionStorage.ReasonIdToUpdate = id;
    window.location.href = "UpdateReason.html";
}

//הוספת סיבה
function AddNewReason() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var newReason = {

                ReasonForSupport: document.getElementById("Reason").value,
                ReasonText: document.getElementById("ReasonArea").value,
            }
            var path = 'https://localhost:44351/api/ReasonsForSupports/Post';
            axios.post(path, newReason).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("נוסף בהצלחה!");
                        window.location.href = "ReasonsForSupports.html";
                    }
                    else
                        alert("לא הצלחנו להוסיף:(");
                },
                (Error) => {
                    console.log(Error);
                    alert("שגיאה")
                }

            )
        }
    }
}
function OpenUpdateReason() {
    axios.get('https://localhost:44351/api/ReasonsForSupports/Get/' + (sessionStorage.ReasonIdToUpdate).substring(0, (sessionStorage.ReasonIdToUpdate).indexOf(' '))).then(
        (response) => {
            var product = response.data;
            document.getElementById("Reason").value = product.ReasonForSupport;
            document.getElementById("ReasonArea").value = product.ReasonText;
        },
        (error) => {
            console.log(error)
        }
    )
}
//עדכון סיבה
function SendUpdateReason() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var newReason = {
                ReasonID: (sessionStorage.ReasonIdToUpdate).substring(0, (sessionStorage.ReasonIdToUpdate).indexOf(' ')),
                ReasonForSupport: document.getElementById("Reason").value,
                ReasonText: document.getElementById("ReasonArea").value,
            }
            var path = 'https://localhost:44351/api/ReasonsForSupports/Put';
            axios.put(path, newReason).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("התעדכן בהצלחה!");
                        window.location.href = "ReasonsForSupports.html";
                    }
                    else
                        alert("לא הצלחנו לעדכן:(");
                },
                (Error) => {
                    console.log(Error);
                    alert("שגיאה")
                }

            )
        }
    }
}
