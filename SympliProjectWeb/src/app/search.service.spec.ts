import { TestBed } from '@angular/core/testing';

import { SearchService } from './search.service';
import { HttpClient } from '@angular/common/http';

describe('SearchService', () => {
  let service: SearchService;
  let httpClientSpy: { get: jasmine.Spy };

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpClient]
    });
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    service = new SearchService(httpClientSpy as any);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
