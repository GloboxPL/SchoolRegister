import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-marks-frequency-view',
  templateUrl: './marks-frequency-view.component.html',
  styleUrls: ['./marks-frequency-view.component.css']
})
export class MarksFrequencyViewComponent implements OnInit {

  marks: any[] = [{ m: 5, s: 'Physics' }, { m: 3, s: 'Art' }, { m: 6, s: 'PE' }];
  freq: any[] = [{ d: 1, s: 'Physics' }, { d: 2, s: 'Art' }, { d: 4, s: 'PE' }];

  constructor() { }

  ngOnInit(): void {
  }

}
