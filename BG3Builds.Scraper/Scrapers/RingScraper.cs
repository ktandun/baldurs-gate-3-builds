using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Scraper.Utilities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class RingScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var ringNodes = new List<HtmlNode>
        {
            web.DocumentNode.QuerySelector("h3 span#Common").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Uncommon").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Rare").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Very_Rare").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Story_Item").ParentNode.NextSibling.NextSibling,
        };

        var ringEntities = ringNodes
            .SelectMany(node => Scrape(node.QuerySelectorAll("table.wikitable tr")))
            .Where(ringEntity => !string.IsNullOrWhiteSpace(ringEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.Rings.AddRange(ringEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        RingName = 1,
    }

    private static IEnumerable<RingEntity> Scrape(IList<HtmlNode> ringRows)
    {
        foreach (var ringRow in ringRows)
        {
            // ring name, weight, price, effects
            var columnNumber = 1;
            var ringName = string.Empty;
            var ringWikiUrl = string.Empty;
            var ringIconUrl = string.Empty;

            foreach (var column in ringRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.RingName:
                        (ringName, ringWikiUrl, ringIconUrl) = ScraperUtility.ScrapeObjectNameFromTablesorter(column);
                        break;
                }

                columnNumber++;
            }

            yield return new RingEntity
            {
                RingId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(ringName),
                WikiUrl = ringWikiUrl,
                IconUrl = ringIconUrl
            };
        }
    }
}
