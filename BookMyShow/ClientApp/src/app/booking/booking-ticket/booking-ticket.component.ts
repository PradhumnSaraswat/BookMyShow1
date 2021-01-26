import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Show } from '../../Model/Show';
import { BookingTicketService } from '../../Service/booking-ticket.service';
import { BookingService } from '../../Service/booking.service';
import { HallService } from '../../Service/hall.service';
import { MovieService } from '../../Service/movie.service';
import { TheaterService } from '../../Service/theater.service';

@Component({
  selector: 'app-booking-ticket',
  templateUrl: './booking-ticket.component.html',
  styleUrls: ['./booking-ticket.component.css']
})
export class BookingTicketComponent implements OnInit {

  showID: number;
  movieName: string;
  theaterName: string;
  hallName: string;
  showTiming: string;
  ShowDate: Date;
  seatSelected: number[] = [];

  constructor(private route: ActivatedRoute, private router: Router,
    private movieService: MovieService, private hallService: HallService,
    private bookingTicketService: BookingTicketService, private theaterService: TheaterService,
    private bookingService: BookingService) { }

  ngOnInit() {

    this.route.paramMap.subscribe((params: ParamMap) => {
      this.showID = parseInt(params.get('showId'));
    });

    this.bookingService.seatSelected.subscribe(list => this.seatSelected = list);
    this.getBookingShow();
    
  }

  getBookingShow() {
    this.bookingTicketService.GetBookingShow(this.showID).subscribe(
      (show) => {
        this.showTiming = show.showTiming;
        this.ShowDate = show.showDate;
        this.getTheater(show.theaterID);
        this.getHall(show.hallID);
        this.getMovie(show.movieID);
      }
    );
  }

  getMovie(movieID: number) {

    this.movieService.getMovieById(movieID).subscribe(
      (movie) => {
        this.movieName = movie.movieName;
      },
      (error) => {
        alert("No Movie Available at this Moment");
      }
    );
  }

  getTheater(TheaterID: number) {
    this.theaterService.getTheaterById(TheaterID).subscribe(
      (theater) => {
        this.theaterName = theater.name;
      },
      (error) => {
        alert("No Hall Available at this Moment");
      }
    );
  }

  getHall(hallID: number) {
    this.hallService.getHallById(hallID).subscribe(
      (hall) => {
        this.hallName = hall.name;
      },
      (error) => {
        alert("No Hall Available at this Moment");
      }
    );
  }

  

}
