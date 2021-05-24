import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Produtos } from '../interface/produtos';
import { StoregeProvider } from '../providers/storege';
import { ApiService } from '../service/api/api.service';

@Component({
  selector: 'app-compras',
  templateUrl: './compras.component.html',
  styleUrls: ['./compras.component.css'],
  providers: [StoregeProvider]
})
export class ComprasComponent implements OnInit {

  constructor(private modalService: BsModalService, private storegeProvider: StoregeProvider) { }

  modalRef: BsModalRef;

  Produtos: Produtos[];

  total: any = 0;

  ngOnInit(): void {
    this.Produtos = JSON.parse(this.storegeProvider.getCarinho());
    this.SomaProdutos();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  RemoverProduto(produto) {
    let pos = this.Produtos.indexOf(produto);
    this.Produtos.splice(pos, 1)
    this.storegeProvider.setCarrinho(this.Produtos)
    ApiService.carrinho.emit(this.storegeProvider.qtdProdutos())
    this.SubProdutos(produto);
    this.Produtos = JSON.parse(this.storegeProvider.getCarinho());
  }

  FormataPreco(preco) {
    return `R$ ${preco.toString().replace(".", ",")}`;
  }

  SomaProdutos() {
    this.Produtos.forEach(e => {
      this.total +=  e.preco
    })
  }

  SubProdutos(produto) {
     this.total -=  produto.preco
  
  }
}
