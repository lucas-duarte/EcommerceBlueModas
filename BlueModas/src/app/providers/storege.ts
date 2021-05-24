import { Injectable } from "@angular/core";

let carrinho = 'carrinho';
let cliente = 'cliente';

@Injectable()
export class StoregeProvider {

    constructor() { }

    getCarinho(): any {

        let car = localStorage.getItem(carrinho);

        if(car == null){
            return '[]';
        }
        return car;
    }

    setCarrinho(produtos) {
        localStorage.setItem(carrinho, JSON.stringify(produtos));
    }

    qtdProdutos() {

        let qtd: any[] = JSON.parse(this.getCarinho())
        if (qtd == null) {
            return 0
        } else {
            return qtd.length
        }
    }

    setCliente(cliente){
        localStorage.setItem(cliente, JSON.stringify(cliente));
    }

    getCliente(){
        return localStorage.getItem(cliente);
    }
}
