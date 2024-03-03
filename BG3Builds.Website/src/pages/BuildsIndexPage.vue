<script setup lang="ts">
import Level from "@components/Level.vue";
import { ref } from "vue";

const buildItems = [
  {
    id: 1,
    head: {
      name: "Dark Justiciar Mask",
      imgSrc: "/images/equipments/Dark_Justiciar_Mask_Unfaded_Icon.png",
    },
    cloak: {
      name: "Cindermoth Cloak",
      imgSrc: "/images/equipments/Cindermoth_Cloak_Unfaded_Icon.png",
    },
    arms: {
      name: "Herbalists' Gloves",
      imgSrc: "/images/equipments/Gloves_Leather_1_Unfaded_Icon.png",
    },
    armour: {
      name: "Blazer of Benevolence",
      imgSrc: "/images/equipments/Blazer_of_Benevolence_Unfaded_Icon.png",
    },
  },
];

let levels = ref([
  {
    value: {
      id: 1,
      imgSrc: "/images/classes/sorcerer.png",
      name: "Sorcerer",
      skills: "Firebolt, Bone Chill",
      feat: "",
    },
  },
]);

const removeClicked = function () {
  if (levels.value.length <= 1) return;

  levels.value.splice(levels.value.length - 2, 1);
};

const duplicateClicked = function () {
  if (levels.value.length >= 12) return;

  const maxId = levels.value
    .map((l) => l.value.id)
    .reduce((a, b) => Math.max(a, b), -Infinity);

  levels.value = [
    ...levels.value,
    {
      value: {
        id: maxId + 1,
        imgSrc: "/images/classes/sorcerer.png",
        name: "Cat",
        skills: "Firebolt, Bone Chill",
        feat: "",
      },
    },
  ];
};
</script>

<template>
  <div class="bg-slate-600 rounded-md">
    <div class="px-2 py-1 text-primary">
      <div class="text-2xl font-black">Necromancer Sorlock</div>
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
        <div class="px-2">
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

    <div class="px-2 py-1 text-primary">
      <div class="text-lg font-black">Items</div>
    </div>

    <div class="p-2 text-primary">
      <div class="text-xl">act 1</div>
      <div class="table">
        <div class="table-header-group">
          <div class="table-row">
            <div class="table-cell text-left px-2">head</div>
            <div class="table-cell text-left px-2">cloak</div>
            <div class="table-cell text-left px-2">arms</div>
            <div class="table-cell text-left px-2">armour</div>
          </div>
        </div>
        <div class="table-row-group text-left">
          <div class="table-row" v-for="item in buildItems" :key="item.id">
            <div class="table-cell text-xs px-2 italic">
              <div>
                {{ item.head.name }}
              </div>
              <img :src="item.head.imgSrc" />
            </div>
            <div class="table-cell text-xs px-2 italic">
              <div>
                {{ item.cloak.name }}
              </div>
              <img :src="item.cloak.imgSrc" />
            </div>
            <div class="table-cell text-xs px-2 italic">
              <div>
                {{ item.arms.name }}
              </div>
              <img :src="item.arms.imgSrc" />
            </div>
            <div class="table-cell text-xs px-2">
              <div>
                {{ item.armour.name }}
              </div>
              <img :src="item.armour.imgSrc" />
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="px-2 py-1 text-primary">
      <div class="text-lg font-black">Levels</div>
    </div>
    {{ levels }}

    <div class="p-2 text-primary">
      <div class="table">
        <div class="table-header-group">
          <div class="table-row">
            <div class="table-cell text-left px-2">Class</div>
            <div class="table-cell text-left px-2">Subclass</div>
            <div class="table-cell text-left px-2">Skills</div>
            <div class="table-cell text-left px-2">Feat</div>
            <div class="table-cell text-left px-2">Feat Extra Choices</div>
          </div>
        </div>
        <div class="table-row-group text-left">
          <div class="table-row" v-for="level in levels" :key="level.value.id">
            <Level
              v-model="level.value"
              @duplicate="duplicateClicked"
              @remove="removeClicked"
            ></Level>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
