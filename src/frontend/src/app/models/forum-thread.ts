import {ForumReply} from './forum-reply';

export interface ForumThread {
  id: string;
  authorId: string;
  authorInfo: {
    userName: string,
    photoUrl: string
  };

  threadTitle: string;
  threadBody?: string;

  replies?: ForumReply[];
  numberOfReplies: number;
  creationDate: string;
  lastReply?: string;
}
