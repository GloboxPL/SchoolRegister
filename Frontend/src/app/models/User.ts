import { Role } from './Role';

export interface User {
    id: number;
    name: string;
    surname: string;
    email: string | null;
    role: Role | null;
}
