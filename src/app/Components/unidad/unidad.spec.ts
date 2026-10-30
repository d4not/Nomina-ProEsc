import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Unidad } from './unidad';

describe('Unidad', () => {
  let component: Unidad;
  let fixture: ComponentFixture<Unidad>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Unidad],
    }).compileComponents();

    fixture = TestBed.createComponent(Unidad);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
