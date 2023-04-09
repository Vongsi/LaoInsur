import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { AddressDto, AddressService } from '@proxy/territories/addresses';
import { VillageDto, VillageService } from '@proxy/territories/villages';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],

})
export class AddressComponent implements OnInit {

  village = {items: [], totalCount: 0} as PagedResultDto<VillageDto>;
  address = {items: [], totalCount: 0} as PagedResultDto<AddressDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedAddress = {} as AddressDto;

  constructor(
    public readonly list: ListService,
    private addressService: AddressService,
    private villageService: VillageService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const villageStreamCreator = (query) => this.villageService.getList(query);
    const addressStreamCreator = (query) => this.addressService.getList(query);

    this.list.hookToQuery(villageStreamCreator).subscribe((response) => {
      this.village = response;
    });

    this.list.hookToQuery(addressStreamCreator).subscribe((response) => {
      this.address = response;
    });
  }

  createAddress() {
    this.selectedAddress = {} as AddressDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editAddress(id: string) {
    this.addressService.get(id).subscribe((response) => {
      this.selectedAddress = response;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      houseNo: [this.selectedAddress.houseNo || '', Validators.required],
      unit: [this.selectedAddress.unit || '', Validators.required],
      street: [this.selectedAddress.street || '', Validators.required],
      alley: [this.selectedAddress.alley || ''],
      villageId: [this.selectedAddress.villageDto?.id|| null, Validators.required],
      villageDto: [this.selectedAddress.villageDto || null],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedAddress.id) {
      this.addressService
        .update(this.selectedAddress.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.addressService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.addressService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }

}
