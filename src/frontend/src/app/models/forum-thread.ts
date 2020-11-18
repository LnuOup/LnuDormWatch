import {ForumReply} from './forum-reply';
import {User} from './user';

export interface ForumThread {
  id: number;
  userId: number; // TODO
  user?: User;

  name: string;
  content: string;
  isPinned: boolean;

  replies: ForumReply[];
  numOfReplies?: number;
  created: string;
  lastReply?: string;
  lastReplyBy?: User;
}
