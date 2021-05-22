import { Role } from './Role';

export interface User {
    id: number;
    name: string;
    surname: string;
    email: string;
    role: Role;
}
