import { Component, OnInit } from '@angular/core';
import { State } from './state';
import { StateService } from './state.service';
import { debug } from 'util';
import { debounce } from 'rxjs/operators/debounce';

@Component({
  selector: 'states',
  templateUrl: './states.component.html',
  styleUrls: ['./states.component.css']
})
export class StatesComponent implements OnInit {

  states: State[];
  constructor(private _stateService: StateService) { }

  ngOnInit() {
    this.getStates();
    debugger;
  }

  getStates() {
    return this._stateService.getStates().subscribe((data: State[]) =>
      this.states = data,
      error => {
        console.log(error);
      });      
  }
}
