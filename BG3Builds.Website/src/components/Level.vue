<script setup lang="ts">
import bg3objects from "@/assets/bg3objects.json";
import ClassChoiceSelect from "@/components/ClassChoiceSelect.vue";
import FeatExtraChoiceSelect from "@/components/FeatExtraChoiceSelect.vue";
import SubclassChoiceSelect from "@/components/SubclassChoiceSelect.vue";
import { ClassChoice } from "@/enums/ClassChoice";
import { Subclass } from "@/enums/Subclass";
import { FeatExtraChoice } from "@/enums/FeatExtraChoice";
import { ref } from "vue";

const level = defineModel<any>();
const emits = defineEmits(["duplicate", "remove"]);

let classChoice = ref<ClassChoice | undefined>();
let featChoice = ref<string | undefined>();
let subclassChoice = ref<Subclass | undefined>();
</script>

<template>
  <div class="table-cell text-xs px-2 py-1 italic">
    <div>
      <ClassChoiceSelect v-model="level.class"></ClassChoiceSelect>
    </div>
  </div>
  <div class="table-cell text-xs px-2 italic">
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
