export interface Warranty {
  customerId?: string;
  serialNumber: string;
  isWarrantied: boolean;
  purchaseDate: Date;
  warrantyEndDate: Date;
  productName: string;
}
