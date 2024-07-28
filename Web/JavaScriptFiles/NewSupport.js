
var Reason = 0;
//מילוי תיבת נתמכים
function BuildSelectSupporteds() {
    axios.get('https://localhost:44351/api/Supporteds/Get').then(
        (Response) => {
            var Supporteds = (Response.data);
            var id = sessionStorage.idSupportedToNewItem;
            var SelectsuppName = document.getElementById("suppName");
            for (var i = 0; i < Supporteds.length; i++) {
                var opt = document.createElement('option');
                opt.text = Supporteds[i].SupFirstName + " " + Supporteds[i].SupLastName + " | " + Supporteds[i].LayerName;
                opt.value = Supporteds[i].SupportedID;
                SelectsuppName.appendChild(opt);
                if (id == Supporteds[i].SupportedID)
                    opt.selected = true;
            }

        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}

//מילוי תיבת סיבות תמיכה
function BuildSelectsuppReasons() {
    axios.get('https://localhost:44351/api/ReasonsForSupports/Get').then(
        (Response) => {
            var suppReasons = (Response.data);
            var SelectSuppReasons = document.getElementById('suppReason');
            for (var i = 0; i < suppReasons.length; i++) {
                var opt = document.createElement('option');
                opt.text = suppReasons[i].ReasonForSupport;
                opt.value = suppReasons[i].ReasonID;
                SelectSuppReasons.appendChild(opt);
            }

        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )
}
//מילוי תיבת צורת תמיכה
function BuildSelectSuppWays(idTr, idProduct, idShop) {
    if ((idShop == 0) || (idProduct == 0)) {
        axios.get('https://localhost:44351/api/SupportWay/Get').then(
            (Response) => {
                var SuppWays = (Response.data);
                var SelectSuppWays = document.getElementById("pWay" + idTr);
                SelectSuppWays.innerHTML = '<option value="0">אמצעי תשלום</option>';
                for (var i = 0; i < SuppWays.length; i++) {
                    var opt = document.createElement('option');
                    opt.text = SuppWays[i].PaymentWay;
                    opt.value = SuppWays[i].SupportWayID;
                    SelectSuppWays.appendChild(opt);
                }
            },
            (Error) => {
                console.log(Error);
                alert("שגיאה")
            }
        )
    }
    else {
        axios.get('https://localhost:44351/api/SupportWay/GetSupportWaysByProdAndProv/' + idProduct + '/' + idShop).then(
            (Response) => {
                var SuppWays = (Response.data);
                var SelectSuppWays = document.getElementById("pWay" + idTr);
                SelectSuppWays.innerHTML = '<option value="0">אמצעי תשלום</option>';
                for (var i = 0; i < SuppWays.length; i++) {
                    var opt = document.createElement('option');
                    opt.text = SuppWays[i].PaymentWay;
                    opt.value = SuppWays[i].SupportWayID;
                    SelectSuppWays.appendChild(opt);
                }
            },
            (Error) => {
                console.log(Error);
                alert("שגיאה")
            }
        )
    }
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

//מוצרים
function BuildSelectProducts(id) {

    axios.get('https://localhost:44351/api/Products/GetAllProductsByReason/' + Reason).then(
        (Response) => {
            var arrProducts = (Response.data);
            //פירוק המערך למערך חדש שכולל רק את שמות המוצרים
            arrProducts = arrProducts.map(e => e.ProdName);
            //הסרת כפולים
            uniq = [...new Set(arrProducts)];
            var Selectproducts = document.getElementById("prodName" + id);
            Selectproducts.innerHTML = '<option value="0" >מוצר</option>';
            for (var i = 0; i < uniq.length; i++) {
                var opt = document.createElement('option');
                opt.text = uniq[i];
                opt.value = i + 1;
                Selectproducts.appendChild(opt);
            }
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )

}

//ספקים
function BuildSelectShops(idTr, Product) {
    if (Product == "מוצר") {
        axios.get('https://localhost:44351/api/Providers/Get').then(
            (Response) => {
                var arrProducts = (Response.data);
                var Selectproducts = document.getElementById("shop" + idTr);
                Selectproducts.innerHTML = '<option value="0" >מקום קנייה</option>';
                for (var i = 0; i < arrProducts.length; i++) {
                    var opt = document.createElement('option');
                    opt.text = arrProducts[i].ProvName;
                    opt.value = arrProducts[i].ProvID;
                    Selectproducts.appendChild(opt);
                }
            },
            (Error) => {
                console.log(Error);
                alert("שגיאה")
            }
        )
    }
    else {
        axios.get('https://localhost:44351/api/Providers/GetByProduct/' + Product).then(
            (Response) => {
                var arrProducts = (Response.data);
                var Selectproducts = document.getElementById("shop" + idTr);
                Selectproducts.innerHTML = '<option value="0" >מקום קנייה</option>';
                for (var i = 0; i < arrProducts.length; i++) {
                    var opt = document.createElement('option');
                    opt.text = arrProducts[i].ProvName;
                    opt.value = arrProducts[i].ProvID;
                    Selectproducts.appendChild(opt);
                }
            },
            (Error) => {
                console.log(Error);
                alert("שגיאה")
            }
        )
    }
}
var iRow;//אמור לשמור את מס השורות בטבלה

//פונקציה שמופעלת בעת טעינת הדף וממלאה את התיבות בחירה
function Load() {
     BuildSelectSupporteds();
     BuildSelectsuppReasons();
     BuildSelectresponsibles();
    fillSelects(1);
    iRow = 1;

}
//עובר על כל השורות בטבלה ומסנן את המוצרים לפי הסיבה
function SortProducts() {
    Reason = document.getElementById("suppReason").value;
    if (Reason != "סיבת תמיכה") {
        var q = document.querySelectorAll(".trs");
        for (var i = 0; i < q.length; i++) {
            BuildSelectProducts(i + 1)
        }
    }
}
//בכל הוספת שורה הפונקציה הזו מופעלת ונשלח אליה מספר השורה
function fillSelects(tr) {
     BuildSelectProducts(tr);
     BuildSelectSuppWays(tr, 0);
     BuildSelectShops(tr, "מוצר");
}
//אם זה מעדכון, אני שולחת את מספר השורה ואם זה מהוספה שולחים 0 ואז צריך להעלות את 
//טבלת מוצרים- הוספת שורות
function addRow() {
    iRow++;
    var tr = document.createElement("tr");
    tr.className = "trs";
    var td1 = document.createElement("td");
    td1.innerHTML = '<select list="prodName" name="prodName" id="prodName' + iRow + '" onchange="fillShops(' + iRow + ')"><option>מוצר</option></select>';
    tr.appendChild(td1);
    var td2 = document.createElement("td");
    td2.innerHTML = '<select list="shop" name="shop" id="shop' + iRow + '" onchange="fillSupportWays(' + iRow + ')"><option>מקום קנייה</option></select>';
    tr.appendChild(td2);
    var td3 = document.createElement("td");
    td3.innerHTML = '<input type="number" value="1" placeholder="כמות" onchange="calcPrice(' + iRow + ')" id="qty' + iRow + '"/>';
    tr.appendChild(td3);
    var td4 = document.createElement("td");
    td4.innerHTML = '<span id="priceToItem' + iRow + '"></span>';
    tr.appendChild(td4);
    var td5 = document.createElement("td");
    td5.innerHTML = '<select list="Pway" name="pWay" id="pWay' + iRow + '"><option>אמצעי תשלום</option></select>';
    tr.appendChild(td5);
    var td6 = document.createElement("td");
    td6.innerHTML = '<input type="tel" data-required="true" id="numChek' + iRow + '"/>';
    tr.appendChild(td6);
    var td7 = document.createElement("td");
    td7.innerHTML = '<input type="checkbox" id="invoice' + iRow + '"/>';
    tr.appendChild(td7);
    var td8 = document.createElement("td");
    td8.innerHTML = '<span id="Total' + iRow + '"></span>';
    tr.appendChild(td8);
    var td9 = document.createElement("td");
    td9.innerHTML = '<button title="עוד מוצר" class="editButton" onclick="addRow()"><img class="editIcon" src="../images/icons8-addition-plus-symbol-to-add-new-objects-24.png" /></button>';
    document.getElementById("last").style.display = "none";
    document.getElementById("last").id = "";
    td9.id = "last";
    tr.appendChild(td9);
    document.getElementById("productsAddTableBody").appendChild(tr);
    fillSelects(iRow);
}

//מילוי תיבת ספקים לפי המוצר הנבחר- מופעלת בעת בחירת מוצר- מקבלת את מס' השורה
function fillShops(id) {
    var prod = document.getElementById("prodName" + id).options[document.getElementById("prodName" + id).selectedIndex].text;
    BuildSelectShops(id, prod);
}

//מילוי תיבת צורות תמיכה לפי מוצר וספק
function fillSupportWays(id) {
    var prod = document.getElementById("prodName" + id).options[document.getElementById("prodName" + id).selectedIndex].text;
    var shop = parseInt(document.getElementById("shop" + id).value);
    axios.get('https://localhost:44351/api/Products/GetPrice/' + prod + '/' + shop).then(
        (Response) => {
            var price = Response.data;
            document.getElementById("priceToItem" + id).innerHTML = price;
            calcPrice(id);
            BuildSelectSuppWays(id, prod, shop);
        },
        (Error) => {
            console.log(Error);
            alert("שגיאה")
        }
    )


}
//חישוב שדה סה"כ
function calcPrice(i) {
    var price = parseFloat(document.getElementById("priceToItem" + i).innerHTML) * document.getElementById("qty" + i).value;
    document.getElementById("Total" + i).innerHTML = price.toFixed(2);
    if (document.getElementById("sum").innerHTML == "סכום")
        document.getElementById("sum").innerHTML = '0';
    var arrTotals = document.querySelectorAll('[id^="Total"]');
    var sum = 0
    for (var i = 0; i < arrTotals.length; i++) {
        sum += parseFloat(arrTotals[i].innerHTML);
    }
    document.getElementById("sum").innerHTML = sum.toFixed(2);
}

//הוספת תמיכה- שליחת תמיכה לשרת
function InsertSupport() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {

        if (DetailsComplete() == true) {
            var table = document.getElementById("productsAddTableBody");
            //מערך של פרטי המוצר בשביל הקוד מוצר
            var prodsArr = [];
            //מערך של שאר הפרטים על המוצר
            var prodDetailsArr = [];
            //מערך של כל השורות בטבלה
            var arrTr = document.querySelectorAll(".trs");
            //מעבר על הטבלה
            for (var j = 1; j < arrTr.length + 1; j++) {
                var newProd = {
                    ProdName: document.getElementById("prodName" + j).options[document.getElementById("prodName" + j).selectedIndex].text,
                    Shop: document.getElementById("shop" + j).value,
                    paymentWay: document.getElementById("pWay" + j).value
                };
                var newAllProd = {
                    Qty: document.getElementById("qty" + j).value,
                    numChek: document.getElementById("numChek" + j).value,
                    invoice: document.querySelector(`#invoice` + j).checked
                };
                prodsArr.push(newProd);
                prodDetailsArr.push(newAllProd);
            }
            var date = (document.getElementById("date").value).split("-");

            //פרטי התמיכה הכלליים
            var newSupport = {
                SupportedID: document.getElementById('suppName').value,
                SupportDate: Date.now,
                ReasonID: document.getElementById('suppReason').value,
                SumOfSupport: parseInt(document.getElementById('sum').innerHTML),
                Details: document.getElementById('datails').value,
                ResponsibleID: document.getElementById('responsible').value,
                Referrer: document.getElementById('referrer').value,

            }
            var SupportObj = [support = newSupport, prods = prodsArr, supportDate = date];

            var result;

            axios.post('https://localhost:44351/api/Supports/Post', SupportObj).then(
                (Response) => {
                    result = Response.data;
                    if (result[1] === 0)
                        alert("לא הצלחנו להוסיף :(");
                    else
                        /*alert("נוספו בהצלחה פרטי התמיכה ללא המוצרים!");*/

                        //יצירת מערך מושלם של מוצרים לתמיכות הכולל קוד תמיכה וקוד מוצר ושאר הפרטים
                        var finnalSupport = [];
                    for (var i = 0; i < result[0].length; i++) {
                        var fullProduct = {
                            SupportID: parseInt(result[1]),
                            ProdID: parseInt(result[0][i]),
                            Qty: prodDetailsArr[i].Qty,
                            NumCheckOrCupon: prodDetailsArr[i].numChek,
                            InvoiceReceived: prodDetailsArr[i].invoice
                        }
                        finnalSupport.push(fullProduct);
                    }
                    //שליחת המערך הזה להוספה לטבלת מוצרים לתמיכות
                    axios.post('https://localhost:44351/api/ProductsToSupports/Post', finnalSupport).then(
                        (Response) => {
                            var result2 = Response.data;
                            if (result2 == true) {
                                alert("נוספו בהצלחה פרטי התמיכה כולל המוצרים!");
                                //כדי שלא יוסיפו תמיכה פעמיים ולא יוסיפו לפני התמיכה
                                document.getElementById("addSupport").disabled = true;
                                document.getElementById("addProtocol").disabled = false;


                            }
                            else
                                alert("  לא הצלחנו להוסיף :(");
                        },
                        (Error) => {
                            console.log(Error);
                            alert("שגיאה")
                        }
                    )
                },
                (Error) => {
                    console.log(Error);
                    alert("שגיאה")
                }

            )
        }
    }
}

//כפתור פרוטוקול- אם יש כבר פרוטוקול פותח את הפרוטוקול ואם לא פותח פרוטוקול חדש- בכל מקרה צריך להביא את מערך המוצרים
function OpenProtcolFromSupport() {
    var supportID = parseInt(sessionStorage.supportID);
    axios.get('https://localhost:44351/api/Protocols/GetProtocolBySupportID/' + supportID).then(
        (Response) => {
            var ans = Response.data;
            //המוצרים הלבנים של התמיכה
            axios.get('https://localhost:44351/api/ProductsToSupports/GetWhiteProductsBySupport/' + supportID).then(
                (response) => {
                    var arrProducts = response.data;
                    sessionStorage.arrProductsToProtocol = JSON.stringify(arrProducts);

                    sessionStorage.Protocol = JSON.stringify(ans);
                    if (ans == null) {
                        window.location.href = "NewProtocol.html";
                    }
                    else {
                        sessionStorage.ProtocolID = ans.id;
                        window.location.href = "ProtocolPage.html";
                    }
                }, (error) => {
                    console.log(error);
                }
            )
        },
        (Error) => {
            console.log(Error);
        }
    )
}
//עדכון תמיכה- פתיחת דף תמיכה חדשה המלא בכל הפרטים 
function UpdateSupport() {
    window.location.href = "UpdateSupport.html";
}



//מילוי דף עדכון תמיכה על פי הנתונים בסטורג
function LoadUpdateSupport() {
    var ans = JSON.parse(sessionStorage.Support);
    Reason = ans.ReasonID;
    Load();
    setTimeout(function () {
    document.getElementById("suppName").value = ans.SupportedID;
    document.getElementById('date').value = formatDateYMD(ans.SupportDate);
    document.getElementById('suppReason').value = ans.ReasonID;
    document.getElementById('responsible').value = ans.ResponsibleID;
    document.getElementById('referrer').value = ans.Referrer;
    document.getElementById('datails').innerHTML = ans.Details;
    document.getElementById('sum').innerHTML = ans.SumOfSupport;
     fillProducts2();
    },300);
}

//מילוי טבלת מוצרים בדף העדכון
 function fillProducts2() {
    var arrProductsFull = JSON.parse(sessionStorage.arrProductsToSupport);
    var BigProductsArr = arrProductsFull[0];
    var smallProductsArr = arrProductsFull[1]
    //אתחול מונה השורות
    iRow = 1;
    for (var i = 1; i < BigProductsArr.length; i++) {
        //הוספת שורה בטבלה
        addRow();
    }
    //מילוי כל השורות בפרטים
    setTimeout(function () {

        for (var i = 0; i < BigProductsArr.length; i++) {
            proddd = document.querySelector(`#prodName` + (i + 1));
            for (var k = 0; k < proddd.length; k++) {
                for (var j = 0; j < smallProductsArr.length; j++) {
                    if (proddd[k].outerText === smallProductsArr[j].ProdName) {
                        proddd[k].selected = true;
                    }
                }
            }
            document.getElementById("shop" + (i + 1)).value = smallProductsArr[i].ProviderID;
            document.getElementById("qty" + (i + 1)).value = BigProductsArr[i].Qty;
            document.getElementById("priceToItem" + (i + 1)).innerHTML = smallProductsArr[i].PricePerUnit;
            document.getElementById("pWay" + (i + 1)).value = smallProductsArr[i].SupportWayID;
            document.getElementById("numChek" + (i + 1)).value = BigProductsArr[i].NumCheckOrCupon;
            document.getElementById("invoice" + (i + 1)).checked = BigProductsArr[i].InvoiceReceived;
            document.getElementById("Total" + (i + 1)).innerHTML = (smallProductsArr[i].PricePerUnit) * (BigProductsArr[i].Qty);

        }
    }, 300);
}

//שליחת העדכון
function SendUpdateSupport() {
    if (IsAllowingAccess(true) != true)
        alert("אין לך הרשאה לבצע פעולה זו. לגישה אנא הכנס כמנהל");
    else {
        if (DetailsComplete() == true) {
            var table = document.getElementById("productsAddTableBody");
            //מערך של פרטי המוצר בשביל הקוד מוצר
            var prodsArr = [];
            //מערך של שאר הפרטים על המוצר
            var prodDetailsArr = [];
            //מערך של כל השורות בטבלה
            var arrTr = document.querySelectorAll(".trs");
            //מעבר על הטבלה
            for (var j = 1; j < arrTr.length + 1; j++) {
                var newProd = {
                    ProdName: document.getElementById("prodName" + j).options[document.getElementById("prodName" + j).selectedIndex].text,
                    Shop: document.getElementById("shop" + j).value,
                    paymentWay: document.getElementById("pWay" + j).value
                };
                var newAllProd = {
                    Qty: document.getElementById("qty" + j).value,
                    numChek: document.getElementById("numChek" + j).value,
                    invoice: document.querySelector(`#invoice` + j).checked
                };
                prodsArr.push(newProd);
                prodDetailsArr.push(newAllProd);
            }
            var date = (document.getElementById("date").value).split("-");

            //פרטי התמיכה הכלליים
            var newSupport = {
                SupportedID: document.getElementById('suppName').value,
                SupportDate: Date.now,
                ReasonID: document.getElementById('suppReason').value,
                SumOfSupport: parseFloat(document.getElementById('sum').innerHTML),
                Details: document.getElementById('datails').value,
                ResponsibleID: document.getElementById('responsible').value,
                Referrer: document.getElementById('referrer').value,

            }
            var idSup = parseInt(sessionStorage.supportID);
            var SupportObj = [id = idSup, support = newSupport, prods = prodsArr, supportDate = date];

            //שליחת פרטי התמיכה כדי לקבל קוד תמיכה עבור המוצרים- 
            //result[0]=קוד התמיכה
            //result[1]=מערך של קודי המוצרים
            axios.put('https://localhost:44351/api/Supports/Put', SupportObj).then(
                (Response) => {
                    var result = Response.data;
                    if (result[1] === 0)
                        alert("לא הצלחנו לעדכן :(");
                    //יצירת מערך מושלם של מוצרים לתמיכות הכולל קוד תמיכה וקוד מוצר ושאר הפרטים
                    var finnalSupport = [];
                    for (var i = 0; i < result[0].length; i++) {
                        var fullProduct = {
                            SupportID: parseInt(idSup),
                            ProdID: parseInt(result[0][i]),
                            Qty: prodDetailsArr[i].Qty,
                            numChek: prodDetailsArr[i].numChek,
                            invoice: prodDetailsArr[i].invoice
                        }
                        finnalSupport.push(fullProduct);
                    }
                    //שליחת המערך הזה להוספה לטבלת מוצרים לתמיכות
                    axios.post('https://localhost:44351/api/ProductsToSupports/Post', finnalSupport).then(
                        (Response) => {
                            var result2 = Response.data;
                            if (result2 == true) {
                                alert("עודכנו בהצלחה פרטי התמיכה כולל המוצרים!");
                                OpenSupportPage(idSup);
                            }
                            else
                                alert("  לא הצלחנו לעדכן :(");
                        },
                        (Error) => {
                            console.log(Error);
                            alert("שגיאה")
                        }
                    )
                },
                (Error) => {
                    console.log(Error);
                    alert("שגיאה")
                }

            )
        }
    }
}

