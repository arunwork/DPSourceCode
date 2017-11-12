import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from '../../../app/http.service';
import { State } from './state';
import { Constants } from '../../../app/constants';

@Injectable()
export class StateService {

    private statesUrl = Constants.ApiBaseUri + 'state';  // URL to web api
    constructor(private _httpService: HttpService) { }

    getStates(): Observable<State[]> {
        return this._httpService.getRequest(this.statesUrl);
    }


}