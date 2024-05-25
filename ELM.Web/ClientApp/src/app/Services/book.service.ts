import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class BookService {

  constructor(private http: HttpClient) { }

  GetBooks(searchObj : any) {
    let params = new HttpParams();

    params = params.append('SearchText', searchObj.searchText);
    params = params.append('PageSize', searchObj.pageSize);
    params = params.append('PageNumber', searchObj.pageNumber);

    return this.http.get<any>('http://localhost:5232/' + 'api/Books', { params: params }).pipe(map(x => x));

  }
}
