using Moq;
using MovieRating;
using MovieRating.Repository;

namespace MovieTest;

public class UnitTest1
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(1, 2, 3)]    
    [InlineData(1, 2, 3)]    
    [InlineData(1, 2, 3)]
    public void GetNumberOfReviewsFromReviewerTest(int reviewerId, int movieID, int grade)
    {
        Mock<IBERepository> mock = new Mock<IBERepository>();
        MovieService movieService = new MovieService(mock.Object);
        List<BEReview> reviews = new List<BEReview>
            { new BEReview { Reviewer = reviewerId, Movie = movieID, Grade = grade, ReviewDate = DateTime.Now } };
        movieService.addList(reviews);
        
        Assert.Equal(4,movieService.GetNumberOfReviewsFromReviewer(1));
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