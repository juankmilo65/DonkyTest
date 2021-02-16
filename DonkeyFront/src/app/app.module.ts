import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from "@angular/forms"
import { BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { FileDetailsComponent } from './file-details/file-details.component';
import { FileDetailsFormComponent } from './file-details/file-details-form/file-details-form.component';
import { HttpClientModule } from '@angular/common/http';

import {FileDetailsService} from './shared/file-details.service'


@NgModule({
  declarations: [
    AppComponent,
    FileDetailsComponent,
    FileDetailsFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [FileDetailsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
