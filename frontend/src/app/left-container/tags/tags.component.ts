import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TagDto } from './tag';



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
}
