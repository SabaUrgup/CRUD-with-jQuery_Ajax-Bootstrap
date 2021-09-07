const apiURL = "http://localhost:52201/api/";

$(document).ready(function(){
    getCustomers();
    getFlowers()
    getFCategory()
});

//müşteri listeleme
function getCustomers(){
    $.ajax({
        url: apiURL+"Customer/CustomerList",
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#listcTbody').empty();
            for(let i = 0; i < data.length; i++){
               $('#listec').append('<tr><td>'+data[i].id+'</td><td>'+data[i].name+'</td><td>'+data[i].surname+'</td><td>'+data[i].telNo+'</td><td>'+data[i].email+'</td><td><button class ="btn btn-danger m-1" onclick = "deleteCustomer('+data[i].id+')">Delete</button><button class ="btn btn-primary m-1" onclick = "openCModal('+data[i].id+')">Update</button></td></tr>') 
        }}
    })
}

//müşteri ekleme
function addCustomer(){

    var newCName = $('#customerName').val();  //VAL() --> INPUT DEĞERİNİN VALUE'SUNU ALIYOR
    var newCSurname = $('#customerSurname').val();
    var newCNumber = $('#customerNumber').val();
    var newCMail = $('#customerMail').val();
    const newCustomer = {
        name: newCName,
        surname : newCSurname,
        email : newCMail,
        telNo : newCNumber
      }

    $.ajax({
        url: apiURL+"Customer/CustomerAdd",
        dataType : 'JSON',
        method : 'POST',
        contentType : "application/json",
        data : JSON.stringify(newCustomer),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
                $('#customerAddModal').modal('hide');     //modal kapatma
                getCustomers();
            } 
        }
    })
}

//müşteri silme
function deleteCustomer(customerId){
  
      $.ajax({
          url:apiURL+"Customer/CustomerDelete/"+customerId,
          datatype:"JSON",
          method:"DELETE",
          success:function(data){
                alert("Deletion is successful!", data);
                getCustomers();
          } 
      })
  }

  
//id'ye göre müşteri getirme
function getCustomerById(customerId){
    $.ajax({
        url: apiURL+"Customer/CustomerIdList/"+ customerId,
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            console.log("rftghyju", data)
            $('#UcustomerId').val(customerId);  //customerId de yazılabilir
            $('#UcustomerName').val(data.name);  
            $('#UcustomerSurname').val(data.surname);  
            $('#UcustomerNumber').val(data.telNo);
            $('#UcustomerMail').val(data.email);
        }
    })
    
}

// müşteri güncellemek için modal açma
function openCModal(id){
    $('#updatecModal').modal('show');     //modal açma
    getCustomerById(id);

}

//müşteri güncelleme
function updateCustomer(){
    var updateCId = $('#UcustomerId').val();  
    var updateCName = $('#UcustomerName').val();  
    var updateCSurname = $('#UcustomerSurname').val();
    var updateCNumber = $('#UcustomerNumber').val();
    var updateCMail =  $('#UcustomerMail').val();
    const updateCustomer = {
        id : updateCId,
        name : updateCName,
        surname : updateCSurname,
        email : updateCMail,
        telNo : updateCNumber
    }

    $.ajax({
        url: apiURL+"Customer/CustomerUpdate",
        dataType : 'JSON',
        method : 'PUT',
        contentType : "application/json",
        data : JSON.stringify(updateCustomer),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
            $('#updatecModal').modal('hide');     //modal kapatma
            getCustomers();
        }
    }    
    })
}

//çiçek listeleme
function getFlowers(){
    $.ajax({
        url: apiURL+"Flower/FlowerList",
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#listfTbody').empty();
            for(let i = 0; i < data.length; i++){
               $('#listf').append('<tr><td>'+data[i].id+'</td><td>'+data[i].name+'</td><td>'+data[i].price+'</td><td>'+data[i].specification+'</td><td>'+data[i].flowerCategoryName+'</td><td><button class ="btn btn-danger m-1" onclick = "deleteFlower('+data[i].id+')">Delete</button><button class ="btn btn-primary m-1" onclick = "openFModal('+data[i].id+')">Update</button></td></tr>') 
        }}
    })
}

//çiçek ekleme
function addFlower(){

    var newFName = $('#fName').val();  //VAL() --> INPUT DEĞERİNİN VALUE'SUNU ALIYOR
    var newFSpecification = $('#fSpecification').val();
    var newFPrice = $('#fPrice').val();
    var newFCid = $('#fCid').val();
    const newFlower = {
        name: newFName,
        specification : newFSpecification,
        price : newFPrice,
        flowerCategoryId : newFCid
      }

    $.ajax({
        url: apiURL+"Flower/FlowerAdd",
        dataType : 'JSON',
        method : 'POST',
        contentType : "application/json",
        data : JSON.stringify(newFlower),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
                document.getElementById('formaf').reset();
                $('#fAddModal').modal('hide');     //modal kapatma
                getFlowers();
            } 
        }
    })
}

//çiçek silme
function deleteFlower(fId){
  
    $.ajax({
        url:apiURL+"Flower/FlowerDelete/"+fId,
        datatype:"JSON",
        method:"DELETE",
        success:function(data){
              alert("Deletion is successful!", data);
              getFlowers();
        } 
    })
}


//id'ye göre çiçek getirme
function getFlowerById(fId){
  $.ajax({
      url: apiURL+"Flower/FlowerIdList/"+fId,
      dataType : 'JSON',
      method : 'GET',
      success : function(data){
          console.log("cicekler", data)
          $('#UfId').val(fId);  //data.id de yazılabilir
          $('#UfName').val(data.name);  
          $('#UfPrice').val(data.price);  
          $('#UfSpecification').val(data.specification);
          $('#UfCid').val(data.flowerCategoryId);
      }
  })
}

// çiçek güncellemek için modal açma
function openFModal(id){
    $('#updatefModal').modal('show');     //modal açma
    getFlowerById(id);

}

//çiçek güncelleme
function updateFlower(){
    var updateFId = $('#UfId').val();  
    var updateFName = $('#UfName').val();  
    var updateFPrice = $('#UfPrice').val();
    var updateFSpecification = $('#UfSpecification').val();
    var updateFCid =  $('#UfCid').val();
    const updateFlower = {
        id : updateFId,
        name : updateFName,
        price : updateFPrice,
        specification : updateFSpecification,
        flowerCategoryId : updateFCid
    }

    $.ajax({
        url: apiURL+"Flower​/FlowerUpdate",
        dataType : 'JSON',
        method : 'PUT',
        contentType : "application/json",
        data : JSON.stringify(updateFlower),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
            $('#updatefModal').modal('hide');     //modal kapatma
            getFlowers();
        }
    }    
    })
}

//tüm çiçek kategorilerini getirir - Select için kullanıldı
function getFCategory() {
    $.ajax({
        url: apiURL + "FlowerCategory/FlowerCategoryList",
        datatype: "JSON",
        method: "GET",
        success: function (data) {
            for (let i = 0; i < data.length; i++) {
                $('#fCid').append('<option value=' + data[i].id + '>' + data[i].name + '</option>')
                $('#UfCid').append('<option value=' + data[i].id + '>' + data[i].name + '</option>')
            }
        }
    })
}
