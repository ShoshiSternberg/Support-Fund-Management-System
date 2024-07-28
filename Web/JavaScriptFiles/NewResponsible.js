

/*הוספת אחראי חדש*/
function AddNewResponsibles() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (!validateEmail(document.getElementById("email").value))
            showValidations("emailValidation", true);
        else {
            showValidations("emailValidation", false);
            if (DetailsComplete() == true) {

                var newResponsible = {
                    ResponsibleName: document.getElementById("FirstName").value,//שם
                    ResponsibleTelephone: document.getElementById("telephone").value,//טלפון
                    ResponsibleEmail: document.getElementById("email").value,//*//*אימייל */
                    LoginPassword: document.getElementById("password").value,//סיסמה
                    AllowingAccess: document.getElementById("AllowingAccess").value,//*//*הרשאת גישה*/
                    Participant: document.getElementById("Participant").value
                }
                var path = 'https://localhost:44351/api/Responsibles/Post';
                axios.post(path, newResponsible).then(
                    (Response) => {
                        var result = Response.data;
                        if (result == true) {
                            alert("נוסף בהצלחה!");
                            window.location.href = "AllResponsibles.html";
                        }
                        else
                            alert("לא הצלחנו להוסיף:(");
                    },
                    (error) => {
                        console.log(error);
                        alert("שגיאה")
                    }
                )
            }
        }
    }
}

//מילוי דף עדכון אחראי
function LoadUpdateResponsible() {
    axios.get('https://localhost:44351/api/Responsibles/GetResponsibleByID/' + (sessionStorage.responsibleToUpdate).charAt(0)).then(
        (response) => {
            var responsible = response.data;
            document.getElementById("FirstName").value = responsible.ResponsibleName;
            document.getElementById("telephone").value = responsible.ResponsibleTelephone;
            document.getElementById("email").value = responsible.ResponsibleEmail;
            document.getElementById("password").value = responsible.LoginPassword
            document.getElementById("AllowingAccess").value = responsible.AllowingAccess;
            document.getElementById("Participant").value = responsible.Participant;
        },
        (error) => {
            console.log(error)
        }
    )

}

// Email validation function
function validateEmail(email) {
    var emailRegex = /^\w+([\.-]?\w+)@\w+([\.-]?\w+)(\.\w{2,3})+$/;
    return emailRegex.test(email);
};

//עדכון אחראי
function UpdateResponsible() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (!validateEmail(document.getElementById("email").value))
            showValidations("emailValidation", true);
        else {
            showValidations("emailValidation", false);
            if (DetailsComplete() == true) {
                showValidations("emailValidation", false);
                var newResponsible = {
                    ResponsibleID: sessionStorage.responsibleToUpdate.charAt(0),
                    ResponsibleName: document.getElementById("FirstName").value,//שם
                    ResponsibleTelephone: document.getElementById("telephone").value,//טלפון
                    ResponsibleEmail: document.getElementById("email").value,//*//*אימייל */
                    LoginPassword: document.getElementById("password").value,//סיסמה
                    AllowingAccess: document.getElementById("AllowingAccess").value,//*//*הרשאת גישה*/
                    Participant: document.getElementById("Participant").value
                }
                var path = 'https://localhost:44351/api/Responsibles/Put';
                axios.put(path, newResponsible).then(
                    (Response) => {
                        var result = Response.data;
                        if (result == true) {
                            alert("התעדכן בהצלחה!");
                            window.location.href = "AllResponsibles.html";
                        }
                        else
                            alert("לא הצלחנו לעדכן:(");
                    },
                    (error) => {
                        console.log(error);
                        alert("שגיאה")
                    }

                )
            }
        }
    }
}