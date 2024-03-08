<script setup lang="ts">
import LevelBuild from "@components/LevelBuild.vue";
import ItemBuild from "@components/ItemBuild.vue";
import { ref } from "vue";

let name = ref<string>("Stealth Gloomstalker");
</script>

<template>
  <div class="bg-slate-700 rounded-md p-4 flex flex-col gap-4">
    <div class="text-primary text-xs">
      <span class="text-yellow-500">protip:</span> give this build a name
      <span>&#10549;</span>
    </div>
    <div class="text-primary">
      <div class="text-yellow-500 text-3xl font-black font-mono">
        <input
          v-model="name"
          class="bg-transparent border-b-2 border-slate-600 min-w-[50rem]"
          maxlength="40"
        />
      </div>
    </div>

    <div>
      <ItemBuild></ItemBuild>
    </div>

    <div>
      <LevelBuild></LevelBuild>
    </div>
  </div>
</template>
