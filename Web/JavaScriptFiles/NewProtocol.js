
//נתמך לפרוטוקול
function BuildSelectSuppToProtocolNames() {
    axios.get('https://localhost:44351/api/Supporteds/Get').then(
        (response) => {
            var Supporteds = response.data;
            var supportedID;
            if (sessionStorage.Support != undefined)
                supportedID = (JSON.parse(sessionStorage.Support)).SupportedID;
            else
                supportedID = (JSON.parse(sessionStorage.Protocol)).supportedID;
            var SelectSupporteds = document.getElementById("SuppToProtocolName");
            for (var i = 0; i < Supporteds.length; i++) {
                var opt = document.createElement('option');
                if (Supporteds[i].SupportedID == supportedID)
                    opt.selected = true;
                opt.value = Supporteds[i].SupportedID;
                opt.innerHTML = Supporteds[i].SupFirstName + " " + Supporteds[i].SupLastName + " | " + Supporteds[i].LayerID;
                SelectSupporteds.appendChild(opt);
            }
        },
        (error) => {
            console.log(error);
        }
    );
}


//פונקציה שמופעלת בעת טעינת הדף וממלאה את התיבות בחירה
function LoadP() {
    // document.getElementById("user").innerHTML = "משתמש:<br>" + sessionStorage.responsibleName;
    BuildSelectsuppReasons();//הפונקציה הזו כתובה בדף של תמיכה חדשה כי זו אותו פונקציה
    BuildSelectSuppToProtocolNames();//זה כן כתוב במיוחד לפרוטוקול חדש כי צריך לבחור את הנתמך המקורי כברירת מחדל
    //אם באת לכאן בשביל הוספת חדש, אין את הפרוטוקול בסטורג' ולכן שים את קוד התמיכה מהסטורג' של התמיכה 
    if (sessionStorage.Protocol == 'null')
        document.getElementById("SupportID").innerHTML = "קוד תמיכה: " + sessionStorage.supportID//קוד התמיכה מהפונקציה ששלחה

    //מילוי טבלה לא דינמית של המוצרים כמו הטבלה בדף פרוטוקול
    fillProducts1();//כתובה בכל הפרוטוקולים
}

//פונקצית ההוספה שמקבלת את תוכן כל התיבות קלט ושולחת את האוביקט להוספה
function AddNewProtocol() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var newProtocol = {
                SupportedToProtocolID: document.getElementById('SuppToProtocolName').value,
                IssueDate: document.getElementById('IssueDate').value,
                ReasonForProtocolID: document.getElementById('suppReason').value,
                SupportID: parseInt((document.getElementById('SupportID').innerHTML).split(":")[1])
            }
            axios.post('https://localhost:44351/api/Protocols/Post', newProtocol).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("נוסף בהצלחה!");
                        OpenProtcolFromSupport(newProtocol.SupportID);
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
//מילוי דף עדכון
function LoadUpdate() {
    LoadP();
    setTimeout(function () {
        var proto = JSON.parse(sessionStorage.Protocol);
        document.getElementById("IssueDate").value = formatDateYMD(proto.IssueDate);
        document.getElementById("SuppToProtocolName").value = proto.SupportedToProtocolID;
        document.getElementById("suppReason").value = proto.ReasonForProtocolID;
        document.getElementById("SupportID").innerHTML = "קוד תמיכה: " + JSON.parse(sessionStorage.Protocol).SupportID//קוד התמיכה מהפונקציה ששלחה

    }, 200);
}

