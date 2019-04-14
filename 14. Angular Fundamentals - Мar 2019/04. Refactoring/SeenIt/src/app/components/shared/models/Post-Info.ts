export interface PostInfo {
    _id: string;
    url: string;
    imageUrl: string;
    description: string;
    author: string;
    _acl: { creator: string };
}