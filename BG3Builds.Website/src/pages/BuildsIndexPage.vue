<script setup lang="ts">
import sorcererImg from "@/assets/classes/sorcerer.png";
import warlockImg from "@/assets/classes/warlock.png";

const buildItems = [
  {
    id: 1,
    head: {
      name: "Dark Justiciar Mask",
      imgSrc:
        "https://bg3.wiki/w/images/3/3d/Dark_Justiciar_Mask_Unfaded_Icon.png",
    },
    cloak: {
      name: "Cindermoth Cloak",
      imgSrc:
        "https://bg3.wiki/w/images/a/ad/Cindermoth_Cloak_Unfaded_Icon.png",
    },
    arms: {
      name: "Herbalists' Gloves",
      imgSrc:
        "https://bg3.wiki/w/images/c/cb/Gloves_Leather_1_Unfaded_Icon.png",
    },
    armour: {
      name: "Blazer of Benevolence",
      imgSrc:
        "https://bg3.wiki/w/images/9/9b/Blazer_of_Benevolence_Unfaded_Icon.png",
    },
  },
];

const levels = [
  {
    id: 1,
    imgSrc: sorcererImg,
    name: "Sorcerer",
    skills: "Firebolt, Bone Chill",
    feat: "",
  },
  {
    id: 2,
    imgSrc: sorcererImg,
    name: "Sorcerer",
    skills: "Firebolt, Bone Chill",
    feat: "",
  },
  {
    id: 3,
    imgSrc: sorcererImg,
    name: "Sorcerer",
    skills: "Firebolt, Bone Chill",
    feat: "",
  },
  {
    id: 4,
    imgSrc: sorcererImg,
    name: "Sorcerer",
    skills: "Firebolt, Bone Chill",
    feat: "Alert",
  },
  {
    id: 5,
    imgSrc: sorcererImg,
    name: "Sorcerer",
    skills: "Firebolt, Bone Chill",
    feat: "",
  },
  {
    id: 6,
    imgSrc: warlockImg,
    name: "Warlock",
    skills: "Eldritch Blast",
    feat: "",
  },
  {
    id: 7,
    imgSrc: warlockImg,
    name: "Warlock",
    skills: "Eldritch Blast",
    feat: "",
  },
  {
    id: 8,
    imgSrc: warlockImg,
    name: "Warlock",
    skills: "Eldritch Blast",
    feat: "",
  },
  {
    id: 9,
    imgSrc: warlockImg,
    name: "Warlock",
    skills: "Eldritch Blast",
    feat: "",
  },
  {
    id: 10,
    imgSrc: warlockImg,
    name: "Warlock",
    skills: "Eldritch Blast",
    feat: "",
  },
  {
    id: 11,
    imgSrc: warlockImg,
    name: "Warlock",
    skills: "Eldritch Blast",
    feat: "",
  },
  {
    id: 12,
    imgSrc: warlockImg,
    name: "Warlock",
    skills: "Eldritch Blast",
    feat: "",
  },
];
</script>

<template>
  <div class="bg-slate-600 rounded-md">
    <div class="px-2 py-1 text-primary">
      <div class="text-2xl font-black">Necromancer Sorlock</div>
      <div class="text-sm flex gap-2 divide-x divide-double divide-slate-500">
        <div class="pr-2">
          <img :src="sorcererImg" height="30" width="30" class="inline" />
          <span class="font-semibold">Sorcerer 5</span>
        </div>
        <div class="px-2">
          <img :src="warlockImg" height="30" width="30" class="inline" />
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
          <div class="table-row" v-for="level in levels" :key="level.id">
            <div class="table-cell text-xs px-2 italic">
              <div>
                <img
                  :src="level.imgSrc"
                  width="20"
                  height="20"
                  class="inline"
                />
                {{ level.name }}
              </div>
            </div>
            <div class="table-cell text-xs px-2 italic">
              <div>
                {{ level.name }}
              </div>
            </div>
            <div class="table-cell text-xs px-2 italic">
              <div>
                {{ level.skills }}
              </div>
            </div>
            <div class="table-cell text-xs px-2 italic">
              <div>
                {{ level.feat }}
              </div>
            </div>
            <div class="table-cell text-xs px-2 italic">
              <div>
                {{ level.feat }}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
