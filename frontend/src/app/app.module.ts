import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LeftContainerModule } from './left-container/left-container.module';
import { MediaContainerModule } from './media-container/media-container.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LeftContainerModule,
    MediaContainerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
