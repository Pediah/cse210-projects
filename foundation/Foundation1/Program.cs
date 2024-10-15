using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();


        Video video1 = new Video("How to Cook Pasta", "Chef John", 300);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "I tried it, turned out perfect."));
        video1.AddComment(new Comment("Charlie", "Can you do a gluten-free version?"));

        Video video2 = new Video("Python for Beginners", "Code Academy", 1200);
        video2.AddComment(new Comment("Dave", "Very helpful tutorial!"));
        video2.AddComment(new Comment("Eve", "I finally understand functions."));
        video2.AddComment(new Comment("Frank", "Looking forward to the next one!"));

        Video video3 = new Video("10-minute Yoga", "Yoga With Adriene", 600);
        video3.AddComment(new Comment("Grace", "This was so relaxing!"));
        video3.AddComment(new Comment("Heidi", "Perfect for beginners."));
        video3.AddComment(new Comment("Ivan", "Great way to start the day."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        Console.WriteLine("Displaying all videos and comments:\n");
        foreach (Video video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine();
        }

        bool running = true;
        while (running)
        {
            Console.WriteLine("Would you like to add a comment? (Press 1 to add, 0 to quit)");
            string input = Console.ReadLine();

            if (input == "0")
            {
                running = false;
                break;
            }
            else if (input == "1")
            {

                Console.WriteLine("\nSelect a video to add a comment:");
                for (int i = 0; i < videos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {videos[i].Title} by {videos[i].Author}");
                }

                string videoInput = Console.ReadLine();
                int videoIndex;
                
                if (int.TryParse(videoInput, out videoIndex) && videoIndex > 0 && videoIndex <= videos.Count)
                {

                    Console.WriteLine($"\nYou selected: {videos[videoIndex - 1].Title}");
                    Comment newComment = CommentInputHelper.GetCommentFromUser();
                    videos[videoIndex - 1].AddComment(newComment);
                    Console.WriteLine("Comment added successfully!");

                    videos[videoIndex - 1].DisplayInfo();
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please press 1 to add a comment or 0 to quit.");
            }
        }

        Console.WriteLine("\nFinal display of all videos and comments:\n");
        foreach (Video video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine();
        }
    }
}
