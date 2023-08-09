import type {TaskStatus} from "@/models/TaskStatus";

export interface TaskItem {
    id: number;
    name: string;
    description: string;
    status: TaskStatus;
    dueDate: Date;
}