import { Component, OnInit } from '@angular/core';
import { Produtos } from '../interface/produtos';
import { StoregeProvider } from '../providers/storege';
import { ApiService } from '../service/api/api.service';


@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css'],
  providers: [StoregeProvider]
})
export class ProdutosComponent implements OnInit {

  Carinho: any[];
  Produtos: any;
  
  constructor(private apiService: ApiService, private storegeProvider: StoregeProvider) { }

  ngOnInit(): void {

    this.Carinho = JSON.parse(this.storegeProvider.getCarinho());

    this.PesquisaProduto();
    this.RetornaProdutos();
  }

  PesquisaProduto() {
    ApiService.pesquisaProduto.subscribe(data => {
      if (data) {
        this.apiService.pesquisarProdutos(data).subscribe(data => {
          this.Produtos = data;
        },
          error => {
            console.log("Erro: ", error)
          });
      } else {
        this.RetornaProdutos();
      }
    });

  }

  RetornaProdutos() {
    this.Produtos = this.apiService.retornaProdutos().subscribe(
      data => {
        this.Produtos = data;
      },
      error => {
        console.log("Erro: ", error)
      });
  }

  AdicionaCarinho(id){
    this.Carinho = JSON.parse(this.storegeProvider.getCarinho());
    alert('Produto adicionado ao carrinho!!!')
    this.Carinho.push(id)
    this.storegeProvider.setCarrinho(this.Carinho);
    ApiService.carrinho.emit(this.storegeProvider.qtdProdutos())
    this.Carinho = JSON.parse(this.storegeProvider.getCarinho());
  }

  FormataPreco(preco){
        return `R$ ${preco.toString().replace(".", ",")}`;
  }
} 
