import { Component, ViewChild } from '@angular/core';
import { SearchBarComponent } from './search-bar/search-bar.component';

@Component({
  selector: 'app-left-container',
  templateUrl: './left-container.component.html',
  styleUrls: ['./left-container.component.scss']
})
export class LeftContainerComponent {
  tags = [
    { name: 'Yanmar' },
    { name: 'Dog' },
    { name: 'Cat' },
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
