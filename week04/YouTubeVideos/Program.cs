using System;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Introduction to C#", "Programming Hub", 620);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for this tutorial."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 Travel Destinations", "Travel Time", 840);
        video2.AddComment(new Comment("Emma", "I want to visit Japan!"));
        video2.AddComment(new Comment("Liam", "Amazing video."));
        video2.AddComment(new Comment("Sophia", "Beautiful scenery."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Easy Chocolate Cake Recipe", "Kitchen Queen", 450);
        video3.AddComment(new Comment("Olivia", "Looks delicious!"));
        video3.AddComment(new Comment("Noah", "Trying this tonight."));
        video3.AddComment(new Comment("Mia", "Thanks for sharing!"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Learn Guitar in 15 Minutes", "Music Academy", 900);
        video4.AddComment(new Comment("Ethan", "Best lesson ever."));
        video4.AddComment(new Comment("Ava", "Easy to follow."));
        video4.AddComment(new Comment("Lucas", "Can't wait for Part 2!"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine();

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _length;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetText()
    {
        return _text;
    }
}