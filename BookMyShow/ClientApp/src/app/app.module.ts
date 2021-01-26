import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MovieComponent } from './movie/movie.component';
import { MovieShowComponent } from './movie/movie-show/movie-show.component';
import { BookingComponent } from './booking/booking.component';
import { BookingTicketComponent } from './booking/booking-ticket/booking-ticket.component'
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BookingService } from './Service/booking.service';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component'
import { UserService } from './Service/user.service';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
//import { AuthInterceptor } from './auth/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FetchDataComponent,
    MovieComponent,
    MovieShowComponent,
    BookingComponent,
    BookingTicketComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    //ToastrModule.forRoot(),
    RouterModule.forRoot([
      
      { path: '', redirectTo: '/user/registration', pathMatch: 'full' },
      {
        path: 'user', component: UserComponent,
        children: [
          { path: 'registration', component: RegistrationComponent },
          { path: 'login', component: LoginComponent }

        ]
      },
      {
        path: 'home', component: HomeComponent, canActivate: [AuthGuard],
        children: [
          { path: '', component: MovieComponent, pathMatch: 'full' },
          { path: 'movie/:movieId', component: MovieShowComponent, },
          { path: 'booking/:showId/:hallId', component: BookingComponent },
          { path: 'bookingTicket/:showId', component: BookingTicketComponent },
        ]
      },
      
      //{ path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [BookingService, UserService, /*{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }*/],
  bootstrap: [AppComponent]
})
export class AppModule { }
