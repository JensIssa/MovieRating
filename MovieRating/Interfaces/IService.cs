namespace MovieRating;

public interface IService
{
    /// <summary>
    /// Gets the number of reviews by a single reviewer
    /// </summary>
    /// <param name="reviewer">The reviewer who has his number of reviews extracted</param>
    /// <returns>returns the number of reviews from a specific reviewer</returns>
    int GetNumberOfReviewsFromReviewer(int reviewer);

    /// <summary>
    /// Gets the average rate from a reviewer
    /// </summary>
    /// <param name="reviewer">The reviewer who has his average rate tracked</param>
    /// <returns>returns a doublee showing the average rate from the specific reviewer</returns>
    double GetAverageRateFromReviewer(int reviewer);

    /// <summary>
    /// Gets the number of the specific rating by the specific reviewer
    /// </summary>
    /// <param name="reviewer">the specific reviewer in question</param>
    /// <param name="rate">the rating which is being checked</param>
    /// <returns>returns the number of rates given by the specific reviewer</returns>
    int GetNumberOfRatesByReviewer(int reviewer, int rate);

    /// <summary>
    /// Gets the number of reviews on a specific movie
    /// </summary>
    /// <param name="movie">The movie id in question</param>
    /// <returns>returns the number of reviews on a specific reviews</returns>
    int GetNumberOfReviews(int movie);

    /// <summary>
    /// Gets the average rating of a specific movie
    /// </summary>
    /// <param name="movie">the movie in question</param>
    /// <returns>returns the average rate of a movie</returns>
    double GetAverageRateOfMovie(int movie);

    /// <summary>
    /// Gets the number of rates a specific movie has received
    /// </summary>
    /// <param name="movie">specific movie in question</param>
    /// <param name="rate">rating being checked in question</param>
    /// <returns>returns the number of rates a specific movie has received</returns>
    int GetNumberOfRates(int movie, int rate);

    /// <summary>
    /// Gets a list of movies with the highest number of top ratings
    /// </summary>
    /// <returns>returns a list with the highest rate movies</returns>
    List<int> GetMoviesWithHighestNumberOfTopRates();

    /// <summary>
    /// Gets a list of reviewers who has done the most ratings
    /// </summary>
    /// <returns>returns a list with the most productive reviews</returns>
    List<int> GetMostProductiveReviewers();

    /// <summary>
    /// Gets the top rated movies in the list
    /// </summary>
    /// <param name="amount">the number of top rated movies</param>
    /// <returns>returns a list of the top rated movies based on N</returns>
    List<int> GetTopRatedMovies(int amount);

    /// <summary>
    /// Gets a list of the top rated movies by a specific reviewer
    /// </summary>
    /// <param name="reviewer">The reviewer in question</param>
    /// <returns>returns the top rated movies by a specific reviewer</returns>
    List<int> GetTopMoviesByReviewer(int reviewer);

    /// <summary>
    /// Gets a list of the reviewers who has rated a specific movie
    /// </summary>
    /// <param name="movie">Movie being revieved by reviewers in question</param>
    /// <returns>returns a list of reviews who has rated the specific movie</returns>
    List<int> GetReviewersByMovie(int movie);
    
}