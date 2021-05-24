import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ModalComponent } from 'src/app/modal/modal.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {

  constructor(private modalService: BsModalService) { }
  openModal() {
    const bsModalRef: BsModalRef = this.modalService.show(ModalComponent);
  }

  onClose() {
    this.modalService.hide();
  }
}
