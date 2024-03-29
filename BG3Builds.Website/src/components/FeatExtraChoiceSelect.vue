<script setup lang="ts">
import { uniqBy } from "lodash";
import { PropType } from "vue";
import { AbilityPoint, abilityPointToString } from "@/enums/AbilityPoint";
import { FeatExtraChoice } from "@/enums/FeatExtraChoice.ts";
import { useBg3ObjectsStore } from "@/stores/Bg3ObjectsStore";
import { crossProduct } from "@/utilities/ArrayUtilities";

const bg3ObjectsStore = useBg3ObjectsStore();

const props = defineProps({
  featExtraChoice: Number as PropType<FeatExtraChoice>,
});

const abilityPoints = [
  AbilityPoint.Strength,
  AbilityPoint.Dexterity,
  AbilityPoint.Constitution,
  AbilityPoint.Intelligence,
  AbilityPoint.Wisdom,
  AbilityPoint.Charisma,
];

const abilityPointsCrossProduct = uniqBy(
  crossProduct(abilityPoints, abilityPoints)
    .map((i) => i.sort())
    .sort(),
  (i) => `${i[0]},${i[1]}`,
).map((i) => {
  const [left, right] = i;

  if (left === right) {
    return `2 x ${abilityPointToString(left)}`;
  }

  return abilityPointToString(left) + " + " + abilityPointToString(right);
});
</script>

<template>
  <select class="px-3 py-2 text-black rounded-sm border-0">
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.StrengthOrDexterity"
    >
      <option>Strength</option>
      <option>Dexterity</option>
    </template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.StrengthOrConstitution"
    >
      <option>Strength</option>
      <option>Constitution</option>
    </template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.AttackRollCantrip"
    >
    </template>
    <template v-if="props.featExtraChoice === FeatExtraChoice.ElementalAdept">
      <option>Elemental Adept: Acid</option>
      <option>Elemental Adept: Cold</option>
      <option>Elemental Adept: Lightning</option>
      <option>Elemental Adept: Fire</option>
      <option>Elemental Adept: Thunder</option>
    </template>

    <template v-if="props.featExtraChoice === FeatExtraChoice.TwoAbilityScores">
      <option v-for="ap in abilityPointsCrossProduct" :key="ap">
        {{ ap }}
      </option>
    </template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.TwoCantripsAndBardSpell"
    ></template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.TwoCantripsAndClericSpell"
    ></template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.TwoCantripsAndDruidSpell"
    ></template>
    <template
      v-if="
        props.featExtraChoice === FeatExtraChoice.TwoCantripsAndSorcererSpell
      "
    ></template>
    <template
      v-if="
        props.featExtraChoice === FeatExtraChoice.TwoCantripsAndWarlockSpell
      "
    ></template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.TwoCantripsAndWizardSpell"
    ></template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.TwoBattleMasterManoeuvres"
    ></template>
    <template v-if="props.featExtraChoice === FeatExtraChoice.TwoRitualSpells">
      <option
        v-for="o in bg3ObjectsStore.ritualSpells"
        :key="o.id"
        :value="o.id"
      >
        {{ o.name }}
      </option>
    </template>
    <template
      v-if="props.featExtraChoice === FeatExtraChoice.AttackRollCantrip"
    ></template>
    <template v-if="props.featExtraChoice === FeatExtraChoice.OneAbilityScore">
      <option>Strength</option>
      <option>Dexterity</option>
      <option>Constitution</option>
      <option>Intelligence</option>
      <option>Wisdom</option>
      <option>Charisma</option>
    </template>
  </select>
</template>
