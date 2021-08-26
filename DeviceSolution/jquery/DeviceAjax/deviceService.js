const apiURL = "http://localhost:37545/api/";

$(document).ready(function(){
    getTVs();
    getTels()
});

//tv listeleme
function getTVs(){
    $.ajax({
        url: apiURL+"Tv/TvList",
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#listtTbody').empty();
            for(let i = 0; i < data.length; i++){
               $('#listt').append('<tr><td>'+data[i].id+'</td><td>'+data[i].brand+'</td><td>'+data[i].size+'</td><td>'+data[i].warrantyStarting.split("T")[0]+'</td><td><button class ="btn btn-danger m-1" onclick = "deleteTV('+data[i].id+')">Delete</button><button class ="btn btn-primary m-1" onclick = "openTvModal('+data[i].id+')">Update</button></td></tr>') 
        }}
    })
}

//tv ekleme
function addTV(){

    var newBrand = $('#tvBrand').val();  //VAL() --> INPUT DEĞERİNİN VALUE'SUNU ALIYOR
    var newSize = $('#tvSize').val();
    var newDate = $('#tvDate').val();
    const newCustomer = {
        brand: newBrand,
        size : newSize,
        warrantyStarting : newDate,
      }

    $.ajax({
        url: apiURL+"Tv/TvAdd",
        dataType : 'JSON',
        method : 'POST',
        contentType : "application/json",
        data : JSON.stringify(newCustomer),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
                document.getElementById('formtv').reset();
                $('#tvAddModal').modal('hide');     //modal kapatma
                getTVs();
            } 
        }
    })
}

//tv silme
function deleteTV(tvId){
  
      $.ajax({
          url:apiURL+"Tv/TvDelete/"+tvId,
          datatype:"JSON",
          method:"DELETE",
          success:function(data){
                alert("Deletion is successful!", data);
                getTVs();
          } 
      })
  }

  
//id'ye göre tv getirme
function getTVById(tvId){
    $.ajax({
        url: apiURL+"Tv/TvIdList/"+ tvId,
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            console.log("Data", data)
            $('#UtvId').val(tvId);  //data.id de yazılabilir
            $('#UtvSize').val(data.size);  
            $('#UtvBrand').val(data.brand);  
            $('#UtvDate').val(data.warrantyStarting.split("T")[0]);
        }
    })
    
}

// tv güncellemek için modal açma
function openTvModal(id){
    $('#updatetModal').modal('show');     //modal açma
    getTVById(id);

}

//tv güncelleme
function updateTV(){
    var updateId = $('#UtvId').val();  
    var updateSize = $('#UtvSize').val();  
    var updateBrand = $('#UtvBrand').val();
    var updateDate = $('#UtvDate').val();
    const newUpdatet = {
        id : updateId,
        size : updateSize,
        brand : updateBrand,
        warrantyStarting : updateDate.split("T")[0],
    }

    $.ajax({
        url: apiURL+"Tv/TvUpdate",
        dataType : 'JSON',
        method : 'PUT',
        contentType : "application/json",
        data : JSON.stringify(newUpdatet),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
            $('#updatetModal').modal('hide');     //modal kapatma
            getTVs();
        }
    }    
    })
}


//tel listeleme
function getTels(){
    $.ajax({
        url: apiURL+"Tel/TelList",
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            $('#listelTbody').empty();
            for(let i = 0; i < data.length; i++){
               $('#listel').append('<tr><td>'+data[i].id+'</td><td>'+data[i].brand+'</td><td>'+data[i].color+'</td><td>'+data[i].warrantyStarting.split("T")[0]+'</td><td><button class ="btn btn-danger m-1" onclick = "deleteTel('+data[i].id+')">Delete</button><button class ="btn btn-primary m-1" onclick = "openTelModal('+data[i].id+')">Update</button></td></tr>') 
        }}
    })
}

//tel ekleme
function addTel(){

    var newTBrand = $('#telBrand').val();  //VAL() --> INPUT DEĞERİNİN VALUE'SUNU ALIYOR
    var newTColor = $('#telColor').val();
    var newTDate = $('#telDate').val();
    const newCustomer = {
        brand: newTBrand,
        color : newTColor,
        warrantyStarting : newTDate,
      }

    $.ajax({
        url: apiURL+"Tel/TelAdd",
        dataType : 'JSON',
        method : 'POST',
        contentType : "application/json",
        data : JSON.stringify(newCustomer),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
                document.getElementById('formtel').reset();
                $('#telAddModal').modal('hide');     //modal kapatma
                getTels();
            } 
        }
    })
}

//tel silme
function deleteTel(telId){
  
      $.ajax({
          url:apiURL+"Tel/TelDelete/"+telId,
          datatype:"JSON",
          method:"DELETE",
          success:function(data){
                alert("Deletion is successful!", data);
                getTels();
          } 
      })
  }

  
//id'ye göre tel getirme
function getTelById(telId){
    $.ajax({
        url: apiURL+"Tel/TelIdList/"+ telId,
        dataType : 'JSON',
        method : 'GET',
        success : function(data){
            console.log("Data", data)
            $('#UtelId').val(telId);  //data.id de yazılabilir
            $('#UtelColor').val(data.color);  
            $('#UtelBrand').val(data.brand);  
            $('#UtelDate').val(data.warrantyStarting.split("T")[0]);
        }
    })
    
}

// tel güncellemek için modal açma
function openTelModal(id){
    $('#updatelModal').modal('show');     //modal açma
    getTelById(id);

}

//tel güncelleme
function updateTel(){
    var updatelId = $('#UtelId').val();  
    var updatelColor = $('#UtelColor').val();  
    var updatelBrand = $('#UtelBrand').val();
    var updatelDate = $('#UtelDate').val();
    const newUpdatel = {
        id : updatelId,
        color : updatelColor,
        brand : updatelBrand,
        warrantyStarting : updatelDate.split("T")[0],
    }

    $.ajax({
        url: apiURL+"Tel/TelUpdate",
        dataType : 'JSON',
        method : 'PUT',
        contentType : "application/json",
        data : JSON.stringify(newUpdatel),
        success : function(response){       //apiden dönen return değeri
            if(response.code.statusCode == 1000){
            $('#updatelModal').modal('hide');     //modal kapatma
            getTels();
        }
    }    
    })
}