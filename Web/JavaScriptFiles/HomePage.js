//פונקציית התחברות
function enterFunction() {
    var name = document.getElementById("userName").value;
    var pass = document.getElementById("userPassword").value;
    if (pass == "" || name == "") {
        document.getElementById("Validations").textContent = "לא הכנסת את כל הפרטים";
    }
    else {
        document.getElementById("load").style.display = "block";
        axios.get('https://localhost:44351/api/Responsibles/GetResponsibleByNamePassword/' + name + '/' + pass).then(
            (response) => {
                document.getElementById("load").style.display = "none";
                var responsible = response.data;
                if (responsible == null)
                    document.getElementById("Validations").textContent = "משתמש לא קיים, אנא נסה שוב";
                else {
                    document.getElementById("Validations").textContent = "ok";
                    sessionStorage.responsibleName = JSON.stringify(responsible);
                    
                    fillUser();
                    
                    window.location.href = "AllSupports.html";
                }                    

            },
            (error) => {
                document.getElementById("Validations").textContent="שגיאה"
            })
    }
}

//פונקציות פתיחה של התפריטים הפנימיים
function OpenMiniBar(open) {
    window.location.href = open + ".html";
}

//מופעל בעת טעינת הדף (חוץ מדף הפתיחה) וממלא את שם המשתמש
function fillUser() {
    document.getElementById("user").innerHTML = "משתמש:<br>" +JSON.parse( sessionStorage.responsibleName).ResponsibleName;

}

//ממיר מדייט לפורמט DD-MM-YYYY
function formatDateDMY(d1) {
    var d = new Date(d1),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    
    return [day,month,year].join('-');
}

//ממיר מדייט לפורמט YYYY-MM-DD
function formatDateYMD(d1) {
    var d = new Date(d1),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('-');
}

function IsAllowingAccess(funcAllow) {
    var all = (JSON.parse(sessionStorage.responsibleName)).AllowingAccess;
    
    if ((all == funcAllow)||(all==true))
    return true;
    else
       return false;
}

function EmptySessionStorage() {
    sessionStorage.clear();
}


//הצגת ההודעה על אי תקינות
function showValidations(id, bool) {
    if (bool == true)
        document.getElementById(id).style.display = "inline-block";
    else
        document.getElementById(id).style.display = "none";
}

//בדיקה שכל השדות בדף מלאים
function DetailsComplete() {
    var InputArr = document.querySelectorAll("input,select");
    for (var i = 0; i < InputArr.length; i++) {
        if ((InputArr[i].value == null) || (InputArr[i].value == "") || (InputArr[i].value == 0) || (InputArr[i].id == "numChek")) {
            if (InputArr[i].hasAttribute("data-required") != true) {
                showValidations("validations", true)
                return false;
            }
        }
    }
    showValidations("validations", false)
    return true;
}

//ייצוא טבלה לאקסל
function htmlTableToExcel(type, id) {
    var d = new Date();
    var data = document.getElementById(id);
    var excelFile = XLSX.utils.table_to_book(data, { sheet: "sheet1" });
    XLSX.write(excelFile, { bookType: type, bookSST: true, type: 'base64' });
    XLSX.writeFile(excelFile, 'ExportedFile:'+formatDateDMY(d)+'_'+id+ '.' + type);
}
