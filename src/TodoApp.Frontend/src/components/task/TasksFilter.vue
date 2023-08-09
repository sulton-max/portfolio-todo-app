<template>
  <div class="px-10 flex items-center justify-between mb-5">

    <div>
      <div class="flex items-center justify-center">
        <input type="text" placeholder="Search" class="p-2 w-[400px] border-blue-500 focus:border-b-2 outline-none">
      </div>
    </div>

    <div>
      <button class="p-2 bg-transparent border-blue-500 w-[100px]" :class="{'border-b-2': isActive}"
              @click="isActive = true">
        Active
      </button>
      <button class="p-2 bg-transparent border-blue-500 w-[100px]" :class="{'border-b-2': !isActive}"
              @click="isActive = false">
        Finished
      </button>
    </div>
  </div>
</template>