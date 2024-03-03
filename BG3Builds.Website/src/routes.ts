import { createRouter, createWebHashHistory } from "vue-router";

const routeNames = {
  builds: "builds",
  buildEdit: "buildEdit",
};

// 2. Define some routes
// Each route should map to a component.
// We'll talk about nested routes later.
const routes = [
  {
    path: "/",
    component: () => import("@pages/BuildsIndexPage.vue"),
    name: routeNames.builds,
  },
  {
    path: "/edit",
    component: () => import("@pages/BuildEditPage.vue"),
    name: routeNames.buildEdit,
  },
];

// 3. Create the router instance and pass the `routes` option
// You can pass in additional options here, but let's
// keep it simple for now.
const router = createRouter({
  // 4. Provide the history implementation to use. We
  // are using the hash history for simplicity here.
  history: createWebHashHistory(),
  routes, // short for `routes: routes`
});

export { router, routeNames };
