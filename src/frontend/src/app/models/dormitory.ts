import {Image} from '@ks89/angular-modal-gallery';

export interface Dormitory {
  id: number;
  number: number;
  mainImageUrl?: string;
  phoneNumber: string;
  address: string;
  latitude: number;
  longitude: number;

  dormitoryPictures?: Image[];
}
