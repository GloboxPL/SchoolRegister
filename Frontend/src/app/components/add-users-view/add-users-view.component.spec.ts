import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUsersViewComponent } from './add-users-view.component';

describe('AddUsersViewComponent', () => {
  let component: AddUsersViewComponent;
  let fixture: ComponentFixture<AddUsersViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUsersViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUsersViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
