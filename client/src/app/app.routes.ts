import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberDetailComponent } from './memebers/member-detail/member-detail.component';
import { MemberListComponent } from './memebers/member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: '', runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children:[
            {path: 'members/:username', component: MemberDetailComponent},
    {path: 'members', component: MemberListComponent, canActivate: [authGuard]},
    {path: 'lists', component: ListsComponent},
    {path: 'messages', component: MessagesComponent}
        ]
    },
    {path: '**', component: HomeComponent,pathMatch:'full'}
];
