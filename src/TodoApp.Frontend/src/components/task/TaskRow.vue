<template>
  <div class="col-span-2 font-medium" :class="rowStyle">{{ task.name }}</div>
  <div :class="rowStyle">{{ formatDate(task.dueDate) }}</div>
  <status-chip :text="task.status" :type="task.status"/>
  <div>Tags</div>
  <!--    <td :class="rowStyle"> {{ task.status }}</td>-->
</template>

<script setup lang="ts">

import type {TaskItem} from "@/models/TaskItem";
import StatusChip from "@/components/common/StatusChip.vue";
import {TaskStatus} from "@/models/TaskStatus";

const rowStyle = 'text-lg';

const props = defineProps({
  task: {
    type: Object as () => TaskItem,
    required: true
  }
});

const formatDate = (date: Date) => {
  return date.toLocaleDateString(undefined, {
    year: 'numeric',
    month: 'short',
    day: 'numeric',
  });
};

</script>