import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  teste = 'lol';
  produtos = ['Produto 1', 'Produto 2', 'Produto 3'];

  constructor() { }

  ngOnInit() {
  }

}
