import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { Country, AddCountry } from '../models/country.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private http: HttpClient) { }

  apiBaseUrl = environment.apiBaseUrl;

  getAllCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.apiBaseUrl + '/api/Country');
  }

  getCountryById(id: number | undefined): Observable<Country> {
    return this.http.get<Country>(this.apiBaseUrl + '/api/Country/' + id);
  }

  updateCountry(id: number | undefined, updateCountryRequest: Country): Observable<Country> {
    return this.http.put<Country>(this.apiBaseUrl + '/api/Country/' + id, updateCountryRequest);
  }

  addCountry(addCountryRequest: AddCountry): Observable<Country> {
    return this.http.post<Country>(this.apiBaseUrl + '/api/Country/', addCountryRequest);
  }

  deleteCountry(id: number | undefined): Observable<Country> {
    return this.http.delete<Country>(this.apiBaseUrl + '/api/Country/' + id);
  }
}
