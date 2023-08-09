<template>

  <div class="w-full px-10 grid grid-cols-5 gap-8">
    <div v-for="header in tableHeaders"
         :key="header.text"
         class="text-gray-600"
         :class="header.style">
      <p>{{ header.text }}</p>
    </div>
    <task-row v-for="task in tasks"
              :key="task.name"
              :task="task"/>
  </div>

</template>
<script setup lang="ts">
import TaskRow from "@/components/task/TaskRow.vue";
import type {TaskItem} from "@/models/TaskItem";

const props = defineProps<{
  tasks: TaskItem[],
  tableHeaders: { text: string, key: string, style: string }[]
}>()

</script>