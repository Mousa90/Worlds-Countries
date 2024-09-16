import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { City, AddCity } from '../models/city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient) { }

  apiBaseUrl = environment.apiBaseUrl;

  getAllCities(): Observable<City[]> {
    return this.http.get<City[]>(this.apiBaseUrl + '/api/City');
  }

  getAllCitiesByCountry(countryId: number | undefined): Observable<City[]> {
    return this.http.get<City[]>(this.apiBaseUrl + '/api/City/ByCountry?countryId=' + countryId);
  }

  getCityById(id: number | undefined): Observable<City> {
    return this.http.get<City>(this.apiBaseUrl + '/api/City/' + id);
  }

  updateCity(id: number | undefined, updateCityRequest: City): Observable<City> {
    return this.http.put<City>(this.apiBaseUrl + '/api/City/' + id, updateCityRequest);
  }

  addCity(addCityRequest: AddCity): Observable<City> {
    return this.http.post<City>(this.apiBaseUrl + '/api/City/', addCityRequest);
  }

  deleteCity(id: number | undefined): Observable<City> {
    return this.http.delete<City>(this.apiBaseUrl + '/api/City/' + id);
  }
}
