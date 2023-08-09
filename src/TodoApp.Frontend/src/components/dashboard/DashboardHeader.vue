<template>

  <div class="p-4 px-10 w-full flex items-center justify-between">

    <!-- Title -->

    <div>
      Hi
    </div>

    <!-- Profile -->
    <div>
      
      <!-- Profile Picture -->
      <img :src="imageUrl" alt="" class="h10 w-10 rounded-full">
      
    </div>


  </div>

</template>

<script setup lang="ts">

const imageUrl = "https://images.unsplash.com/photo-1550525811-e5869dd03032?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"


</script>