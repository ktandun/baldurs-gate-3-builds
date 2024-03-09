using System.Text.RegularExpressions;
using System.Web;
using BG3Builds.Database;
using BG3Builds.Database.Entities;
using BG3Builds.Shared.Enums;
using HtmlAgilityPack;

namespace BG3Builds.Scraper.Scrapers;

public static partial class FeatScraper
{
    private static readonly Regex Whitespace = WhitespaceRegex();
    public static void Scrape(string connectionString, string htmlFile)
    {
        var web = new HtmlDocument();
        web.Load(htmlFile);

        var featNodes = new List<HtmlNode>
        {
            web.DocumentNode.QuerySelector("h2 span#List_of_all_feats").ParentNode.NextSibling.NextSibling
        };

        var featEntities = featNodes
            .SelectMany(node => Scrape(node.QuerySelectorAll("table.wikitable tr")))
            .Where(featEntity => !string.IsNullOrWhiteSpace(featEntity.Name))
            .ToList();

        using var database = new DatabaseContext(connectionString);

        database.AddRange(featEntities);

        database.SaveChanges();
    }

    private enum Columns
    {
        FeatName = 1,
    }

    private static IEnumerable<FeatEntity> Scrape(IList<HtmlNode> featRows)
    {
        foreach (var featRow in featRows)
        {
            // feat name, armour class, stealth disadvantage, weight, price, special
            var columnNumber = 1;
            var featName = string.Empty;
            var featWikiUrl = string.Empty;
            var featIconUrl = string.Empty;

            foreach (var column in featRow.QuerySelectorAll("th[scope='rowgroup']"))
            {
                switch (columnNumber)
                {
                    case (int)Columns.FeatName:
                        featName = Whitespace.Replace(column.InnerText, "").Trim();
                        break;
                }

                columnNumber++;
            }

            featName = HttpUtility.HtmlDecode(featName);

            yield return new FeatEntity
            {
                Name = featName,
                WikiUrl = featWikiUrl,
                IconUrl = featIconUrl,
                ExtraChoice = featName switch
                {
                    "Ability Improvement" => FeatExtraChoice.TwoAbilityScores,
                    "Athlete" => FeatExtraChoice.StrengthOrDexterity,
                    "Elemental Adept" => FeatExtraChoice.ElementalAdept,
                    "Lightly Armoured" => FeatExtraChoice.StrengthOrDexterity,
                    "Magic Initiate: Bard" => FeatExtraChoice.TwoCantripsAndBardSpell,
                    "Magic Initiate: Cleric" => FeatExtraChoice.TwoCantripsAndClericSpell,
                    "Magic Initiate: Druid" => FeatExtraChoice.TwoCantripsAndDruidSpell,
                    "Magic Initiate: Sorcerer" => FeatExtraChoice.TwoCantripsAndSorcererSpell,
                    "Magic Initiate: Warlock" => FeatExtraChoice.TwoCantripsAndWarlockSpell,
                    "Magic Initiate: Wizard" => FeatExtraChoice.TwoCantripsAndWizardSpell,
                    "Martial Adept" => FeatExtraChoice.TwoBattleMasterManoeuvres,
                    "Moderately Armoured" => FeatExtraChoice.StrengthOrDexterity,
                    "Resilient" => FeatExtraChoice.OneAbilityScore,
                    "Ritual Caster" => FeatExtraChoice.TwoRitualSpells,
                    "Spell Sniper" => FeatExtraChoice.AttackRollCantrip,
                    "Tavern Brawler" => FeatExtraChoice.StrengthOrConstitution,
                    "Weapon Master" => FeatExtraChoice.StrengthOrDexterity,
                    _ => FeatExtraChoice.None,
                }
            };
        }
    }

    [GeneratedRegex(@"<[^>]*(>|$)|&nbsp;|&zwnj;|&raquo;|&laquo;|&gt;")]
    private static partial Regex WhitespaceRegex();
}
