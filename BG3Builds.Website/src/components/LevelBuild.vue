<template>
  <div class="flex flex-col gap-2">
    <div class="text-yellow-500 text-lg font-black font-mono">
      Levels Progression
    </div>
    <div class="text-sm flex text-primary flex-col">
      <div
        v-for="(group, groupIndex) in levelBuildSummary"
        :key="groupIndex"
        :class="{ 'pl-2': groupIndex > 0 }"
        class="flex flex-row gap-2"
      >
        <span v-if="groupIndex > 0">&#10551;</span>
        <div
          v-for="(progression, progressionIndex) in group"
          :key="progressionIndex"
          class="flex flex-row gap-2"
        >
          <img
            :src="progression.imageUrl"
            height="22"
            width="22"
            class="inline"
          />
          <span class="italic"
            >{{ progression.name }} [{{ progression.level }}]</span
          >
        </div>
      </div>
    </div>
    <table class="table-auto">
      <thead class="text-primary font-semibold text-left">
        <th class="min-w-[30px]">Level</th>
        <th class="">Class</th>
        <th class="">Subclass</th>
        <th class="max-w-[300px] min-w-[200px]">Key Skills</th>
        <th class="">Feat</th>
        <th class="">Feat Extra Choices</th>
        <th></th>
      </thead>
      <tbody>
        <tr v-for="(level, index) in levels" :key="level.value.id">
          <td
            v-if="level.value.respec"
            class="text-gray-400 italic text-center"
            colspan="3"
          >
            -- respec here --
          </td>
          <template v-else>
            <td class="text-primary">{{ level.value.charLevel }}</td>
            <td>
              <div>
                <ChoiceSelect
                  v-model="level.value.class"
                  :options="[
                    { id: ClassChoice.Barbarian, name: 'Barbarian' },
                    { id: ClassChoice.Bard, name: 'Bard' },
                    { id: ClassChoice.Cleric, name: 'Cleric' },
                    { id: ClassChoice.Druid, name: 'Druid' },
                    { id: ClassChoice.Fighter, name: 'Fighter' },
                    { id: ClassChoice.Monk, name: 'Monk' },
                    { id: ClassChoice.Paladin, name: 'Paladin' },
                    { id: ClassChoice.Ranger, name: 'Ranger' },
                    { id: ClassChoice.Rogue, name: 'Rogue' },
                    { id: ClassChoice.Sorcerer, name: 'Sorcerer' },
                    { id: ClassChoice.Warlock, name: 'Warlock' },
                    { id: ClassChoice.Wizard, name: 'Wizard' },
                  ]"
                >
                </ChoiceSelect>
              </div>
            </td>
            <td>
              <div>
                <SubclassChoiceSelect
                  v-model="level.value.subclass"
                  :class-choice="level.value.class"
                ></SubclassChoiceSelect>
              </div>
            </td>
            <td>
              <MultiselectAutocomplete
                v-model="level.value.skills"
                :options="bg3objects.spells"
              ></MultiselectAutocomplete>
            </td>
            <td>
              <div>
                <ChoiceSelect
                  v-model="level.value.feat"
                  :options="bg3objects.feats"
                >
                </ChoiceSelect>
              </div>
            </td>
            <td>
              <FeatExtraChoiceSelect
                :feat-extra-choice="FeatExtraChoice.TwoAbilityScores"
              >
              </FeatExtraChoiceSelect>
            </td>

            <td>
              <ActionButton @click="removeClicked(index)">remove</ActionButton>
            </td>
          </template>
        </tr>
      </tbody>
    </table>
    <div class="flex gap-1">
      <ActionButton @click="addClicked(false)">+ progression</ActionButton>
      <ActionButton @click="addClicked(true)">+ respec</ActionButton>
    </div>
  </div>
</template>

