import { User } from "./User";
export interface Log{
    id: string;
    name?: string;
    userId: string;
    status: string;
    createdAt: Date;
    user?: User;
}

