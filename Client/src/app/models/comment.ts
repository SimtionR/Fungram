import { Post } from "./post";
import { Profile } from "./profile";

export interface Comment{
    commentId: number;
    commentBody: string;
    profileId: number;
    profile? : Profile;
    postId: number;
    post?: Post;
}