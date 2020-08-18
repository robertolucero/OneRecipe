import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, tap } from 'rxjs/operators';
import { throwError, BehaviorSubject } from 'rxjs';

import { User } from './user.model';

export interface AuthResponseData {
  // kind: string;
  // idToken: string;
  // email: string;
  // refreshToken: string;
  // expiresIn: string;
  // localId: string;
  // registered?: boolean;
  id: string;
  email: string;
  token: string;
  tokenExpirationDate: Date;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  user = new BehaviorSubject<User>(null);
  private tokenExpirationTimer: any;

  constructor(private http: HttpClient, private router: Router) {}

  signup(email: string, password: string) {
    return this.http
      .post<AuthResponseData>(
        'https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=AIzaSyDb0xTaRAoxyCgvaDF3kk5VYOsTwB_3o7Y',
        {
          email: email,
          password: password,
        }
      )
      .pipe(
        catchError(this.handleError),
        tap(resData => {
          this.handleAuthentication(
            resData.id,
            resData.email,
            resData.token,
            resData.tokenExpirationDate
          );
        })
      );
  }

  login(email: string, password: string) {
    return this.http
      .post<AuthResponseData>(
        'https://localhost:44356/api/Authentication/Authenticate',
        {
          email: email,
          password: password,
        }
      )
      .pipe(
        catchError(this.handleError),
        tap(resData => {
          this.handleAuthentication(
            resData.id,
            resData.email,
            resData.token,
            resData.tokenExpirationDate
          );
        })
      );
  }

  autoLogin() {
    const userData: {
        email: string;
        id: string;
        _token: string;
        _tokenExpirationDate: Date;
      } = JSON.parse(localStorage.getItem('userData'));
      if (!userData) {
        return;
      }

      const loadedUser = new User(
        userData.email,
        userData.id,
        userData._token,
        userData._tokenExpirationDate
      );

      if (loadedUser.token) {
        this.user.next(loadedUser);
      }
  }

  logout() {
    this.user.next(null);
    this.router.navigate(['/auth']);
    localStorage.removeItem('userData');
    if (this.tokenExpirationTimer) {
      clearTimeout(this.tokenExpirationTimer);
    }
    this.tokenExpirationTimer = null;
  }

  autoLogout(expirationDuration: number) {
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }

  private handleAuthentication(
    id: string,
    email: string,
    token: string,
    tokenExpirationDate: Date
  ) {
    const user = new User(email, id, token, tokenExpirationDate);
    this.user.next(user);
    localStorage.setItem('userData', JSON.stringify(user));
  }

  private handleError(errorRes: HttpErrorResponse) {
    if (!errorRes.error) {
      return throwError('An unknown error occurred!');
    }
    return throwError(errorRes.error);
  }
}
