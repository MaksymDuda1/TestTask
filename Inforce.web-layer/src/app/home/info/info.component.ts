import { Component, Input, OnInit, } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlModel } from '../../../models/url';
import { UrlService } from '../../../services/urlService';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrl: './info.component.scss'
})
export class InfoComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  url: UrlModel = new UrlModel();

  id: string = '';

  ngOnInit() {
    this.route.params.subscribe(params => {
       this.id = params['id'];
       this.url.longUrl = params['longUrl'];
       this.url.shortUrl = params['shortUrl'];
       this.url.dateOfCreation = params['dateOfCreation'];
       this.url.userId = params['userId'];
    });
  }
}
