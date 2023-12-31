import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MediaComponent } from './media/media.component';
import { MediaContainerComponent } from './media-container.component';



@NgModule({
  declarations: [
    MediaComponent,
    MediaContainerComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MediaContainerComponent
  ]
})
export class MediaContainerModule { }
