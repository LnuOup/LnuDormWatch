export interface ForumReply {
  id: number;
  userId: number;

  quote?: ForumReply;
  posted: string;

  content: string;
}
