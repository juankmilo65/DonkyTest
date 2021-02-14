import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FileDetailsService } from 'src/app/shared/file-details.service';

@Component({
  selector: 'app-file-details-form',
  templateUrl: './file-details-form.component.html',
  styleUrls: ['./file-details-form.component.css']
})
export class FileDetailsFormComponent implements OnInit {

  constructor(public service:FileDetailsService) { }

  ngOnInit(): void {
  }

  onSubmit(from:NgForm){
    this.service.postFileDetails().subscribe(
      res=>{
        
      },err=>{
        console.log(err);
      }
    )
  }
}
