<template>
  <div class="w-full h-full">

    <!-- Dashboard Header -->
    <dashboard-header class="mb-10" />

    <!-- Tasks filter -->
    <tasks-filter class="mb-10" />

    <!-- Tasks table -->
    <tasks-list :tasks="tasks" :tableHeaders="tableHeaders" />

    <!-- New Task Card -->
    <new-task-card class="flex-grow"></new-task-card>

  </div>
</template>

<script setup lang="ts">

import { reactive, ref } from "vue";
import type { TaskItem } from "@/models/TaskItem";
import { TaskStatus } from "@/models/TaskStatus";
import DashboardHeader from "@/components/dashboard/DashboardHeader.vue";
import TasksFilter from "@/components/task/TasksFilter.vue";
import TasksList from "@/components/task/TasksList.vue";
import NewTaskCard from "@/components/task/NewTaskCard.vue";

const isActive = ref(true)

const tableHeaders = [
  {
    text: 'Name',
    key: 'name',
    style: 'col-span-2'
  },
  {
    text: 'Due Date',
    key: 'dueDate',
    style: ''
  },
  {
    text: 'Status',
    key: 'status',
    style: ''
  },
  {
    text: 'Tags',
    key: 'status',
    style: ''
  },
]

const tasks = reactive<TaskItem[]>([
  {
    id: 1,
    name: 'Udemy course',
    description: 'Finish the course in Udemy and get a certificate',
    status: TaskStatus.Pending,
    dueDate: new Date(),
  },
  {
    id: 1,
    name: 'Udemy course',
    description: 'Finish the course in Udemy and get a certificate',
    status: TaskStatus.InProgress,
    dueDate: new Date(),
  },
  {
    id: 1,
    name: 'Udemy course',
    description: 'Finish the course in Udemy and get a certificate',
    status: TaskStatus.Done,
    dueDate: new Date(),
  },
  {
    id: 1,
    name: 'Udemy course',
    description: 'Finish the course in Udemy and get a certificate',
    status: TaskStatus.ToDo,
    dueDate: new Date(),
  },
]);

const formatDate = (date: Date) => {
  return date.toLocaleDateString(undefined, {
    year: 'numeric',
    month: 'short',
    day: 'numeric',
  });
};


</script>