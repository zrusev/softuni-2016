import { Component, OnInit } from '@angular/core';
import { Furniture } from 'src/app/models/furniture';
import { FurnitureService } from '../furniture.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-furniture-all',
  templateUrl: './furniture-all.component.html',
  styleUrls: ['./furniture-all.component.css']
})
export class FurnitureAllComponent implements OnInit {
  furnitures$: Observable<Furniture[]>;
  constructor(private furnitureService: FurnitureService) { }

  ngOnInit() {
    this.furnitures$ = this.furnitureService.getAllFurnitures();
  }

}
