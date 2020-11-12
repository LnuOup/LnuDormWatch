import { TestBed } from '@angular/core/testing';

import { DormitoryService } from './dormitory.service';

describe('DormitoryService', () => {
  let service: DormitoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DormitoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
