import { ClassChoice } from "@/enums/ClassChoice";
import { Subclass } from "@/enums/Subclass";
import { IOptionModel } from "./OptionModel";

export interface ILevelBuildModel {
  id: number;
  class: null | ClassChoice;
  subclass: null | Subclass;
  charLevel: number;
  skills: IOptionModel[];
  feat: null | IOptionModel;
  respec: boolean;
}
