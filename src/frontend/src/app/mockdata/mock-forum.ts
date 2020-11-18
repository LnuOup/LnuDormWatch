// Mock data for forum

import {ForumSection} from '../models/forum-section';

export const mockForumSections: ForumSection[] = [
  // News
  {
    id: 0,
    isAdminOnly: true,

    title: 'News & Announcements',
    description: 'Etiam rhoncus pellentesque venenatis. Cras maximus ipsum sit amet erat rutrum venenatis.',

    threads: [
      {
        id: 0,
        isPinned: true,
        userId: 0,

        created: '2015-04-23T18:05:43.511Z',
        lastReply: '2015-04-23T18:55:43.511Z',

        name: 'Vivamus iaculis augue ac suscipit',
        content: 'Fusce dignissim id mi ut ornare. Nunc urna ligula, lobortis quis convallis ac, finibus nec libero. Donec malesuada nisl nulla, in lobortis ex ultricies vel. Praesent ut nunc orci. Pellentesque luctus tristique mollis. Morbi vitae orci nulla. Vivamus eget vestibulum lacus. Suspendisse sed turpis odio. Praesent malesuada, mauris eget ornare tristique, est ipsum sollicitudin quam, non ultricies leo leo vel mi. Nullam venenatis, lorem ut ultrices interdum, purus felis egestas justo, ut semper nibh nunc nec neque. Nulla sit amet risus convallis, venenatis urna ut, volutpat mi. Maecenas augue felis, commodo id viverra non, tristique at arcu. Pellentesque volutpat enim sapien, vitae blandit arcu dapibus eu. Nulla feugiat lacus sit amet leo lacinia sollicitudin.\n' +
          '\n' +
          'Nunc faucibus mauris eu ante varius, at sodales ligula congue. Cras aliquam aliquam scelerisque. Integer tristique fringilla nisl, quis pellentesque mauris semper tempus. Integer quis porttitor risus. Proin nec nisi sed odio maximus semper at viverra enim. Nullam blandit elit et egestas congue. Ut et pretium justo, in egestas ipsum. Aenean pulvinar purus at cursus varius. Proin at elit ut nisi sollicitudin pulvinar nec ut nisi. Etiam vulputate ligula quam, ac fringilla ligula eleifend nec. Aenean vulputate lorem ac sollicitudin mollis. Nam tempor nisl non blandit pulvinar. Nunc nec risus quis eros pellentesque tempor quis sit amet urna.',
        replies: [
          {
            id: 0,
            userId: 1,
            posted: '2015-04-23T18:25:43.511Z',
            content: 'Nulla scelerisque tortor et neque ornare egestas. Praesent sollicitudin eleifend accumsan. Donec ut viverra erat. Aenean at nulla in mauris consequat dictum vulputate rhoncus nisl. Pellentesque pellentesque viverra magna at iaculis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tortor erat, scelerisque eu eleifend vel, aliquam eu augue. Ut rutrum ultricies metus nec cursus. Donec scelerisque sit amet arcu condimentum consequat. Integer turpis tellus, imperdiet sit amet lobortis fringilla, sodales eu enim.'
          },
          {
            id: 1,
            userId: 2,
            posted: '2015-04-23T18:26:43.511Z',
            content: 'Donec et turpis viverra, feugiat massa nec, dictum risus. Etiam facilisis leo risus, sit amet vestibulum est sollicitudin a. Nam laoreet dapibus dictum. Cras interdum, nisi nec blandit pulvinar, diam lectus accumsan tellus, eu finibus tortor elit aliquam purus. Ut sodales tellus purus, sed aliquet mauris mattis mollis. In facilisis libero id ex mattis, vitae gravida velit convallis. Mauris felis nibh, imperdiet sed lobortis et, sagittis at mauris. Sed sodales mollis nisl vel ornare. Nunc sagittis arcu magna, eu volutpat mauris vestibulum a. Donec eu faucibus elit, eget aliquam nisi. Maecenas accumsan bibendum nunc, quis hendrerit mi mollis a. Aenean placerat malesuada lobortis. Vestibulum laoreet auctor lacus vel interdum. Integer bibendum varius tristique.'
          },
          {
            id: 2,
            userId: 0,
            posted: '2015-04-23T18:38:43.511Z',
            content: 'Mauris dignissim libero elit, et condimentum nunc placerat et. Donec ultrices leo molestie tellus dictum, a convallis ligula accumsan. Curabitur viverra tincidunt consequat. Phasellus nec massa mauris. Donec a risus quis nibh lacinia pharetra. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam enim diam, cursus eu aliquet nec, elementum in tellus. Vestibulum tempor commodo turpis, et fermentum magna volutpat non. Vestibulum eu lacinia lacus. Donec facilisis vel risus et laoreet. Donec tristique purus vitae fermentum tincidunt. Praesent sollicitudin tortor odio, ac commodo urna tempus vitae.'
          },
          {
            id: 3,
            userId: 1,
            posted: '2015-04-23T18:43:43.511Z',
            content: 'Pellentesque et eros venenatis, vestibulum leo eget, semper metus. In congue sodales dolor. Etiam aliquam velit id dui varius, at consectetur arcu placerat. Donec vehicula, velit vitae aliquet finibus, leo nisi molestie lacus, nec aliquet nisl ante vitae quam. Duis quis sagittis felis. Nam molestie sapien nec ligula ornare rutrum. Quisque varius mauris id ante aliquam, ut blandit velit luctus. Aliquam maximus finibus accumsan. Proin sodales lacus mi, et tincidunt urna pulvinar at.'
          },
          {
            id: 4,
            userId: 1,
            posted: '2015-04-23T18:55:43.511Z',
            content: 'Praesent congue mauris id justo mollis, ut fermentum libero mattis. Maecenas non metus non augue dapibus eleifend vitae sed nibh. Integer molestie porta feugiat. Nam ornare sem ut nisi faucibus mattis. Vestibulum rhoncus faucibus risus. Nunc a aliquam augue. Proin non vestibulum odio, eu imperdiet sem.'
          }
        ]
      },
      {
        id: 1,
        isPinned: true,
        userId: 2,

        created: '2012-04-23T18:05:43.511Z',
        lastReply: '2012-04-23T18:59:43.511Z',

        name: 'Nunc elementum metus ac enim placerat, ut',
        content: 'Sed efficitur egestas porta. Curabitur tempor justo at nibh tempor sodales. Nam at turpis eu leo feugiat condimentum id in lacus. Curabitur eget purus porttitor, pulvinar tortor ut, molestie elit. Suspendisse fringilla massa vel neque egestas, et fermentum lorem scelerisque. Nunc feugiat ligula non mollis aliquam. Aliquam pretium diam nisl, at posuere nisi rhoncus ac. Proin nec eros sapien. Sed turpis massa, pellentesque eu pellentesque et, pulvinar quis erat. In at pellentesque mauris. Nullam blandit pretium quam, non imperdiet purus convallis quis.\n' +
          '\n' +
          'Nulla facilisi. Maecenas auctor justo et dignissim ultricies. Duis volutpat eget nisl quis tincidunt. Praesent nec metus a elit lobortis bibendum. Quisque hendrerit quis nulla eget imperdiet. Maecenas sed massa maximus tellus vulputate fermentum eget a libero. Curabitur commodo orci ut nisl faucibus, quis viverra risus luctus. Donec id hendrerit arcu, at aliquet velit. Vestibulum volutpat, neque tempor cursus molestie, lorem lectus convallis arcu, at semper turpis leo eget quam. Fusce sed commodo sapien, sit amet congue dui.',
        replies: [
          {
            id: 5,
            userId: 1,
            posted: '2012-04-23T18:25:43.511Z',
            content: 'Nulla scelerisque tortor et neque ornare egestas. Praesent sollicitudin eleifend accumsan. Donec ut viverra erat. Aenean at nulla in mauris consequat dictum vulputate rhoncus nisl. Pellentesque pellentesque viverra magna at iaculis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tortor erat, scelerisque eu eleifend vel, aliquam eu augue. Ut rutrum ultricies metus nec cursus. Donec scelerisque sit amet arcu condimentum consequat. Integer turpis tellus, imperdiet sit amet lobortis fringilla, sodales eu enim.'
          },
          {
            id: 6,
            userId: 0,
            posted: '2012-04-23T18:35:43.511Z',
            content: 'Mauris dignissim libero elit, et condimentum nunc placerat et. Donec ultrices leo molestie tellus dictum, a convallis ligula accumsan. Curabitur viverra tincidunt consequat. Phasellus nec massa mauris. Donec a risus quis nibh lacinia pharetra. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam enim diam, cursus eu aliquet nec, elementum in tellus. Vestibulum tempor commodo turpis, et fermentum magna volutpat non. Vestibulum eu lacinia lacus. Donec facilisis vel risus et laoreet. Donec tristique purus vitae fermentum tincidunt. Praesent sollicitudin tortor odio, ac commodo urna tempus vitae.'
          },
          {
            id: 7,
            userId: 1,
            posted: '2012-04-23T18:59:43.511Z',
            content: 'Pellentesque et eros venenatis, vestibulum leo eget, semper metus. In congue sodales dolor. Etiam aliquam velit id dui varius, at consectetur arcu placerat. Donec vehicula, velit vitae aliquet finibus, leo nisi molestie lacus, nec aliquet nisl ante vitae quam. Duis quis sagittis felis. Nam molestie sapien nec ligula ornare rutrum. Quisque varius mauris id ante aliquam, ut blandit velit luctus. Aliquam maximus finibus accumsan. Proin sodales lacus mi, et tincidunt urna pulvinar at.'
          }
        ]
      },
      {
        id: 2,
        isPinned: true,
        userId: 0,

        created: '2009-09-23T12:05:43.511Z',
        lastReply: '2009-09-23T12:25:43.511Z',

        name: 'Curabitur quam nunc, eleifend nec aliquet ut',
        content: 'Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam tristique ipsum eu tempus rhoncus. Aenean convallis ligula ante, ac faucibus lacus sagittis vel. Ut in aliquet metus. Aliquam sit amet eros in nulla hendrerit malesuada viverra ullamcorper sapien. Cras nec urna scelerisque, efficitur nulla eu, luctus turpis. Donec vel vehicula ligula. Morbi a eros dapibus, sollicitudin tortor eget, vulputate ipsum. Vivamus eu nibh augue. Maecenas fermentum consectetur tristique. Suspendisse a luctus mi. Nullam tincidunt eros diam, et placerat justo ultricies id. Cras a ligula at mauris viverra molestie. Sed tincidunt, ex nec rutrum facilisis, justo augue tempus risus, lacinia malesuada erat nisl vitae augue. Praesent pellentesque congue velit, in convallis massa imperdiet at. Vestibulum vestibulum lectus ac enim auctor, in tempor augue pellentesque.\n' +
          '\n' +
          'Maecenas consequat tortor vel congue faucibus. Nunc magna dui, euismod ut imperdiet ac, pretium eu nulla. Maecenas lacus ante, bibendum quis eros vel, eleifend ultricies lorem. Maecenas a sollicitudin est. Nulla facilisi. Quisque ac elit consectetur, luctus est quis, accumsan elit. Nunc a lectus finibus, vestibulum libero at, consequat eros. Duis tempus fermentum diam in auctor. Vestibulum aliquam imperdiet leo, et volutpat risus aliquet sed. Aenean vel eros massa.',
        replies: [
          {
            id: 8,
            userId: 1,
            posted: '2009-09-23T12:25:43.511Z',
            content: 'Nulla scelerisque tortor et neque ornare egestas. Praesent sollicitudin eleifend accumsan. Donec ut viverra erat. Aenean at nulla in mauris consequat dictum vulputate rhoncus nisl. Pellentesque pellentesque viverra magna at iaculis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tortor erat, scelerisque eu eleifend vel, aliquam eu augue. Ut rutrum ultricies metus nec cursus. Donec scelerisque sit amet arcu condimentum consequat. Integer turpis tellus, imperdiet sit amet lobortis fringilla, sodales eu enim.'
          }
        ]
      }
    ]
  },
  // University
  {
    id: 1,
    isAdminOnly: true,

    title: 'University',
    description: 'Pellentesque porttitor nisl quam, efficitur interdum ante auctor et.',

    threads: []
  },
  // Dorm #1
  {
    id: 2,
    isAdminOnly: true,

    title: 'Dorm #1',
    description: 'Nunc at luctus justo, a dictum lacus. Nullam iaculis velit dolor, quis molestie nisl scelerisque eget.',

    threads: []
  },
];
