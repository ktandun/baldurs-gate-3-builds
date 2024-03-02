using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class FootwearScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var footwearNodes = new Dictionary<HtmlNode, ArmourProficiency>
        {
            {
                web.DocumentNode.QuerySelector("h3 span#Non-Armour").ParentNode.NextSibling.NextSibling.NextSibling.NextSibling,
                ArmourProficiency.None
            },
            {
                web.DocumentNode.QuerySelector("h3 span#Medium") .ParentNode .NextSibling .NextSibling.NextSibling.NextSibling,
                ArmourProficiency.Medium
            },
        };

        var footwearEntities = footwearNodes
            .SelectMany(kv => Scrape(kv.Key.QuerySelectorAll("table.wikitable tr"), kv.Value))
            .Where(footwearEntity => !string.IsNullOrWhiteSpace(footwearEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.Footwears.AddRange(footwearEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        FootwearName = 1,
    }

    private static IEnumerable<FootwearEntity> Scrape(IList<HtmlNode> footwearRows, ArmourProficiency armourProficiency)
    {
        foreach (var footwearRow in footwearRows)
        {
            // footwear name, weight, price, effects
            var columnNumber = 1;
            var footwearName = string.Empty;
            var footwearWikiUrl = string.Empty;

            foreach (var column in footwearRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.FootwearName:
                        footwearName = column.QuerySelector("p a span").InnerText.Trim();
                        footwearWikiUrl = column.QuerySelector("p a").GetAttributeValue("href", string.Empty);
                        break;
                }

                columnNumber++;
            }

            yield return new FootwearEntity
            {
                FootwearId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(footwearName),
                ArmourProficiency = armourProficiency,
                WikiUrl = footwearWikiUrl
            };
        }
    }
}
