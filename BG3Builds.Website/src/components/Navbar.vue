<script setup lang="ts">
import { routeNames } from "@/routes";
const tabs = [
  { name: "builds", href: routeNames.builds, current: false },
  { name: "your builds", href: routeNames.buildEdit, current: false },
];
</script>

<template>
  <div>
    <div class="sm:hidden">
      <label for="tabs" class="sr-only">Select a tab</label>
      <!-- Use an "onChange" listener to redirect the user to the selected tab URL. -->
      <select
        id="tabs"
        name="tabs"
        class="block w-full rounded-md border-gray-300 px-2"
      >
        <option v-for="tab in tabs" :key="tab.name" :selected="tab.current">
          {{ tab.name }}
        </option>
      </select>
    </div>
    <div class="hidden sm:block">
      <nav class="flex space-x-4" aria-label="Tabs">
        <router-link
          v-for="tab in tabs"
          :key="tab.name"
          :to="{ name: tab.href }"
          :class="[
            tab.current
              ? 'bg-gray-100 text-gray-700'
              : 'border-2 border-sky-800 text-gray-500 hover:text-gray-700 hover:bg-slate-400',
            'rounded-md px-3 py-2 text-sm font-medium',
          ]"
          :aria-current="tab.current ? 'page' : undefined"
          >{{ tab.name }}</router-link
        >
      </nav>
    </div>
  </div>
</template>
