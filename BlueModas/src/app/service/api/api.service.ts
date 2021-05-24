import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  static pesquisaProduto = new EventEmitter<string>();
  static carrinho = new EventEmitter<number>();
  static pedidoFinalizado = new EventEmitter<any[]>();

  UrlApi: string = `${environment.UrlApi}`;

  constructor(private _http: HttpClient) { }

  retornaProdutos() {
    return this._http.get<any>(`${this.UrlApi}/Produtos`);
  }

  pesquisarProdutos(produto) {
    return this._http.get<any>(`${this.UrlApi}/Produtos/nome/${produto}`);
  }

  ProdutosId(id) {
    return this._http.get<any>(`${this.UrlApi}/Produtos/${id}`);
  }

  cadastraCliente(cliente){
    return this._http.post<any>(`${this.UrlApi}/Clientes`, cliente);
  }

  inserirCompra(compras){
    return this._http.post<any>(`${this.UrlApi}/Compras`, compras);
  }

  RetornarClienteId(email){
    return this._http.get<any>(`${this.UrlApi}/Clientes/${email}`);
  }

  pesquisaNavBar(produto){
    ApiService.pesquisaProduto.emit(produto)
  }

  inserirEmail(email){
    ApiService.pedidoFinalizado.emit(email)
  }

} 
