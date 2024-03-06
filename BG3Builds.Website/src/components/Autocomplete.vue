<script lang="ts" setup>
import { OptionModel } from "@/models/OptionModel";
import { PropType, computed, ref } from "vue";

const props = defineProps({
  options: Array as PropType<OptionModel[]>,
});
const emits = defineEmits<{ selected: [id: number | string] }>();

let input = ref<string>("");
let showOptions = ref<boolean>(true);
let filteredOptions = computed(() => {
  if (!props.options) return [];

  const filtered = props.options.filter((o) => {
    if (input?.value) {
      return o.name.toLowerCase().includes(input.value.toLocaleLowerCase());
    }
  });

  return filtered;
});

const optionSelected = function (id: string | number) {
  emits("selected", id);

  if (props.options) {
    input.value = props.options.find((o) => o.id === id)?.name ?? "";
    showOptions.value = false;
  }
};
</script>

<template>
  <input
    v-model="input"
    type="text"
    class="px-1 text-black rounded-sm border-0"
    @input="showOptions = true"
  />
  <ul v-for="option in filteredOptions" :key="option.id" v-if="showOptions">
    <li
      @click="optionSelected(option.id)"
      class="px-2 py-1 bg-gray-300 text-slate-800 hover:bg-gray-100"
    >
      {{ option.name }}
    </li>
  </ul>
</template>
