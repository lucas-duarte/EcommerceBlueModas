import { Component, OnInit, TemplateRef } from '@angular/core';
import { StoregeProvider } from '../providers/storege';
import { ApiService } from '../service/api/api.service';
import { ModalService } from '../service/serviceModal/modal.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  providers: [StoregeProvider]
})
export class NavComponent implements OnInit {

  Carrinho: []
  Qtd: number;

  constructor(
    private apiService: ApiService,
    private modalService: ModalService,
    private storegeProvider: StoregeProvider
  ) { }

  ngOnInit(): void {
    this.Qtd = this.storegeProvider.qtdProdutos();
    ApiService.carrinho.subscribe(data => {
      this.Qtd = data
    })
  }

  openModal() {
    this.modalService.openModal();
  }

  PesquisarProdutos(event: any) {
    this.apiService.pesquisaNavBar(event.target.value);
  }

}
