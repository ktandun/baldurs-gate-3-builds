<template>
  <div class="relative w-full bg-gray-200 rounded-sm p-1">
    <div class="flex flex-row flex-wrap gap-1 relative">
      <div
        class="rounded-sm bg-slate-600 px-2 py-1 inline-flex relative"
        v-for="(option, index) in input"
        :key="option.id"
      >
        <img
          :src="option.imageUrl"
          :title="option.name"
          @click="input.splice(index, 1)"
          width="20"
        />
        <span class="mx-1 text-sm text-primary my-auto">{{ option.name }}</span>
        <span
          class="text-gray-200 rounded-full text-xs my-auto p-1 hover:bg-gray-400 cursor-pointer"
          @click="input.splice(index, 1)"
          >&#10005;</span
        >
      </div>
    </div>
    <input
      v-model="searchText"
      type="text"
      class="text-black rounded-sm border-0 bg-transparent text-sm px-2 py-1 relative"
      placeholder="type to search..."
      @keyup.enter="enterPressed"
      @keyup.down.stop="downPressed"
      @keyup.up.stop="upPressed"
      @input="showOptions = true"
    />
    <div class="absolute z-10 rounded-sm bg-gray-300 mt-1">
      <ul v-if="showOptions" class="list-none">
        <template v-for="option in filteredOptions" :key="option.id">
          <li
            @mouseenter="keyboardSelector = option"
            @click="optionSelected(option)"
            class="px-2 py-1 text-slate-800 rounded-sm"
            :class="{ 'bg-red-200': option.id == keyboardSelector?.id }"
          >
            <img
              v-if="option.imageUrl"
              :src="option.imageUrl"
              width="25"
              height="25"
              class="inline"
            />
            {{ option.name }}
          </li>
        </template>
      </ul>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { IOptionModel } from "@/models/OptionModel";
import { PropType, computed, ref } from "vue";

const props = defineProps({
  options: Array as PropType<IOptionModel[]>,
});
const emits = defineEmits<{ selected: [id: number | string] }>();

let input = ref<IOptionModel[]>([]);
let searchText = ref<string>("");
let keyboardSelector = ref<IOptionModel | null>(null);
let showOptions = ref<boolean>(false);
let filteredOptions = computed(() => {
  if (!props.options) return [];

  const filtered = props.options
    .filter((o) => {
      return searchText?.value
        ? o.name.toLowerCase().includes(searchText.value.toLocaleLowerCase()) &&
            !input.value.map((i) => i.id).includes(o.id)
        : true;
    })
    .slice(0, 10);

  return filtered;
});

const optionSelected = function (option: IOptionModel) {
  input.value.push({ ...option });

  searchText.value = "";
  showOptions.value = false;
  keyboardSelector.value = null;
};

const enterPressed = function () {
  if (keyboardSelector.value) {
    optionSelected(keyboardSelector.value);
  } else if (filteredOptions.value.length > 0) {
    optionSelected(filteredOptions.value[0]);
  }
};

const upPressed = function () {
  if (filteredOptions.value.length > 0 && showOptions) {
    if (keyboardSelector.value == null) {
      keyboardSelector.value =
        filteredOptions.value[filteredOptions.value.length - 1];
    } else {
      keyboardSelector.value =
        filteredOptions.value[
          Math.max(
            filteredOptions.value.findIndex(
              (o) => o.id === keyboardSelector.value!.id
            ) - 1,
            0
          )
        ];
    }
  }
};

const downPressed = function () {
  if (filteredOptions.value.length > 0 && showOptions) {
    if (keyboardSelector.value == null) {
      keyboardSelector.value = filteredOptions.value[0];
    } else {
      keyboardSelector.value =
        filteredOptions.value[
          Math.min(
            filteredOptions.value.findIndex(
              (o) => o.id === keyboardSelector.value!.id
            ) + 1,
            filteredOptions.value.length - 1
          )
        ];
    }
  }
};
</script>
