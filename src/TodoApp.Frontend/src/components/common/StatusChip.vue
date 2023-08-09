<template>

  <div class="w-fit p-1 px-2 rounded-full flex items-center justify-center gap-3 font-semibold" :class="chipStyle">
    <span class="h-2 w-2 rounded-full bg-black bg-opacity-30"></span>
    <span> {{ text }}</span>
  </div>


</template>

<script setup lang="ts">

import {TaskStatus} from "@/models/TaskStatus";
import type {PropType} from "vue";
import {computed} from "vue";

const props = defineProps({
  text: {
    type: String,
    required: true
  },
  type: {
    type: String,
    required: true
  }
});

const chipStyle = computed(() => {
    switch (props.type) {
      case TaskStatus.InProgress:
        return 'bg-blue-200 text-blue-600';
      case TaskStatus.Pending:
        return 'bg-orange-200 text-orange-600';
      case TaskStatus.Done:
        return 'bg-green-200 text-green-600';
      default:
        return 'bg-gray-200 text-gray-600';
    }
});

</script>