//עדכון פרוטוקול
function SendUpdateProtocol() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        var InputArr = document.querySelectorAll("input");
        var bool = true;
        for (var i = 0; i < InputArr.length; i++) {
            if ((InputArr[i].value == null) || (InputArr[i].value == ""))
                bool = false;
        }
        if (bool == false)
            showValidations("validations", true);
        else {
            showValidations("validations", false);
            var newProtocol = {

                SupportedToProtocolID: document.getElementById('SuppToProtocolName').value,
                IssueDate: document.getElementById('IssueDate').value,
                ReasonForProtocolID: document.getElementById('suppReason').value,
                SupportID: parseInt((document.getElementById('SupportID').innerHTML).split(":")[1])
            }
            var ProtocolObj = [protocolID = JSON.parse(sessionStorage.Protocol).ProtocolID, newProto = newProtocol]
            axios.put('https://localhost:44351/api/Protocols/Put', ProtocolObj).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("עודכן בהצלחה!");
                        OpenProtocolPage(JSON.parse(sessionStorage.Protocol).ProtocolID);
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

//פונקציית הדפסה- שולחת מערך שמכיל את הפרטים שמולאו בדף הנוכחי וממלאה אותם בפרוטוקול
function print1() {
    
    //אוספים את כל המוצרים מהפרוטוקול
    //בודקים אלו צבועים ואת האיי די שלהם דוחפים למערך
    //בהדפסה נבדוק אילו קודים נמצאים במערך ואותם נוסיף
    var arrProductsInProtocol = document.querySelectorAll("tr");
    var arrProductsToPrint = [];
    for (var i = 0; i < arrProductsInProtocol.length; i++) {
        if (arrProductsInProtocol[i].style.backgroundColor == 'rgb(231, 234, 237)')
            arrProductsToPrint.push(parseInt(arrProductsInProtocol[i].id));
    }
    sessionStorage.arrProductsToPrint = JSON.stringify(arrProductsToPrint);
    sessionStorage.reasonSyntax = JSON.stringify(document.getElementById("PrintableCaption").value);
    window.location.href = "PrintProtocol.html";
}
function fillFile() {
    //שליפת כל האחראיים שמשתתפים בישיבות
    axios.get('https://localhost:44351/api/Responsibles/GetNamesOfparticipants').then(
        (Response) => {
            var result = Response.data;
            var ListOfParticipant = "";
            for (var i = 0; i < result.length; i++) {
                ListOfParticipant = ListOfParticipant + result[i] + ", ";
                if ((i+1) % 2 == 1) {
                    document.getElementById("Signatures").innerHTML = document.getElementById("Signatures").innerHTML +
                        '<span class="participantsSign" id="participants' + i + 'Sign">' + result[i] + '</span><span class="revach">&emsp;&emsp;&emsp;</span>';
                }
                else {
                    document.getElementById("Signatures").innerHTML = document.getElementById("Signatures").innerHTML +
                        '<span class="participantsSign" id="participants' + i + 'Sign">' + result[i] + '</span><span ></br></br></span>';
                }
            }
            //האחראיים
            document.getElementById("participants").innerHTML = ListOfParticipant;
            var ans = JSON.parse(sessionStorage.Protocol);
            var d = new Date();
            //סיבת תמיכה
            var reason = JSON.parse(sessionStorage.reasonSyntax);
            if (reason == "")
                document.getElementById('reasonSupport').innerHTML = ans.ReasonForProtocol.ReasonText;//סיבת תמיכה
            else
                document.getElementById('reasonSupport').innerHTML = reason;
            //מוצרים
            var productsID = JSON.parse(sessionStorage.arrProductsToPrint);
            var arrProducts = (JSON.parse(sessionStorage.arrProductsToProtocol));
            var bigarr = arrProducts[0];
            var smallarr = arrProducts[1];
            var string = "<br />מוצרים:<br />";
            var sum = 0;
            var j = 0;
            for (var i = 0; i < smallarr.length; i++) {
                if (productsID[j] == bigarr[i].ProdsToSupportsID) {
                    string += "  -  " + smallarr[i].ProdName + " כמות:  " + bigarr[i].Qty + " מחיר " + smallarr[i].PricePerUnit + '  ש"ח  ' + "<br />";
                    sum += (bigarr[i].Qty * smallarr[i].PricePerUnit);
                    j++;
                }
            }
            //שאר הפרטים
            document.getElementById('dateMeeting').innerHTML = formatDateDMY(ans.IssueDate)
            document.getElementById('numProtocol').innerHTML = ans.ProtocolID;
            document.getElementById('suppName').innerHTML = ans.SupportedToProtocolName;
            document.getElementById('IdSupp').innerHTML = ans.SupportedIdentity;
            document.getElementById('product').innerHTML = string;
            document.getElementById('sum').innerHTML = sum + '  ש"ח.  ';
            printf();

        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }

    )

}

