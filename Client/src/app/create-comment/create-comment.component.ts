import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CommentService } from '../services/comment.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css']
})
export class CreateCommentComponent implements OnInit {
  commentForm: FormGroup;
  id: any;

  constructor(private fb:FormBuilder, 
              private commentService: CommentService,
              private route: ActivatedRoute, 
              private router: Router,
              private toastrService: ToastrService) {
    this.commentForm= this.fb.group({
      'CommentBody': ['',Validators.required]

      

    })
   }

  ngOnInit(): void {
    this.route.params.subscribe(res => {
      this.id=res['id'];
    })
  }

  create(){
    this.commentService.postComment(this.id,this.commentForm.value).subscribe(res =>
      {
        this.redirect()
        this.toastrService.success("Comment posted!")
      })
  }

  redirect()
  {
    this.router.navigate(["posts", this.id])
  }
    
    
  

}
