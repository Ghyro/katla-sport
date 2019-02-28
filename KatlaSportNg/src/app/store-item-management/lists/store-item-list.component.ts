import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreItemListItem } from '../models/store-item-list-item';
import { StoreItemService } from '../services/store-item.service';
import { StoreItem } from '../models/store-item';

@Component({
    selector: 'app-store-item-list',
    templateUrl: './store-item-list.component.html',
    styleUrls: ['./store-item-list.component.css']
})
export class StoreItemListComponent implements OnInit {

    hiveId: number;
    hiveSectionId: number;
    confirmedStoreItems: StoreItemListItem[];
    unconfirmedStoreItems: StoreItemListItem[];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private storeItemService: StoreItemService
    ) { }

    ngOnInit() {
        this.route.params.subscribe(p => {
            this.hiveId = p['hiveId'];
            this.hiveSectionId = p['id'];
            this.storeItemService.getHiveSectionStoreItems(this.hiveSectionId).subscribe(i => {
                this.confirmedStoreItems = i.filter(si => si.isConfirmed == true);
                this.unconfirmedStoreItems = i.filter(si => si.isConfirmed == false);
            });
        })
    }

    onConfirm(storeItemListItem: StoreItemListItem) {
        this.storeItemService.confirmStoreItem
        (new StoreItem(
            storeItemListItem.id,
            storeItemListItem.productId,
            +this.hiveSectionId,
            storeItemListItem.quantity,
            true
        )).subscribe(i => {
            storeItemListItem.isConfirmed = true;
            let index = this.unconfirmedStoreItems.indexOf(storeItemListItem);
            if (index !== -1) this.unconfirmedStoreItems.splice(index, 1);
            this.confirmedStoreItems.push(storeItemListItem);
        });
    }
}