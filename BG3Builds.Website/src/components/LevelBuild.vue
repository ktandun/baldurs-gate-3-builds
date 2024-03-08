<template>
  <div class="text-yellow-500 text-lg font-black font-mono">
    Levels Progression
  </div>
  <div
    class="text-md flex gap-2 divide-x divide-double divide-slate-500 text-primary"
  >
    <div
      v-for="(c, index) in levelBuildSummary"
      :key="c.name"
      :class="{ 'pl-2': index > 0, 'pr-2': index == 0 }"
      class="my-2"
    >
      <img :src="c.imageUrl" height="30" width="30" class="inline" />
      <span class="font-semibold">{{ c.name }} {{ c.level }}</span>
    </div>
  </div>
  <table class="mb-1">
    <thead class="text-primary font-semibold text-left">
      <th class="min-w-[180px]">Class</th>
      <th class="min-w-[200px]">Subclass</th>
      <th class="min-w-[200px]">Skills</th>
      <th class="min-w-[200px]">Feat</th>
      <th class="min-w-[200px]">Feat Extra Choices</th>
    </thead>
    <tbody>
      <tr v-for="level in levels" :key="level.value.id">
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
        <!--
        <td class="italic">
          <div>
            {{ level.skills }}
          </div>
        </td>
        <td class="italic">
          <div>
            <select
              v-model="level.feat"
              name="feat-select"
              class="px-2 py-1 text-black rounded-sm border-0"
            >
              <option
                v-for="feat in bg3objects.feats"
                :key="feat.featId"
                :value="feat.featId"
              >
                {{ feat.name }}
              </option>
            </select>
          </div>
        </td>
        <td class="italic">
          <div>
            <FeatExtraChoiceSelect
              :feat-extra-choice="FeatExtraChoice.ElementalAdept"
            >
            </FeatExtraChoiceSelect>
          </div>
        </td>

        <td class="italic">
          <div class="flex gap-2">
            <ActionButton @click="removeClicked">remove</ActionButton>
          </div>
        </td>
-->
      </tr>
    </tbody>
  </table>
  <ActionButton @click="addClicked">+ progression</ActionButton>
</template>

<script setup lang="ts">
import {
  ClassChoice,
  getClassImageUrl,
  getClassName,
} from "@/enums/ClassChoice";
import ChoiceSelect from "./ChoiceSelect.vue";
import SubclassChoiceSelect from "@/components/SubclassChoiceSelect.vue";
// import FeatExtraChoiceSelect from "@/components/FeatExtraChoiceSelect.vue";
// import bg3objects from "@/assets/bg3objects.json";
// import { FeatExtraChoice } from "@/enums/FeatExtraChoice";
import { computed, ref } from "vue";
import ActionButton from "./BuildingBlocks/ActionButton.vue";

const emits = defineEmits(["duplicate", "remove"]);

let levels = ref([
  {
    value: {
      id: 1,
      class: null,
      subclass: null,
    },
  },
]);

// const removeClicked = function () {
//   if (levels.value.length <= 1) return;

//   levels.value.splice(levels.value.length - 2, 1);
// };
const addClicked = function () {
  if (levels.value.length >= 12) return;

  const maxId = levels.value
    .map((l) => l.value.id)
    .reduce((a, b) => Math.max(a, b), -Infinity);

  levels.value = [
    ...levels.value,
    {
      value: {
        id: maxId + 1,
        class: null,
        subclass: null,
      },
    },
  ];
};

const levelBuildSummary = computed(() => {
  const result: {
    class: ClassChoice;
    name: string;
    level: number;
    imageUrl: string;
  }[] = [];

  levels.value.forEach((l) => {
    if (l.value.class) {
      const existingIndex = result.findIndex((r) => r.class === l.value.class);

      if (existingIndex !== -1) {
        result[existingIndex].level += 1;
      } else {
        result.push({
          class: l.value.class,
          name: getClassName(l.value.class),
          level: 1,
          imageUrl: getClassImageUrl(l.value.class),
        });
      }
    }
  });

  return result;
});
</script>
