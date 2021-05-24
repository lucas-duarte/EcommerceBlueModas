import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { NavComponent } from './nav/nav.component';
import { ComprasComponent } from './compras/compras.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ModalModule } from 'ngx-bootstrap/modal';
import { CadastroComponent } from './cadastro/cadastro.component';
import { PedidoRealizadoComponent } from './pedido-realizado/pedido-realizado.component';
import { ModalComponent } from './modal/modal.component';

import { HttpClientModule } from '@angular/common/http';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ProdutosComponent,
    NavComponent,
    ComprasComponent,
    CadastroComponent,
    PedidoRealizadoComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    HttpClientModule,
    PopoverModule.forRoot(),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
