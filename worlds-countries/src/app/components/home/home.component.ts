import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Country } from '../../models/country.model';
import { Router } from '@angular/router';
import { CountryService } from '../../services/country.service';
import { ToastService } from '../../services/toast.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, AfterViewInit {

  countries: Country[] = [];
  paginatedCountries: Country[] = [];
  pageSize = 12;
  pageEvent!: PageEvent;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private router: Router,
    private countryService: CountryService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.loadCountries();
  }

  private loadCountries(): void {
    this.countryService.getAllCountries().subscribe({
      next: (response) => {
        this.countries = response.sort((a, b) => a.name.localeCompare(b.name));
        this.updatePaginator(); // Update paginated countries after loading
      },
      error: (err) => {
        console.error('Error loading countries:', err);
        this.toastService.toast('failure', 'Error loading countries');
      }
    });
  }

  ngAfterViewInit() {
    this.updatePaginator();
  }

  updatePaginator() {
    const startIndex = this.paginator.pageIndex * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.paginatedCountries = this.countries.slice(startIndex, endIndex);
  }
}
