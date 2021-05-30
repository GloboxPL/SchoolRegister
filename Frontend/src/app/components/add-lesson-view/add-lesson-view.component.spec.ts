import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLessonViewComponent } from './add-lesson-view.component';

describe('AddLessonViewComponent', () => {
  let component: AddLessonViewComponent;
  let fixture: ComponentFixture<AddLessonViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLessonViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLessonViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
