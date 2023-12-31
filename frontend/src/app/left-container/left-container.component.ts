import { Component, ViewChild } from '@angular/core';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { TagCategory, TagDto } from '../models/tags';

@Component({
  selector: 'app-left-container',
  templateUrl: './left-container.component.html',
  styleUrls: ['./left-container.component.scss']
})
export class LeftContainerComponent {
  tags: TagDto[] = [
    { name: 'Yanmar', category: TagCategory.General },
    { name: 'Dog', category: TagCategory.General },
    { name: 'Cat', category: TagCategory.General },
  ];

  @ViewChild(SearchBarComponent) searchBarComponent: SearchBarComponent;

  handleTagPicking(tag: string) {
    this.searchBarComponent.appendToSearchValue(tag);
  }

  handleSearchInputChanged(value: string) {
  }

  handleSearch(query: string) {
  }
}
