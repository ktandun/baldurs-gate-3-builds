using System.Text.Json;
using BG3Builds.Database;
using BG3Builds.Shared.Models;

namespace BG3Builds.Scraper.Generators;

public static class JsonGenerator
{
    public static void GenerateJson(string connectionString)
    {
        using var database = new DatabaseContext(connectionString);

        var model = new BG3ObjectsModel
        {
            Amulets = database.Amulets
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.AmuletModel
                {
                    Id = e.AmuletId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl)
                })
                .ToArray(),
            Armours = database.Armours
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.ArmourModel
                {
                    Id = e.ArmourId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl)
                })
                .ToArray(),
            Cloaks = database.Cloaks
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.CloakModel
                {
                    Id = e.CloakId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl)
                })
                .ToArray(),
            Feats = database.Feats
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.FeatModel
                {
                    Id = e.FeatId,
                    Name = e.Name,
                    ExtraChoice = e.ExtraChoice
                })
                .ToArray(),
            Footwears = database.Footwears
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.FootwearModel
                {
                    Id = e.FootwearId,
                    Name = e.Name,
                    ArmourProficiency = e.ArmourProficiency,
                    ImageUrl = GetImageFilename(e.IconUrl)
                })
                .ToArray(),
            Headwears = database.Headwears
                .OrderBy(e => e.Name)
                .Select(h => new BG3ObjectsModel.HeadwearModel
                {
                    Id = h.HeadwearId,
                    Name = h.Name,
                    ImageUrl = GetImageFilename(h.IconUrl),
                    ArmourProficiency = h.ArmourProficiency,
                })
                .ToArray(),
            Handwears = database.Handwears
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.HandwearModel
                {
                    Id = e.HandwearId,
                    Name = e.Name,
                    ArmourProficiency = e.ArmourProficiency,
                    ImageUrl = GetImageFilename(e.IconUrl)
                })
                .ToArray(),
            Rings = database.Rings
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.RingModel
                {
                    Id = e.RingId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl)
                })
                .ToArray(),
            Weapons = database.Weapons
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.WeaponModel
                {
                    Id = e.WeaponId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl)
                })
                .ToArray(),
        };

        var json = JsonSerializer.Serialize(model, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });

        var solutionDirectory = Directory.GetParent(Environment.CurrentDirectory)!
            .Parent!
            .Parent!
            .Parent!
            .FullName;

        File.WriteAllText(Path.Join(solutionDirectory, "BG3Builds.Website", "src", "assets", "bg3objects.json"), json);
    }

    private static string GetImageFilename(string imagePath)
    {
        return $"/images/equipments/{Path.GetFileName(imagePath)}";
    }
}