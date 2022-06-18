using System;
using Cleverbit.CodingTask.Domain.Entities;
using Cleverbit.CodingTask.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data
{
    public static class CodingTaskContextExtensions
    {
        public static async Task Initialize(this CodingTaskContext context, IHashService hashService)
        {
            await context.Database.MigrateAsync();

            var currentUsers = await context.Users.ToListAsync();

            bool anyNewUser = false;
            bool anyMatchType = false;

            if (!currentUsers.Any(u => u.UserName == "User1"))
            {
                context.Users.Add(new User
                {
                    UserName = "User1",
                    Password = await hashService.HashText("Password1")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User2"))
            {
                context.Users.Add(new User
                {
                    UserName = "User2",
                    Password = await hashService.HashText("Password2")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User3"))
            {
                context.Users.Add(new User
                {
                    UserName = "User3",
                    Password = await hashService.HashText("Password3")
                });

                anyNewUser = true;
            }

            if (!currentUsers.Any(u => u.UserName == "User4"))
            {
                context.Users.Add(new User
                {
                    UserName = "User4",
                    Password = await hashService.HashText("Password4")
                });

                anyNewUser = true;
            }

            var currentMatchTypes = await context.MatchTypes.ToListAsync();

            if (currentMatchTypes.Count == 0)
            {
                context.MatchTypes.Add(new MatchType
                {
                    Name = "Funny Game",
                    Duration = TimeSpan.FromMinutes(3)
                });

                anyMatchType = true;
            }

            if (anyNewUser || anyMatchType)
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
