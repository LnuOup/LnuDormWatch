import { Location } from "../models/location";
import {Rating} from "../models/rating";

export interface Dormitory {
  id: number;
  number: number;
  mainImageUrl: string;
  phoneNumber: string;
  location?: Location;
  rating?: Rating;
}
