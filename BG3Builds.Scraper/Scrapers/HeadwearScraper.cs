using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Extensions;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class HeadwearScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var headwearNodes = new Dictionary<HtmlNode, ArmourProficiency>
        {
            {
                web.DocumentNode.QuerySelector("h3 span#Non-Armour").ParentNode.NextSibling.NextSibling.NextSibling.NextSibling,
                ArmourProficiency.None
            },
            {
                web.DocumentNode.QuerySelector("h3 span#Light") .ParentNode .NextSibling .NextSibling.NextSibling.NextSibling,
                ArmourProficiency.Light
            },
            {
                web.DocumentNode.QuerySelector("h3 span#Medium") .ParentNode .NextSibling .NextSibling.NextSibling.NextSibling,
                ArmourProficiency.Medium
            },
            {
                web.DocumentNode.QuerySelector("h3 span#Heavy") .ParentNode .NextSibling .NextSibling.NextSibling.NextSibling,
                ArmourProficiency.Heavy
            }
        };

        var headwearEntities = headwearNodes
            .SelectMany(kv => Scrape(kv.Key.QuerySelectorAll("table.wikitable tr"), kv.Value))
            .Where(headwearEntity => !string.IsNullOrWhiteSpace(headwearEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.Headwears.AddRange(headwearEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        HeadwearName = 1,
    }

    private static IEnumerable<HeadwearEntity> Scrape(IList<HtmlNode> headwearRows, ArmourProficiency armourProficiency)
    {
        foreach (var headwearRow in headwearRows)
        {
            // headwear name, weight, price, special
            var columnNumber = 1;
            var headwearName = string.Empty;
            var headwearWikiUrl = string.Empty;

            foreach (var column in headwearRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.HeadwearName:
                        headwearName = column.QuerySelector("p a span").InnerText.Trim();
                        headwearWikiUrl = column.QuerySelector("p a").GetAttributeValue("href", string.Empty);
                        break;
                }

                columnNumber++;
            }

            yield return new HeadwearEntity
            {
                HeadwearId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(headwearName),
                HeadwearProficiency = armourProficiency,
                WikiUrl = headwearWikiUrl
            };
        }
    }
}
