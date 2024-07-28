
//הצגת טבלה של כל התנועות
function GetAllTransactions() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        var arrTransactions;
        axios.get('https://localhost:44351/api/TransactionsOnCoffer/Get').then(
            (response) => {                
                arrTransactions = response.data;
                arrTransactions = arrTransactions.sort(function (a, b) {
                    // Turn your strings into dates, and then subtract them
                    // to get a value that is either negative, positive, or zero.
                    return new Date(b.TransactionDate) - new Date(a.TransactionDate);
                });
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
                th.innerHTML = "תאריך";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "סוג תנועה";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "סכום";
                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = "שחור/לבן";
                tr.appendChild(th);
                thead.appendChild(tr);
                table.appendChild(thead);
                //גוף הטבלה
                var tbody = document.createElement("tbody");
                for (var i = 0; i < arrTransactions.length; i++) {
                    //שורות
                    var tr = document.createElement("tr");
                    //עמודות
                    var td = document.createElement("td");
                    td.innerHTML = arrTransactions[i].TransactionID;
                    tr.id = arrTransactions[i].TransactionID;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = formatDateDMY(arrTransactions[i].TransactionDate);
                    td.setAttribute('data-date', formatDateYMD(arrTransactions[i].TransactionDate))
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrTransactions[i].TypeOfExpensesAndIncomeName;
                    td.setAttribute("ExpensesAndIncome", arrTransactions[i].ExpensesOrIncome);
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrTransactions[i].TransactionSum > 0 ? arrTransactions[i].TransactionSum : Math.abs(arrTransactions[i].TransactionSum) + " - ";
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = arrTransactions[i].BlackOrWhite ? "לבן" : "שחור";
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    var button = document.createElement("button");
                    button.innerHTML = '<img class="editIcon" src="../images/edit.ico" />';
                    button.title = "עדכון";
                    button.id = arrTransactions[i].TransactionID + " button";
                    button.className = "editButton";
                    button.addEventListener("click", function (e) {
                        OpenUpdateTransactionPage(e.target.parentElement.id);
                    })
                    td.appendChild(button);
                    tr.appendChild(td);
                    tbody.appendChild(tr);
                }
                table.appendChild(tbody);
                body.appendChild(table);
                document.getElementById("headline").innerHTML = document.getElementById("headline").innerHTML + "(" + arrTransactions.length + ")";
            },
            (Error) => {
                console.log(Error);
            }
        );
    }
}

function Load() {
    GetAllTransactions();
    DisplayBalance();
}

