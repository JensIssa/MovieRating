using MovieRating;
using MovieRating.Repository;

namespace MovieTest;

public class UnitTest1
{
    [Fact]
    public void GetNumberOfReviewsFromReviewerTest()
    {
        IBERepository repository = new BERepository();
        MovieService movieService = new MovieService(repository);
        
        //Assert
        Assert.Equal(5,movieService.GetNumberOfReviewsFromReviewer(1));
    }

    [Fact]
    public void GetAverageRateFromReviewerTest()
    {
        //Arrange
        
        //ACt
        IBERepository repository = new BERepository();
        MovieService movieService = new MovieService(repository);
        //Assert 
        Assert.Equal(3.25, movieService.GetAverageRateFromReviewer(1));
    }
}