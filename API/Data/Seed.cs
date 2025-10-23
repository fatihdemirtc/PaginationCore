using System;
using System.Text.Json;
using API.Entity;

namespace API.Data;

public class Seed
{
    public static async Task SeedMembers(AppDbContext context)
    {
        var memberData = await File.ReadAllTextAsync("Data/MemberSeedData.json");
        var members = JsonSerializer.Deserialize<List<Member>>(memberData);

        if (members == null)
        {
            Console.WriteLine("No members in seed data");
            return;
        }

        foreach (var member in members)
        {
            context.Members.Add(new Member
            {
                Id = member.Id,
                DisplayName = member.DisplayName,
                Description = member.Description,
                DateOfBirth = member.DateOfBirth,
                ImageUrl = member.ImageUrl,
                Gender = member.Gender,
                City = member.City,
                Country = member.Country,
                LastActive = member.LastActive,
                Created = member.Created
            });
        }

        await context.SaveChangesAsync();
    }
}
