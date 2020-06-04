import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectComponent } from './project.component';
import { FormsModule } from '@angular/forms';
//import { BsDatepickerModule, ModalModule, BsModalService } from 'ngx-bootstrap';
import { ModalModule, BsModalService } from "ngx-bootstrap/modal";
import { BsDatepickerModule } from "ngx-bootstrap//datepicker";
import { BrowserModule } from '@angular/platform-browser';
import { RouterTestingModule } from '@angular/router/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { FilteruserPipe } from '../pipes/filteruser.pipe';
import { Ng5SliderModule } from 'ng5-slider';
import { EventService } from '../services/event.service';
import { ProjectService } from '../services/project.service';
import { UserService } from '../services/user.service';
import { TaskService } from '../services/task.service';
import { Directive } from '@angular/core';
import { HostListener } from '@angular/core';
import { Input } from '@angular/core';


@Directive({
  selector: '[routerLink]'
})
export class RouterLinkDirectiveStub {
  @Input('routerLink') linkParams: any;
  navigatedTo: any = null;

  @HostListener('click')
  onClick() {
    this.navigatedTo = this.linkParams;
  }
}

@Directive({
  selector: '[routerLinkActive]'
})
export class routerLinkActiveDirectiveStub {
  @Input('routerLinkActive') linkParams: any;
  navigatedTo: any = null;

  @HostListener('click')
  onClick() {
    this.navigatedTo = this.linkParams;
  }
}

describe('ProjectComponent', () => {
  let component: ProjectComponent;
  let fixture: ComponentFixture<ProjectComponent>;



  var mockProjectService = jasmine.createSpyObj(['getProject', 'addProject', 'updateProject', 'deleteProject']);
  var mockEventService = jasmine.createSpyObj(['showSuccess', 'showWarning', 'showError', 'showLoading']);
  var mockUserService = jasmine.createSpyObj(['getUser', 'addUser', 'updateUser', 'deleteUser']);
  var mockModalService = jasmine.createSpyObj(['show', 'hide']);
  var mockTaskService = jasmine.createSpyObj(['getParentTask', 'addTask', 'getAllTasksByProjectId', 'updateTask', 'deleteTask']);


  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, BsDatepickerModule.forRoot(), ModalModule.forRoot(),
        BrowserModule,
        BrowserAnimationsModule,
        RouterTestingModule,
        ToastrModule.forRoot({
          timeOut: 3000,
          positionClass: 'toast-bottom-right',
          preventDuplicates: true
        }), Ng5SliderModule],
      declarations: [ProjectComponent, FilteruserPipe,
        RouterLinkDirectiveStub, routerLinkActiveDirectiveStub],
      providers: [

        { provide: EventService, useValue: mockEventService },
        { provide: ProjectService, useValue: mockProjectService },
        { provide: UserService, useValue: mockUserService },
        { provide: TaskService, useValue: mockTaskService },
        { provide: BsModalService, useValue: mockModalService }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectComponent);
    component = fixture.componentInstance;
    mockUserService.getUser.and.returnValue({ subscribe: () => { } });
    mockProjectService.getProject.and.returnValue({ subscribe: () => { } });
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
