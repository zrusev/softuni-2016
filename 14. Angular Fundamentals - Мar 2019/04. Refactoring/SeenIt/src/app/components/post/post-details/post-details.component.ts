import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { PostService } from '../../../core/services/post.service';
import { CommentService } from '../../../core/services/comment.service';
import { CommentInfo } from '../../models/Comment-Info';
import { PostInfo } from '../../models/Post-Info';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {
  @ViewChild('f') createCommentForm: NgForm;
  post$: Observable<PostInfo>;
  comments: CommentInfo[];
  id: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService,
    private commentService: CommentService
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.post$ = this.postService.getDetails(this.id);
    this.commentService.getAllForPost(this.id)
      .subscribe((data) => {
        this.comments = data;
      });
  }

  loadComments() {
    this.commentService.getAllForPost(this.id)
      .subscribe((data) => {
        this.comments = data;
      });
  }

  deleteComment(id: string) {
    this.commentService.deleteComment(id)
      .subscribe(() => {
        this.loadComments();
      })
  }

  postComment() {
    const body = this.createCommentForm.value;
    body['postId'] = this.id;
    body['author'] = localStorage.getItem('username');

    this.commentService
      .postComment(this.createCommentForm.value)
      .subscribe(() => {
        this.createCommentForm.reset();
        this.loadComments();
      })
  }

  isAuthor(commentInfo: Object) {
    return commentInfo['_acl']['creator'] === localStorage.getItem('userId');
  }

  deletePost(id: string) {
    this.postService.deletePost(id)
      .subscribe(() => {
        this.router.navigate(['/posts']);
      })
  }
}
