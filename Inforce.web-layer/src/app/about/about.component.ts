import { Component, OnInit, input } from '@angular/core';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UrlService } from '../../services/urlService';
import { algorithInfoService } from '../../services/algorithInfoService';

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

  isAdmin: boolean = false;

  stage1 = '';
  stage2 = '';
  stage3 = '';
  stage4 = '';
  stage5 = '';
  stage6 = '';
  stage7 = '';



  ngOnInit(): void {

    this.algorithmInfoService.getAlgorithmInfo().subscribe( data =>{
      this.stage1 = data.stage1;
      this.stage2 = data.stage2;
      this.stage3 = data.stage3;
      this.stage4 = data.stage4;
      this.stage5 = data.stage5;
      this.stage6 = data.stage6;
      this.stage7 = data.stage7;
    });

    let token = this.localService.get(LocalService.AuthTokenName);

    if (token) {
      let decodedData = this.jwtHelperService.decodeToken(token);
      this.isAdmin = decodedData.role == "Admin";
      if(!this.isAdmin){
        var inputFields = document.querySelectorAll<HTMLInputElement>('input[type="text"]');
        inputFields.forEach(function(inputField) {
            inputField.readOnly = true;
        });
      }
    }
  }
}
