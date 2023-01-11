import { Component } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-produto-modal',
  templateUrl: './add-produto-modal.component.html',
})
export class AddProdutoModalComponent {
  constructor(public modal: NgbActiveModal) {}
}
