import { IOptionModel } from "./OptionModel";

export interface ItemBuildModel {
  id: number;
  name: string;
  headwear: IOptionModel | null;
  cloak: IOptionModel | null;
  handwear: IOptionModel | null;
  armour: IOptionModel | null;
  footwear: IOptionModel | null;
  weaponMain: IOptionModel | null;
  weaponOff: IOptionModel | null;
  weaponRange: IOptionModel | null;
  weaponRangeOff: IOptionModel | null;
  amulet: IOptionModel | null;
  ring1: IOptionModel | null;
  ring2: IOptionModel | null;
}
