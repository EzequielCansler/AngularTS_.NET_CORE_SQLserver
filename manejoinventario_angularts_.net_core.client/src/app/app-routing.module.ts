import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './Component/menu/menu.component'
import { HomeComponent } from './Component/home/home.component'
import { DetailComponent } from './Component/detail/detail.component'

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'detail/:Id', component: DetailComponent },
  { path: 'menu', component: MenuComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'home' } 

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
