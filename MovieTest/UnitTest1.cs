using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Moq;
using MovieRating;
using MovieRating.Repository;

namespace MovieTest;

public class UnitTest1
{
    
    #region GetMostProductiveReviewers

   public static IEnumerable<Object[]> GetMostProductiveReviewers_TestCaseValidInput()
    {
        // Top-reviewer equals list(2)
        yield return new object[]
        {
            new BEReview[]
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
            },
            new List<int>(){2}
        };
    }

   public static IEnumerable<Object[]> GetMostProductiveReviewersTwoOrMoreValidInputTestCase()
   {
       yield return new object[]
       {
           new BEReview[]
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
           },
           new List<int>(){1,2}
       };
   }


    #endregion

    #region GetMoviesWithHighestNumberOfTopRatesTestValidInput

    public static IEnumerable<Object[]> GetMoviesWithHighestNumberOfTopRatesTestValidInputTestCase()
    {
        // Top-reviewer equals list(2)
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview { Reviewer = 1, Movie = 1, Grade = 3, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = DateTime.Now }
            },
            new List<int>(){2}
        };
    }

    public static IEnumerable<Object[]> GetMoviesWithHighestNumberOfTopRatesValidInputTwoOrMoreMaxTestTestCase()
    {
        yield return new object[]
        {
            new BEReview[]
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
            },
            new List<int>() { 2, 4 }
        };
    }

    #endregion
    
    #region GetTopRatedMoviesValidInputTest

    public static IEnumerable<Object[]> GetTopRatedMoviesValidInputTestTestCase()
    {
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview { Reviewer = 1, Movie = 1, Grade = 4, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 1, Movie = 2, Grade = 4, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now }
            },
            new List<int>() { 1, 2 }
        };
    }


    #endregion

    #region GetTopMoviesByReviewerValidInputTest

    public static IEnumerable<Object[]> GetTopMoviesByReviewerValidInputTestTestCase()
    {
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview { Reviewer = 1, Movie = 1, Grade = 5, ReviewDate = new DateTime(2020, 12, 25) },
                new BEReview { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime(2018, 7, 19) },
                new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 1, Movie = 4, Grade = 5, ReviewDate = new DateTime(2015, 6, 5) },
                new BEReview { Reviewer = 2, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 3, Movie = 4, Grade = 4, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 4, Movie = 4, Grade = 4, ReviewDate = DateTime.Now }
            },
            new List<int>() { 1, 4, 2 }
        };
    }
    
    #endregion

    #region GetReviewersByMovieValidInputTest

    public static IEnumerable<Object[]> GetReviewersByMovieValidInputTestTestCase()
    {
        yield return new object[]
        {
            new BEReview[]
            {
                new BEReview { Reviewer = 1, Movie = 1, Grade = 5, ReviewDate = new DateTime(2020, 12, 25) },
                new BEReview { Reviewer = 1, Movie = 2, Grade = 3, ReviewDate = new DateTime(2018, 7, 19) },
                new BEReview { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 2, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 2, Movie = 3, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 1, Movie = 4, Grade = 5, ReviewDate = new DateTime(2015, 6, 5) },
                new BEReview { Reviewer = 2, Movie = 4, Grade = 5, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 3, Movie = 4, Grade = 4, ReviewDate = DateTime.Now },
                new BEReview { Reviewer = 4, Movie = 4, Grade = 4, ReviewDate = DateTime.Now }
            },
            new List<int>() { 2, 1 }
        };
    }

    #endregion
    /// <summary>
    /// Tests whether we can extract valid values from the mock object list, and see how many reviews an reviewer has given
    /// </summary>
    /// <param name="reviewerId">reviewer ID given</param>
    /// <param name="expectedResult">the expected result, which is the number of reviews the specific id has given</param>
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(3, 0)]
    public void GetNumberOfReviewsFromReviewerValidTest(int reviewerId, int expectedResult)
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
        Assert.Equal(expectedResult, result);
       
    }

    /// <summary>
    /// Tests whether our expception works whenever we insert an invalid value
    /// </summary>
    /// <param name="reviewerId">The invalid reviewer id</param>
    /// <param name="expectedException">The expected exception message</param>
    [Theory]
    [InlineData(-1, "Id must be a positive number")]
    [InlineData(0, "Id must be a positive number")]
    public void GetNumberOfReviewsFromReviewerInvalidTest(int reviewerId, string expectedException)
    {
        //Arrange
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        IService service = new MovieService(mockRepo.Object);
        Action action = () => service.GetNumberOfReviewsFromReviewer(reviewerId);
        //Act
        var ex = Assert.Throws<ArgumentException>(action);
        //Assert
        Assert.Equal(expectedException, ex.Message);
    }

    /// <summary>
    ///  Tests whether we can extract valid values from the mock object list,
    /// and see the average rate by an individual reviewer
    /// </summary>
    /// <param name="reviewerId">reviewer Id given</param>
    /// <param name="expectedResult">the expected average rate</param>
    [Theory]
    [InlineData(1, 4)] //true
    [InlineData(2, 4)] //true
    public void GetAverageRateFromReviewerValidTest(int reviewerId, double expectedResult)
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
    }

    /// <summary>
    ///  Tests whether our expception works whenever we insert an invalid value
    /// </summary>
    /// <param name="reviewerId"> the given reviewer id</param>
    /// <param name="expectedException">The expected exception message</param>
    [Theory]
    [InlineData(-1, "Id must be a positive number")]
    [InlineData(0, "Id must be a positive number")]
    public void GetAverageRateFromReviewerInvalidTest(int reviewerId, string expectedException)
    {
        //Arrange
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        IService service = new MovieService(mockRepo.Object);
        Action action = () => service.GetAverageRateFromReviewer(reviewerId);
        //Act
        var ex = Assert.Throws<ArgumentException>(action);
        //Assert
        Assert.Equal(expectedException, ex.Message);
    }

    /// <summary>
    /// Tests whether we can extract the number of a specific rate given by an individual reviewer
    /// </summary>
    /// <param name="reviewerID">the reviewer in question</param>
    /// <param name="rate">the specific rate being searched for</param>
    /// <param name="expectedRate">the number of the specific rate, given by the specific reviewer</param>
    [Theory]
    [InlineData(1, 3, 2)] //true
    [InlineData(2, 4, 2)] //true
    public void GetNumberOfRatesByReviewerValidTest(int reviewerID, int rate, int expectedRate)
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
        
    }

    /// <summary>
    /// Tests whether our expception works whenever we insert an invalid value.
    /// In our assignment, it was specified that the grade must be a number between
    /// 1-5, and therefore we also test that.
    /// </summary>
    /// <param name="reviewerid">Invalid reviewer input</param>
    /// <param name="rate">Invalid rate input</param>
    /// <param name="expectedException">The expected exceptionmessage for each of the invalid inputs</param>
    [Theory]
    [InlineData(-1, 3, "Id must be a positive number")]
    [InlineData(0, 2, "Id must be a positive number")]
    [InlineData(2, 7, "Grade must be a number between 1 and 5")]
    [InlineData(2, 0, "Grade must be a number between 1 and 5")]
    public void GetNumberofRatesByReviewerInvalidTest(int reviewerid, int rate, string expectedException)
    {
        //Arrange
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        IService service = new MovieService(mockRepo.Object);
        Action action = () => service.GetNumberOfRatesByReviewer(reviewerid, rate);
        //Act
        var ex = Assert.Throws<ArgumentException>(action);
        //Assert
        Assert.Equal(expectedException, ex.Message);
    }

    /// <summary>
    /// Tests whether we extract the correct number of reviews given to a specific movie
    /// </summary>
    /// <param name="movieId">the movieId in question</param>
    /// <param name="expectedResult">the number of reviews given</param>
    [Theory]
    [InlineData(1, 2)] //true
    [InlineData(2, 2)] //true
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

    /// <summary>
    /// Tests whether we get the correct exception message, when we insert an invalid value
    /// </summary>
    /// <param name="movieId">invalid movie id inserted</param>
    /// <param name="expectedException">the correct exception message</param>
    [Theory]
    [InlineData(-1, "Id must be a positive number")]
    [InlineData(0, "Id must be a positive number")]
    public void GetNumberofReviewsInvalidTest(int movieId, string expectedException)
    {
        //Arrange
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        IService service = new MovieService(mockRepo.Object);
        Action action = () => service.GetNumberOfReviews(movieId);
        //Act
        var ex = Assert.Throws<ArgumentException>(action);
        //Assert
        Assert.Equal(expectedException, ex.Message);
    }

    /// <summary>
    /// Gets the average rate of the inserted movie id
    /// </summary>
    /// <param name="movieId">the specific movie id being checked</param>
    /// <param name="expectedResult">the average rate of the specific movie</param>
    [Theory]
    [InlineData(1, 4)] //true
    [InlineData(2, 4)] //true
    public void GetAverageRateOfMovieValidTest(int movieId, double expectedResult)
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

    /// <summary>
    /// Tests whether we get the correct exception message, when we insert an invalid value
    /// </summary>
    /// <param name="movieId">the invalid movieId</param>
    /// <param name="expectedException">the expected exception message</param>
    [Theory]
    [InlineData(-1, "Id must be a positive number")]
    [InlineData(0, "Id must be a positive number")]
    public void GetAverageRateOfMovieInvalidTest(int movieId, string expectedException)
    {
        //Arrange
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        IService service = new MovieService(mockRepo.Object);
        Action action = () => service.GetAverageRateOfMovie(movieId);
        //Act
        var ex = Assert.Throws<ArgumentException>(action);
        //Assert
        Assert.Equal(expectedException, ex.Message);
    }

    /// <summary>
    /// Tests whether the method gets the number of a specific rating, that a specific movie has been given
    /// </summary>
    /// <param name="movieId">the movie inserted</param>
    /// <param name="rate">the rating inserted</param>
    /// <param name="expectedRate">the number of rates</param>
    [Theory]
    [InlineData(1, 4, 1)] //true
    [InlineData(2, 4, 1)] //true
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

    /// <summary>
    /// Tests whether our expception works whenever we insert an invalid value.
    /// In our assignment, it was specified that the grade must be a number between
    /// 1-5, and therefore we also test that.
    /// </summary>
    /// <param name="movieId">invalid movie id</param>
    /// <param name="rate">invalid rating</param>
    /// <param name="expectedException">the expected exception message</param>
    [Theory]
    [InlineData(-1, 3, "Id must be a positive number")]
    [InlineData(0, 2, "Id must be a positive number")]
    [InlineData(2, 7, "Grade must be a number between 1 and 5")]
    [InlineData(2, 0, "Grade must be a number between 1 and 5")]
    public void GetNumberOfRatesInvalidTest(int movieId, int rate, string expectedException)
    {
        //Arrange
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        IService service = new MovieService(mockRepo.Object);
        Action action = () => service.GetNumberOfRates(movieId, rate);
        //Act
        var ex = Assert.Throws<ArgumentException>(action);
        //Assert
        Assert.Equal(expectedException, ex.Message);
    }

    /// <summary>
    /// Tests whether we get get the ONE movie with the highest number of top rates.
    /// </summary>
    [Theory]
    [MemberData(nameof(GetMoviesWithHighestNumberOfTopRatesTestValidInputTestCase))]
    public void GetMoviesWithHighestNumberOfTopRatesTestValidInput(BEReview[] data, List<int> expectedResult)
    {
        //Arrange
        var fakeRepo = data;
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo.ToList);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetMoviesWithHighestNumberOfTopRates();
        //Assert
        Assert.Equal(expectedResult, result);
    }

    /// <summary>
    /// Tests whether we can extract two or more movies, if they have the same amount of top rates 
    /// </summary>
    [Theory]
    [MemberData(nameof(GetMoviesWithHighestNumberOfTopRatesValidInputTwoOrMoreMaxTestTestCase))]
    public void GetMoviesWithHighestNumberOfTopRatesValidInputTwoOrMoreMaxTest(BEReview[] data, List<int> expectedResult)
    {
        //Arrange
        var fakeRepo = data;
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo.ToList);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetMoviesWithHighestNumberOfTopRates();
        //Assert
        Assert.Equal(expectedResult, result);
    }

    /// <summary>
    /// Tests whether we get the correct exception, when we insert an invalid input
    /// </summary>
    [Fact]
    public void GetMoviesWithHighestNumberOfTopRatesInvalidInputTest()
    {
        //Arrange

        List<BEReview> fakeRepo = new List<BEReview>
            { new BEReview { Reviewer = 4, Movie = 4, Grade = 4, ReviewDate = DateTime.Now } };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var ex = Assert.Throws<ArgumentException>(() => service.GetMoviesWithHighestNumberOfTopRates());
        //Assert
        Assert.Equal("No movies has a rating of 5", ex.Message);
    }

    /// <summary>
    /// Tests whether we can extract the most productive SINGULAR reviewer.
    /// </summary>
    [Theory]
    [MemberData(nameof(GetMostProductiveReviewers_TestCaseValidInput))]
    public void GetMostProductiveReviewersTestValidInputTest(BEReview[] data, List<int> expectedResult)
    {
        //Arrange
        var fakeRepo = data;
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        IService service = new MovieService(mockRepo.Object);
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo.ToList);
        //Act
        var result = service.GetMostProductiveReviewers();
        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    /// <summary>
    /// Tests whether we can extract two or more most productive reviewers, if they have the same amount of reviews 
    /// </summary>
    [Theory]
    [MemberData(nameof(GetMostProductiveReviewersTwoOrMoreValidInputTestCase))]
    public void GetMostProductiveReviewersTwoOrMoreValidInputTest(BEReview[] data, List<int> expectedResult)
    {
        //Arrange
        var fakeRepo = data;
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo.ToList);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetMostProductiveReviewers();
        //Assert
        Assert.Equal(expectedResult, result);
    }

    /// <summary>
    /// Tests whether the method throws the correct exception, when we insert an invalid input
    /// </summary>
    [Fact]
    public void GetMostProductiveReviewersInvalidInputTest()
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview> { };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var ex = Assert.Throws<ArgumentException>(() => service.GetMostProductiveReviewers());
        //Assert
        Assert.Equal("There is no reviewer(s)", ex.Message);
    }
    
    /// <summary>
    /// Extracts the highest rated movies
    /// </summary>
    [Theory]
    [MemberData(nameof(GetTopRatedMoviesValidInputTestTestCase))]
    public void GetTopRatedMoviesValidInputTest(BEReview[] data, List<int> expectedResult)
    {
        //Arrange
        var fakeRepo = data;
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo.ToList);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetTopRatedMovies(4);
        //Assert
        Assert.Equal(expectedResult, result);
    }

