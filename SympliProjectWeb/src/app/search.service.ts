import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Search } from './models/search.model';
import { environment } from '../environments/environment'
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  private searchEndpoint = `${environment.apiURL}/Search`;

  constructor(private http: HttpClient) { }

  getSearch(searchModel: Search) {
    const requestUrl = `${this.searchEndpoint}/${searchModel.searchEngine}`;

    let searchParams = new HttpParams();
    searchParams = searchParams.append('keywords', searchModel.keywords);
    searchParams = searchParams.append('matchUrl', searchModel.matchUrl);
    searchParams = searchParams.append('numResults', searchModel.numResults.toString());

    return this.http.get(
      requestUrl,
      {
        params: searchParams
      }
    )
    .pipe(
      catchError(errorResponse => {
        return throwError(errorResponse);
      })
    );
  }
}
