import { Component, OnInit } from '@angular/core';
import { NgForm , NgControl} from '@angular/forms';
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
  public mimeType: string | undefined;
  public optionSelected : string | undefined;
  private fileToUpload: File | null = null;
  
  constructor(
    public service:FileDetailsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.getMimeType();
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
    this.mimeType = undefined;
   
  }

  onSelectMime(e:any){
    debugger
    this.mimeType = e === 'Choose'? undefined:`.${e}` ;
  }

  onSetSize(e:any){

  }

  resetForm(form:NgForm){
    form.form.reset;
    this.service.formData = new FileDetails();
    this.mimeType = undefined;
  }

  handleFileInput(files:any)
  {
    debugger
    
    if(files.length === 0)
    return;

    let reader = new FileReader();
    this.fileToUpload = <File>files[0];

    this.service.formData.fileDate = formatDate(new Date(), 'yyyy/MM/dd', 'en');
    this.service.formData.fileName =   this.fileToUpload.name;
    this.service.formData.fileSize = this.fileToUpload.size.toString();
    this.service.formData.fileType = this.fileToUpload.type;
    reader.onload = () => {
      if(reader && reader.result)
      {
        this.service.formData.file = reader.result.toString();
      }
  }
  reader.readAsDataURL(this.fileToUpload);

  }
}
