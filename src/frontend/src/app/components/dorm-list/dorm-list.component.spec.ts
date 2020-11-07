import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DormListComponent } from './dorm-list.component';

describe('DormListComponent', () => {
  let component: DormListComponent;
  let fixture: ComponentFixture<DormListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DormListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DormListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
