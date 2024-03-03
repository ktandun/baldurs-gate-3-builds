export enum Subclass {
  // barbarian
  Berserker = 1,
  WildMagic = 2,
  Wildheart = 3,
  // bard
  CollegeOfLore = 4,
  CollegeOfSwords = 5,
  CollegeOfValour = 6,
  // cleric
  KnowledgeDomain = 7,
  LifeDomain = 8,
  LightDomain = 9,
  NatureDomain = 10,
  TempestDomain = 11,
  TrickeryDomain = 12,
  WarDomain = 13,
  // druid
  CircleOfTheLand = 14,
  CircleOfTheMoon = 15,
  CircleOfTheSpores = 16,
  // fighter
  BattleMaster = 17,
  Champion = 18,
  EldritchKnight = 19,
  // monk
  WayOfTheOpenHand = 20,
  WayOfShadow = 21,
  WayOfTheFourElements = 22,
  // paladin
  OathOfTheAncients = 23,
  OathOfDevotion = 24,
  OathOfVengeance = 25,
  OathBreaker = 26,
  // ranger
  Hunter = 27,
  BeastMaster = 28,
  GloomStalker = 29,
  // rogue
  ArcaneTrickster = 30,
  Thief = 31,
  Assassin = 32,
  // sorcerer
  DraconicBloodline = 33,
  WildMagicSorcerer = 34,
  StormSorcery = 35,
  // warlock
  TheArchfey = 36,
  TheFiend = 37,
  TheGreatOldOne = 38,
  // wizard
  AbjurationSchool = 39,
  ConjurationSchool = 40,
  DivinationSchool = 41,
  EnchantmentSchool = 42,
  EvocationSchool = 43,
  IllusionSchool = 44,
  NecromancySchool = 45,
  TransmutationSchool = 46,
}

export const subclassToString = function (subclass: Subclass): string {
  switch (subclass) {
    case Subclass.Berserker:
      return "Berserker";
    case Subclass.WildMagic:
      return "Wild Magic";
    case Subclass.Wildheart:
      return "Wildheart";
    case Subclass.CollegeOfLore:
      return "College of Lore";
    case Subclass.CollegeOfSwords:
      return "College of Swords";
    case Subclass.CollegeOfValour:
      return "College of Valour";
    case Subclass.KnowledgeDomain:
      return "Knowledge Domain";
    case Subclass.LifeDomain:
      return "Life Domain";
    case Subclass.LightDomain:
      return "Light Domain";
    case Subclass.NatureDomain:
      return "Nature Domain";
    case Subclass.TempestDomain:
      return "Tempest Domain";
    case Subclass.TrickeryDomain:
      return "Trickery Domain";
    case Subclass.WarDomain:
      return "War Domain";
    case Subclass.CircleOfTheLand:
      return "Circle of the Land";
    case Subclass.CircleOfTheMoon:
      return "Circle of the Moon";
    case Subclass.CircleOfTheSpores:
      return "Circle of the Spores";
    case Subclass.BattleMaster:
      return "Battle Master";
    case Subclass.Champion:
      return "Champion";
    case Subclass.EldritchKnight:
      return "Eldritch Knight";
    case Subclass.WayOfTheOpenHand:
      return "Way of the OpenHand";
    case Subclass.WayOfShadow:
      return "WayOfShadow";
    case Subclass.WayOfTheFourElements:
      return "Way of the Four Elements";
    case Subclass.OathOfTheAncients:
      return "Oath of the Ancients";
    case Subclass.OathOfDevotion:
      return "Oath of Devotion";
    case Subclass.OathOfVengeance:
      return "Oath of Vengeance";
    case Subclass.OathBreaker:
      return "Oath Breaker";
    case Subclass.Hunter:
      return "Hunter";
    case Subclass.BeastMaster:
      return "Beast Master";
    case Subclass.GloomStalker:
      return "Gloom Stalker";
    case Subclass.ArcaneTrickster:
      return "Arcane Trickster";
    case Subclass.Thief:
      return "Thief";
    case Subclass.Assassin:
      return "Assassin";
    case Subclass.DraconicBloodline:
      return "Draconic Bloodline";
    case Subclass.WildMagicSorcerer:
      return "Wild Magic";
    case Subclass.StormSorcery:
      return "Storm Sorcery";
    case Subclass.TheArchfey:
      return "The Archfey";
    case Subclass.TheFiend:
      return "The Fiend";
    case Subclass.TheGreatOldOne:
      return "The Great Old One";
    case Subclass.AbjurationSchool:
      return "Abjuration School";
    case Subclass.ConjurationSchool:
      return "Conjuration School";
    case Subclass.DivinationSchool:
      return "Divination School";
    case Subclass.EnchantmentSchool:
      return "Enchantment School";
    case Subclass.EvocationSchool:
      return "Evocation School";
    case Subclass.IllusionSchool:
      return "Illusion School";
    case Subclass.NecromancySchool:
      return "Necromancy School";
    case Subclass.TransmutationSchool:
      return "Transmutation School";
  }
};
