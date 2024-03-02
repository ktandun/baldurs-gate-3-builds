using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Extensions;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class ArmourScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var armourNodes = new Dictionary<HtmlNode, ArmourProficiency>
        {
            {
                web.DocumentNode.QuerySelector("h2 span#List_of_light_armour").ParentNode.NextSibling.NextSibling,
                ArmourProficiency.Light
            },
            {
                web.DocumentNode.QuerySelector("h2 span#List_of_medium_armour") .ParentNode .NextSibling .NextSibling,
                ArmourProficiency.Medium
            },
            {
                web.DocumentNode.QuerySelector("h2 span#List_of_heavy_armour") .ParentNode .NextSibling .NextSibling,
                ArmourProficiency.Heavy
            }
        };

        var armourEntities = armourNodes
            .SelectMany(kv => Scrape(kv.Key.QuerySelectorAll("table.wikitable tr"), kv.Value))
            .Where(armourEntity => !string.IsNullOrWhiteSpace(armourEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.Armours.AddRange(armourEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        ArmourName = 1,
        ArmourClass = 2,
        ArmourStealthDisadvantage = 3,
    }

    private static IEnumerable<ArmourEntity> Scrape(IList<HtmlNode> armourRows, ArmourProficiency armourProficiency)
    {
        foreach (var armourRow in armourRows)
        {
            // armour name, armour class, stealth disadvantage, weight, price, special
            var columnNumber = 1;
            var armourName = string.Empty;
            var armourWikiUrl = string.Empty;
            var armourClass = 0;
            var armourStealthDisadvantage = true;

            foreach (var column in armourRow.QuerySelectorAll("td"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.ArmourName:
                        armourName = column.QuerySelector("p a span").InnerText.Trim();
                        armourWikiUrl = column.QuerySelector("p a").GetAttributeValue("href", string.Empty);
                        break;

                    case (int)Columns.ArmourClass:
                        armourClass = int.Parse(column.InnerText.Trim());
                        break;

                    case (int)Columns.ArmourStealthDisadvantage:
                        armourStealthDisadvantage = column.InnerText.Trim().ToBool();
                        break;
                }

                columnNumber++;
            }

            yield return new ArmourEntity
            {
                ArmourId = Guid.NewGuid(),
                Name = HttpUtility.HtmlDecode(armourName),
                ArmourClass = armourClass,
                StealthDisadvantage = armourStealthDisadvantage,
                ArmourProficiency = armourProficiency,
                WikiUrl = armourWikiUrl
            };
        }
    }
}
