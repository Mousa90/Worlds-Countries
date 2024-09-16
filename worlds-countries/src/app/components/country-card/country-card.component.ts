import { Component, Input, OnInit } from '@angular/core';

import { City } from '../../models/city.model';
import { Country } from '../../models/country.model';
import { CityService } from '../../services/city.service';

@Component({
  selector: 'country-card',
  templateUrl: './country-card.component.html',
  styleUrl: './country-card.component.css'
})
export class CountryCardComponent implements OnInit {

  @Input('country') country: Country = {
    id: 0,
    name: '',
    description: '',
    imageUrl: '',
    flagUrl: ''
  };
  @Input('show-actions') showActions: boolean = true;

  cities!: City[];

  constructor(
    private cityService: CityService
  ) { }

  ngOnInit(): void {
    this.loadCities();
  }

  refreshCities() {
    this.loadCities(); // Initial load
  }

  private loadCities(): void {
    this.cityService.getAllCitiesByCountry(this.country.id).subscribe({
      next: (response) => this.cities = response,
      error: (err) => {
        console.error('Error loading cities:', err);
      }
    });
  }

  trimString(str: string): string {
    const maxLength = 150;
    if (str.length > maxLength) {
      const trimmed = str.slice(0, maxLength);
      const lastSpace = trimmed.lastIndexOf(' ');
      return lastSpace > -1 ? trimmed.slice(0, lastSpace) + ' ...' : trimmed + ' ...';
    }
    return str;
  }

}
