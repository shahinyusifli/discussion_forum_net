using Microsoft.EntityFrameworkCore;

namespace DevAcademyAssigment.Models 
{
  public class Message
  {
      public int MessageId { get; set; }
      public string? MessageContent { get; set; }
      public DateTime? Date { get; set;  }
      public int TopicId { get; set; }
      public int UserId { get; set; }
    
  }



  public class Topic
  {
      public int TopicId { get; set; }
      public string? TopicContent { get; set; }
  }


  public class User
  {
      public int UserId { get; set; }
      public string? UserName { get; set; }
      public string? Password { get; set; }
      public string? Email { get; set; }
      public string? HashCode {get; set;}
      public string? Role {get; set;}
  }

  class MessagesDb : DbContext
{
    public MessagesDb(DbContextOptions options) : base(options) { }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<User> Users { get; set; }
    
}
}
