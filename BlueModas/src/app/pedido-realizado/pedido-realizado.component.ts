import { Component, OnInit } from '@angular/core';
import { StoregeProvider } from '../providers/storege';
import { ApiService } from '../service/api/api.service';
import { ModalService } from '../service/serviceModal/modal.service';

@Component({
  selector: 'app-pedido-realizado',
  templateUrl: './pedido-realizado.component.html',
  styleUrls: ['./pedido-realizado.component.css'],
  providers: [StoregeProvider]
})
export class PedidoRealizadoComponent implements OnInit {

  Cliente: any;
  Compras: any;
  Produtos: any;

  constructor(
    private modalService: ModalService,
    private apiService: ApiService,
    private storegeProvider: StoregeProvider) {
  }

  ngOnInit(): void {
    this.RetornaId();
  }

  RetornaId() {
    ApiService.pedidoFinalizado.subscribe(e => {
      this.RetornaCliente(e);
    });
  }


  RetornaCliente(cliente) {
    this.apiService.RetornarClienteId(cliente).subscribe(
      data => {
        this.Cliente = data
        data.compras.forEach(element => {
          this.Compras = element
        });
      })
  }

  onClose() {
    console.log(localStorage.getItem('carrinho'));
    this.modalService.onClose();
    localStorage.removeItem('carrinho');
    ApiService.carrinho.emit(0);
  }

  FormataPreco(preco) {
    return `R$ ${preco.toString().replace(".", ",")}`;
  }
}
