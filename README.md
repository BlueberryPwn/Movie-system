# Movie system

This application is a basic movie database that makes use of two different APIs: a basic API made by me as well as an API from [TMDB](https://developer.themoviedb.org/docs). The user can submit their preferred movies and genres to the database and also submit their own movie reviews. It is also possible for the user to receive lists of their submitted movies, genres and reviews and discover new movies through TMDB.

## API-calls

This application can make several API-calls. Here's a list of them:

- GET (local server and port number)/api/Genres/GetAllGenres = Gets all genres.

- GET (local server and port number)/api/LikedGenres/GetLikedGenresByUserId/{UserId} = Gets all genres connected to a user.

- POST (local server and port number)/api/LikedGenres/AddLikedGenre/{UserId}/{GenreId} = The user can connect genres to themselves.

- GET (local server and port number)/api/Movie/GetAllMovies = Gets all movies.

- GET (local server and port number)/api/Movie/GetMovieByUserId/{UserId} = Gets all movies connected to a user.

- POST (local server and port number)/api/Movie/AddNewMovie/{MovieName}/{MovieGenre}/{MovieDescription}/{Link}/{UserId} = The user can add a movie along with some information to the database and connect themselves to it.

- GET (local server and port number)/api/Review/GetReviewByUserId/{UserId} = Gets reviews submitted by a user.

- POST (local server and port number)/api/Review/AddReview/{UserId}/{MovieId}/{ReviewRating}/{ReviewName} = The user can make a review and submit it to the database.

- GET (local server and port number)/api/TMDB/TMDBDiscover/{TmdbId} = The user can discover new movies through TMDB. Note: This requires TMDBs own genre IDs. Some of them can be found through the link below.

- GET (local server and port number)/api/User/GetAllUsers = Gets all users available in the database.

- GET (local server and port number)/api/User/GetUserById/{UserId} = Gets a specific user from the database.

## TMDB

This application utilizes TMDBs own API. Usage of TMDBs genre IDs is therefore necessary for the TMDB method to work correctly. Some of them may be found [here](https://www.themoviedb.org/talk/5daf6eb0ae36680011d7e6ee). Many thanks goes to TMDB for making this a possibility!

<p align="center"><img
img width="256" height="256" src="https://www.themoviedb.org/assets/2/v4/logos/v2/blue_square_2-d537fb228cf3ded904ef09b136fe3fec72548ebc1fea3fbbd1ad9e36364db38b.svg"></p>