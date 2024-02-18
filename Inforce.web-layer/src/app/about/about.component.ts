import { Component, OnInit, input } from '@angular/core';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UrlService } from '../../services/urlService';
import { algorithInfoService } from '../../services/algorithInfoService';
import { AlgorithInfoModel } from '../../models/algorithInfo';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrl: './about.component.scss'
})
export class AboutComponent implements OnInit {

  constructor(private localService: LocalService,
    private jwtHelperService: JwtHelperService,
    private algorithmInfoService: algorithInfoService) {

  }
  
  islogged: boolean = false;
  isAdmin: boolean = false;

  algorithmInfo = new AlgorithInfoModel();


  onUpdate() {
    let algorithInfoModel = this.algorithmInfo;
    this.algorithmInfoService.updateAlgorithmInfo(algorithInfoModel).subscribe(data => {
      this.algorithmInfo = data;
    });
}


ngOnInit(): void {

  this.algorithmInfoService.getAlgorithmInfo().subscribe(data => {
    this.algorithmInfo = data;
  });

  var inputFields = document.querySelectorAll<HTMLInputElement>('input[type="text"]');
      inputFields.forEach(function (inputField) {
        inputField.readOnly = true;
      });

  let token = this.localService.get(LocalService.AuthTokenName);

  if(token) {
    let decodedData = this.jwtHelperService.decodeToken(token);
    this.isAdmin = decodedData.role == "Admin";
    if (this.isAdmin) {
      inputFields.forEach(function (inputField) {
        inputField.readOnly = false;
      });
    }
  }
}
}
