import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Comment } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private commentPath= environment.apiUrl+ 'comment'

  constructor(private http: HttpClient) { 

    
  }


  getComments(id: number): Observable<Array<Comment>>{
    return this.http.get<Array<Comment>>(this.commentPath + '/'+ id);
  }

  postComment(id: number, data: any) : Observable<Comment>{
    return this.http.post<Comment>(this.commentPath+ '/' + id, data);

  }

  deleteComment(id: number): Observable<Comment>
  {
    return this.http.delete<Comment>(this.commentPath+'/'+ id);
  }
}
