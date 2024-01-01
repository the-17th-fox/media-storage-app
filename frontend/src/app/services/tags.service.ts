import { Injectable } from '@angular/core';
import { TagDto } from '../models/tags';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  constructor(
    private httpClient: HttpClient) { 

  }

  private apiRoute: string = 'https://localhost:7057/api/tags';

  getAll() {
    return this.httpClient
      .get<TagDto[]>(`${this.apiRoute}`, {
        headers: {
          'Access-Control-Allow-Origin': '*'
        }
      });
  }
}
