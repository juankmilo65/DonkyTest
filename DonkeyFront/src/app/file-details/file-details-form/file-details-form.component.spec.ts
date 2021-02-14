import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileDetailsFormComponent } from './file-details-form.component';

describe('FileDetailsFormComponent', () => {
  let component: FileDetailsFormComponent;
  let fixture: ComponentFixture<FileDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FileDetailsFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
