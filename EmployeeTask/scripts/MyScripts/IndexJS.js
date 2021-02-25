$(document).ready(function () {
    loadData();
    getCountryList();
    $("#Birthdate").datepicker();
    $("#sDate").datepicker();
}
);  

$("#CountryId").change(function (event) {
    var id = parseInt(event.target.value);
    getCities(id);
});

function getCountryList() {
    $.ajax({
        type: "GET",
        url: "http://localhost:50268//Country//GetAllCountry",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            res.forEach(e => {
                $("#CountryId").append("<option value=" + e.CountryId + ">" + e.CountryName + "</option>");
            });
        }

    });
}

function getCityList() {
    $.ajax({
        type: "GET",
        url: "http://localhost:50268//City//GetAllCities",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            res.forEach(e => {
                $("#CityId").append("<option value=" + e.CityId + ">" + e.CityName + "</option>");
            });
        }

    });
}


function getCities(id) {
    $.ajax({
        type: "GET",
        url: "http://localhost:50268//City//GetCitiesByCountryId/" + id,
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            console.log(res);
            $("#CityId").empty();
            $("#CityId").append("<option value='' disabled selected>Select</option>");
            res.forEach(e => {
                $("#CityId").append("<option value=" + e.CityId + ">" + e.CityName + "</option>");
            });
        }

    });
}

