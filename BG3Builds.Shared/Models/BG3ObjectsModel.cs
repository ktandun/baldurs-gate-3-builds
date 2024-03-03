using BG3Builds.Shared.Enums;

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

    public record HeadwearModel
    {
        public required Guid HeadwearId { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
        public required ArmourProficiency ArmourProficiency { get; init; }
    }

    public record CloakModel
    {
        public required Guid CloakId { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record AmuletModel
    {
        public required Guid AmuletId { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record ArmourModel
    {
        public required Guid ArmourId { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record FeatModel
    {
        public required Guid FeatId { get; init; }
        public required string Name { get; init; }
        public FeatExtraChoice? ExtraChoice { get; init; }
    }

    public record FootwearModel
    {
        public required Guid FootwearId { get; init; }
        public required string Name { get; init; }
        public required ArmourProficiency ArmourProficiency { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record HandwearModel
    {
        public required Guid HandwearId { get; init; }
        public required string Name { get; init; }
        public required ArmourProficiency ArmourProficiency { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record RingModel
    {
        public required Guid RingId { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }

    public record WeaponModel
    {
        public required Guid WeaponId { get; init; }
        public required string Name { get; init; }
        public required string ImageUrl { get; init; }
    }
}