import { i18nMetaToJSDoc } from '@angular/compiler/src/render3/view/i18n/meta';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Comment } from '../models/comment';
import { CommentService } from '../services/comment.service';

@Component({
  selector: 'app-comment-list',
  templateUrl: './comment-list.component.html',
  styleUrls: ['./comment-list.component.css']
})
export class CommentListComponent implements OnInit {
  comments: Array<Comment> = [];
  postId :any;

  constructor(private commentService: CommentService, private route: ActivatedRoute ) {
    this.route.params.subscribe( result => {
      this.postId= result['id'];
      this.commentService.getComments(this.postId).subscribe(res =>{
        this.comments=res;
      })

    })
   }

  ngOnInit(): void {
    
    
  }


  getComments(postId: number){
    this.commentService.getComments(postId).subscribe(result =>
      {
        this.comments= result;
      })
  }

  deleteComment(commentId: number)
  {
    this.commentService.deleteComment(commentId).subscribe(res =>
      {
        this.getComments(this.postId);
      });
  }

}
