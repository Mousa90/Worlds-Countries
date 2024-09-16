import { AfterViewInit, Component, OnInit, ViewEncapsulation } from '@angular/core';

import { Location } from '@angular/common';
import { CountryService } from '../../services/country.service';
import { AddCountry, Country } from '../../models/country.model';
import { CityService } from '../../services/city.service';
import { AddCity, City } from '../../models/city.model';
import { ToastService } from '../../services/toast.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-country-form',
  templateUrl: './country-form.component.html',
  styleUrl: './country-form.component.css',
  encapsulation: ViewEncapsulation.None
})
export class CountryFormComponent implements OnInit, AfterViewInit {

  title: string = "Country"

  countryAdd: AddCountry = {
    name: '',
    description: '',
    imageUrl: '',
    flagUrl: ''
  };

  country: Country = {
    id: 0,
    name: '',
    description: '',
    imageUrl: '',
    flagUrl: ''
  };

  cities: City[] = []; // Initialize with an empty array
  city: AddCity = {
    name: '',
    countryId: 0
  };

  id!: any;
  isNewCountry = false;
  private currentCityId!: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private location: Location,
    private countryService: CountryService,
    private cityService: CityService,
    private toastService: ToastService
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.route.snapshot.routeConfig?.path === "countries/new") {
      this.title = "New Country";
      this.isNewCountry = true;
    } else {
      this.title = "Edit Country";
      this.loadCountry();
      this.loadCities();
    }
  }

  ngAfterViewInit(): void {
    console.log(this.country); // Check if the country object is correctly bound after view initialization
  }

  private loadCountry(): void {
    this.countryService.getCountryById(this.id).subscribe({
      next: (response) => {
        this.country = response;
        console.log(this.country);
      },
      error: (err) => {
        console.error('Error loading country:', err);
        this.toastService.toast("failure", "Error loading country");
      }
    });
  }

  private loadCities(): void {
    this.cityService.getAllCitiesByCountry(this.id).subscribe({
      next: (response) => this.cities = response,
      error: (err) => {
        console.error('Error loading cities:', err);
        this.toastService.toast("failure", "Error loading cities");
      }
    });
  }

  save(countryData: any): void {
    if (this.id) {
      this.updateCountry(countryData);
    } else {
      this.addCountry(countryData);
    }
  }

  private updateCountry(countryData: any): void {
    this.country = { ...countryData, id: this.id };
    this.countryService.updateCountry(this.id, this.country).subscribe({
      next: () => {
        this.router.navigate(['/countries']);
        this.toastService.toast("success", "The country has been updated successfully!");
      },
      error: (err) => {
        console.error('Error updating country:', err);
        this.toastService.toast("failure", "Error updating country!");
      }
    });
  }

  private addCountry(countryData: any): void {
    this.countryAdd = countryData;
    this.countryService.addCountry(this.countryAdd).subscribe({
      next: () => {
        this.router.navigate(['/countries']);
        this.toastService.toast("success", "The country has been added successfully!");
      },
      error: (err) => {
        console.error('Error adding country:', err);
        this.toastService.toast("failure", "Error adding country!");
      }
    });
  }

  deleteCountry(): void {
    this.countryService.deleteCountry(this.id).subscribe({
      next: () => {
        this.router.navigate(['/countries']);
        this.toastService.toast("success", "The country has been deleted successfully!");
      },
      error: (err) => {
        console.error('Error deleting country:', err);
        this.toastService.toast("failure", "Error deleting country!");
      }
    });
  }

  addCity(cityData: any, fc:NgForm): void {
    this.city = { name: cityData.cityName, countryId: this.id };
    this.cityService.addCity(this.city).subscribe({
      next: () => {
        this.loadCities();
        
        if (this.cities.length == 0)
          this.toastService.toast("success", "The capital has been added successfully!");
        else
          this.toastService.toast("success", "The city has been added successfully!");

          fc.resetForm();
      },
      error: (err) => {
        console.error('Error adding city:', err);
        this.toastService.toast("failure", "Error adding city!");
      }
    });
  }

  updateKey(cityId: number): void {
    this.currentCityId = cityId;
  }

  deleteCity(): void {
    this.cityService.deleteCity(this.currentCityId).subscribe({
      next: () => {
        this.loadCities();
        if (this.cities.length == 1)
          this.toastService.toast("success", "The capital has been deleted successfully!");
        else
          this.toastService.toast("success", "The city has been deleted successfully!");
      },
      error: (err) => {
        console.error('Error deleting city:', err);
        this.toastService.toast("failure", "Error deleting city!");
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/countries']);
  }
}
