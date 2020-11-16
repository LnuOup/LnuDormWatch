import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumSectionThreadListComponent } from './forum-section-thread-list.component';

describe('ForumSectionThreadListComponent', () => {
  let component: ForumSectionThreadListComponent;
  let fixture: ComponentFixture<ForumSectionThreadListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumSectionThreadListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ForumSectionThreadListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
