import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AminalUpdateComponent } from './aminal-update.component';

describe('AminalUpdateComponent', () => {
  let component: AminalUpdateComponent;
  let fixture: ComponentFixture<AminalUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AminalUpdateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AminalUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
