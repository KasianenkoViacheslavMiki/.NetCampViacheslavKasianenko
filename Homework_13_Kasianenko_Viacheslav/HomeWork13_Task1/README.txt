# Project Title
The Ukrainian cinema network.
## Description
The project was built on MS SQL Server. 
This project was targeted at the structure`s saving information about films shown in cinemas, clients who buy tickets at cinemas, saving showtime, and where these films are shown.
## Database structure
### Entities
* Films;
Information about films which are shown in these cinemas.
* Cinema halls;
Information about where be showtime films. 
* Client (User);
Information about clients who buy tickets and see films.
### Connection tables
* Booking.
Connection table for save information about ticket which buy client for another showtime and on another place.
* Showtime;
Information about a time when and where shown film in these cinema networks.
### Other tables
* PlaceCinemaHall
Information about place which have cinema hall
## Decisions
Was add a table for saving all places in all the cinema halls.
When the client buys the ticket, in the table save information GUID showtime and place cinema hall.

On database can run all these tasks:
• Select all the showtimes for the current week, including movie name, date and time of the
show.
• Select all available seats for the specific show.
• Find seats which were never booked.
• Calculate all the money earned by each movie and display in descending order along with
movies names.
• Show top 3 users, who spent most money in the specified dates interval.
• Find cinema halls, which received less visitors in the last week (7 days), than in the week
(another 7 days) before that.
• Find the couples of users, who attends the shows only together.

## Author
Viacheslav Kasianenko, student .NETCamp Sigma. 