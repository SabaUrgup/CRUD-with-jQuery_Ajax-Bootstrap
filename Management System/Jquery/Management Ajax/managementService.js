const apiURL = "http://localhost:2898/api/";

$(document).ready(function(){
    getEmployees();
    getEmployers();
});

//yönetici listeleme
function getEmployers(){
    $.ajax({
        url: apiURL+"Employer/EmployerList",
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#liste2Tbody').empty();
            for(let i = 0; i < data.length; i++){
               $('#liste2').append('<tr><td>'+data[i].id+'</td><td>'+data[i].name+'</td><td>'+data[i].surname+'</td><td>'+data[i].position+'</td><td><button class ="btn btn-danger m-1" onclick = "deleteEmployer('+data[i].id+')">Delete</button><button class ="btn btn-primary m-1" onclick = "openModal('+data[i].id+')">Update</button></td></tr>') 
        }}
    })
}

//id'ye göre yönetici getirme
function getEmployerById(id){
    $.ajax({
        url: apiURL+"Employer/EmployerGet/"+ id,
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#UemployerId').val(data.id);  
            $('#UemployerName').val(data.name);  
            $('#UemployerSurname').val(data.surname);
            $('#UemployerPosition').val(data.position);
        }
    })
    
}

// yönetici güncellemek için modal açma
function openModal(id){
    $('#updateModal').modal('show');     //modal açma
    getEmployerById(id);

}

//yönetici güncelleme
function updateEmployer(){
    var updateEmployerId = $('#UemployerId').val();  
    var updateEmployerName = $('#UemployerName').val();  
    var updateEmployerSurname = $('#UemployerSurname').val();
    var updateEmployerPosition = $('#UemployerPosition').val();
    const updateEmployer = {
        id : updateEmployerId,
        name : updateEmployerName,
        surname : updateEmployerSurname,
        position : updateEmployerPosition
    }

    $.ajax({
        url: apiURL+"Employer/EmployerUpdate",
        dataType : 'JSON',
        method : 'PUT',
        contentType : "application/json",
        data : JSON.stringify(updateEmployer),
        success : function(response){       //apiden dönen return değeri
            console.log(response)
            if(response.code.statusCode == 1000){
            $('#updateModal').modal('hide');     //modal kapatma
            getEmployers();
        }
    }    
    })
}

//yönetici ekleme
function addEmployer(){
    console.log("ttt");

    var newEmployerName = $('#employerName').val();  //VAL() --> INPUT DEĞERİNİN VALUE'SUNU ALIYOR
    var newEmployerSurname = $('#employerSurname').val();
    var newEmployerPosition = $('#employerPosition').val();
    const newEmployer = {
        name : newEmployerName,
        surname : newEmployerSurname,
        position : newEmployerPosition
    }

    $.ajax({
        url: apiURL+"Employer/EmployerAdd",
        dataType : 'JSON',
        method : 'POST',
        contentType : "application/json",
        data : JSON.stringify(newEmployer),
        success : function(response){       //apiden dönen return değeri
            console.log("sss", response);
            if(response.code.statusCode == 1000){
            $('#addModal').modal('hide');     //modal kapatma
            getEmployers();
            } 
        }   
    })
}

//yönetici silme
function deleteEmployer(employerId){
    console.log("id", employerId);
  
      $.ajax({
          url:apiURL+"Employer/EmployerDelete/"+employerId,
          datatype:"JSON",
          method:"DELETE",
          success:function(data){
                alert("Deletion is successful!", data);
                getEmployers();
  
          } 
      })
  }

//çalışan listeleme
function getEmployees(){
    $.ajax({            //apimizdeki verileri kullanma aracı -->ajax
        url: apiURL+"Employee/EmployeeList",
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#listeTbody').empty();
            for (let i = 0; i < data.length; i++) {

                $('#liste').append('<tr><td>'+data[i].id+'</td><td>'+data[i].name+'</td><td>'+data[i].surname+'</td><td>'+data[i].no+'</td><td><button class ="btn btn-danger m-1" onclick = "deleteEmployee('+data[i].id+')">Delete</button><button class ="btn btn-primary m-1" onclick = "openeeModal('+data[i].id+')">Update</button></td></tr>')
                
            }
        }
    })
}

//çalışan ekleme
function addEmployee(){
    console.log("girdi")
    var newEmployeeName = $('#employeeName').val();
    var newEmployeeSurname = $('#employeeSurname').val();
    var newEmployeeNumber = $('#employeeNumber').val();

    const newEmployee = {
        name : newEmployeeName,
        surname : newEmployeeSurname,
        no : newEmployeeNumber
    }

    $.ajax({
        url: apiURL+"Employee/EmployeeAdd",
        dataType : 'JSON',
        method : 'POST',
        contentType : "application/json",
        data : JSON.stringify(newEmployee),
        success : function(response){
            if(response.code.statusCode == 1000){
                $('#staticBackdrop').modal('hide');
                getEmployees();
            }
        }
    })
}

//çalışan silme
function deleteEmployee(employeeId){
    console.log("id", employeeId);
  
      $.ajax({
          url:apiURL+"Employee/EmployeeDelete/"+employeeId,
          datatype:"JSON",
          method:"DELETE",
          success:function(data){
                alert("Deletion is successful!", data);
                getEmployees();
  
          } 
      })
  }

//id'ye göre çalışan getirme
function getEmployeeById(id){
    $.ajax({
        url: apiURL+"Employee/EmployeeGet/"+ id,
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#UemployeeId').val(data.id);  
            $('#UemployeeName').val(data.name);  
            $('#UemployeeSurname').val(data.surname);
            $('#UemployeeNumber').val(data.no);
        }
    })
    
}

// çalışan güncellemek için modal açma
function openeeModal(id){
    $('#updateeeModal').modal('show');     //modal açma
    getEmployeeById(id);

}

//çalışan güncelleme
function updateEmployee(){
    var updateEmployeeId = $('#UemployeeId').val();  
    var updateEmployeeName = $('#UemployeeName').val();  
    var updateEmployeeSurname = $('#UemployeeSurname').val();
    var updateEmployeeNumber = $('#UemployeeNumber').val();
    const updateEmployee = {
        id : updateEmployeeId,
        name : updateEmployeeName,
        surname : updateEmployeeSurname,
        no : updateEmployeeNumber
    }

    $.ajax({
        url: apiURL+"Employee/EmployeeUpdate",
        dataType : 'JSON',
        method : 'PUT',
        contentType : "application/json",
        data : JSON.stringify(updateEmployee),
        success : function(response){       //apiden dönen return değeri
            console.log(response)
            if(response.code.statusCode == 1000){
            $('#updateeeModal').modal('hide');     //modal kapatma
            getEmployees();
        }
    }    
    })
}
