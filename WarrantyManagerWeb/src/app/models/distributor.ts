import { Customer } from "./customer";
import { SystemUser } from "./systemuser";

export interface Distributor {
  id?: string;
  name: string;
  customers: Customer[];
  users: SystemUser[]
}
