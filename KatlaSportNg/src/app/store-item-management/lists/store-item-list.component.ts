import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreItem } from '../models/store-item';
import { StoreItemService } from '../services/store-item.service';

@Component({
    selector: 'app-store-item-list',
    templateUrl: './store-item-list.component.html',
    styleUrls: ['./store-item-list.component.css']
})
export class StoreItemListComponent implements OnInit {

    hiveId: number;
    hiveSectionId: number;
    storeItems: StoreItem[];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private storeItemService: StoreItemService
    ) { }

    ngOnInit() {
        this.route.params.subscribe(p => {
            this.hiveId = p['hiveId'];
            this.hiveSectionId = p['id'];
            this.storeItemService.getHiveSectionStoreItems(this.hiveSectionId).subscribe(i => this.storeItems = i);
        })
    }

}