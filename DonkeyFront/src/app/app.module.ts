import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from "@angular/forms"

import { AppComponent } from './app.component';
import { FileDetailsComponent } from './file-details/file-details.component';
import { FileDetailsFormComponent } from './file-details/file-details-form/file-details-form.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    FileDetailsComponent,
    FileDetailsFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
