import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import {Post} from '../models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private postPath= environment.apiUrl+ 'post'

  constructor(private http: HttpClient) { }


  create(data : any) : Observable<Post>{
    return this.http.post<Post>(this.postPath, data);
  }

  getPosts() : Observable<Array<Post>>{
    return this.http.get<Array<Post>>(this.postPath);
  }

  getPost(id: number) : Observable<Post>
  {
    return this.http.get<Post>(this.postPath + '/' + id);
  }

  deletePost(id: number) :Observable<Post>
  {
    return this.http.delete<Post>(this.postPath + '/' + id)
  }

  updatePost(data: any) 
  {
    return this.http.put<Post>(this.postPath, data);
  }
}
