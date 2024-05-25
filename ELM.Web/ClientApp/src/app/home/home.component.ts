import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatTableDataSource } from '@angular/material/table';
import { SearchDto } from '../SearchDto';
import { BookService } from '../Services/book.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [BookService]
})



export class HomeComponent implements OnInit {

  bookList: any[] = [];
  constructor(
    private bookService: BookService) {
  }

  ngOnInit(): void {
    let obj = new SearchDto();
    obj.pageNumber = 1;
    obj.pageSize = 10;
    obj.searchText = '';
    this.GetBook(obj);

  }
  dataSource = new MatTableDataSource<any>([]); // Replace any with your actual data type
  displayedColumns: string[] = ['column1', 'column2']; // Replace with your actual column names

  applyFilter(value : any) {
    value = value.value.trim(); // Remove whitespace
    value = value.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = value;
    let obj = new SearchDto();
    obj.pageNumber = 1;
    obj.pageSize = 10;
    obj.searchText = value;
    this.GetBook(obj);
  }


  GetBook(obj:any) {
    this.bookService.GetBooks(obj).subscribe((res: any) => {
      if (res != null) {
        this.bookList = res;
      }
    });
  }

}
