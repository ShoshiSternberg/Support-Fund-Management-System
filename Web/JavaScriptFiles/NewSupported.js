

function BuildSelectLayers() {
    var Layers;
    axios.get('https://localhost:44351/api/Layers/GET').then(
        (Response) => {
            Layers = (Response.data);
            var SelectLayers = document.getElementById("Layer");
            for (var i = 0; i < 7; i++) {
                var opt = document.createElement('option');
                opt.text = Layers[i].Layer;
                opt.value = Layers[i].LayerID;
                opt.selected = false;
                SelectLayers.appendChild(opt);
            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )

}
function BuildSelectStatuses() {

    axios.get('https://localhost:44351/api/Statuses/GET').then(
        (Response) => {
            var Statuses = Response.data;
            var SelectStatuses = document.getElementById('Status');
            for (var i = 0; i < Statuses.length; i++) {
                var opt = document.createElement('option');
                opt.text = Statuses[i].StatusName;
                opt.value = Statuses[i].StatusID;
                SelectStatuses.appendChild(opt);

            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    );


}
let base64String = null;
//פונקציה שמופעלת בעת טעינת הדף וממלאה את התיבות בחירה
function LoadSupported() {
    BuildSelectLayers();
    BuildSelectStatuses();

    //קריאת התמונה ברגע ההעלאה לתוך משתנה גלובלי 
    const fileInput = document.querySelector('input[type=file]');

    // Listen for the change event so we can capture the file
    fileInput.addEventListener('change', (e) => {
        // Get a reference to the file
        const file = e.target.files[0];

        // Encode the file using the FileReader API
        const reader = new FileReader();
        reader.onloadend = () => {
            // Use a regex to remove data url part
             base64String = reader.result
                .replace('data:', '')
                .replace(/^.+,/, '');
        };
        reader.readAsDataURL(file);
    });
}


//בדיקת תקינות הת"ז- קוד בדיקה
// DEFINE RETURN VALUES
var R_ELEGAL_INPUT = -1;
var R_NOT_VALID = -2;
var R_VALID = 1;

function ValidateID(str) {
    //INPUT VALIDATION

    // Just in case -> convert to string
    var IDnum = String(str);

    // Validate correct input
    if ((IDnum.length > 9) || (IDnum.length < 5) && (IDnum.length != 0))
        return R_ELEGAL_INPUT;
    if (isNaN(IDnum))
        return R_ELEGAL_INPUT;

    // The number is too short - add leading 0000
    if (IDnum.length < 9) {
        while (IDnum.length < 9) {
            IDnum = '0' + IDnum;
        }
    }

    // CHECK THE ID NUMBER
    var mone = 0, incNum;
    for (var i = 0; i < 9; i++) {
        incNum = Number(IDnum.charAt(i));
        incNum *= (i % 2) + 1;
        if (incNum > 9)
            incNum -= 9;
        mone += incNum;
    }
    if (mone % 10 == 0)
        return R_VALID;
    else
        return R_NOT_VALID;
}
//בדיקת תקינות הת"ז
function IsidentityStandards() {
    var tz = document.getElementById("identityNum").value;
    switch (ValidateID(tz)) {
        case R_ELEGAL_INPUT:
            document.getElementById("validationsIDNotCorrect").innerHTML = "מספר הזהות אינו חוקי";
            showValidations("validationsIDNotCorrect", true);
            document.getElementById("insertButton").style.pointerEvents = "none";
            break;
        case R_NOT_VALID:
            document.getElementById("validationsIDNotCorrect").innerHTML = "מספר הזהות אינו תקין";
            showValidations("validationsIDNotCorrect", true);
            document.getElementById("insertButton").style.pointerEvents = "none";
            break;
        case R_VALID:
            showValidations("validationsIDNotCorrect", false);
            document.getElementById("insertButton").style.pointerEvents = "auto";
            break;

    }

}

/*הוספת נתמך חדש*/
function AddNewSupported() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {             
            var newSupported = {
                supFirstName: document.getElementById("FirstName").value,//שם פרטי
                supLastName: document.getElementById("LastName").value,//שם משפחה
                LayerID: document.getElementById("Layer").value,//*//*שכבה */
                SupportedIdentity: document.getElementById("identityNum").value,//מס זהות
                SupTelephone: document.getElementById("Telephone").value,//טלפון
                StatusID: document.getElementById("Status").value,//*//*סטטוס*/
                Gambar: base64String//תמונה מקודדת
            }            
            var path = 'https://localhost:44351/api/Supporteds/Post';
            axios.post(path, newSupported).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("נוסף בהצלחה!");
                        window.location.href = "AllSupporteds.html";
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

//עדכון נתמך
function UpdateSupported() {
    window.location.href = "UpdateSupported.html";
}
//טעינת דף העדכון עם הפרטים המקוריים
function loadUpdateSupported() {
    LoadSupported();
    setTimeout(function () {
        var supp = JSON.parse(sessionStorage.Supported);
        document.getElementById("FirstName").value = supp.SupFirstName;
        document.getElementById("LastName").value = supp.SupLastName;
        document.getElementById("identityNum").value = supp.SupportedIdentity;
        document.getElementById("Layer").selectedIndex = supp.LayerID;
        document.getElementById("Layer").options[supp.LayerID].selected = true;
        document.getElementById("Telephone").value = supp.SupTelephone;
        document.getElementById("Status").selectedIndex = supp.StatusID;
        document.getElementById("Status").options[supp.StatusID].selected = true;        
        document.getElementById("gambarPicture").src = ' data: image / png; base64,' + supp.Gambar;
        //קריאת התמונה ברגע ההעלאה לתוך משתנה גלובלי 
        const fileInput = document.querySelector('input[type=file]');
        const pic = document.getElementById("gambarPicture");
        // Listen for the change event so we can capture the file
        fileInput.addEventListener('change', (e) => {
            // Get a reference to the file
            const file = e.target.files[0];

            // Encode the file using the FileReader API
            const reader = new FileReader();
            reader.onloadend = () => {
                // Use a regex to remove data url part
                base64String = reader.result               

                    .replace('data:', '')
                    .replace(/^.+,/, '');
                
                pic.src = reader.result;
            };
            reader.readAsDataURL(file);
        });
    }, 500)

}

//עדכון נתמך
function SendUpdateSupported() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            if (base64String == null)
                base64String = JSON.parse(sessionStorage.Supported).Gambar;
            var newSupported = {
                SupportedID: parseInt(sessionStorage.id),
                supFirstName: document.getElementById("FirstName").value,//שם פרטי
                supLastName: document.getElementById("LastName").value,//שם משפחה
                LayerID: parseInt(document.getElementById("Layer").value),//*//*שכבה */                
                SupTelephone: document.getElementById("Telephone").value,//טלפון
                StatusID: parseInt(document.getElementById("Status").value),//*//*סטטוס*/
                SupportedIdentity: document.getElementById("identityNum").value,//מס זהות
                Gambar: base64String.replace('data:', '').replace(/^.+,/, '')
            }            
            //var newSup = [id = parseInt(sessionStorage.id), newsupp = newSupported];
            var path = 'https://localhost:44351/api/Supporteds/Put';
            axios.put(path, newSupported).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("הנתמך התעדכן בהצלחה!");
                        sessionStorage.Supported = JSON.stringify(result);
                        OpenSupportedPage(parseInt(sessionStorage.id))
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

