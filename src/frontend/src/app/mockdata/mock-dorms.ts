// Mock data for mockDorms

import {Dormitory} from '../models/dormitory';

export const mockDorms: Dormitory[] = [
  {
    id: 1,
    number: 1,
    phoneNumber: '+380322394005',
    location: {
      lat: 49.8366502399999995,
      lng: 24.082058,
      name: 'Гуртожиток №1',
      address: 'Ярослава Стецька 3'
    }
  },
  {
    id: 2,
    number: 3,
    phoneNumber: '+380322514541',
    location: {
      lat: 49.8253766,
      lng: 24.0781675,
      name: 'Гуртожиток №3',
      address: 'Медової печери  39а'
      }
    },
  {
    id: 3,
    number: 8,
    phoneNumber: '+380322514541',
    location: {
      lat: 49.83230584,
      lng: 24.01049678,
      name: 'Гуртожиток №8',
      address: 'Пасічна 62'
    }
  }
];
