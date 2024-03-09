import { defineStore } from "pinia";
import allBg3Objects from "@/assets/bg3objects.json";

export const bg3ObjectsStore = "bg3objects";

// You can name the return value of `defineStore()` anything you want,
// but it's best to use the name of the store and surround it with `use`
// and `Store` (e.g. `useUserStore`, `useCartStore`, `useProductStore`)
// the first argument is a unique id of the store across your application
export const useBg3ObjectsStore = defineStore(bg3ObjectsStore, () => {
  // other options...
  const bg3Objects = allBg3Objects;

  const ritualSpells = bg3Objects.spells.filter((o) => o.isRitual);

  return {
    bg3Objects,
    ritualSpells,
  };
});
