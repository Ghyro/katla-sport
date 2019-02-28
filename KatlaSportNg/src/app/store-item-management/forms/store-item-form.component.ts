import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../product-management/services/product.service';
import { ProductCategoryService } from '../../product-management/services/product-category.service';
import { StoreItemService } from '../services/store-item.service';
import { StoreItem } from '../models/store-item';
import { ProductCategory } from 'app/product-management/models/product-category';
import { ProductCategoryProductListItem } from 'app/product-management/models/product-category-product-list-item';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
    selector: 'app-store-item-form',
    templateUrl: './store-item-form.component.html',
    styleUrls: ['./store-item-form.component.css']
})
export class StoreItemFormComponent implements OnInit {

    storeItemForm: FormGroup = new FormGroup({
        quantity: new FormControl('1', Validators.min(1))
    });

    storeItem = new StoreItem(0, 0, 0, 0, false);

    hiveId: number;
    hiveSectionId: number;
    productCategory: ProductCategory;

    allowedProductCategories: ProductCategory[];
    allowedProducts: ProductCategoryProductListItem[];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private productCategoryService: ProductCategoryService,
        private productService: ProductService,
        private storeItemService: StoreItemService,
    ) {  }

    get quantity(): any { return this.storeItemForm.get('quantity'); }

    ngOnInit() {
        this.route.params.subscribe(p => {
            this.hiveId = p['hiveId'];
            this.hiveSectionId = p['id'];
            this.storeItem.hiveSectionId = this.hiveSectionId;
            this.productCategoryService.getAllowedHiveSectionProductCategories(this.hiveSectionId).subscribe(c => {
                this.allowedProductCategories = c;
            });
        })
    }

    onSubmit() {
        this.storeItem.quantity = this.quantity.value;
        this.storeItemService.addHiveSectionStoreItem(this.storeItem).subscribe(s => this.navigateToHiveSectionStoreItems());
    }

    onCancel() {
        this.navigateToHiveSection();
    }

    navigateToHiveSection() {
        this.router.navigate([`/hive/${this.hiveId}/sections`]);
    }

    navigateToHiveSectionStoreItems() {
        this.router.navigate([`/hive/${this.hiveId}/section/${this.hiveSectionId}/storeItems`]);
    }    

    updateAllowedProducts() {
        this.productService.getCategoryProducts(this.productCategory.id).subscribe(p => {
            this.allowedProducts = p;
        })
    }
}