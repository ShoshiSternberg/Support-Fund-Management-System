//מילוי תיבת בחירה- ספק
function BuildSelectProviders() {
    var providers = [];
    axios.get('https://localhost:44351/api/Providers/GET').then(
        (Response) => {
            providers = (Response.data);
            var SelectProviders = document.getElementById("provider");
            for (var i = 0; i < providers.length; i++) {
                var opt = document.createElement('option');
                opt.text = providers[i].ProvName;
                opt.value = providers[i].ProvID;
                SelectProviders.appendChild(opt);
            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}
//מילוי תיבת בחירה- צורת תשלום
function BuildSelectPaymentWay() {
    var PaymentWays = [];
    axios.get('https://localhost:44351/api/SupportWay/GET').then(
        (Response) => {
            PaymentWays = (Response.data);
            var SelectPaymentWays = document.getElementById("PaymentWay");
            for (var i = 0; i < PaymentWays.length; i++) {
                var opt = document.createElement('option');
                opt.text = PaymentWays[i].PaymentWay;
                opt.value = PaymentWays[i].SupportWayID;
                SelectPaymentWays.appendChild(opt);
            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה");
        }
    )
}

//סימון סיבות התמיכה המתאימות למוצר
function BuildSelectReasons() {
    axios.get('https://localhost:44351/api/ReasonsForSupports/Get').then(
        (Response) => {
            var suppReasons = (Response.data);
            var SelectSuppReasons = document.getElementById('suppReason');
            for (var i = 0; i < suppReasons.length; i++) {
                var div1 = document.createElement("div");
                div1.className = " checkbox1";
                div1.dir = "ltr";
                var label = document.createElement("label");
                label.className = "labels";
                label.for = suppReasons[i].ReasonForSupport;
                label.innerText = suppReasons[i].ReasonForSupport;
                var input = document.createElement("input");
                input.type = "checkbox";
                input.className = "inputsOfChecks";
                input.id = suppReasons[i].ReasonID;
                input.name = suppReasons[i].ReasonForSupport;
                input.value = suppReasons[i].ReasonID;
                div1.appendChild(label);
                div1.appendChild(input);
                SelectSuppReasons.appendChild(div1);
            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}

//טעינת תיבות הבחירה- ספק וצורת תשלום
function LoadProducts() {
    BuildSelectProviders();
    BuildSelectPaymentWay();
    BuildSelectReasons();
}

function AddNewProduct() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var newProd = {
                ProdName: document.getElementById("ProdName").value,
                providerID: document.getElementById("provider").value,
                pricePerUnit: document.getElementById("pricePerUnit").value,
                SupportWayID: document.getElementById("PaymentWay").value,
            }
            var Reasons = [];
            var elems = document.querySelectorAll('.inputsOfChecks');
            for (var i = 0; i < elems.length; i++) {
                if (elems[i].checked == true)
                    Reasons.push(elems[i].id);
            }
            var ProdObj = [Reason = Reasons, newProd];
            var path = 'https://localhost:44351/api/Products/Post';
            axios.post(path, ProdObj).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("נוסף בהצלחה!");
                        window.location.href = "AllProducts.html";
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

//מילוי דף עדכון מוצר
function LoadUpdateProducts() {
    axios.get('https://localhost:44351/api/Products/GetProductByID/' + (sessionStorage.productToUpdate).substring(0, (sessionStorage.productToUpdate).indexOf(' '))).then(
        (response) => {
            var product = response.data;
            LoadProducts();
            setTimeout(function () {
                document.getElementById("ProdName").value = product.ProdName;
                document.getElementById("provider").value = product.ProviderID;
                document.getElementById("pricePerUnit").value = product.PricePerUnit;
                document.getElementById("PaymentWay").value = product.SupportWayID;
                var reasons = product.Reasons;
                for (var i = 0; i < reasons.length; i++) {
                    document.getElementById(reasons[i]).checked = true;
                }
            }, 1000);
        },
        (error) => {
            console.log(error)
        }
    )

}

//עדכון מוצר
function UpdateProduct() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var newProd = {
                ProdID: (sessionStorage.productToUpdate).substring(0, (sessionStorage.productToUpdate).indexOf(' ')),
                ProdName: document.getElementById("ProdName").value,
                providerID: document.getElementById("provider").value,
                pricePerUnit: document.getElementById("pricePerUnit").value,
                SupportWayID: document.getElementById("PaymentWay").value,
            }
            var Reasons = [];
            var elems = document.querySelectorAll('.inputsOfChecks');
            for (var i = 0; i < elems.length; i++) {
                if (elems[i].checked == true)
                    Reasons.push(elems[i].id);
            }
            var ProdObj = [Reason = Reasons, newProd];
            var path = 'https://localhost:44351/api/Products/Put';
            axios.put(path, ProdObj).then(
                (Response) => {
                    var result = Response.data;
                    if (result == true) {
                        alert("התעדכן בהצלחה!");
                        window.location.href = "AllProducts.html";
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
