import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SearchService } from '../search.service';
import { Search } from '../models/search.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  @ViewChild('f') searchForm: NgForm;
  searchObject: Search;
  loading = false;
  error = null;
  results = null;
  defaultEngine = "Google";
  
  
  constructor(private searchService: SearchService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.error = null;
    this.loading = true;
    this.searchObject = this.searchForm.value;
    this.searchObject.numResults=100;
    this.searchService.getSearch(this.searchObject).subscribe(response => {
      this.loading = false;  
      this.results = response;  
    }, error => {
      this.error = error;
    });
  }

  onReset() {
    this.results = null;
  }
}
