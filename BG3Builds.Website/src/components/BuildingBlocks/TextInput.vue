<template>
  <input
    v-model="model"
    type="text"
    class="text-black rounded-sm border-0 w-full text-sm px-2 py-1"
  />
</template>

<script lang="ts" setup>
const model = defineModel();
</script>
