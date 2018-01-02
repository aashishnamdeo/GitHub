namespace MessageBoard.Migrations
{
    using MessageBoard.Data;
    using MessageBoard.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Title = "I love MVC",
                    CreatedDate = DateTime.Now,
                    Body = "I Love ASP.net MVC",
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "I love it too!",
                            ReplyDateTime = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Me to!",
                            ReplyDateTime = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Aw Shucks",
                            ReplyDateTime = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "JaVa is better",
                            ReplyDateTime = DateTime.Now
                        }
                    }
                };

                context.Topics.Add(topic);

                var anotheTopic = new Topic()
                {
                    Title = "I love movies"
                    ,
                    CreatedDate = DateTime.Now
                    ,
                    Body = "TZH, Titainc"
                };

                context.Topics.Add(anotheTopic);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
#endif
        }
    }
}
