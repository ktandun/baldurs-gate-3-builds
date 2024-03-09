<template>
  <div class="text-yellow-500 text-lg font-black font-mono">
    Items Progression
  </div>
  <div class="overflow-x-auto">
    <table class="table-fixed">
      <tbody>
        <tr>
          <td class="text-primary font-semibold min-w-[150px]">Name</td>
          <td
            v-for="buildItem in buildItems"
            :key="buildItem.id"
            class="px-1 min-w-[220px]"
          >
            <TextInput v-model="buildItem.name"></TextInput>
          </td>
          <td class="text-primary font-semibold min-w-[150px]">Name</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Headwear</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.headwear?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Headwear, $event)"
                :options="bg3objects.headwears"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Headwear</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Cloak</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.cloak?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Cloak, $event)"
                :options="bg3objects.cloaks"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Cloak</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Handwear</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.handwear?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Handwear, $event)"
                :options="bg3objects.handwears"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Handwear</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Armour</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.armour?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Armour, $event)"
                :options="bg3objects.armours"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Armour</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Footwear</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.footwear?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Footwear, $event)"
                :options="bg3objects.footwears"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Footwear</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Weap. Main</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.weaponMain?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Weapon, $event)"
                :options="bg3objects.weapons"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Weap. Main</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Weap. Off</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.weaponOff?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.WeaponOff, $event)"
                :options="bg3objects.weapons"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Weap. Off</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Weap. Range</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="
                  buildItem.weaponRange?.imageUrl ?? '/images/dices/d20.png'
                "
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.WeaponRange, $event)"
                :options="bg3objects.weapons"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Weap. Range</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Weap. Range Off</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="
                  buildItem.weaponRangeOff?.imageUrl ?? '/images/dices/d20.png'
                "
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="
                  objectSelected(index, ItemType.WeaponRangeOff, $event)
                "
                :options="bg3objects.weapons"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Weap. Range Off</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Amulet</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.amulet?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Amulet, $event)"
                :options="bg3objects.amulets"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Amulet</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Ring 1</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.ring1?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Ring1, $event)"
                :options="bg3objects.rings"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Ring 1</td>
        </tr>
        <tr>
          <td class="text-primary font-semibold">Ring 2</td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <div class="flex justify-between">
              <img
                :src="buildItem.ring2?.imageUrl ?? '/images/dices/d20.png'"
                height="30"
                width="30"
                class="inline mr-2 object-cover"
              />
              <Autocomplete
                @selected="objectSelected(index, ItemType.Ring2, $event)"
                :options="bg3objects.rings"
              ></Autocomplete>
            </div>
          </td>
          <td class="text-primary font-semibold">Ring 2</td>
        </tr>
        <tr>
          <td>
            <ActionButton @click="addClicked()">+ progression</ActionButton>
          </td>
          <td
            v-for="(buildItem, index) in buildItems"
            :key="buildItem.id"
            class="px-1"
          >
            <ActionButton @click="removeClicked(index)">remove</ActionButton>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import ActionButton from "./BuildingBlocks/ActionButton.vue";
import Autocomplete from "@components/BuildingBlocks/Autocomplete.vue";
import TextInput from "./BuildingBlocks/TextInput.vue";
import bg3objects from "@/assets/bg3objects.json";
import { ItemBuildModel } from "@/models/ItemBuildModel";
import { IOptionModel } from "@/models/OptionModel";
import { ref } from "vue";

enum ItemType {
  Headwear,
  Cloak,
  Handwear,
  Armour,
  Footwear,
  Weapon,
  WeaponOff,
  WeaponRange,
  WeaponRangeOff,
  Amulet,
  Ring1,
  Ring2,
}

let buildItems = ref<ItemBuildModel[]>([
  {
    id: 1,
    name: "Act 1",
    headwear: null,
    cloak: null,
    handwear: null,
    armour: null,
    footwear: null,
    weaponMain: null,
    weaponOff: null,
    weaponRange: null,
    weaponRangeOff: null,
    amulet: null,
    ring1: null,
    ring2: null,
  },
  {
    id: 2,
    name: "Act 2",
    headwear: null,
    cloak: null,
    handwear: null,
    armour: null,
    footwear: null,
    weaponMain: null,
    weaponOff: null,
    weaponRange: null,
    weaponRangeOff: null,
    amulet: null,
    ring1: null,
    ring2: null,
  },
]);

const getDataSource = (itemType: ItemType): IOptionModel[] => {
  let source: IOptionModel[] = [];

  switch (itemType) {
    case ItemType.Headwear:
      source = bg3objects.headwears;
      break;

    case ItemType.Handwear:
      source = bg3objects.handwears;
      break;

    case ItemType.Cloak:
      source = bg3objects.cloaks;
      break;

    case ItemType.Armour:
      source = bg3objects.armours;
      break;

    case ItemType.Footwear:
      source = bg3objects.footwears;
      break;

    case ItemType.Weapon:
    case ItemType.WeaponOff:
    case ItemType.WeaponRange:
    case ItemType.WeaponRangeOff:
      source = bg3objects.weapons;
      break;

    case ItemType.Amulet:
      source = bg3objects.amulets;
      break;

    case ItemType.Ring1:
    case ItemType.Ring2:
      source = bg3objects.rings;
      break;
  }

  return source;
};

const objectSelected = (
  index: number,
  itemType: ItemType,
  id: string | number
): void => {
  const notFound = -1;
  const source = getDataSource(itemType);
  const item = buildItems.value[index];
  const objectIndex = source.findIndex((h) => h.id === id);

  if (objectIndex !== notFound) {
    switch (itemType) {
      case ItemType.Handwear:
        item.handwear = { ...source[objectIndex] };
        break;

      case ItemType.Headwear:
        item.headwear = { ...source[objectIndex] };
        break;

      case ItemType.Cloak:
        item.cloak = { ...source[objectIndex] };
        break;

      case ItemType.Armour:
        item.armour = { ...source[objectIndex] };
        break;

      case ItemType.Footwear:
        item.footwear = { ...source[objectIndex] };
        break;

      case ItemType.Weapon:
        item.weaponMain = { ...source[objectIndex] };
        break;

      case ItemType.WeaponOff:
        item.weaponOff = { ...source[objectIndex] };
        break;

      case ItemType.WeaponRange:
        item.weaponRange = { ...source[objectIndex] };
        break;

      case ItemType.WeaponRangeOff:
        item.weaponRangeOff = { ...source[objectIndex] };
        break;

      case ItemType.Amulet:
        item.amulet = { ...source[objectIndex] };
        break;

      case ItemType.Ring1:
        item.ring1 = { ...source[objectIndex] };
        break;

      case ItemType.Ring2:
        item.ring2 = { ...source[objectIndex] };
        break;
    }
  }
};

const addClicked = () => {
  const maxId = buildItems.value
    .map((bi) => bi.id)
    .reduce((a, b) => Math.max(a, b), 0);

  buildItems.value.push({
    id: maxId + 1,
    name: "Rename me",
    headwear: null,
    cloak: null,
    handwear: null,
    armour: null,
    footwear: null,
    weaponMain: null,
    weaponOff: null,
    weaponRange: null,
    weaponRangeOff: null,
    amulet: null,
    ring1: null,
    ring2: null,
  });
};

const removeClicked = (index: number) => {
  if (buildItems.value.length >= 2) buildItems.value.splice(index, 1);
};
</script>
