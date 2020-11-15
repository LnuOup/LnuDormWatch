import {ForumReply} from './forum-reply';

export interface ForumThread {
  id: number;
  userId: number; // TODO

  name: string;
  content: string;
  isPinned: boolean;

  replies: ForumReply[];
  numOfReplies?: number;
  lastReply?: string;
}
