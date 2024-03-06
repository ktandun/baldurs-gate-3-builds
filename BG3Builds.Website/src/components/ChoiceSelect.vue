<script lang="ts" setup>
import { OptionModel } from "@/models/OptionModel";
import { PropType, computed, ref } from "vue";

const props = defineProps({ options: Array as PropType<OptionModel[]> });
const emits = defineEmits<{ selected: [id: number | string] }>();

let input = ref<string>("");
let options = computed(() => {
  if (!props.options) return [];

  return props.options;
});
</script>

<template>
  <select
    v-model="input"
    type="text"
    class="px-1 text-black rounded-sm border-0"
  >
    <option
      v-for="option in options"
      :key="option.id"
      class="px-2 py-1"
      :value="option.id"
    >
      {{ option.name }}
    </option>
  </select>
</template>
