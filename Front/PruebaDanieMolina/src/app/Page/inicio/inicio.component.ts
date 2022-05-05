import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Account } from 'src/app/Models/Account';
import { Customer } from 'src/app/Models/Customer';
import { AccountsService } from 'src/app/Service/accounts.service';
import { CustomerService } from 'src/app/Service/customer.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  listCustomer?: Customer[];
  loading = false;
  cuenta: FormGroup;
  numCuenta: any;
  usuario: any;
  constructor(private customerService: CustomerService,
    private modalService: NgbModal,
    private fb: FormBuilder,
    private accountsService: AccountsService) {
    this.cuenta = this.fb.group({
      saldo: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.getCustomer();
  }

  getCustomer() {
    this.loading = true;
    this.customerService.getCustomer().subscribe(data => {
      this.loading = false;
      this.listCustomer = data;

    });
  }

  crearCuenta(content2: any) {
    this.modalService.open(content2, { size: 'lg' });
  }
  saveCuenta(cuenta: any, content: any) {
    if (cuenta.nombres != null) {
      this.usuario = cuenta.nombres + "" + cuenta.apellidos;
    } else {
      this.usuario = cuenta.razonSocial;
    }

    const deposit: Account = {
      IdCliente: parseInt(cuenta.idCliente),
      saldo: 0.0,
      fecha: new Date(),
      tipoTransaccion: 4
    };
    this.accountsService.saveAccounts(deposit).subscribe(data => {
      this.numCuenta = data.idCuenta;
      this.message(content);
    });
  }

  message(content: any) {
    this.modalService.open(content, { size: 'lg' });
    this.customerService.getCustomer().subscribe(data => {
      this.loading = false;
      this.listCustomer = data;
    });
  }
}