/// <summary>
/// Checks if the correct exception message prints, when the input is invalid
/// </summary>
    [Fact]
    public void GetTopRatedMoviesInvalidInputTest()
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview> { };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var ex = Assert.Throws<ArgumentException>(() => service.GetTopRatedMovies(4));
        //Assert
        Assert.Equal("There is no top rated movies", ex.Message);
    }

/// <summary>
/// Checks to see, if we can extract the highest rated movies, and thereafter sort by the date, if two movies
/// has the same average rate
/// </summary>
    [Theory]
    [MemberData(nameof(GetTopMoviesByReviewerValidInputTestTestCase))]
    public void GetTopMoviesByReviewerValidInputTest(BEReview[] data, List<int> expectedResult)
    {
        //Arrange
        var fakeRepo = data;
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo.ToList);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetTopMoviesByReviewer(1);
        //Assert
        Assert.Equal(expectedResult, result);
    }

/// <summary>
/// Checks to see if the correct exception message is thrown, if an invalid input is inserted
/// </summary>
    [Fact]
    public void GetTopMoviesByReviewerInvalidInputTest()
    {
        //Arrange
        List<BEReview> fakeRepo = new List<BEReview> { };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var ex = Assert.Throws<ArgumentException>(() => service.GetTopMoviesByReviewer(4));
        //Assert
        Assert.Equal("There is no top rated movies made by the reviewer", ex.Message);
    }

/// <summary>
/// Checks to see if we can different reviews for a singular movie by the reviewers , first sorted by rating
/// and thereafter by date
/// </summary>
    [Theory]
    [MemberData(nameof(GetReviewersByMovieValidInputTestTestCase))]
    public void GetReviewersByMovieValidInputTest(BEReview[] data, List<int> expectedResult)
    {
        //Arrange
        var fakeRepo = data;
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo.ToList);
        IService service = new MovieService(mockRepo.Object);
        //Act
        var result = service.GetReviewersByMovie(1);
        //Assert
        Assert.Equal(expectedResult, result);
    }

/// <summary>
/// Checks to see if the correct exception message is thrown, if the
/// </summary>
    [Fact]
    public void GetReviewersByMovieInvalidInputTest()
    {
        //Arrange

        List<BEReview> fakeRepo = new List<BEReview> { };
        Mock<IBERepository> mockRepo = new Mock<IBERepository>();
        mockRepo.Setup(r => r.getAllReviews()).Returns(fakeRepo);
        IService service = new MovieService(mockRepo.Object);

        //Act
        var ex = Assert.Throws<ArgumentException>(() => service.GetReviewersByMovie(1));

        //Assert
        Assert.Equal("No one has reviewed this movie", ex.Message);
    }
}