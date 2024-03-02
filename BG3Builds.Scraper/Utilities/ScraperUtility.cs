using HtmlAgilityPack;

namespace BG3Builds.Scraper.Utilities;

public static class ScraperUtility
{
    private const string Space = " ";

    public static (string name, string wikiUrl, string iconUrl) ScrapeObjectNameFromTablesorter(HtmlNode? node)
    {
        if (node is null)
        {
            return (string.Empty, string.Empty, string.Empty);
        }


        var name = node.QuerySelector("p a span").InnerText.Trim();
        var wikiUrl = node.QuerySelector("p a").GetAttributeValue("href", string.Empty);
        var iconUrl = node.QuerySelector("p a img").GetAttributeValue("srcset", string.Empty);

        if (iconUrl.Contains(Space))
        {
            iconUrl = iconUrl.Split(Space).First();
        }

        return (name, wikiUrl, iconUrl);
    }
}