import { Component, Input, OnInit } from '@angular/core';
import { Post, } from '../models/post';
import { Reaction } from '../models/reaction';
import { PostService } from '../services/post.service';
import { ReactionsService } from '../services/reactions.service';

@Component({
  selector: 'app-reactions',
  templateUrl: './reactions.component.html',
  styleUrls: ['./reactions.component.css']
})
export class ReactionsComponent implements OnInit {
  reactions: Array<Reaction> =[];
  @Input() numberOfReactions: any;
  @Input() postId: any;
  data: any;

  posts : Array<Post>= [];
  constructor(private reactionService: ReactionsService) { }

  ngOnInit(): void {
    
  }

  like(postId: number)
  {
    this.reactionService.post(postId,this.data).subscribe(res =>
          window.location.reload()
        
        
      );
  }
  dislike(postId: number)
  {
    this.reactionService.delete(postId).subscribe(res =>
      window.location.reload());
  }



}
