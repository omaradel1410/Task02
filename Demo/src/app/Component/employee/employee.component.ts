import { Component, OnInit } from '@angular/core';
import { APIsService } from '../../Services/apis.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

declare var $:any;

// export class employee {
//   id:number ;
//   name:string;
//   address:string;
//   salary:number;
//   isActive:boolean;
//   hireDate: Date;
// }

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})


export class EmployeeComponent implements OnInit {

  constructor(public _APIsService:APIsService) {  }

  //---------------   Get All Employees ---------------   
  AllEmp:any ; // allEmployee
  public getAllEmp()
  {
    this._APIsService.GetAllEmployee().subscribe(res =>{      
      if (res.message == 'Data Retrived')
      {
          this.AllEmp = res.data;
      }
    }, (err)=>{ console.log(err);
     })
   }
  //---------------  / Get All Employees \ ---------------   
  
  
  
  //---------------   Get Employee By Id  ---------------   
  
  empDetails:any; // get Emloyee Details
  getEmployeeById(id:number)
  {  
    this._APIsService.getEmployeeById(id).subscribe( (res) =>{

        let emp = Array.of( res.data);
        this.empDetails = emp;
    },
    (err)=>{console.log(err);
    })  
  }
 //---------------  / Get Employee By Id \ ---------------  



  //---------------   Create Employee ---------------   
  maxDate ="2004-12-31" ;

   create = new FormGroup({
    // 'id': new FormControl(),

    'name': new FormControl(null,
        [Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20),
        Validators.pattern("^[a-zA-Z ]+$")] ),

    'address': new FormControl(
        null,
        [Validators.required,
        Validators.pattern("^[1-9]{1,4}-[a-zA-Z]{2,10}-[a-zA-Z]{2,10}-[a-zA-Z]{2,10}$") ]), // 55-st-strict-city

    'salary': new FormControl(null,
        [Validators.required,
        Validators.min(1000),
        Validators.max(50000) ]),

    'hireDate': new FormControl( null, Validators.required),
    
    'isActive': new FormControl(null, Validators.required),
  })


public formData() 
{
  if (this.create.valid)
  {
     this._APIsService.createEmployee(this.create.value).subscribe(res => 
      {       
        if(res.message == 'Data Modified') {
          $('#CreateEmp').modal('hide');
          this.getAllEmp();
          this.create.reset();
        }

      }, (err)=> {console.log(err)} );
  }
}  
 //---------------   \ Create Employee \ ---------------  

   

 //---------------   Update Employee  ---------------   
   edidId:number;
   setValue(id:number)
   {
     for (let i = 0; i < this.AllEmp.length; i++)
     {
       if(this.AllEmp[i].id == id)
       {
         this.edidId = id;
         let alldata = this.create.setValue({
           name: this.AllEmp[i].name,
           address: this.AllEmp[i].address,
           salary: this.AllEmp[i].salary,
           hireDate: this.AllEmp[i].hireDate,
           isActive: this.AllEmp[i].isActive,
         })
       }
     }
   }
 
 
   EditEmp() {
     let data = {
       id:this.edidId,
       name: this.create.value.name,
       address: this.create.value.address,
       salary: this.create.value.salary,
       hireDate: this.create.value.hireDate,
       isActive: this.create.value.isActive,
     }

     this._APIsService.UpdateEmployee(data).subscribe(res => {
 
       if(res.message == 'Data Modified')
       {         
         $('#Edit').modal('hide');
         this.getAllEmp();
         this.create.reset();
       } 
     }, (err)=> {console.log(err);
     } )
   }
   //-------------- /Update Employee\  ---------------  
   
   
   //---------------   Delete Employee  ---------------  
   dataEmpDelete:any;
   id:number = 0 ;
   GetIdEmp(id:number)
   {
      this.id = id;
   }
    
   DeleteEmp() {
      this._APIsService.DeleteEmployee(this.id).subscribe(res => {

      if(res.message == 'Data Deleted')
      {
        $('#Delete').modal('hide');
        this.getAllEmp();
      }

    }, (err)=> {console.log(err);
    } )
  }
  


  resetForm() {
    this.create.reset();
  }

  ngOnInit():void {
    this.getAllEmp()

    $(document).ready( function () {
        $('#myTable').DataTable();
    });
  }

}


