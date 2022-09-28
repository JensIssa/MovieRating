using MovieRating.Repository;

namespace MovieRating;

public class BERepository : IBERepository
{
    /*
    public List<BEReview> reviews = new List<BEReview>
    {
        new BEReview{Reviewer = 1, Movie = 1, Grade = 5, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 3, Grade = 4, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 1, Movie = 4, Grade = 1, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 2, Movie = 1, Grade = 4, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 2, Movie = 2, Grade = 4, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 2, Movie = 3, Grade = 3, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 2, Movie = 4, Grade = 2, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 3, Movie = 1, Grade = 3, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 3, Movie = 2, Grade = 3, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 3, Movie = 3, Grade = 5, ReviewDate = DateTime.Now},
        new BEReview{Reviewer = 3, Movie = 4, Grade = 2, ReviewDate = DateTime.Now}
    };
    */

    public List<BEReview> getAllReviews(List<BEReview> reviews)
    {
        return reviews;
    }
}