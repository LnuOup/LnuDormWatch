import {ForumThread} from './forum-thread';

export interface ForumSection {
  id: number;

  title: string;
  description: string;
  isAdminOnly: boolean;

  threads: ForumThread[];
  numOfThreads?: number;
  lastReply?: string;
}
