import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from '../models/post';
import { PostService } from '../services/post.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-update-post',
  templateUrl: './update-post.component.html',
  styleUrls: ['./update-post.component.css']
})
export class UpdatePostComponent implements OnInit {
  postForm!: FormGroup;
  postId!: number;
  post!: Post;
  constructor(private fb: FormBuilder, 
              private route:ActivatedRoute,
              private postService: PostService,
              private router: Router,
              private toastrService: ToastrService) {
    this.postForm= this.fb.group({
      'postId':[''],
      'description':['']
    });
   }

  ngOnInit(): void {
    this.route.params.subscribe( params => {
      this.postId= params['id'];

      this.postService.getPost(this.postId).subscribe(res =>
        {
          this.post= res;

          this.postForm = this.fb.group({
            'postId': [this.post.postId],
            'description': [this.post.postDescription]
          })
        });    

    })
    
  }
  updatePost()
  {
    this.postService.updatePost(this.postForm.value).subscribe( res => {
      this.toastrService.success("Post updated!")
      this.router.navigate(["posts"])
    });
  }

}
