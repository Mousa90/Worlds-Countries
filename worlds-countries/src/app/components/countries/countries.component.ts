import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { CountryService } from './../../services/country.service';
import { Country } from './../../models/country.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ToastService } from './../../services/toast.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrl: './countries.component.css'
})
export class CountriesComponent implements OnInit, AfterViewInit {

  countries: Country[] = [];
  dataSource = new MatTableDataSource<Country>();
  displayedColumns: string[] = ['country', 'delete-button', 'edit-button'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  private currentCountryId!: number;

  constructor(
    private router: Router,
    private countryService: CountryService,
    private toastService: ToastService
  ) { }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.loadCountries();
  }

  private loadCountries(): void {
    this.countryService.getAllCountries().subscribe({
      next: (response) => {
        this.countries = response.sort((a, b) => a.name.localeCompare(b.name));
        this.dataSource.data = this.countries;
      },
      error: (err) => {
        console.error('Error loading countries:', err);
        this.toastService.toast("failure", "Error loading countries");
      }
    });
  }

  deleteCountry(): void {
    if (!this.currentCountryId) return;

    this.countryService.deleteCountry(this.currentCountryId).subscribe({
      next: () => {
        this.ngOnInit();
        this.toastService.toast("success", "The country has been deleted successfully!");
      },
      error: (err) => {
        console.error('Error deleting country:', err);
        this.toastService.toast("failure", "Error deleting country");
      }
    });
  }

  setCountryId(countryId: number): void {
    this.currentCountryId = countryId;
  }

  goToEditPage(countryId: string) {
    this.router.navigate(['/countries/' + countryId]);
  }
}
