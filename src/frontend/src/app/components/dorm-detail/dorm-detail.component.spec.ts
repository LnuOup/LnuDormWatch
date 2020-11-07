import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DormDetailComponent } from './dorm-detail.component';

describe('DormDetailComponent', () => {
  let component: DormDetailComponent;
  let fixture: ComponentFixture<DormDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DormDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DormDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
