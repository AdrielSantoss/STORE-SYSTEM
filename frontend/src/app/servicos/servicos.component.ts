import { Component } from '@angular/core';

export interface PeriodicElement {
  id: number;
  nome: string;
  tipo: string;
  preco: number;
  quantidade: number;
  codigoBarras: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    id: 1,
    nome: 'Hydrogen',
    tipo: 'INFORMÁTICA',
    preco: 1.0079,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 2,
    nome: 'Helium',
    tipo: 'INFORMÁTICA',
    preco: 4.0026,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 3,
    nome: 'Lithium',
    tipo: 'INFORMÁTICA',
    preco: 6.941,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 4,
    nome: 'Hydrogen',

    tipo: 'INFORMÁTICA',
    preco: 9.0122,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 5,
    nome: 'Boron',
    tipo: 'INFORMÁTICA',
    preco: 10.811,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 6,
    nome: 'Hydrogen',
    tipo: 'INFORMÁTICA',
    preco: 12.0107,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 7,
    nome: 'Hydrogen',
    tipo: 'INFORMÁTICA',
    preco: 14.0067,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 8,
    nome: 'Hydrogen',
    tipo: 'INFORMÁTICA',
    preco: 15.9994,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 9,
    nome: 'Hydrogen',
    tipo: 'INFORMÁTICA',
    preco: 18.9984,
    quantidade: 15,
    codigoBarras: 123456,
  },
  {
    id: 10,
    nome: 'Hydrogen',
    tipo: 'INFORMÁTICA',
    preco: 20.1797,
    quantidade: 15,
    codigoBarras: 123456,
  },
];

@Component({
  selector: 'app-servicos',
  templateUrl: './servicos.component.html',
})
export class ServicosComponent {
  displayedColumns: string[] = [
    'id',
    'nome',
    'tipo',
    'preco',
    'quantidade',
    'codigoBarras',
    'acao',
  ];
  dataSource = ELEMENT_DATA;
  constructor() {}

  addServico() {}
}
