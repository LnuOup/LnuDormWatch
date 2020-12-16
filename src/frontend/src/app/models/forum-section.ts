import {ForumThread} from './forum-thread';

export interface ForumSection {
  id: string;

  sectionTitle: string;
  sectionDescription: string;
  isAdminOnly?: boolean;

  creationDate: string;

  threads?: ForumThread[];
  numberOfThreads?: number;
  lastReply?: string;
}
