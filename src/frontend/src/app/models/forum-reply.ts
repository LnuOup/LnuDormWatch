export interface ForumReply {
  id: number;
  userId: number;

  quote?: ForumReply;

  content: string;
}
