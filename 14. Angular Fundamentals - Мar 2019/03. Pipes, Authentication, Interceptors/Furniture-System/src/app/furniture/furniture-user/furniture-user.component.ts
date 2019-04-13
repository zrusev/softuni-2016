import { Component, OnInit } from '@angular/core';
import { FurnitureService } from '../furniture.service';
import { Furniture } from 'src/app/models/furniture';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-furniture-user',
  templateUrl: './furniture-user.component.html',
  styleUrls: ['./furniture-user.component.css']
})
export class FurnitureUserComponent implements OnInit {
  userFurniture$: Observable<Furniture[]>;
  constructor(private furnitureService: FurnitureService) { }

  ngOnInit() {
    this.userFurniture$ = this.furnitureService.getUserFurniture();
  }

  deleteFurniture(id: string) {
    this.furnitureService.deleteFurniture(id).subscribe((data) => {
      this.userFurniture$ = this.furnitureService.getUserFurniture();
    });
  }

}
