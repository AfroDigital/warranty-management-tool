import { Warranty } from "./warranty";

export interface Customer {
  id?: string;
  name: string;
  warranties: Warranty[];
}



