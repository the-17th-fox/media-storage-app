import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent {
  @Output() searchInputChanged = new EventEmitter<string>();
  @Output() searchButtonClicked = new EventEmitter<string>();

  searchValue: string = '';

  onSearchInputChange(event: any) {
    this.searchValue = event.target.value;
    this.searchInputChanged.emit(event.target.value);
  }

  onSearch() {
    this.searchButtonClicked.emit(this.searchValue);
  }

  appendToSearchValue(value: string) {
    this.searchValue += ` ${value}`;
  }
}
