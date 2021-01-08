import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchComponent } from './search.component';
import { Observable } from 'rxjs';
import { SearchService } from '../search.service';
import { FormsModule } from '@angular/forms';

describe('SearchComponent', () => {
  let component: SearchComponent;
  let fixture: ComponentFixture<SearchComponent>;
  let searchService = jasmine.createSpy('').and.returnValue({
    getSearch: jasmine.createSpy('').and.returnValue(new Observable<Object>())
  });
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchComponent ],  
      imports: [FormsModule],
      providers: [{provide: SearchService, useClass: searchService}]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  
  it('after onSubmit searchObject should be loaded', () => {
    
  });
});
