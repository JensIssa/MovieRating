namespace MovieRating;

public class BEReview
{
    public int reviewer;
    public int movie;
    public int grade;
    public DateTime reviewDate;
    
    public int Reviewer
    {
        get => reviewer;
        set => reviewer = value;
    }

    public int Movie
    {
        get => movie;
        set => movie = value;
    }

    public int Grade
    {
        get => grade;
        set => grade = value;
    }

    public DateTime ReviewDate
    {
        get => reviewDate;
        set => reviewDate = value;
    }

    

}