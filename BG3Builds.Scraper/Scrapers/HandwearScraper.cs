using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Scraper.Utilities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class HandwearScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var handwearNodes = new Dictionary<HtmlNode, ArmourProficiency>
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

        var handwearEntities = handwearNodes
            .SelectMany(kv => Scrape(kv.Key.QuerySelectorAll("table.wikitable tr"), kv.Value))
            .Where(handwearEntity => !string.IsNullOrWhiteSpace(handwearEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.Handwears.AddRange(handwearEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        HandwearName = 1,
    }

    private static IEnumerable<HandwearEntity> Scrape(IList<HtmlNode> handwearRows, ArmourProficiency armourProficiency)
    {
        foreach (var handwearRow in handwearRows)
        {
            // handwear name, weight, price, effects
            var columnNumber = 1;
            var handwearName = string.Empty;
            var handwearWikiUrl = string.Empty;
            var handwearIconUrl = string.Empty;

            foreach (var column in handwearRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.HandwearName:
                        (handwearName, handwearWikiUrl, handwearIconUrl) = ScraperUtility.ScrapeObjectNameFromTablesorter(column);
                        break;
                }

                columnNumber++;
            }

            yield return new HandwearEntity
            {
                HandwearId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(handwearName),
                ArmourProficiency = armourProficiency,
                WikiUrl = handwearWikiUrl,
                IconUrl = handwearIconUrl
            };
        }
    }
}
