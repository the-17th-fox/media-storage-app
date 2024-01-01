import { Component, OnInit, ViewChild } from '@angular/core';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { TagCategory, TagDto } from '../models/tags';
import { TagsService } from '../services/tags.service';

@Component({
  selector: 'app-left-container',
  templateUrl: './left-container.component.html',
  styleUrls: ['./left-container.component.scss']
})
export class LeftContainerComponent implements OnInit {
  constructor(
    private tagsService: TagsService
  ) { }

  tags: TagDto[] = [];

  @ViewChild(SearchBarComponent) searchBarComponent: SearchBarComponent;

  ngOnInit(): void {
    this.tagsService
      .getAll()
      .subscribe(resp => {
        this.tags = resp;
      })
  }

  handleTagPicking(tag: string) {
    this.searchBarComponent.appendToSearchValue(tag);
  }

  handleSearchInputChanged(value: string) {
  }

  handleSearch(query: string) {
  }
}
