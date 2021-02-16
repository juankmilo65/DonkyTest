import { Injectable } from '@angular/core';
import { FileDetails } from './file-details.model';
import {HttpClient} from "@angular/common/http";
import mimeTypes from '../../assets/mimeTypes.json'

@Injectable({
  providedIn: 'root'
})
export class FileDetailsService {

  constructor(private http:HttpClient) { }

  formData: FileDetails = new FileDetails();
  list: FileDetails[];
  filetypes = new Array() ;

  readonly baseUrl='http://localhost:51962/api/FileDetails'
  
  postFileDetails(){
   return this.http.post(this.baseUrl, this.formData)
  }

  deleteFile(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseUrl).toPromise()
    .then(res => this.list = res as FileDetails[]);
  }

  getMimeType(){
    mimeTypes.map((o:any)=> this.filetypes.push(o as {code:string}))
  }
}
