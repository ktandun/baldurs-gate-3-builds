<script setup lang="ts">
import { ClassChoice } from "@/enums/ClassChoice";
const model = defineModel();
</script>

<template>
  <select
    v-model="model"
    class="px-1 text-black rounded-sm border-0"
    name="feat-extra-choice-select"
  >
    <option :value="ClassChoice.Barbarian">Barbarian</option>
    <option :value="ClassChoice.Bard">Bard</option>
    <option :value="ClassChoice.Cleric">Cleric</option>
    <option :value="ClassChoice.Druid">Druid</option>
    <option :value="ClassChoice.Fighter">Fighter</option>
    <option :value="ClassChoice.Monk">Monk</option>
    <option :value="ClassChoice.Paladin">Paladin</option>
    <option :value="ClassChoice.Ranger">Ranger</option>
    <option :value="ClassChoice.Rogue">Rogue</option>
    <option :value="ClassChoice.Sorcerer">Sorcerer</option>
    <option :value="ClassChoice.Warlock">Warlock</option>
    <option :value="ClassChoice.Wizard">Wizard</option>
  </select>
</template>
