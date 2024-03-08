import { OptionModel } from "./OptionModel";

export interface ItemBuildModel {
  id: number;
  name: string;
  headwear: OptionModel | null;
  cloak: OptionModel | null;
  handwear: OptionModel | null;
  armour: OptionModel | null;
  footwear: OptionModel | null;
  weaponMain: OptionModel | null;
  weaponOff: OptionModel | null;
  weaponRange: OptionModel | null;
  weaponRangeOff: OptionModel | null;
  amulet: OptionModel | null;
  ring1: OptionModel | null;
  ring2: OptionModel | null;
}
