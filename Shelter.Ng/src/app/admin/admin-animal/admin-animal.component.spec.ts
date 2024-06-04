import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAnimalComponent } from './admin-animal.component';

describe('AdminAnimalComponent', () => {
  let component: AdminAnimalComponent;
  let fixture: ComponentFixture<AdminAnimalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminAnimalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminAnimalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
