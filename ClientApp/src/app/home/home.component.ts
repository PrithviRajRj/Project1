import { Component } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { registeruser } from 'src/Model/Userbody';
import { AppserviceService } from '../appservice.service';
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  AddDataForm = this.fb.group({
    collegeId:new FormControl(''),
    Name:new FormControl(''),
    Email:new FormControl(''),
    Mobilenumber:new FormControl(''),
    Address:new FormControl(''),
    State:new FormControl(''),
    City:new FormControl(''),
    Department:new FormControl('')
  })
  displayedColumns: any[] = ['collegeid','name','number','department','getdelete'];
  dataSource = new MatTableDataSource<any>([]);

  constructor(private fb:FormBuilder,private router:Router,private service:AppserviceService){}

  ngOnInit(): void {
    this.getDetails();
  }

  getsubmit(){
    let getregister = new registeruser()
    getregister.collegeId = this.AddDataForm.get('collegeId')?.value;
    getregister.Name = this.AddDataForm.get('Name')?.value;
    getregister.Email = this.AddDataForm.get('Email')?.value;
    getregister.Address = this.AddDataForm.get('Address')?.value;
    getregister.Mobilenumber = this.AddDataForm.get('Mobilenumber')?.value;
    getregister.Department = this.AddDataForm.get('Department')?.value;
    getregister.State = this.AddDataForm.get('State')?.value;
    getregister.City = this.AddDataForm.get('City')?.value;
    this.service.Register(getregister).subscribe((res:any)=>{
      alert('account added successfully')
      window.location.reload();
      
    })
  }

  getDetails(){
    this.service.getalldetails("getdata").subscribe((res:any)=>{
      this.dataSource = res.data;
    })
  }

  deletedata(data:any){
    this.service.deletedata(data).subscribe((res:any)=>{

    })
  }
}
