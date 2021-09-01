import { Component, OnInit } from '@angular/core';
import { disableDebugTools, ɵDomSharedStylesHost } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Post } from '../models/post';
import { PostService } from '../services/post.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {
  posts:Array<Post> =[]



  constructor(private postService: PostService,
              private router: Router,
              private toastrService: ToastrService) { }

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
    this.postService.deletePost(postId).subscribe( del =>{
      this.toastrService.success("Post deleted!");
      this.getPosts();
    });
   
  }

  updatePost(postId: number){
    
    this.router.navigate(["posts", postId, "update"])
    
  }

}
