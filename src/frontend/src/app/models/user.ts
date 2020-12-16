export interface User {
  id?: number;
  userName: string;
  photoUrl?: string;
  compressedPhotoUrl?: string;
  email: string;
  phoneNumber?: string;
  isEmailConfirmed?: boolean;

  isAdmin?: boolean;
}
