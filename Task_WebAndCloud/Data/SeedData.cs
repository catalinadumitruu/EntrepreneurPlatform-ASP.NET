using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Task_WebAndCloud.Models;

namespace Task_WebAndCloud.Data
{
    public class SeedData
    {
        public static void Populate(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Title = "Looking for Java Developer",
                        Content = "Looking for a job? Don't hesitate to contact us at adobe@adobe.com! We are thrilled to have you in our team!",
                        PostingDate = DateTime.Now,
                        Category = "Hiring",
                        UserEmail = "user@user.com"
                    },
                     new Post
                     {
                         Title = "Looking for public speaker",
                         Content = "If you think you know how to entertain an entire room (zoom room :) ) please contact us! We are hosting a conference and we are in need of a host!",
                         PostingDate = DateTime.Now,
                         Category = "Hiring",
                         UserEmail = "user1@user.com"
                     },
                      new Post
                      {
                          Title = "Newest virus is out now",
                          Content = "Have you heard? There is a new mobile virus surfing over the internet. Pay attention to what sites you access from you mobile phone.",
                          PostingDate = DateTime.Now,
                          Category = "News",
                          UserEmail = "user2@user.com"
                      },
                       new Post
                       {
                           Title = "New formula of AstraZeneca",
                           Content = "German scientists say they can help improve Covid vaccines to prevent blood clots",
                           PostingDate = DateTime.Now,
                           Category = "Development",
                           UserEmail = "user1@user.com"
                       },
                       new Post
                       {
                           Title = "Have you heard about the new Android virus?",
                           Content = "FluBot is a new malware that affects Android phones. So if you get a message with a link, do yourself a favor and do not open it!",
                           PostingDate = DateTime.Now,
                           Category = "News",
                           UserEmail = "user@user.com"
                       },
                       new Post
                       {
                           Title = "Laser experiments suggest helium rain falls on Jupiter",
                           Content = "Sprinkles of helium rain may fall on Jupiter.",
                           PostingDate = DateTime.Now,
                           Category = "News",
                           UserEmail = "user@user.com"
                       },
                       new Post
                       {
                           Title = "Space station detectors found the source of weird ‘blue jet’ lightning",
                           Content = "A ‘blue bang’ sparks an unusual type of lightning in the upper atmosphere",
                           PostingDate = DateTime.Now,
                           Category = "Development",
                           UserEmail = "user1@user.com"
                       }
                    );

                context.SaveChanges();
            }
        }
    }
}
