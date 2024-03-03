<script setup lang="ts">
import { ClassChoice } from "@/enums/ClassChoice";
import { Subclass, subclassToString } from "@/enums/Subclass";
import { PropType, ref, watchEffect } from "vue";

const model = defineModel();

const props = defineProps({
  classChoice: Number as PropType<ClassChoice>,
});

let subclassOptions = ref<Subclass[]>([]);

watchEffect(() => {
  if (!props.classChoice) {
    subclassOptions.value = [];
  }

  switch (props.classChoice) {
    case ClassChoice.Barbarian:
      subclassOptions.value = [
        Subclass.Berserker,
        Subclass.WildMagic,
        Subclass.Wildheart,
      ];
      break;

    case ClassChoice.Bard:
      subclassOptions.value = [
        Subclass.CollegeOfLore,
        Subclass.CollegeOfSwords,
        Subclass.CollegeOfValour,
      ];
      break;

    case ClassChoice.Cleric:
      subclassOptions.value = [
        Subclass.KnowledgeDomain,
        Subclass.LifeDomain,
        Subclass.LightDomain,
        Subclass.NatureDomain,
        Subclass.TempestDomain,
        Subclass.TrickeryDomain,
        Subclass.WarDomain,
      ];
      break;

    case ClassChoice.Druid:
      subclassOptions.value = [
        Subclass.CircleOfTheLand,
        Subclass.CircleOfTheMoon,
        Subclass.CircleOfTheSpores,
      ];
      break;

    case ClassChoice.Fighter:
      subclassOptions.value = [
        Subclass.BattleMaster,
        Subclass.Champion,
        Subclass.EldritchKnight,
      ];
      break;

    case ClassChoice.Monk:
      subclassOptions.value = [
        Subclass.WayOfTheOpenHand,
        Subclass.WayOfShadow,
        Subclass.WayOfTheFourElements,
      ];
      break;

    case ClassChoice.Paladin:
      subclassOptions.value = [
        Subclass.OathOfTheAncients,
        Subclass.OathOfDevotion,
        Subclass.OathOfVengeance,
        Subclass.OathBreaker,
      ];
      break;

    case ClassChoice.Ranger:
      subclassOptions.value = [
        Subclass.Hunter,
        Subclass.BeastMaster,
        Subclass.GloomStalker,
      ];
      break;

    case ClassChoice.Rogue:
      subclassOptions.value = [
        Subclass.ArcaneTrickster,
        Subclass.Thief,
        Subclass.Assassin,
      ];
      break;

    case ClassChoice.Sorcerer:
      subclassOptions.value = [
        Subclass.DraconicBloodline,
        Subclass.WildMagicSorcerer,
        Subclass.StormSorcery,
      ];
      break;

    case ClassChoice.Warlock:
      subclassOptions.value = [
        Subclass.TheArchfey,
        Subclass.TheFiend,
        Subclass.TheGreatOldOne,
      ];
      break;

    case ClassChoice.Wizard:
      subclassOptions.value = [
        Subclass.AbjurationSchool,
        Subclass.ConjurationSchool,
        Subclass.DivinationSchool,
        Subclass.EnchantmentSchool,
        Subclass.EvocationSchool,
        Subclass.IllusionSchool,
        Subclass.NecromancySchool,
        Subclass.TransmutationSchool,
      ];
      break;
  }
});
</script>

<template>
  <select
    v-model="model"
    class="px-1 text-black rounded-sm border-0"
    name="feat-extra-choice-select"
  >
    <option v-for="choice in subclassOptions" :key="choice" :value="choice">
      {{ subclassToString(choice) }}
    </option>
  </select>
</template>
