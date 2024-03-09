<template>
  <select
    v-model="input"
    type="text"
    class="bg-gray-200 text-black rounded-sm border-0 px-3 py-2 w-full"
  >
    <option v-for="option in options" :key="option.id" :value="option.id">
      {{ option.name }}
    </option>
  </select>
</template>

<script lang="ts" setup>
import { IOptionModel } from "@/models/OptionModel";
import { PropType, computed } from "vue";

const props = defineProps({ options: Array as PropType<IOptionModel[]> });
const emits = defineEmits<{ selected: [id: number | string] }>();

let input = defineModel();
let options = computed(() => {
  if (!props.options) return [];

  return props.options;
});
</script>
