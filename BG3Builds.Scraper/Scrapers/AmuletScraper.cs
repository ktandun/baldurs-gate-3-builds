using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class AmuletScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var amuletNodes = new List<HtmlNode>
        {
            web.DocumentNode.QuerySelector("h3 span#Common").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Uncommon").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Rare").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Very_Rare").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Story_Item").ParentNode.NextSibling.NextSibling,
        };

        var amuletEntities = amuletNodes
            .SelectMany(node => Scrape(node.QuerySelectorAll("table.wikitable tr")))
            .Where(amuletEntity => !string.IsNullOrWhiteSpace(amuletEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.Amulets.AddRange(amuletEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        AmuletName = 1,
    }

    private static IEnumerable<AmuletEntity> Scrape(IList<HtmlNode> amuletRows)
    {
        foreach (var amuletRow in amuletRows)
        {
            // amulet name, weight, price, effects
            var columnNumber = 1;
            var amuletName = string.Empty;
            var amuletWikiUrl = string.Empty;

            foreach (var column in amuletRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.AmuletName:
                        amuletName = column.QuerySelector("p a span").InnerText.Trim();
                        amuletWikiUrl = column.QuerySelector("p a").GetAttributeValue("href", string.Empty);
                        break;
                }

                columnNumber++;
            }

            yield return new AmuletEntity
            {
                AmuletId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(amuletName),
                WikiUrl = amuletWikiUrl
            };
        }
    }
}
