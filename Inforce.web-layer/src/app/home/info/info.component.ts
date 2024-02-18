import { Component, Input, OnInit, } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlModel } from '../../../models/url';
import { UrlService } from '../../../services/urlService';
import moment from 'moment';

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
      this.url.dateOfCreation = moment(params['dateOfCreation']).format('MMMM Do YYYY, h:mm:ss a');
      this.url.userId = params['userId'];
    });
  }
}
