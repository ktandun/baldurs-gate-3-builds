using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Scraper.Utilities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class ClothingScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var clothingNodes = new Dictionary<HtmlNode, ArmourProficiency>
        {
            {
                web.DocumentNode.QuerySelector("h2 span#List_of_Clothing").ParentNode.NextSibling.NextSibling,
                ArmourProficiency.None
            },
        };

        var clothingEntities = clothingNodes
            .SelectMany(kv => Scrape(kv.Key.QuerySelectorAll("table.wikitable tr"), kv.Value))
            .Where(clothingEntity => !string.IsNullOrWhiteSpace(clothingEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.AddRange(clothingEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        ClothingName = 1,
    }

    private static IEnumerable<ArmourEntity> Scrape(IList<HtmlNode> clothingRows, ArmourProficiency armourProficiency)
    {
        foreach (var clothingRow in clothingRows)
        {
            // clothing name, armour class, stealth disadvantage, weight, price, special
            var columnNumber = 1;
            var clothingName = string.Empty;
            var clothingWikiUrl = string.Empty;
            var clothingIconUrl = string.Empty;
            var clothingClass = 0;

            foreach (var column in clothingRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.ClothingName:
                        (clothingName, clothingWikiUrl, clothingIconUrl) = ScraperUtility.ScrapeObjectNameFromTablesorter(column);
                        break;
                }

                columnNumber++;
            }

            yield return new ArmourEntity
            {
                ArmourId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(clothingName),
                ArmourClass = 10,
                StealthDisadvantage = false,
                ArmourProficiency = armourProficiency,
                WikiUrl = clothingWikiUrl,
                IconUrl = clothingIconUrl
            };
        }
    }
}
