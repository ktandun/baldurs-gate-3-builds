<script setup lang="ts">
import Navbar from "./components/Navbar.vue";
</script>

<template>
  <div class="mx-auto max-w-8xl p-1 sm:px-6 lg:px-8 bg-slate-800 min-h-screen">
    <div class="text-3xl text-primary font-mono">bg3builds.net</div>
    <div class="text-sm text-primary font-sans">
      share your builds with everyone
    </div>
    <navbar class="my-2"></navbar>
    <router-view></router-view>
  </div>
</template>
