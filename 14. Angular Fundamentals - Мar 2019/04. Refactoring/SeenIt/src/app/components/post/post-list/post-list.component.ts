import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, UrlSegment, Router } from '@angular/router';
import { PostService } from '../../../core/services/post.service';
import { PostInfo } from '../../models/Post-Info';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {
  allPosts$: Observable<PostInfo[]>;

  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    // const segmentArr = this.route.snapshot.url;
    // const segment = segmentArr[0];
    // if (!segment) {
    //   this.allPosts$ = this.postService.getAll();
    // } else {
    //   this.allPosts$ = this.postService.getUserPosts();
    // }
    this.route.url.subscribe((segmentArr: UrlSegment[]) => {
      const segment = segmentArr[0];
      if (!segment) {
        this.allPosts$ = this.postService.getAll();
      } else {
        this.allPosts$ = this.postService.getUserPosts();
      }
    });
  }

  onDeletePost(id: string) {
    this.postService.deletePost(id)
      .subscribe(() => {
        this.allPosts$ = this.postService.getAll();
      });
  }

  isAuthor(post: Object) {
    return post['_acl']['creator'] === localStorage.getItem('userId');
  }

  deletePost(id: string) {
    this.postService.deletePost(id)
      .subscribe(() => {
        this.router.navigate(['/posts']);
      });
  }
}
