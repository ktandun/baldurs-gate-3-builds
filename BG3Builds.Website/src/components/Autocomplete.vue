<template>
  <div class="static">
    <input
      v-model="input"
      type="text"
      class="text-black rounded-sm border-0 text-sm px-2 py-1 w-full inline-block"
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
            @click="optionSelected(option.id)"
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
import { OptionModel } from "@/models/OptionModel";
import { PropType, computed, ref } from "vue";

const props = defineProps({
  options: Array as PropType<OptionModel[]>,
});
const emits = defineEmits<{ selected: [id: number | string] }>();

let input = ref<string>("");
let keyboardSelector = ref<OptionModel | null>(null);
let showOptions = ref<boolean>(false);
let filteredOptions = computed(() => {
  if (!props.options) return [];

  const filtered = props.options
    .filter((o) => {
      return input?.value
        ? o.name.toLowerCase().includes(input.value.toLocaleLowerCase())
        : true;
    })
    .slice(0, 10);

  return filtered;
});

const optionSelected = function (id: string | number) {
  emits("selected", id);

  if (props.options) {
    input.value = props.options.find((o) => o.id === id)?.name ?? "";
    showOptions.value = false;
    keyboardSelector.value = null;
  }
};

const enterPressed = function () {
  if (keyboardSelector.value) {
    optionSelected(keyboardSelector.value.id);
  } else if (filteredOptions.value.length > 0) {
    optionSelected(filteredOptions.value[0].id);
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
