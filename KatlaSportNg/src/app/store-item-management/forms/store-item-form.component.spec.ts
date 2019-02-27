import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreItemFormComponent } from './store-item-form.component';

import { FormsModule } from '@angular/forms';

describe('StoreItemFormComponent', () => {
  let component: StoreItemFormComponent;
  let fixture: ComponentFixture<StoreItemFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        imports: [ FormsModule ],
      declarations: [ StoreItemFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreItemFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});