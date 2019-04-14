import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { FurnitureService } from '../furniture.service';

import { FurnitureUserComponent } from '../furniture-user/furniture-user.component';
import { FurnitureDetailsComponent } from '../furniture-details/furniture-details.component';
import { CreateFurnitureComponent } from '../create-furniture/create-furniture.component';
import { FurnitureAllComponent } from '../furniture-all/furniture-all.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'create', component: CreateFurnitureComponent },
      { path: 'all', component: FurnitureAllComponent },
      { path: 'details/:id', component: FurnitureDetailsComponent },
      { path: 'user', component: FurnitureUserComponent }
    ])
  ],
  declarations: [
    FurnitureAllComponent,
    CreateFurnitureComponent,
    FurnitureDetailsComponent,
    FurnitureUserComponent
  ],
  providers: [
    FurnitureService
  ]
})

export class FurnitureModule { }
