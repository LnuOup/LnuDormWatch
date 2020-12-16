import {User} from './user';

export interface ForumReply {
  id: string;
  authorId: number;
  author?: User;

  parentForumThreadReply?: ForumReply;
  creationDate: string;

  replyBody: string;
}
