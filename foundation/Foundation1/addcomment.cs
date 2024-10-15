using System;

public class CommentInputHelper
{

    public static Comment GetCommentFromUser()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Enter your comment:");
        string text = Console.ReadLine();
        

        return new Comment(name, text);
    }
}
