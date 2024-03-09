using System.Text.RegularExpressions;
using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static partial class SpellScraper
{
    private static readonly Regex Whitespace = WhitespaceRegex();

    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var cantripNodes = new List<HtmlNode>
        {
            web.DocumentNode.QuerySelector("h4 span#Cantrips").ParentNode.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling
        };

        var cantripEntities = cantripNodes
            .SelectMany(node => Scrape(node.QuerySelectorAll("li"), SpellType.Cantrip))
            .Where(spellEntity => !string.IsNullOrWhiteSpace(spellEntity.Name))
            .OrderBy(spellEntity => spellEntity.Name)
            .ToList();

        var spellNodes = new List<HtmlNode>
        {
            web.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[4]"),
            web.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[5]"),
            web.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[6]"),
            web.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[7]"),
            web.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[8]"),
            web.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[9]"),
            web.DocumentNode.SelectSingleNode("/html/body/div[3]/div[3]/div[5]/div[1]/div[10]"),
        };

        var spellEntities = spellNodes
            .SelectMany(node => Scrape(node.QuerySelectorAll("li"), SpellType.Spell))
            .Where(spellEntity => !string.IsNullOrWhiteSpace(spellEntity.Name))
            .OrderBy(spellEntity => spellEntity.Name)
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.AddRange(cantripEntities);
        database.AddRange(spellEntities);

        database.SaveChanges();
    }

    private static IEnumerable<SpellEntity> Scrape(IList<HtmlNode> spellRows, SpellType spellType)
    {
        foreach (var spellRow in spellRows)
        {
            var spell = spellRow.QuerySelector("span a");

            var spellName = HttpUtility.HtmlDecode(
                Whitespace.Replace(
                    spell.Attributes.First(a => a.Name == "title").Value ?? string.Empty, "").Trim());

            var spellWikiUrl = HttpUtility.HtmlDecode(
                spell.Attributes.First(a => a.Name == "href").Value);

            var spellIconUrl = HttpUtility.HtmlDecode(
                spell.QuerySelector("img").Attributes.First(a => a.Name == "src").Value);

            yield return new SpellEntity
            {
                Name = spellName,
                SpellType = spellType,
                WikiUrl = spellWikiUrl,
                IconUrl = spellIconUrl,
            };
        }
    }

    [GeneratedRegex(@"<[^>]*(>|$)|&nbsp;|&zwnj;|&raquo;|&laquo;|&gt;")]
    private static partial Regex WhitespaceRegex();
}
