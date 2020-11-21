// Mock data for mockDorms

import {Dormitory} from '../models/dormitory';
import {Image} from "@ks89/angular-modal-gallery";

export const mockDorms: Dormitory[] = [
  {
    id: 1,
    number: 1,
    mainImageUrl : 'https://i0.wp.com/tripadvisor.wpengine.com/wp-content/uploads/2019/01/jASdOnzl.jpeg?quality=90&w=627',
    phoneNumber: '+380322394005',
    location: {
      lat: 49.8366502399999995,
      lng: 24.082058,
      address: 'Ярослава Стецька, 3'
    },
    rating: {
      negative: 10,
      positive: 25
    },
    images: [
      new Image(
        0,
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/milan-pegasus-gallery-statue.jpg',
          description: 'Description 1'
        },
        { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-milan-pegasus-gallery-statue.jpg',
          title: 'First image title',
          alt: 'First image alt',
          ariaLabel: 'First image aria-label' }
      ),
      new Image(1, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-47223.jpeg' }, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-47223.jpg' }),
      new Image(
        2,
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-52062.jpeg',
          description: 'Description 3',
          title: 'Third image title',
          alt: 'Third image alt',
          ariaLabel: 'Third image aria-label'
        },
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-52062.jpg',
          description: 'Description 3'
        }
      ),
      new Image(1, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-47223.jpeg' }, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-47223.jpg' }),
      new Image(
        2,
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-52062.jpeg',
          description: 'Description 3',
          title: 'Third image title',
          alt: 'Third image alt',
          ariaLabel: 'Third image aria-label'
        },
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-52062.jpg',
          description: 'Description 3'
        }
      ),
      new Image(1, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-47223.jpeg' }, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-47223.jpg' }),
      new Image(
        2,
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-52062.jpeg',
          description: 'Description 3',
          title: 'Third image title',
          alt: 'Third image alt',
          ariaLabel: 'Third image aria-label'
        },
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-52062.jpg',
          description: 'Description 3'
        }
      ),
      new Image(1, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-47223.jpeg' }, { img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-47223.jpg' }),
      new Image(
        2,
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/pexels-photo-52062.jpeg',
          description: 'Description 3',
          title: 'Third image title',
          alt: 'Third image alt',
          ariaLabel: 'Third image aria-label'
        },
        {
          img: 'https://raw.githubusercontent.com/Ks89/angular-modal-gallery/master/examples/systemjs/assets/images/gallery/thumbs/t-pexels-photo-52062.jpg',
          description: 'Description 3'
        }
      ),
    ]
  },
  {
    id: 2,
    number: 3,
    mainImageUrl : 'https://i0.wp.com/tripadvisor.wpengine.com/wp-content/uploads/2019/01/DShnbcHH.jpeg?quality=90&w=627',
    phoneNumber: '+380322514541',
    location: {
      lat: 49.8253766,
      lng: 24.0781675,
      address: 'Медової печери,  39а'
      },
    rating: {
      negative: 100,
      positive: 1000
    }
  },
  {
    id: 3,
    number: 8,
    mainImageUrl : 'https://i0.wp.com/media-cdn.tripadvisor.com/media/photo-o/1c/34/4f/f4/hotel-alpin-spa-tuxerhof.jpg?quality=90&w=627',
    phoneNumber: '+380322514541',
    location: {
      lat: 49.83230584,
      lng: 24.01049678,
      address: 'Пасічна, 62'
    },
    rating: {
      negative: 1,
      positive: 1
    }
  }
];
