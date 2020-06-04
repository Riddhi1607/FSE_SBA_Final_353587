import { Injectable } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { map, catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable()
export class UserService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    getUser(): Observable<User[]> {
        return this.http.get(super.baseurl() + 'api/user')
            .pipe(map((res: HttpResponse<any>) => {
                const data = res["data"];
                return data;
            }))
            .pipe(catchError(this.handleError));
    }

    addUser(user: User): Observable<any> {
        return this.http.post(super.baseurl() + 'api/user/add', user)
            .pipe(map((res: HttpResponse<any>) => {
                debugger;
                const data = res["data"];
                return data;
            }))
            .pipe(catchError(this.handleError));
    }

    updateUser(user: User): Observable<any> {
        return this.http.post(super.baseurl() + 'api/user/update', user)
            .pipe(map((res: HttpResponse<any>) => {
                const data = res["data"];
                return data;
            }))
            .pipe(catchError(this.handleError));
    }

    deleteUser(user: User): Observable<any> {
        return this.http.post(super.baseurl() + 'api/user/delete', user)
            .pipe(map((res: HttpResponse<any>) => {
                const data = res["data"];
                return data;
            }))
            .pipe(catchError(this.handleError));
    }
}   