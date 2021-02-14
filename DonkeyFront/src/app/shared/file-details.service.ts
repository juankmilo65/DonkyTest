import { Injectable } from '@angular/core';
import { FileDetails } from './file-details.model';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class FileDetailsService {

  constructor(private http:HttpClient) { }

  formData: FileDetails = new FileDetails()
  readonly baseUrl='http://localhost:51962/'

  postFileDetails(){
   return this.http.post(this.baseUrl+'api/FileDetails', {
      "fileId": 0,
      "fileName": "JuanK",
      "fileSize": "22",
      "fileDate": "22/02/2021"
    })
  }
}
