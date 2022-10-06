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
        if (reviewer < 1 )
        {
            throw new ArgumentException("Id must be a positive number");
        }
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

        if (reviewer < 1 )
        {
           throw new ArgumentException("Id must be a positive number");
        }
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
        if (reviewer < 1)
        {
            throw new ArgumentException("Id must be a positive number");
        }
        if (rate < 1 || rate > 5)
        {
            throw new ArgumentException("Grade must be a number between 1 and 5");
        }
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
        if (movie < 1)
        {
            throw new ArgumentException("Id must be a positive number");
        }
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
        if (movie < 1)
        {
            throw new ArgumentException("Id must be a positive number");
        }
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
        if (movie < 1)
        {
            throw new ArgumentException("Id must be a positive number");
        }
        if (rate < 1 || rate > 5)
        {
            throw new ArgumentException("Grade must be a number between 1 and 5");
        }
        
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
        if (moviesWithFive.Count == 0)
        {
            throw new ArgumentException("No movies has a rating of 5");
        }
        else
        {
            var input = moviesWithFive.GroupBy(i => i).ToList();
            int max = input.Max(c => c.Count());
            return input.Where(d => d.Count() == max).
                Select(c => c.Key).ToList();
        }
    }

    public List<int> GetMostProductiveReviewers()
    {
        List<int> reviewers = new List<int>();
        foreach (var review in _repository.getAllReviews())
        {
            reviewers.Add(review.Reviewer);
        }
        if (reviewers.Count == 0)
        {

            throw new ArgumentException("There is no reviewer(s)");
        }
        else
        {
            var input = reviewers.GroupBy(i => i).ToList();
            int max = input.Max(c => c.Count());
            var productiveReviwers = input.Where(d => d.Count() == max).
                Select(c => c.Key).ToList();
        
            return productiveReviwers;
        }
    }

    public List<int> GetTopRatedMovies(int amount)
    {
        List<int> movies = new List<int>();
        foreach (var review in _repository.getAllReviews())
        {
            if (amount <= review.Grade)
            {
                movies.Add(review.Movie);
            }

            foreach (var movie in movies)
            {
                GetAverageRateOfMovie(movie);
            }
        }
        if (movies.Count == 0)
        {
            throw new ArgumentException("There is no top rated movies");
        }
        else
        {
            var input = movies.GroupBy(i => i).ToList();
            int max = input.Max(c => c.Count());
            var topRatedMovies = input.Where(d => d.Count() == max).
                Select(c => c.Key).ToList();
        
            return topRatedMovies;
        }
    }

    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        var topMovies = _repository.getAllReviews().Where(r => r.Reviewer == reviewer).OrderByDescending(r => r.Grade)
            .ThenByDescending(r => r.ReviewDate).Select(r => r.Movie).ToList();
        if (topMovies.Count ==0)
        {
            throw new ArgumentException("There is no top rated movies made by the reviewer");
        }
        return topMovies;
    }

    public List<int> GetReviewersByMovie(int movie)
    {
        var reviewerMovies = _repository.getAllReviews().Where(r => r.Movie == movie).OrderByDescending(r => r.Grade)
            .ThenByDescending(r => r.ReviewDate).Select(r => r.Reviewer).ToList();
        if (reviewerMovies.Count ==0)
        {
            throw new ArgumentException("No one has reviewed this movie");
        }
        return reviewerMovies;
    }
}