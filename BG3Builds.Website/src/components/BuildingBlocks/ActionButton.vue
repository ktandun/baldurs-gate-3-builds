<script setup lang="ts">
const emits = defineEmits(["click"]);
</script>

<template>
  <button
    class="bg-gray-300 hover:bg-gray-400 px-2 rounded-sm text-slate-800"
    @click="emits('click')"
  >
    <slot></slot>
  </button>
</template>