//כל התנועות- הצגת יתרה שחורה ולבנה
function DisplayBalance() {
    var date = new Date();
    var year = date.getFullYear();
    //איך עושים את התאריך של היום
    axios.get('https://localhost:44351/api/AnnualSummary/GetByYear/' + year).then(
        (Response) => {
            var annaulSummary = (Response.data);
            document.getElementById("whiteBalance").innerHTML = document.getElementById("whiteBalance").innerHTML + " " + annaulSummary.CurrentWhiteBalance;
            document.getElementById("blackBalance").innerHTML = document.getElementById("blackBalance").innerHTML + " " + annaulSummary.CurrentBlackBalance;
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}
//סינון התנועות
function FilterTransactions() {
    var fromDate = new Date(document.getElementById("fromdate").value);
    var untilDate = new Date(document.getElementById("untildate").value);
    var BOW = document.getElementById("selectBlackOrWhiteToFilter").value;
    var EOI = document.getElementById("selectExpensesAndIncomeToFilter").value;
    var arrTrs = document.getElementsByTagName("table")[1].children[1].children;
    for (var i = 0; i < arrTrs.length; i++) {
        var d = new Date(formatDateYMD(arrTrs[i].children[1].getAttribute('data-date')));
        if (((arrTrs[i].children[4].innerHTML == BOW) || (BOW == "שחור ולבן")) && (((arrTrs[i].children[2].getAttribute("expensesAndIncome")) == EOI) || (EOI == "הוצאות והכנסות")) && (((d > fromDate) || (fromDate == 'Invalid Date')) && ((d < untilDate) || (untilDate == 'Invalid Date'))))
            arrTrs[i].style.display = "table-row";
        else
            arrTrs[i].style.display = "none";

    }
}
//תנועה חדשה- מילוי תיבות הבחירה
//מילוי תיבת סוג תנועה

function BuildSelectTypesOfTransaction() {
    var types = [];
    axios.get('https://localhost:44351/api/TypesOfExpensesAndIncome/Get').then(
        (Response) => {
            types = (Response.data);
            var Selecttypes = document.getElementById("TypeOfTransaction");
            for (var i = 0; i < types.length; i++) {
                var opt = document.createElement('option');
                opt.text = types[i].TypeName;
                opt.value = types[i].TypeID;
                Selecttypes.appendChild(opt);
            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}

//טעינת הדף- מילוי תיבות הבחירה
function LoadNewTransaction() {
    BuildSelectTypesOfTransaction();
}

//הוספת התנועה
function AddNewTransaction() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var supportID1 = parseInt((document.getElementById('SupportID').innerHTML).split(":")[1]);
            if (isNaN(supportID1) == true)
                supportID1 = 0;
            var newTransaction = {
                //תאריך, סכום, קוד תמיכה אם יש
                TransactionDate: document.getElementById("TransactionDate").value,
                TransactionSum: document.getElementById("sumTransaction").value,
                SupportID: supportID1,
                TypeOfExpensesAndIncome: document.getElementById("TypeOfTransaction").value,
                BlackOrWhite: document.getElementById("color").value,
            }
            var path = 'https://localhost:44351/api/TransactionsOnCoffer/Post';
            axios.post(path, newTransaction).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("נוסף בהצלחה!");
                        window.location.href = "TransactionsOnCoffer.html";

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
//פתיחת דף עדכון תנועה
function OpenUpdateTransactionPage(id) {
    sessionStorage.TransactionToUpdate = id;
    window.location.href = "UpdateTransaction.html";
}

//מילוי דף עדכון תנועה
function LoadUpdateTransaction() {
    axios.get('https://localhost:44351/api/TransactionsOnCoffer/Get/' + (sessionStorage.TransactionToUpdate).substring(0, (sessionStorage.TransactionToUpdate).indexOf(' '))).then(
        (response) => {
            var transaction = response.data;
            LoadNewTransaction();
            setTimeout(function () {
                document.getElementById("TransactionDate").value = formatDateYMD(transaction.TransactionDate);
                document.getElementById("sumTransaction").value = transaction.TransactionSum > 0 ? transaction.TransactionSum : transaction.TransactionSum * -1;
                document.getElementById("SupportID").innerHTML = document.getElementById("SupportID").innerHTML + " " + transaction.SupportID;
                document.getElementById("SupportID").addEventListener("click", function (e) {
                    // הפונקציה הזו אמורה להעביר לדף תמיכה המלא בפרטי התמיכה שהאיי די שלה הוא מה שנשלח  
                    OpenSupportPage(parseInt((document.getElementById('SupportID').innerHTML).split(":")[1]));
                });
                var type = transaction.TypeOfExpensesAndIncome;
                document.getElementById("TypeOfTransaction").value = type;
                document.getElementById("color").value = transaction.ExpensesOrIncome;

            }, 1000);
        },
        (error) => {
            console.log(error)
        }
    )
}

//עדכון תנועה
function UpdateTransaction() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var supportID1 = parseInt((document.getElementById('SupportID').innerHTML).split(":")[1]);
            if (isNaN(supportID1) == true)
                supportID1 = 0;
            var newTransaction = {
                TransactionID: (sessionStorage.TransactionToUpdate).substring(0, (sessionStorage.TransactionToUpdate).indexOf(' ')),
                TransactionDate: document.getElementById("TransactionDate").value,
                TransactionSum: document.getElementById("sumTransaction").value,
                SupportID: supportID1,
                TypeOfExpensesAndIncome: document.getElementById("TypeOfTransaction").value,
                BlackOrWhite: document.getElementById("color").value,
            }
            var path = 'https://localhost:44351/api/TransactionsOnCoffer/Put';
            axios.put(path, newTransaction).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("התעדכן בהצלחה!");
                        window.location.href = "TransactionsOnCoffer.html";
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