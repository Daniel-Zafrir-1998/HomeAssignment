using Domain.Abstractions.DatabaseSeeder;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using HtmlAgilityPack;

namespace Infrastructure.Utils.Database
{
    public class IMDBDatabaseSeeder(IActorRepository actorRepository) : IDatabaseSeeder
    {
        public async Task Seed()
        {
            var htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load("https://www.imdb.com/list/ls054840033/");

            var listItemHeader = htmlDoc.DocumentNode.SelectNodes("//h3[@class='lister-item-header']");

            if (listItemHeader != null)
            {
                var Actors = new List<Actor>();

                foreach (var item in listItemHeader)
                {
                    var name = item.SelectSingleNode(".//a").InnerText;
                    var number = item.SelectSingleNode(".//span[@class='lister-item-index unbold text-primary']").InnerText;

                    Actors.Add(new(name.Trim(), null, null, int.Parse(number.Replace(".", "").Trim()), "IMDBD"));
                }

                await actorRepository.AddRangeAsync(Actors);
            }
        }
    }
}
