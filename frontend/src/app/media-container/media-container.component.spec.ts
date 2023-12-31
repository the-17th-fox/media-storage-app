import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MediaContainerComponent } from './media-container.component';

describe('MediaContainerComponent', () => {
  let component: MediaContainerComponent;
  let fixture: ComponentFixture<MediaContainerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MediaContainerComponent]
    });
    fixture = TestBed.createComponent(MediaContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
