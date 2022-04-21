using System;

namespace mvcapp.Models;

public static class FakeDataFactory
{
    public static IEnumerable<Blog> Blogs => new List<Blog>()
    {
        new Blog()
        {
            Id = 1,
            Title = "Blog number 1",
            Description = "Here is a description for Blog N1",
        },
        new Blog()
        {   
            Id = 2,
            Title = "Blog number 2",
            Description = "Here is a description for Blog N2"
        }
    };

}