namespace AskMe.APP.Pages
{
    public class Question
    {
        public string? Id { get; set; }
        public string? Code { get; set; }
        public string? Title { get; set; }
        public string? TitleAR { get; set; }
        public string? Details { get; set; }
        public string? DetailsAR { get; set; }
        public Writer? WriterInfo { get; set; }
        public List<Answer>? Answers { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Writer
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NameAR { get; set; }
        public string? Email { get; set; }
    }
    public class Answer
    {
        public string? Id { get; set; }
        public string? TheAnswer { get; set; }
        public Owner? OwnerInfo { get; set; }
        public DateTime AnswerDate { get; set; }

    }

    public class Owner
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NameAR { get; set; }
        public string? Email { get; set; }
    }
}
