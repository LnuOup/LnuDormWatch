import { Location } from "../models/location";

export interface Dormitory {
  id: number;
  number: number;
  phoneNumber: string;
  location?: Location;
}
