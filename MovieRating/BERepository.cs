using MovieRating.Repository;

namespace MovieRating;

public class BERepository : IBERepository
{
    public List<BEReview> reviews = new List<BEReview>
    {
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now},
    };

    public List<BEReview> getAllReviews()
    {
        return reviews;
    }
}