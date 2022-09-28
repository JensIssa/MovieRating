using Moq;
using MovieRating;
using MovieRating.Repository;

namespace MovieTest;

public class UnitTest1
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]    
    [InlineData(3, 0)]
    public void GetNumberOfReviewsFromReviewerTest(int reviewerId, int expectedResult)
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);

        IService service = new MovieService(mockRepo.Object);
        
        //Act
        var result = service.GetNumberOfReviewsFromReviewer(reviewerId);
        
        //Assert
        Assert.Equal(expectedResult,result);
        mockRepo.Verify(r => r.getAllReviews(), Times.Once);
    }
    
    
}