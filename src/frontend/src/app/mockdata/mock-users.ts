import {User} from '../models/user';

export const mockUsers: User[] = [
  {
    id: 0,
    userName: 'Admin',
    email: 'admin@lnu.edu.ua',
    photoUrl: 'https://placeimg.com/640/480/people',
    isAdmin: true
  },

  {
    id: 1,
    userName: 'superAdmin',
    email: 'superAdmin@LnuDormWatch.com',
    photoUrl: 'https://placeimg.com/640/480/people',
    isAdmin: true
  },

  {
    id: 2,
    userName: 'Student',
    email: 'student@lnu.edu.ua',
    photoUrl: 'https://placeimg.com/640/480/people',
    isAdmin: false
  }
];
