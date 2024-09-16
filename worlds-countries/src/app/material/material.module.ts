import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatTooltipModule} from '@angular/material/tooltip';


@NgModule({
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatTooltipModule,
    MatButtonModule
  ],
  exports: [
    MatTableModule,
    MatPaginatorModule,
    MatTooltipModule,
    MatButtonModule
  ]
})
export class MaterialModule { }
