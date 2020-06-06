import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ModalModule } from "ngx-bootstrap/modal";
import { BsDatepickerModule } from "ngx-bootstrap//datepicker";
import { Ng5SliderModule } from 'ng5-slider';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module'

import { UserService } from './services/user.service';
import { ToastrModule } from 'ngx-toastr';

import { EventService } from './services/event.service';
import { BaseService } from './services/base.service';
import { ProjectService } from './services/project.service';
import { TaskService } from './services/task.service';

import { FilteruserPipe } from './pipes/filteruser.pipe';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { ProjectComponent } from './project/project.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { ViewTaskComponent } from './view-task/view-task.component'




@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    FilteruserPipe,
    ProjectComponent,
    AddTaskComponent,
    ViewTaskComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),

    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-left-Custom',
      preventDuplicates: true
    }),
    Ng5SliderModule
  ],
  providers: [BaseService, UserService, EventService, ProjectService, TaskService],
  bootstrap: [AppComponent]
})
export class AppModule { }
