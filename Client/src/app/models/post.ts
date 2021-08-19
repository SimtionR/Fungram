import { Profile } from "./profile";

export interface Post
{
    postId:number;
    imageUrl:string;
    postDescription?:string;
    profile?:Profile;

}