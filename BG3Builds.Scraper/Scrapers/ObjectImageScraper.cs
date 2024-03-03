using System.Web;
using BG3Builds.Database;
using BG3Builds.Shared.Constants;
using BG3Builds.Shared.Interfaces;

namespace BG3Builds.Scraper.Scrapers;

public static class ObjectImageScraper
{
    public static async Task ScrapeAsync(string connectionString)
    {
        await using var database = new DatabaseContext(connectionString);

        await DownloadIconUrlsAsync(database.Amulets);
        await DownloadIconUrlsAsync(database.Armours);
        await DownloadIconUrlsAsync(database.Cloaks);
        await DownloadIconUrlsAsync(database.Footwears);
        await DownloadIconUrlsAsync(database.Handwears);
        await DownloadIconUrlsAsync(database.Headwears);
        await DownloadIconUrlsAsync(database.Rings);
        await DownloadIconUrlsAsync(database.Weapons);
    }

    private static async Task DownloadIconUrlsAsync<TEntity>(IQueryable<TEntity> entities)
        where TEntity : IHasIconUrl
    {
        var iconUrls = entities
            .Select(e => e.IconUrl)
            .ToArray();

        var projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!
            .Parent!
            .Parent!
            .Parent!
            .FullName;

        using var client = new HttpClient();

        foreach (var iconUrl in iconUrls)
        {
            var uri = Bg3WikiConstants.WikiBaseUrl + iconUrl;
            var imagePath = Path.Join(projectDirectory, "BG3Builds.Website", "public", "images", "equipments", HttpUtility.UrlDecode(Path.GetFileName(uri)));

            if (Path.Exists(imagePath)) continue;

            await using var stream = await client.GetStreamAsync(uri);
            await using var fileStream = new FileStream(imagePath, FileMode.OpenOrCreate);

            await stream.CopyToAsync(fileStream);
        }
    }
}