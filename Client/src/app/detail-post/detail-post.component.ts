import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../models/post';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-detail-post',
  templateUrl: './detail-post.component.html',
  styleUrls: ['./detail-post.component.css']
})
export class DetailPostComponent implements OnInit {

  id: any;
  post!: Post;
  constructor(private route: ActivatedRoute, private postService:PostService) { 
    this.route.params.subscribe( result => {
      this.id = result['id'];
      this.postService.getPost(this.id).subscribe( res => {
        this.post=res;
        
      })

    })
  }

  ngOnInit(): void {
    console.log("test")
  }

}
