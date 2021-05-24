import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastroComponent } from './cadastro/cadastro.component';
import { ComprasComponent } from './compras/compras.component';
import { ModalComponent } from './modal/modal.component';
import { PedidoRealizadoComponent } from './pedido-realizado/pedido-realizado.component';

const routes: Routes = [
  { path: 'modal', component: ModalComponent },
  { path: 'compras', component: ComprasComponent },
  { path: 'compras/cadastro', component: CadastroComponent },
  { path: 'compras/cadastro/pedido-realizado', component: PedidoRealizadoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