function search() {
    debugger;
    var date = $("#sDate").val();
    $.ajax({
        type: "GET",
        url: "http://localhost:50268//Employee//Search?date=" + date,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            result.forEach(item => {
                //var myDate = new Date(parseInt(item.Birthdate.replace("/Date(", "").replace(")/", ""), 10));
                //var output = myDate.getDate() + "\\" + (myDate.getMonth() + 1) + "\\" + myDate.getFullYear();
                html += '<tr>';
                html += '<td>' + item.EmployeeName + '</td>';
                html += '<td>' + item.Birthdate.toString().split('T')[0] + '</td>';
                html += '<td>' + item.Gender + '</td>';
                html += '<td>' + item.Country.CountryName + '</td>';
                html += '<td>' + item.City.CityName + '</td>';
                html += '<td><button class="btn btn-primary" onclick="return getbyID(' + item.EId + ')">Edit</button> | <button class="btn btn-danger" onclick="Delete(' + item.EId + ')">Delete</button></td>';
                html += '</tr>';
            });
            $('tbody').html(html);  
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  



//Load Data function  
function loadData() {  
    $.ajax({  
        url: "http://localhost:50268//Employee//GetAllEmployees",  
        type: "GET",  
        contentType: "application/json;charset=utf-8",  
        dataType: "json",  
        success: function (result) {
            var html = '';
            result.forEach(item => {
                //var myDate = new Date(parseInt(item.Birthdate.replace("/Date(", "").replace(")/", ""), 10));
                //var output = myDate.getDate() + "\\" + (myDate.getMonth() + 1) + "\\" + myDate.getFullYear();
                html += '<tr>';  
                html += '<td>' + item.EmployeeName + '</td>';
                html += '<td>' + item.Birthdate.toString().split('T')[0] + '</td>';
                html += '<td>' + item.Gender + '</td>';  
                html += '<td>' + item.Country.CountryName + '</td>';  
                html += '<td>' + item.City.CityName + '</td>';  
                html += '<td><button class="btn btn-primary" onclick="return getbyID(' + item.EId + ')">Edit</button> | <button class="btn btn-danger" onclick="Delete(' + item.EId + ')">Delete</button></td>';  
                html += '</tr>';  
            });
            $('tbody').html(html);  
        },  
        error: function (errormessage) {  
            alert(errormessage.responseText);  
        }  
    });  
}  
  
//Add Data Function   
function Add() {
    var res = validate();  
    if (res == false) {  
        return false;  
    }  
    var empObj = {  
        EId: $('#EId').val(),  
        EmployeeName: $('#EmployeeName').val(),  
        Birthdate: $('#Birthdate').val(),  
        Gender: $('#Gender').val(),  
        CountryId: $('#CountryId').val(),  
        CityId: $('#CityId').val()  
    }; 
    $.ajax({  
        url: "http://localhost:50268//Employee//AddEmployee",  
        data: JSON.stringify(empObj),  
        type: "POST",  
        contentType: "application/json;charset=utf-8",  
        dataType: "json",  
        success: function (result) {  
            loadData();  
            $('#myModal').modal('hide');  
        },  
        error: function (errormessage) {  
            alert(errormessage.responseText);  
        }  
    });  
}  
  
//Function for getting the Data Based upon Employee ID  
function getbyID(EmpID) {  
    $('#EmployeeName').css('border-color', 'lightgrey');  
    $('#Birthdate').css('border-color', 'lightgrey');  
    $('#Gender').css('border-color', 'lightgrey');  
    $('#CountryId').css('border-color', 'lightgrey');  
    $('#CityId').css('border-color', 'lightgrey');  
    $.ajax({  
        url: "http://localhost:50268//Employee//GetEmployeeById//" + EmpID,  
        typr: "GET",  
        contentType: "application/json;charset=UTF-8",  
        dataType: "json",  
        success: function (result) {
            //console.log(result);
            //var myDate = new Date(parseInt(result.Birthdate.replace("/Date(", "").replace(")/", ""), 10));
            //var output = myDate.getDate() + "\\" + (myDate.getMonth() + 1) + "\\" + myDate.getFullYear();
            getCityList();
            $('#EId').val(result.EId);  
            $('#EmployeeName').val(result.EmployeeName);
            $('#Birthdate').val(result.Birthdate.toString().split('T')[0]);  
            $('#Gender').val(result.Gender); 
            $('#CountryId').val(result.CountryId);
            $('#CityId').val(result.CityId);  
  
            $('#myModal').modal('show');  
            $('#btnUpdate').show();  
            $('#btnAdd').hide();
            $("#myModalLabel").text("Edit Employee");
        },  
        error: function (errormessage) {  
            alert(errormessage.responseText);  
        }  
    });  
    return false;  
}  
  
//function for updating employee's record  
function Update() {  
    var res = validate();  
    if (res == false) {  
        return false;  
    }  
    var empObj = {  
        EId: $('#EId').val(),  
        EmployeeName: $('#EmployeeName').val(),  
        Birthdate: $('#Birthdate').val(),  
        Gender: $('#Gender').val(),  
        CountryId: $('#CountryId').val(),  
        CityId: $('#CityId').val(),  
    };  
    $.ajax({  
        url: "http://localhost:50268//Employee//UpdateEmployee",  
        data: JSON.stringify(empObj),  
        type: "POST",  
        contentType: "application/json;charset=utf-8",  
        dataType: "json",  
        success: function (result) {  
            loadData();  
            $('#myModal').modal('hide');  
            $('#EId').val("");  
            $('#EmployeeName').val("");  
            $('#Birthdate').val("");  
            $('#Gender').val("");  
            $('#CountryId').val("");  
            $('#CityId').val("");  
        },  
        error: function (errormessage) {  
            alert(errormessage.responseText);  
        }  
    });  
}  
  
//function for deleting employee's record  
function Delete(ID) {  
    var ans = confirm("Are you sure you want to delete this Record?");  
    if (ans) {  
        $.ajax({  
            url: "http://localhost:50268//Employee//DeleteEmployee//" + ID,  
            type: "GET",  
            contentType: "application/json;charset=UTF-8",  
            dataType: "json",  
            success: function (result) {  
                loadData();  
            },  
            error: function (errormessage) {  
                alert(errormessage.responseText);  
            }  
        });  
    }  
}  
  
//Function for clearing the textboxes  
function clearTextBox() {  
    $('#EId').val("");  
    $('#EmployeeName').val("");  
    $('#Birthdate').val("");  
    $('#Gender').val("");  
    $('#CountryId').val("");  
    $('#CityId').val("");  
    $('#btnUpdate').hide();  
    $('#btnAdd').show();  
    $('#EmployeeName').css('border-color', 'lightgrey');  
    $('#Birthdate').css('border-color', 'lightgrey');  
    $('#Gender').css('border-color', 'lightgrey');  
    $('#CountryId').css('border-color', 'lightgrey');  
    $('#CityId').css('border-color', 'lightgrey');  
    $("#myModalLabel").text("Add Employee");
    getCityList();
}  
//Valdidation using jquery  
function validate() {  
    var isValid = true;  
    if ($('#EmployeeName').val().trim() == "") {  
        $('#EmployeeName').css('border-color', 'Red');  
        isValid = false;  
    }  
    else {  
        $('#EmployeeName').css('border-color', 'lightgrey');  
    }
    if ($('#Birthdate').val().trim() == "") {  
        $('#Birthdate').css('border-color', 'Red');  
        isValid = false;  
    }  
    else {  
        $('#Birthdate').css('border-color', 'lightgrey');  
    }
    if ($('#Gender').val() == "") {  
        $('#Gender').css('border-color', 'Red');  
        isValid = false;  
    }  
    else {  
        $('#Gender').css('border-color', 'lightgrey');  
    }  
    if ($('#CountryId').val() == "") {  
        $('#CountryId').css('border-color', 'Red');  
        isValid = false;  
    }  
    else {  
        $('#CountryId').css('border-color', 'lightgrey');  
    }  
    if ($('#CityId').val() == "") {
        $('#CityId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CityId').css('border-color', 'lightgrey');
    }  
    return isValid;  
}  


