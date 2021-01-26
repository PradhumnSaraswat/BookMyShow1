import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators  } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { element } from 'protractor';
import { Booking } from '../Model/Booking';
import { BookSeat } from '../Model/BookSeat';
import { Hall } from '../Model/Hall';
import { BookingService } from '../Service/booking.service';
import { HallService } from '../Service/hall.service';
import { UserService } from '../Service/user.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {


  hallID: number;
  numberOfSeat: number;
  totalRow: number;
  bookedSeat: number[] = [];
  hall: Hall;
  bookSeat: BookSeat = { SeatList: [], UserName: '', ShowID: null };
  

  constructor(private bookingService: BookingService, private route: ActivatedRoute, private router: Router, private hallService: HallService, private service: UserService) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.bookSeat.ShowID = parseInt(params.get('showId'));
      this.hallID = parseInt(params.get('hallId'));
    });

    this.service.currentuserName.subscribe(
      (userName) => {
        this.bookSeat.UserName = userName;
      },
      err => {
        console.log(err);
      },
    );

    this.bookingService.currentNumberOfSeat.subscribe(seat => this.numberOfSeat = seat);
    this.getBookings();
    this.getHall();
  }

  getBookings() {
    this.bookingService.getBookedSeat(this.bookSeat.ShowID).subscribe(
      (bookings) => {
        this.bookedSeat = bookings;
      },
      (error) => {
        alert("No Shows Available at this Moment");
      }
    );
  }

  //to get showsList
  getHall() {
    this.hallService.getHallById(this.hallID).subscribe(
      (halls) => {
        this.hall = halls;
       this.totalRow = this.hall.totalseat/5;
      },
      (error) => {
        alert("No Shows Available at this Moment");
      }
    );
  }
  bookTicket() {
    if (this.bookSeat.SeatList.length == this.numberOfSeat) {
      
      this.bookingService.postBookSeat(this.bookSeat).subscribe(
        (result) => {
          if (result == true) {
            this.bookingService.updateList(this.bookSeat.SeatList);
            this.router.navigate(['home/bookingTicket', this.bookSeat.ShowID], { queryParams: { bookingAdded: true } });
          }
          else {
            this.getBookings();
          }
        });
    }
    else {
      alert("please select " + (this.numberOfSeat - this.bookSeat.SeatList.length) + " more");
    }

  }


  isSeatBooked(seat: number) {
    if (this.bookedSeat.find(element => element == seat)) {
      return true;
    }
      return false;
  }
  isSeatSelected(seat: number) {
    if (this.bookSeat.SeatList.find(element => element == seat)) {
      return true;
    }
    return false;
  }


  selectSeat(seat: number) {
    if (!this.bookedSeat.includes(seat)) {
      if (this.bookSeat.SeatList.find(element => element == seat)) {
        var index = this.bookSeat.SeatList.findIndex(element => element == seat);
        this.bookSeat.SeatList.splice(index, 1);
        }
        else {
        if (this.numberOfSeat - this.bookSeat.SeatList.length != 0) {
          var counter = this.numberOfSeat - this.bookSeat.SeatList.length;
            for (var i = 0; i < counter; i++) {
              if (this.bookedSeat.includes(seat + i) || this.bookSeat.SeatList.includes(seat + i)) {
                break;
              }
              
              this.bookSeat.SeatList.push(seat + i);
            }
          }
          else {
            alert("You have already Selected " + (this.numberOfSeat) + " seat");
          }
          
        }
      
    }
    

}

}
