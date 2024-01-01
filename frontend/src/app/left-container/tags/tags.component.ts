import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TagCategory, TagDto } from '../../models/tags';



@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss']
})
export class TagsComponent implements OnInit {
  @Input() tags: TagDto[];
  @Input() orderAlphabetically: boolean = true;

  @Output() onTagPicking = new EventEmitter<string>;

  ngOnInit(): void {
    if(this.orderAlphabetically) {
      this.tags.sort((a, b) => a.name.localeCompare(b.name));
    }
  }
  
  handleTagPicking(tag: string) {
    this.onTagPicking.emit(tag);
  }

  getTagColor(category: TagCategory) {
    switch(category) {
      case TagCategory.General:
        return "cyan";

      case TagCategory.Author:
        return "orange";

      case TagCategory.Quality:
        return "blue";

      default: 
        return "white";
    }
  }
}
