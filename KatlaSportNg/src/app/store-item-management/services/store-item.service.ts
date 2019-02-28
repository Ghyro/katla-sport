import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { StoreItemListItem } from '../models/store-item-list-item';
import { StoreItem } from '../models/store-item';

@Injectable({
    providedIn: 'root'
})
export class StoreItemService {
    private url = environment.apiUrl + 'api/storeItems/';
    private sectionUrl = this.url + 'sections/';

    constructor(private http: HttpClient) { }

    getHiveSectionStoreItems(hiveSectionId: number): Observable<Array<StoreItemListItem>> {
        return this.http.get<Array<StoreItemListItem>>(`${this.sectionUrl}${hiveSectionId}`);
    }

    addHiveSectionStoreItem(storeItem: StoreItem): Observable<StoreItem> {
        return this.http.post<StoreItem>(`${this.url}`, storeItem);
    }

    confirmStoreItem(storeItem: StoreItem): Observable<Object> {
        storeItem.isConfirmed = true;
        return this.http.put<StoreItem>(`${this.url}${storeItem.id}`, storeItem);
    }
}