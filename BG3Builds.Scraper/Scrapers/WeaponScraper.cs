using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Scraper.Utilities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static class WeaponScraper
{
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var weaponNodes = web.DocumentNode.QuerySelectorAll("table.wikitable tr");

        var weaponEntities = weaponNodes
            .Select(weaponNode => Scrape(weaponNode.QuerySelectorAll("td")))
            .Where(weaponEntity => !string.IsNullOrWhiteSpace(weaponEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.AddRange(weaponEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        WeaponName = 1,
        WeaponDamage = 3,
        WeaponDamageType = 4,
        WeaponExtraDamage = 5,
        WeaponExtraDamageType = 6
    }

    private static WeaponEntity Scrape(IList<HtmlNode> weaponAttributes)
    {
        // weapon name, enchantment, damage, damage type, extra damage, extra damage type, weight, price, special
        var columnNumber = 1;
        var weaponName = string.Empty;
        var weaponWikiUrl = string.Empty;
        var weaponIconUrl = string.Empty;
        var weaponDamage = string.Empty;
        var weaponDamageType = DamageType.Acid;
        var weaponExtraDamage = string.Empty;
        var weaponExtraDamageType = DamageType.Acid;

        foreach (var column in weaponAttributes)
        {
            switch (columnNumber)
            {
                case (int)Columns.WeaponName:
                    (weaponName, weaponWikiUrl, weaponIconUrl) = ScraperUtility.ScrapeObjectNameFromTablesorter(column);
                    break;

                case (int)Columns.WeaponDamage:
                    weaponDamage = column.InnerText.Trim();
                    break;

                case (int)Columns.WeaponDamageType:
                    weaponDamageType = column.InnerText.Trim().ToDamageType();
                    break;

                case (int)Columns.WeaponExtraDamage:
                    weaponExtraDamage = column.InnerText.Trim();
                    break;

                case (int)Columns.WeaponExtraDamageType:
                    weaponExtraDamageType = column.InnerText.Trim().ToDamageType();
                    break;
            }

            columnNumber++;
        }

        return new WeaponEntity
        {
            WeaponId = Guid.NewGuid(),
            Name = HttpUtility.HtmlDecode(weaponName),
            WikiUrl = weaponWikiUrl,
            IconUrl = weaponIconUrl,
            ImageId = default,
            Damage = weaponDamage,
            DamageType = weaponDamageType,
            ExtraDamage = weaponExtraDamage,
            ExtraDamageType = weaponExtraDamageType
        };
    }
}