import {User} from './user';

export interface ForumReply {
  id: number;
  userId: number;
  user?: User;

  quoteId?: number;
  quote?: ForumReply;
  posted: string;

  content: string;
}
