import {ForumReply} from './forum-reply';
import {User} from './user';

export interface ForumThread {
  id: string;
  authorId: string;
  author?: User;

  threadTitle: string;
  threadBody?: string;

  replies?: ForumReply[];
  numberOfReplies: number;
  creationDate: string;
  lastReply?: string;
}
