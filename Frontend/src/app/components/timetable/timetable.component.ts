import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']
})
export class TimetableComponent implements OnInit {

  blocksCount = 8;
  primaryColor = '#673ab7';
  accentColor = '#ffd740';
  emptyColor = 'white';
  tiles: Tile[] = [];
  lessons: any[] = [
    { day: 1, lesson: 1, text1: 'English', color: 'red' },
    { day: 3, lesson: 4, text1: 'Science', color: 'green' },
  ];

  constructor() { }

  ngOnInit(): void {
    this.generateTable();
  }

  generateTable(): void {
    this.generateFirstRow();
    this.generateBlocks();
    this.lessons.forEach(lesson => {
      this.insertTotable(lesson.day, lesson.lesson, lesson.text1, '');
    });
  }

  generateFirstRow(): void {
    const days = ['', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'];
    days.forEach(day => {
      const tile: Tile = {
        text1: day,
        text2: '',
        color: this.primaryColor
      };
      this.tiles.push(tile);
    });
  }

  generateBlocks(): void {
    let tile: Tile;
    for (let i = 0; i < this.blocksCount * 6; i++) {
      if (i % 6 === 0) {
        tile = {
          text1: 'Lesson \n' + (i / 6 + 1).toString(),
          text2: this.getHour(i / 6 + 7),
          color: this.primaryColor
        };
      }
      else {
        tile = {
          text1: '',
          text2: '',
          color: this.emptyColor
        };
      }
      this.tiles.push(tile);
    }
  }

  getHour(hour: number): string {
    return hour.toString() + ':00 - ' + hour.toString() + ':45';
  }

  insertTotable(day: number, lesson: number, text1: string, text2: string, color: string = this.accentColor): void {
    const i = lesson * 6 + day + 1;
    this.tiles[i].text1 = text1;
    this.tiles[i].text2 = text2;
    this.tiles[i].color = color;
  }

  modulo(n: number, d: number): number {
    return n % d;
  }
}

export interface Tile {
  text1: string;
  text2: string;
  color: string;
}

