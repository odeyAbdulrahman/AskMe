namespace AskMe.API.Domain.Entities
{
    public class Answer
    {
        public string? Id { get; set; }
        public string? TheAnswer { get; set; }
        public Owner? OwnerInfo { get; set; }
        public DateTime AnswerDate { get; set; }
        
    }
}
