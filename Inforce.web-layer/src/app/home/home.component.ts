import { Component, OnInit } from '@angular/core';
import { UrlModel, UrlForShortModel, ShortenerUrl } from '../../models/url';
import { UrlService } from '../../services/urlService';
import { Observable } from 'rxjs';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  constructor(private urlService: UrlService, private router: Router,
    private route: ActivatedRoute,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService) {

    this.urls$ = this.urlService.getAll();
  }
  urls$: Observable<UrlModel[]>;

  longUrl: string = "";
  code: string = "";
  errorMessage: string = '';

  isAdmin: boolean = false;
  islogged: boolean = false;

  getById(id: string) {
    this.urlService.getById(id).subscribe(data => {
      this.router.navigate(['/info', data]);
    })
  }

  deleteById(id: string): void {
    this.urlService.deleteById(id).subscribe(data => {
      this.urls$ = this.urlService.getAll();
    },
      error => {
        this.errorMessage = error.message;
      });
  }

  deleteAll() {
    this.urlService.deleteAll().subscribe(data => {
      this.urls$ = this.urlService.getAll();
    },
      error => {
        this.errorMessage = error.message;
      })
  }

  addNewUrl() {
    let url = new UrlForShortModel();
    url.longUrl = this.longUrl;
    url.code = this.code;

    this.urlService.add(url).subscribe(data => {
      this.urls$ = this.urlService.getAll();
    },
      error => {
        this.errorMessage = error.error;
      })
  }

  ngOnInit(): void {

    let token = this.localService.get(LocalService.AuthTokenName);

    if (token) {
      this.islogged = true;
      let decodedData = this.jwtHelperService.decodeToken(token);
      this.isAdmin = decodedData.role == "Admin";
    }
  }

}
