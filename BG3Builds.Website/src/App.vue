<template>
  <div
    class="mx-auto max-w-8xl p-1 sm:px-6 lg:px-8 bg-slate-800 min-h-screen flex flex-col gap-2"
  >
    <div class="text-2xl text-primary font-mono">
      <span class="text-yellow-500">bg3</span>builds.net
    </div>
    <div class="italic text-primary">just give me the damn build!</div>
    <Navbar></Navbar>
    <router-view></router-view>
  </div>
</template>

<script setup lang="ts">
import Navbar from "./components/Navbar.vue";
</script>
