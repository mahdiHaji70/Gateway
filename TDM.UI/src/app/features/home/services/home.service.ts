import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor() { }

  getStores(): any {
    return [
      {
        id: 1,
        name: 'F32',
        color: '#b4c5e0'
      },
      {
        id: 2,
        name: 'F32',
        color: '#b4c5e0'
      },
      {
        id: 3,
        name: 'B29',
        color: '#b4c5e0'
      },
      {
        id: 4,
        name: 'A20',
        color: '#db2e42'
      },
      {
        id: 5,
        name: 'E24',
        color: '#b4c5e0'
      },
      {
        id: 6,
        name: 'S12',
        color: '#b4c5e0'
      },
      {
        id: 7,
        name: 'A25',
        color: '#db2e42'
      },
      {
        id: 8,
        name: 'A26',
        color: '#b4c5e0'
      },
      {
        id: 9,
        name: 'A27',
        color: '#db2e42'
      },
      {
        id: 10,
        name: 'A28',
        color: '#b4c5e0'
      },
      {
        id: 11,
        name: 'A29',
        color: '#db2e42'
      },
      {
        id: 12,
        name: 'A30',
        color: '#b4c5e0'
      },
      {
        id: 13,
        name: 'E25',
        color: '#b4c5e0'
      },
      {
        id: 14,
        name: 'E26',
        color: '#b4c5e0'
      },
      {
        id: 15,
        name: 'E27',
        color: '#b4c5e0'
      },
      {
        id: 16,
        name: 'E28',
        color: '#b4c5e0'
      },
      {
        id: 17,
        name: 'E29',
        color: '#b4c5e0'
      },
      {
        id: 18,
        name: 'E30',
        color: '#b4c5e0'
      },
      {
        id: 19,
        name: 'B25',
        color: '#b4c5e0'
      },
      {
        id: 20,
        name: 'B26',
        color: '#db2e42'
      },
      {
        id: 21,
        name: 'B27',
        color: '#b4c5e0'
      },
      {
        id: 22,
        name: 'B28',
        color: '#db2e42'
      },
      {
        id: 23,
        name: 'B29',
        color: '#b4c5e0'
      },
      {
        id: 24,
        name: 'B30',
        color: '#b4c5e0'
      }
    ]
  }
}
