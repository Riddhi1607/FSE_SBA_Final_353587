import { async, ComponentFixture, TestBed, } from '@angular/core/testing';
import { Directive, HostListener, Input } from '@angular/core'
import { AddTaskComponent } from './add-task.component';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { Ng5SliderModule } from 'ng5-slider';
import { BsDatepickerModule } from "ngx-bootstrap//datepicker";
import { FilteruserPipe } from '../pipes/filteruser.pipe';
import { EventService } from '../services/event.service';
import { ProjectService } from '../services/project.service';
import { UserService } from '../services/user.service';
import { TaskService } from '../services/task.service';
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal';
import { RouterTestingModule } from '@angular/router/testing';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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

describe('AddTaskComponent', () => {
  let component: AddTaskComponent;
  let fixture: ComponentFixture<AddTaskComponent>;

  beforeEach(async(() => {
    var mockProjectService = jasmine.createSpyObj(['getProject', 'addProject', 'updateProject', 'deleteProject']);
    var mockEventService = jasmine.createSpyObj(['showSuccess', 'showWarning', 'showError', 'showLoading']);
    var mockUserService = jasmine.createSpyObj(['getUser', 'addUser', 'updateUser', 'deleteUser']);
    var mockModalService = jasmine.createSpyObj(['show', 'hide']);
    var mockTaskService = jasmine.createSpyObj(['getParentTask', 'addTask', 'getAllTasksByProjectId', 'updateTask', 'deleteTask']);
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
      declarations: [AddTaskComponent, FilteruserPipe,
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
    fixture = TestBed.createComponent(AddTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
