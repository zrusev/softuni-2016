import { Component, OnInit, DoCheck } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit, DoCheck {
  isLoggedIn: boolean;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  ngDoCheck() {
    this.isLoggedIn = this.authService.isAuthenticated();
  }

}
