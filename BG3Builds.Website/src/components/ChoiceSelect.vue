<template>
  <select
    v-model="input"
    type="text"
    class="text-black rounded-sm border-0 px-2 py-1 w-full"
  >
    <option v-for="option in options" :key="option.id" :value="option.id">
      {{ option.name }}
    </option>
  </select>
</template>

<script lang="ts" setup>
import { OptionModel } from "@/models/OptionModel";
import { PropType, computed, ref } from "vue";

const props = defineProps({ options: Array as PropType<OptionModel[]> });
const emits = defineEmits<{ selected: [id: number | string] }>();

let input = defineModel();
let options = computed(() => {
  if (!props.options) return [];

  return props.options;
});
</script>
