namespace MovieRating.Repository;

public interface IBERepository
{
    List<BEReview> getAllReviews(List<BEReview> reviews);
}