import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Account } from 'src/app/Models/Account';
import { AccountsService } from 'src/app/Service/accounts.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {
  idUsuario: any;
  loading: boolean = false;
  listAccount?: Account[];
  deposit: FormGroup;
  sal: any;
  item:any;
  pageSize:any;
  page:any;
  cuenta:any;
  constructor(private router: Router,
    private route: ActivatedRoute,
    private accountsService: AccountsService,
    private modalService: NgbModal,
    private fb: FormBuilder) {
    this.deposit = this.fb.group({
      saldo: ['', Validators.required]
    });
    this.pageSize=7;
    this.page=1;
  }

  ngOnInit(): void {
    this.idUsuario = this.route.snapshot.paramMap.get('id');
    this.getAccounts();
  }


  getAccounts() {
    this.loading = true;
    this.accountsService.getAccounts(parseInt(this.idUsuario)).subscribe(data => {
      this.loading = false;
      this.listAccount = data;
      this.item=data.length;
    });
  }

  deposito(content: any, sal: any) {
    this.sal = sal.saldo;
    this.cuenta=sal.idCuenta;

    this.deposit.patchValue({
      saldo: sal.saldo,
    });

    this.modalService.open(content, { size: 'lg' });
  }

  retiro(content1: any, sal: any) {
    this.sal = sal;
    this.cuenta=sal.idCuenta;
    this.deposit.patchValue({
      saldo: sal.saldo
    });
    this.modalService.open(content1, { size: 'lg' });
  }

  edit(trans: any,content2: any) {
    const deposit: Account = {
      IdCliente: parseInt(this.idUsuario),
      saldo: parseInt(this.deposit.get('saldo')?.value),
      fecha: new Date(),
      tipoTransaccion: trans,
      idCuenta:this.cuenta
    };
    this.accountsService.saveAccounts(deposit).subscribe(data => {
      this.sal = data.saldo;
      if (data.tipoTransaccion == 3) {
        this.modalService.dismissAll();
        this.message(content2);
      } else {
        this.modalService.dismissAll();
        this.accountsService.getAccounts(parseInt(this.idUsuario)).subscribe(data => {
          this.loading = false;
          this.listAccount = data;
        });
      }


    });
  }

  message(content2:any) {
    this.modalService.open(content2, { size: 'lg' });
    this.accountsService.getAccounts(parseInt(this.idUsuario)).subscribe(data => {
      this.loading = false;
      this.listAccount = data;
    });
  }
}