<script setup lang="ts">
import {
  ClassChoice,
  getClassImageUrl,
  getClassName,
} from "@/enums/ClassChoice";
import ChoiceSelect from "@components/BuildingBlocks/ChoiceSelect.vue";
import SubclassChoiceSelect from "@/components/SubclassChoiceSelect.vue";
import FeatExtraChoiceSelect from "@/components/FeatExtraChoiceSelect.vue";
import bg3objects from "@/assets/bg3objects.json";
import { FeatExtraChoice } from "@/enums/FeatExtraChoice";
import { computed, ref } from "vue";
import ActionButton from "./BuildingBlocks/ActionButton.vue";
import { cloneDeep } from "lodash";
import MultiselectAutocomplete from "@components/BuildingBlocks/MultiselectAutocomplete.vue";
import { ILevelBuildModel } from "@/models/LevelBuildModel";

const emits = defineEmits(["duplicate", "remove"]);

let levels = ref<{ value: ILevelBuildModel }[]>([
  {
    value: {
      id: 1,
      class: null,
      subclass: null,
      charLevel: 1,
      feat: null,
      skills: [],
      respec: false,
    },
  },
]);

const removeClicked = (index: number) => {
  if (levels.value.length <= 1) return;

  levels.value.splice(index, 1);

  removeDuplicateRespecs();
};

const removeDuplicateRespecs = () => {
  if (levels.value.length >= 2) {
    for (let i = 0; i < levels.value.length - 2; i++) {
      if (levels.value[i].value.respec && levels.value[i + 1].value.respec) {
        levels.value.splice(i, 1);
        return;
      }
    }
  }
};

const addClicked = (respec: boolean) => {
  const maxLevel = 12;
  const lastRespecIndex = levels.value.findLastIndex(
    (l) => l.value.respec === true
  );

  const levelBuildsAfterLastRespec =
    lastRespecIndex !== -1
      ? levels.value
          .slice(lastRespecIndex)
          .filter((l) => l.value.respec === false)
      : levels.value;

  if (levelBuildsAfterLastRespec.length === maxLevel) return;
  if (respec && levels.value[levels.value.length - 1].value.respec === true)
    return;

  const maxId = levels.value
    .map((l) => l.value.id)
    .reduce((a, b) => Math.max(a, b), 0);

  const lastClass = levels.value[levels.value.length - 1].value.class;
  const lastSubclass = levels.value[levels.value.length - 1].value.subclass;

  if (respec) {
    levels.value = [
      ...levels.value,
      {
        value: {
          id: maxId + 1,
          charLevel: -1,
          class: lastClass,
          subclass: lastSubclass,
          feat: null,
          skills: [],
          respec: true,
        },
      },
      ...cloneDeep(levelBuildsAfterLastRespec),
      {
        value: {
          id: maxId + 1,
          charLevel: -1,
          class: null,
          subclass: null,
          feat: null,
          skills: [],
          respec: false,
        },
      },
    ];
  } else {
    levels.value = [
      ...levels.value,
      {
        value: {
          id: maxId + 1,
          charLevel: -1,
          class: lastClass,
          subclass: lastSubclass,
          feat: null,
          skills: [],
          respec: false,
        },
      },
    ];
  }

  recalculateCharacterLevel();
};

const recalculateCharacterLevel = () => {
  let levelCounter = 0;

  levels.value.forEach((l) => {
    if (l.value.respec) {
      levelCounter = 0;
    } else {
      levelCounter++;
    }

    l.value.charLevel = levelCounter;
  });
};

const levelBuildSummary = computed(() => {
  const groupedProgressionSplitByRespec: {
    class: ClassChoice;
    name: string;
    level: number;
    imageUrl: string;
  }[][] = [];

  let levelProgression: {
    class: ClassChoice;
    name: string;
    level: number;
    imageUrl: string;
  }[] = [];

  levels.value.forEach((l) => {
    if (l.value.respec) {
      groupedProgressionSplitByRespec.push(levelProgression);
      levelProgression = [];
    } else if (l.value.class) {
      const existingIndex = levelProgression.findIndex(
        (r) => r.class === l.value.class
      );

      if (existingIndex !== -1) {
        levelProgression[existingIndex].level += 1;
      } else {
        levelProgression.push({
          class: l.value.class,
          name: getClassName(l.value.class),
          level: 1,
          imageUrl: getClassImageUrl(l.value.class),
        });
      }
    }
  });

  groupedProgressionSplitByRespec.push(levelProgression);

  return groupedProgressionSplitByRespec;
});
</script>
