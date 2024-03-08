export enum ClassChoice {
  Barbarian = 1,
  Bard = 2,
  Cleric = 3,
  Druid = 4,
  Fighter = 5,
  Monk = 6,
  Paladin = 7,
  Ranger = 8,
  Rogue = 9,
  Sorcerer = 10,
  Warlock = 11,
  Wizard = 12,
}

export const getClassName = (c: ClassChoice): string => {
  switch (c) {
    case ClassChoice.Barbarian:
      return "Barbarian";
    case ClassChoice.Bard:
      return "Bard";
    case ClassChoice.Cleric:
      return "Cleric";
    case ClassChoice.Druid:
      return "Druid";
    case ClassChoice.Fighter:
      return "Fighter";
    case ClassChoice.Monk:
      return "Monk";
    case ClassChoice.Paladin:
      return "Paladin";
    case ClassChoice.Ranger:
      return "Ranger";
    case ClassChoice.Rogue:
      return "Rogue";
    case ClassChoice.Sorcerer:
      return "Sorcerer";
    case ClassChoice.Warlock:
      return "Warlock";
    case ClassChoice.Wizard:
      return "Wizard";
  }
};

export const getClassImageUrl = (c: ClassChoice): string => {
  switch (c) {
    case ClassChoice.Barbarian:
      return "/images/classes/barbarian.png";
    case ClassChoice.Bard:
      return "/images/classes/bard.png";
    case ClassChoice.Cleric:
      return "/images/classes/cleric.png";
    case ClassChoice.Druid:
      return "/images/classes/druid.png";
    case ClassChoice.Fighter:
      return "/images/classes/fighter.png";
    case ClassChoice.Monk:
      return "/images/classes/monk.png";
    case ClassChoice.Paladin:
      return "/images/classes/paladin.png";
    case ClassChoice.Ranger:
      return "/images/classes/ranger.png";
    case ClassChoice.Rogue:
      return "/images/classes/rogue.png";
    case ClassChoice.Sorcerer:
      return "/images/classes/sorcerer.png";
    case ClassChoice.Warlock:
      return "/images/classes/warlock.png";
    case ClassChoice.Wizard:
      return "/images/classes/wizard.png";
  }
};
