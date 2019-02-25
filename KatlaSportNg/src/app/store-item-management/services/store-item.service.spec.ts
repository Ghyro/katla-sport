import { TestBed, inject } from '@angular/core/testing';

import { StoreItemService } from './store-item.service';

describe('StoreItemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StoreItemService]
    });
  });

  it('should be created', inject([StoreItemService], (service: StoreItemService) => {
    expect(service).toBeTruthy();
  }));
});