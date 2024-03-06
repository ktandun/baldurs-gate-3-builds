<script lang="ts" setup>
import { OptionModel } from "@/models/OptionModel";
import { PropType, computed, ref } from "vue";

const props = defineProps({
  options: Array as PropType<OptionModel[]>,
});
const emits = defineEmits<{ selected: [id: number | string] }>();

let input = ref<string>("");
let keyboardSelector = ref<OptionModel | null>(null);
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

<template>
  <input
    v-model="input"
    type="text"
    class="px-1 text-black rounded-sm border-0"
    @keyup.enter="enterPressed"
    @keyup.down.stop="downPressed"
    @keyup.up.stop="upPressed"
    @input="showOptions = true"
  />
  <div class="absolute">
    <ul
      v-for="option in filteredOptions"
      :key="option.id"
      v-if="showOptions"
      class="list-none"
    >
      <li
        @click="optionSelected(option.id)"
        class="px-2 py-1 bg-gray-300 text-slate-800 hover:bg-red-200 z-10 relative"
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
    </ul>
  </div>
</template>
