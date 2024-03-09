using System.Text.Json;
using BG3Builds.Database;
using BG3Builds.Shared.Enums;
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
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Equipments)
                })
                .ToArray(),
            Armours = database.Armours
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.ArmourModel
                {
                    Id = e.ArmourId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Equipments)
                })
                .ToArray(),
            Cloaks = database.Cloaks
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.CloakModel
                {
                    Id = e.CloakId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Equipments)
                })
                .ToArray(),
            Feats = database.Feats
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.FeatModel
                {
                    Id = e.FeatId,
                    Name = e.Name,
                    ImageUrl = string.Empty,
                    ExtraChoice = e.ExtraChoice
                })
                .ToArray()
                .Prepend(
                    new BG3ObjectsModel.FeatModel
                    {
                        Id = 42,
                        Name = "None",
                        ImageUrl = string.Empty
                    })
                .ToArray(),
            Footwears = database.Footwears
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.FootwearModel
                {
                    Id = e.FootwearId,
                    Name = e.Name,
                    ArmourProficiency = e.ArmourProficiency,
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Equipments)
                })
                .ToArray(),
            Headwears = database.Headwears
                .OrderBy(e => e.Name)
                .Select(h => new BG3ObjectsModel.HeadwearModel
                {
                    Id = h.HeadwearId,
                    Name = h.Name,
                    ImageUrl = GetImageFilename(h.IconUrl, ImageDirectory.Equipments),
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
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Equipments)
                })
                .ToArray(),
            Rings = database.Rings
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.RingModel
                {
                    Id = e.RingId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Equipments)
                })
                .ToArray(),
            Weapons = database.Weapons
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.WeaponModel
                {
                    Id = e.WeaponId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Equipments)
                })
                .ToArray(),
            Spells = database.Spells
                .OrderBy(e => e.Name)
                .Select(e => new BG3ObjectsModel.SpellModel
                {
                    Id = e.SpellId,
                    Name = e.Name,
                    ImageUrl = GetImageFilename(e.IconUrl, ImageDirectory.Spells)
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

    private static string GetImageFilename(string imagePath, ImageDirectory imageDirectory)
    {
        var imageFolder = ImageDirectoryHelper.GetImageDirectoryName(imageDirectory);

        return $"/images/{imageFolder}/{Path.GetFileName(imagePath)}";
    }
}