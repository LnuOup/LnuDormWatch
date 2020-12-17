

export interface ForumReply {
  id: string;
  authorId: number;
  authorInfo: {
    userName: string,
    photoUrl: string
  };

  parentForumThreadReply?: ForumReply;
  creationDate: string;

  replyBody: string;
}
