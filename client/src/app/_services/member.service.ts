import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member } from '../_models/member';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
private httpclient = inject(HttpClient);
private accountService = inject(AccountService)
baseUrl = environment.apiUrl;

getMembers(){
  return this.httpclient.get<Member[]>(this.baseUrl + 'users');
}

getMember(username: string)
{
  return this.httpclient.get<Member>(this.baseUrl + 'users/' + username);
}
}
