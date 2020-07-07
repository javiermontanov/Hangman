using HangmanAPI.Data;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace HangmanAPI.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void UseDataSeeders(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
      {
				SeedData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
      }
		}

		public static void SeedData(ApplicationDbContext context)
    {
			context.Database.Migrate();

			if(!context.WordsCategories.Any())
      {
				List<string> categories = new List<string>()
				{
						"Animal",
						"Sport",
						"Technologies",
				};

				foreach (var category in categories)
				{
					context.WordsCategories.Add(new WordsCategories { Text = category });
				}
				context.SaveChanges();
			}

			if (!context.Words.Any())
			{
				var ids = context.WordsCategories.ToDictionary(x => x.Text, y => y.Id);
				string technologiesKey = "Technologies";
				string sportKey = "Sport";
				string animalsKey = "Animal";
				var words = new List<Words>()
				{
						new Words { Text = "blazor", Difficulty = 1, CategoryId = ids[technologiesKey] },
						new Words { Text = "webapis", Difficulty = 2, CategoryId = ids[technologiesKey] },
						new Words { Text = "programming", Difficulty = 3, CategoryId = ids[technologiesKey] },
						new Words { Text = "dog", Difficulty = 1, CategoryId = ids[animalsKey] },
						new Words { Text = "tiger", Difficulty = 2, CategoryId = ids[animalsKey] },
						new Words { Text = "elephant", Difficulty = 3, CategoryId = ids[animalsKey] },
						new Words { Text = "polo", Difficulty = 1, CategoryId = ids[sportKey] },
						new Words { Text = "tennis", Difficulty = 2, CategoryId = ids[sportKey] },
						new Words { Text = "cricket", Difficulty = 3, CategoryId = ids[sportKey] },
						new Words { Text = "badminton", Difficulty = 4, CategoryId = ids[sportKey] }
				};

				foreach (var word in words)
				{
					word.Text = word.Text.ToUpper();
					context.Words.Add(word);
				}
				context.SaveChanges();
			}
    }
	}
}