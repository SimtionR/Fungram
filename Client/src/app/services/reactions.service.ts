import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Reaction } from '../models/reaction';


@Injectable({
  providedIn: 'root'
})
export class ReactionsService {
  private reactionPath=environment.apiUrl+'reaction';

  constructor(private http: HttpClient) { }


  get(postId: number) :Observable<Array<Reaction>>{

    return this.http.get<Array<Reaction>>(this.reactionPath+ '/' +postId);
  }

  delete(postId: number) :Observable<Reaction>{
    return this.http.delete<Reaction>(this.reactionPath+ '/' +postId);
  }

  post(postId:number, data: any) :Observable<Reaction>{
    return this.http.post<Reaction>(this.reactionPath+ '/' + postId, data);
  }
}
