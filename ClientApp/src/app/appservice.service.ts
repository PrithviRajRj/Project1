import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { registeruser } from 'src/Model/Userbody';

@Injectable({
  providedIn: 'root'
})
export class AppserviceService {

  baseUrlString = '';
  userdataforwithdraw: any;
  constructor(private https: HttpClient, @Inject('BASE_URL') baseurl: string, private router: Router) {
    this.baseUrlString = baseurl;
  }

Register(data: registeruser) {
  const url = `${this.baseUrlString}api/Auth/register`;
  return this.https.post(url, data)
}

getalldetails(data: any) {
  const url = `${this.baseUrlString}api/Auth/GetAlldata`;
  return this.https.get(url)
}
deletedata(data: any) {
  const url = `${this.baseUrlString}api/Auth/DeleteData/${data}`;
  return this.https.delete(url, data)
}
}
