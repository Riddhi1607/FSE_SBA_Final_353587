import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceError } from '../models/serviceerror';


export class BaseService {
    constructor() { }    

    protected extractData(res: HttpResponse<any>) {
        debugger;
        const body = res.body;
        if (body.status === 'success') {
            return body.data;
        } else if (body.status === 'fail') {
            throw new ServiceError(body.message, body.data, 'fail');
        } else if (body.status === 'error') {
            throw new ServiceError(body.message, body.data);
        } else {
            throw new ServiceError('Invalid JSend Response Status [' + body.status + ']');
        }
    }


    public baseurl(): string {
        return 'http://localhost:8001/';
    }

    protected handleError(error: any) {
        debugger;
        if (error instanceof ServiceError) {
            return Observable.throw(error);
        } else {
            const errMsg = (error.message) ? error.message : error.status ? `${error.status} - ${error.statusText}` : 'Server error';
            return Observable.throw(new ServiceError(errMsg));
        }
    }
}