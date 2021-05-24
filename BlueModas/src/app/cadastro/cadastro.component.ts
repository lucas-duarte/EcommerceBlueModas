import { Component, Input, OnInit } from '@angular/core';
import { EmailValidator, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Produtos } from '../interface/produtos';
import { StoregeProvider } from '../providers/storege';
import { ApiService } from '../service/api/api.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
  providers: [StoregeProvider]
})
export class CadastroComponent implements OnInit {

  //Compras: Produtos[];
  Cliente: any;
  Compras: any[];

  Pedido: any;

  public clienteForm: FormGroup
  public comprasForm: FormGroup


  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private storegeProvider: StoregeProvider,
    private apiService: ApiService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.Compras = JSON.parse(this.storegeProvider.getCarinho())
  }

  criarForm() {
    this.clienteForm = this.formBuilder.group({
      nome: ['', Validators.required],
      email: ['', Validators.required],
      telefone: ['', Validators.required]
    });

  }

  clienteSubmit() {

    this.Cliente = this.clienteForm.value;

    this.apiService.cadastraCliente(
      this.comprasJson(
        this.Cliente.email,
        this.Cliente.nome,
        this.Cliente.telefone,
        this.Compras
      )
    ).subscribe(e => {
      this.router.navigateByUrl('compras/cadastro/pedido-realizado');
      this.apiService.RetornarClienteId(this.Cliente.email).subscribe(data => {
        this.apiService.inserirEmail(this.Cliente.email)
      })
    })

  }

  comprasJson(id, nome, telefone, produto) {
    return {
      clienteId: id,
      nome: nome,
      telefone: telefone,
      compras: [
        {
          comprasProdutos: produto
        }
      ]
    }
  }


}
