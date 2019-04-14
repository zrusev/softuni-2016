export interface CommentInfo {
    _id: string;
    author: string;
    content: string;
    _acl: { creator: string };
}