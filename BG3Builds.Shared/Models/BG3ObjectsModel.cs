using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Interfaces;

namespace BG3Builds.Shared.Models;

public record BG3ObjectsModel
{
    public required AmuletModel[] Amulets { get; init; }
    public required ArmourModel[] Armours { get; init; }
    public required CloakModel[] Cloaks { get; init; }
    public required FeatModel[] Feats { get; set; }
    public required FootwearModel[] Footwears { get; init; }
    public required HandwearModel[] Handwears { get; init; }
    public required HeadwearModel[] Headwears { get; init; }
    public required RingModel[] Rings { get; init; }
    public required WeaponModel[] Weapons { get; init; }
    public required SpellModel[] Spells { get; set; }

    public record HeadwearModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
        public required ArmourProficiency ArmourProficiency { get; init; }
    }

    public record CloakModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record AmuletModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record ArmourModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record FeatModel : IOptionModel
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
        public FeatExtraChoice? ExtraChoice { get; init; }
    }

    public record FootwearModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required ArmourProficiency ArmourProficiency { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record HandwearModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required ArmourProficiency ArmourProficiency { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record RingModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record WeaponModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record SpellModel
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }
}