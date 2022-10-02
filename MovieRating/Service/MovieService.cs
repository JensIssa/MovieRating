using MovieRating.Repository;

namespace MovieRating;

public class MovieService : IService
{
    private IBERepository _repository;

    public MovieService(IBERepository repository)
    {
        _repository = repository;
    }


    public int GetNumberOfReviewsFromReviewer(int reviewer)
    {
        int reviews = 0;
        foreach (var review in _repository.getAllReviews())
        {
            if (review.Reviewer == reviewer)
            {
                reviews++;
            }
        }

        return reviews;
    }

    public double GetAverageRateFromReviewer(int reviewer)
    {
        int rates = 0;
        foreach (var review in _repository.getAllReviews())
        {
            if (review.Reviewer == reviewer)
            {
                rates += review.Grade;
            }
        }

        double average = rates / GetNumberOfReviewsFromReviewer(reviewer);
        return average;
    }

    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        int rates = 0;
        foreach (var review in _repository.getAllReviews())
        {
            review.Reviewer = reviewer;
            if (rate == review.Grade)
            {
                rates++;
            }
        }

        return rates;
    }

    public int GetNumberOfReviews(int movie)
    {
        int movieReviews = 0;
        foreach (var review in _repository.getAllReviews())
        {
            if (review.Movie == movie)
            {
                movieReviews++;
            }
        }

        return movieReviews;
    }

    public double GetAverageRateOfMovie(int movie)
    {
        int rates = 0;
        foreach (var review in _repository.getAllReviews())
        {
            if (review.Movie == movie)
            {
                rates += review.Grade;
            }
        }

        double average = rates / GetNumberOfReviews(movie);
        return average;
    }

    public int GetNumberOfRates(int movie, int rate)
    {
        int rates = 0;
        foreach (var review in _repository.getAllReviews())
        {
            if (review.Grade == rate && review.Movie == movie)
            {
                rates++;
            }
        }

        return rates;
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        List<int> moviesWithFive = new List<int>();
        foreach (var review in _repository.getAllReviews())
        {
            if (review.Grade == 5)
            {
                moviesWithFive.Add(review.Movie);
            }
        }

        var input = moviesWithFive.GroupBy(i => i).ToList();
        int max = input.Max(c => c.Count());
        var mostTimes = input.Where(d => d.Count() == max).
            Select(c => c.Key).ToList();

        bool isEmpty = !mostTimes.Any(); 
        
        if (isEmpty)
        {
            throw new InvalidOperationException("No movies has a rating of 5");
        }
        
        return mostTimes;
    }

    public List<int> GetMostProductiveReviewers()
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopRatedMovies(int amount)
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public List<int> GetReviewersByMovie(int movie)
    {
        throw new NotImplementedException();
    }
}