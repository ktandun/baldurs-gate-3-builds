using System.Web;
using BG3Builds.Database;
using BG3Builds.Shared.Constants;
using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Interfaces;

namespace BG3Builds.Scraper.Scrapers;

public static class ObjectImageScraper
{
    public static async Task ScrapeAsync(string connectionString)
    {
        await using var database = new DatabaseContext(connectionString);

        await DownloadIconUrlsAsync(database.Amulets, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Armours, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Cloaks, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Footwears, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Handwears, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Headwears, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Rings, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Weapons, ImageDirectory.Equipments);
        await DownloadIconUrlsAsync(database.Spells, ImageDirectory.Spells);
    }

    private static async Task DownloadIconUrlsAsync<TEntity>(IQueryable<TEntity> entities, ImageDirectory imageDirectory)
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
            var imageFolder = ImageDirectoryHelper.GetImageDirectoryName(imageDirectory);
            var folderFullPath = Path.Join(projectDirectory, "BG3Builds.Website", "public", "images", imageFolder);

            Directory.CreateDirectory(folderFullPath);

            var imagePath = Path.Join(folderFullPath, HttpUtility.UrlDecode(Path.GetFileName(uri)));

            if (Path.Exists(imagePath)) continue;

            await using var stream = await client.GetStreamAsync(uri);
            await using var fileStream = new FileStream(imagePath, FileMode.OpenOrCreate);

            await stream.CopyToAsync(fileStream);
        }
    }
}