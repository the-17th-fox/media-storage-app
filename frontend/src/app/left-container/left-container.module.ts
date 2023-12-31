import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeftContainerComponent } from './left-container.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { TagsComponent } from './tags/tags.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    SearchBarComponent,
    LeftContainerComponent,
    TagsComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    LeftContainerComponent
  ]
})
export class LeftContainerModule { }
