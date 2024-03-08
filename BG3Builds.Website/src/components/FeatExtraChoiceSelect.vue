<script setup lang="ts">
import { FeatExtraChoice } from "@/enums/FeatExtraChoice.ts";
import { PropType } from "vue";

const props = defineProps({
  featExtraChoice: Number as PropType<FeatExtraChoice>,
});
</script>

<template>
  <select
    v-if="props.featExtraChoice === FeatExtraChoice.ElementalAdept"
    class="px-2 py-1 text-black rounded-sm border-0"
    name="feat-extra-choice-select"
  >
    <option>Elemental Adept: Acid</option>
    <option>Elemental Adept: Cold</option>
    <option>Elemental Adept: Lightning</option>
    <option>Elemental Adept: Fire</option>
    <option>Elemental Adept: Thunder</option>
  </select>
</template>
