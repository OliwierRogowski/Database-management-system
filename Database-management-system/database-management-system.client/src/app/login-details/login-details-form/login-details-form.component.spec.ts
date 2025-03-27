import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginDetailsFormComponent } from './login-details-form.component';

describe('LoginDetailsFormComponent', () => {
  let component: LoginDetailsFormComponent;
  let fixture: ComponentFixture<LoginDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginDetailsFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoginDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
