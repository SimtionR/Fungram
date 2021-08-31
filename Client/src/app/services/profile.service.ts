import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {environment} from '../../environments/environment'
import { Observable } from 'rxjs';
import { Profile } from '../models/profile';
import { AuthService } from './auth.service';


@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private profilePath = environment.apiUrl +'profile'

  constructor(private http: HttpClient, private authService: AuthService) { }


  create(data :any ): Observable<Profile>{
 
    return this.http.post<Profile>(this.profilePath, data)
  }

  get(): Observable<Profile>
  {
    return this.http.get<Profile>(this.profilePath);
  }
}
