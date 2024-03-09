export enum AbilityPoint {
  Strength = 1,
  Dexterity = 2,
  Constitution = 3,
  Intelligence = 4,
  Wisdom = 5,
  Charisma = 6,
}

export const abilityPointToString = (ap: AbilityPoint): string => {
  switch (ap) {
    case AbilityPoint.Strength:
      return "Strength";

    case AbilityPoint.Dexterity:
      return "Dexterity";

    case AbilityPoint.Constitution:
      return "Constitution";

    case AbilityPoint.Intelligence:
      return "Intelligence";

    case AbilityPoint.Wisdom:
      return "Wisdom";

    case AbilityPoint.Charisma:
      return "Charisma";
  }
};
