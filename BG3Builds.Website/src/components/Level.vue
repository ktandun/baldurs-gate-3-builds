<script setup lang="ts">
import bg3objects from "@/assets/bg3objects.json";
import { ClassChoice } from "@/enums/ClassChoice";
import FeatExtraChoiceSelect from "@/components/FeatExtraChoiceSelect.vue";
import ChoiceSelect from "./ChoiceSelect.vue";
import SubclassChoiceSelect from "@/components/SubclassChoiceSelect.vue";
import { FeatExtraChoice } from "@/enums/FeatExtraChoice";

const level = defineModel<any>();
const emits = defineEmits(["duplicate", "remove"]);
</script>

<template>
  <div class="table-cell text-xs px-2 py-1">
    <div>
      <ChoiceSelect
        v-model="level.class"
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
  </div>
  <div class="table-cell text-xs px-2">
    <div>
      <SubclassChoiceSelect
        v-model="level.subclass"
        :class-choice="level.class"
      ></SubclassChoiceSelect>
    </div>
  </div>
  <div class="table-cell text-xs px-2 italic">
    <div>
      {{ level.skills }}
    </div>
  </div>
  <div class="table-cell text-xs px-2 italic">
    <div>
      <select
        v-model="level.feat"
        name="feat-select"
        class="px-1 text-black rounded-sm border-0"
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
  </div>
  <div class="table-cell text-xs px-2 italic">
    <div>
      <FeatExtraChoiceSelect
        :feat-extra-choice="FeatExtraChoice.ElementalAdept"
      >
      </FeatExtraChoiceSelect>
    </div>
  </div>

  <div class="table-cell text-xs px-2 italic">
    <div class="flex gap-2">
      <button
        class="bg-gray-300 hover:bg-gray-400 px-2 rounded-sm text-slate-800"
        @click="$emit('duplicate')"
      >
        duplicate
      </button>
      <button
        class="bg-gray-300 hover:bg-gray-400 px-2 rounded-sm text-slate-800"
        @click="$emit('remove')"
      >
        remove
      </button>
    </div>
  </div>
</template>
