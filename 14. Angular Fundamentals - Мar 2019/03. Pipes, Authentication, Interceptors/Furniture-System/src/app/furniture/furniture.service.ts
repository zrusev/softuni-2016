import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Furniture } from '../models/furniture';
import { Observable } from 'rxjs';

const CREATE_URL = 'http://localhost:5000/furniture/create';
const ALL_URL = 'http://localhost:5000/furniture/all';

@Injectable({
  providedIn: 'root'
})
export class FurnitureService {

  constructor(private http: HttpClient) { }

  createFurniture(data) {
    return this.http.post<Furniture>(CREATE_URL, data);
  }

  getAllFurnitures(): Observable<Furniture[]> {
    return this.http.get<Furniture[]>(ALL_URL);
  }

}
