﻿using MovieRating.Repository;

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
        foreach (var review  in _repository.getAllReviews())
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
        throw new NotImplementedException();
    }

    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfReviews(int movie)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateOfMovie(int movie)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfRates(int movie, int rate)
    {
        throw new NotImplementedException();
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        throw new NotImplementedException();
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