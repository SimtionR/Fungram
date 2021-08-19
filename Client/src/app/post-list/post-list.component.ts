import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../models/post';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {
  posts:Array<Post> =[]

  constructor(private postService: PostService, private router: Router) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts(){
    this.postService.getPosts().subscribe(result => 
      {
        this.posts=result;

      })
  }

  postRoute(postId: number) {
    this.router.navigate(["posts", postId])
  }

  deletePost(postId: number){
    this.postService.deletePost(postId).subscribe();
    this.getPosts();
  }

  updatePost(postId: number){
    console.log("works");
    this.router.navigate(["posts", postId, "update"])
  }

}
