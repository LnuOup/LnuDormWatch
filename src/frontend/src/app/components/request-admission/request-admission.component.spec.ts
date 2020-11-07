import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestAdmissionComponent } from './request-admission.component';

describe('RequestAdmissionComponent', () => {
  let component: RequestAdmissionComponent;
  let fixture: ComponentFixture<RequestAdmissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestAdmissionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestAdmissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
