import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FileDetailsService } from '../shared/file-details.service';

@Component({
  selector: 'app-file-details',
  templateUrl: './file-details.component.html',
  styleUrls: ['./file-details.component.css']
})
export class FileDetailsComponent implements OnInit {

   title = "Welcome to File storage";

  constructor(
    public service: FileDetailsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList()
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?')){
      this.service.deleteFile(id)
      .subscribe(
        ()=>{
          this.service.refreshList();
          this.toastr.error("Deleted successfully", 'File Storage')
        },
        (err: any) =>{console.error(err)}
      )
    }
  }
}
