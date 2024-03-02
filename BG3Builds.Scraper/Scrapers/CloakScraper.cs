using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class CloakScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var cloakNodes = new List<HtmlNode>
        {
            web.DocumentNode.QuerySelector("h3 span#Common").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Uncommon").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Rare").ParentNode.NextSibling.NextSibling,
            web.DocumentNode.QuerySelector("h3 span#Very_Rare").ParentNode.NextSibling.NextSibling,
        };

        var cloakEntities = cloakNodes
            .SelectMany(htmlNode => Scrape(htmlNode.QuerySelectorAll("table.wikitable tr")))
            .Where(cloakEntity => !string.IsNullOrWhiteSpace(cloakEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.Cloaks.AddRange(cloakEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        CloakName = 1,
    }

    private static IEnumerable<CloakEntity> Scrape(IList<HtmlNode> cloakRows)
    {
        foreach (var cloakRow in cloakRows)
        {
            // cloak name, weight, price, effects
            var columnNumber = 1;
            var cloakName = string.Empty;
            var cloakWikiUrl = string.Empty;

            foreach (var column in cloakRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.CloakName:
                        cloakName = column.QuerySelector("p a span").InnerText.Trim();
                        cloakWikiUrl = column.QuerySelector("p a").GetAttributeValue("href", string.Empty);
                        break;
                }

                columnNumber++;
            }

            yield return new CloakEntity
            {
                CloakId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(cloakName),
                WikiUrl = cloakWikiUrl
            };
        }
    }
}
