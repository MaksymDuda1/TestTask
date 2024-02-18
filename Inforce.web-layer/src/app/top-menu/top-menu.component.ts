import { Component, OnInit } from '@angular/core';
import { LocalService } from '../../services/localService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrl: './top-menu.component.scss'
})
export class TopMenuComponent {
  constructor(private localService: LocalService, private router: Router) {

  }


  isLogged: boolean = false;
  currentRoute: string = '';

  ngOnInit(): void {
    if (this.localService.get(LocalService.AuthTokenName) != null) {
      this.isLogged = true;
    }
  }

  onExit() {
    this.isLogged = false;
    this.localService.remove(LocalService.AuthTokenName);
    window.location.href = '/login';
  }
}
