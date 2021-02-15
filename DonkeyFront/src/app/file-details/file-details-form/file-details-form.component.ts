import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FileDetails } from 'src/app/shared/file-details.model';
import { FileDetailsService } from 'src/app/shared/file-details.service';
import {formatDate} from '@angular/common';

@Component({
  selector: 'app-file-details-form',
  templateUrl: './file-details-form.component.html',
  styleUrls: ['./file-details-form.component.css']
})
export class FileDetailsFormComponent implements OnInit {

  public message: string;
  public progress: number;

  private fileToUpload: File | null = null;
  private fileName: String;


  constructor(
    public service:FileDetailsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    debugger
    this.service.postFileDetails().subscribe(
      res=>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted successfully', 'File uploaded')
      },err=>{
        console.log(err);
      }
    )
  }
  onCleanForm()
  {
    this.service.formData = new FileDetails();
  }

  resetForm(form:NgForm){
    form.form.reset;
    this.service.formData = new FileDetails();
  }

  handleFileInput(files:any)
  {
    debugger
    
    if(files.length === 0)
    return;

    this.fileToUpload = <File>files[0];

    this.service.formData.fileDate = formatDate(new Date(), 'yyyy/MM/dd', 'en');
    this.service.formData.fileName =   this.fileToUpload.name;
    this.service.formData.fileSize = this.fileToUpload.size.toString();
  }
}
