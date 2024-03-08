<script setup lang="ts">
import LevelBuild from "@components/LevelBuild.vue";
import ItemBuild from "@components/ItemBuild.vue";
</script>

<template>
  <div class="bg-slate-600 rounded-md p-2">
    <div class="mb-2 text-primary">
      <div class="text-yellow-500 text-2xl font-black font-mono">
        Necromancer Sorlock
      </div>
      <div class="text-sm flex gap-2 divide-x divide-double divide-slate-500">
        <div class="pr-2">
          <img
            src="/images/classes/sorcerer.png"
            height="30"
            width="30"
            class="inline"
          />
          <span class="font-semibold">Sorcerer 5</span>
        </div>
        <div>
          <img
            src="/images/classes/warlock.png"
            height="30"
            width="30"
            class="inline"
          />
          <span class="font-semibold">Warlock 7</span>
        </div>
      </div>
    </div>

    <div class="mb-2">
      <ItemBuild></ItemBuild>
    </div>

    <div>
      <LevelBuild></LevelBuild>
    </div>
  </div>
</template>
