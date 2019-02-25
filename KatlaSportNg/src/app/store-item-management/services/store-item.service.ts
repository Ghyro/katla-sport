import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { StoreItem } from '../models/store-item';

@Injectable({
    providedIn: 'root'
})
export class StoreItemService {
    private url = environment.apiUrl + 'api/storeItems/';

    constructor(private http: HttpClient) { }

    getHiveSectionStoreItems(hiveSectionId: number): Observable<Array<StoreItem>> {
        return this.http.get<Array<StoreItem>>(`${this.url}${hiveSectionId}`);
    }
}