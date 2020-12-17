import { Location } from "../models/location";
import {Rating} from "../models/rating";
import {Image} from "@ks89/angular-modal-gallery";

export interface Dormitory {
  id: number;
  number: number;
  mainImageUrl: string;
  phoneNumber: string;
  location?: Location;
  rating?: Rating;
  images?: Image[];
}
