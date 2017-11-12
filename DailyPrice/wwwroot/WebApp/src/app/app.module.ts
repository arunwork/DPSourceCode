import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { StatesComponent } from './admin/states/states.component';
import { StateService } from './admin/states/state.service';
import { HttpClientModule } from '@angular/common/http';
import { HttpService } from './http.service';


@NgModule({
  declarations: [
    AppComponent,
    StatesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [StateService,HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
