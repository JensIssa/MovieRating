using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

    [Theory]
    [InlineData(1,2)]
    [InlineData(1,4)]//true
    [InlineData(2,3)]
    [InlineData(2,4)]//true
    public void GetAverageRateFromReviewerTest(int reviewerId, double expectedResult)
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);

        IService service = new MovieService(mockRepo.Object);
        
        //Act
        var result = service.GetAverageRateFromReviewer(reviewerId);
        
        //Assert
        Assert.Equal(expectedResult, result);
       // mockRepo.Verify(r=>r.getAllReviews(), Times.Once);
    }

    [Theory]
    [InlineData(1, 5, 2)] // false
    [InlineData(1, 3, 2)] //true
    [InlineData(2, 3, 1)] //false
    [InlineData(2, 4, 2)] //true
    public void GetNumberOfRatesByReviewerTest(int reviewerID, int rate, int expectedRate)
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);

        IService service = new MovieService(mockRepo.Object);
        
        //Act
        var result = service.GetNumberOfRatesByReviewer(reviewerID, rate);
        
        //Assert
        Assert.Equal(expectedRate, result);
        //mockRepo.Verify(r => r.getAllReviews(), Times.Once);
    }

    [Theory]
    [InlineData(1,2)]//true
    [InlineData(2,2)]//true
    [InlineData(2,3)]//false
    public void GetNumberOfReviewsTest(int movieId, int expectedResult)
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);

        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetNumberOfReviews(movieId);
        //Assert
        Assert.Equal(expectedResult, result);
        
    }

    [Theory]
    [InlineData(1,4)]//true
    [InlineData(2,4)]//true
    [InlineData(3,4)]//false
    public void GetAverageRateOfMovieTest(int movieId, double expectedResult)
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);

        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetAverageRateOfMovie(movieId);
        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1, 4, 1)] //true
    [InlineData(2, 4, 1)] //true
    [InlineData(1, 2, 4)] //false
    public void GetNumberOfRatesTest(int movieId, int rate, int expectedRate)
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);

        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetNumberOfRates(movieId, rate);
        //Assert
        Assert.Equal(expectedRate, result);
    }

    
    [Fact]
    public void GetMoviesWithHighestNumberOfTopRatesTest1()
    {
        //Arrange
       
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = DateTime.Now }
            
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        
        //Act
        var result = service.GetMoviesWithHighestNumberOfTopRates();
        List<int> expectedResult = new List<int>();
        expectedResult.Add(2);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void GetMoviesWithHighestNumberOfTopRatesTest2()
    {
        //Arrange
       
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 3, Movie = 4, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 4, Movie = 4, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        
        //Act
        var result = service.GetMoviesWithHighestNumberOfTopRates();
        List<int> expectedResult = new List<int>();
        expectedResult.Add(2);
        expectedResult.Add(4);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void GetMoviesWithHighestNumberOfTopRatesTest3()
    {
        //Arrange

        List<BEReview> fakeRepo = new List<BEReview>{new BEReview { Reviewer = 4, Movie = 4, Grade = 4, ReviewDate = DateTime.Now }};
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        
        //Act
        var ex = Assert.Throws<ArgumentException>(() => service.GetMoviesWithHighestNumberOfTopRates());

        //Assert
        Assert.Equal("No movies has a rating of 5", ex.Message);
        
    }

    [Fact]
    public void GetMostProductiveReviewersTest1()
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 3, Movie = 4, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 4, Movie = 4, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetMostProductiveReviewers();
        List<int> expectedResult = new List<int>();
        expectedResult.Add(2);
        //Assert
        Assert.Equal(expectedResult, result);

    }
    
    [Fact]
    public void GetMostProductiveReviewersTest2()
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 4, Grade = 4, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 4, Movie = 4, Grade = 4, ReviewDate = DateTime.Now }
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetMostProductiveReviewers();
        List<int> expectedResult = new List<int>();
        expectedResult.Add(1);
        expectedResult.Add(2);
        //Assert
        Assert.Equal(expectedResult, result);
    }

   [Fact]
   public void GetTopRatedMoviesTest1()
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
            new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
        };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetTopRatedMovies(4);
        List<int> expectedResult = new List<int>();
        expectedResult.Add(1);
        expectedResult.Add(2);
        //Assert
        Assert.Equal(expectedResult, result);
    }
}