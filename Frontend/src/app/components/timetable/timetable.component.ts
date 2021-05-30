import { Component, OnInit } from '@angular/core';
import { Lesson } from 'src/app/models/Lesson';
import { DataService } from 'src/app/services/data.service';

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
  lessons: Lesson[] = [];

  constructor(private data: DataService) {
    this.lessons = data.lessons;
  }

  ngOnInit(): void {
    this.generateTable();
  }

  generateTable(): void {
    this.generateFirstRow();
    this.generateBlocks();
    this.lessons.forEach(lesson => {
      this.insertTotable(lesson.id, lesson.day, lesson.time, lesson.subject, '');
    });
  }

  generateFirstRow(): void {
    const days = ['', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'];
    days.forEach(day => {
      const tile: Tile = {
        id: null,
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
          id: null,
          text1: 'Lesson \n' + (i / 6 + 1).toString(),
          text2: this.getHour(i / 6 + 7),
          color: this.primaryColor
        };
      }
      else {
        tile = {
          id: null,
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

  insertTotable(id: number, day: number, lesson: number, text1: string, text2: string, color: string = this.accentColor): void {
    const i = lesson * 6 + day;
    this.tiles[i].id = id;
    this.tiles[i].text1 = text1;
    this.tiles[i].text2 = text2;
    this.tiles[i].color = color;
  }

  modulo(n: number, d: number): number {
    return n % d;
  }

  clicked(i: number): void {
    if (i < 6 || this.modulo(i, 6) === 0 || this.tiles[i].id === null) {
      return;
    }
    this.data.editLesson(this.tiles[i].id);
  }
}

export interface Tile {
  id: number | null;
  text1: string;
  text2: string;
  color: string;
}

