import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Customer } from '../../../models/customer';
import { Warranty } from '../../../models/warranty';
import { CustomerService } from '../../../services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {


  customers: Customer[] = [];
  selectedCustomer!: Customer;
  selectedWarranty!: Warranty;


  panelOpenState = false;

  constructor(private customerService:CustomerService) { }

  ngOnInit(): void {
    this.customerService
      .getAllCustomers()
      .subscribe(
        (res) => {

          
          this.customers = res;

        },
        (err) => {
          console.log(err);
        }
      );
  }

  selectCustomer(customer: Customer) {
    this.selectedCustomer = customer;
    console.log(this.selectedCustomer);

  }

  selectWarranty(warranty: Warranty) {
    this.selectedWarranty = warranty;
    console.log(this.selectedWarranty);

  }


}
