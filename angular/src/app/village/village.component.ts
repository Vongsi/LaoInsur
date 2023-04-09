import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { DistrictDto, DistrictService } from '@proxy/territories/districts';
import { VillageDto, VillageService } from '@proxy/territories/villages';

@Component({
  selector: 'app-village',
  templateUrl: './village.component.html',
  styleUrls: ['./village.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class VillageComponent implements OnInit {

  district = {items: [], totalCount: 0} as PagedResultDto<DistrictDto>;
  village = {items: [], totalCount: 0} as PagedResultDto<VillageDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedVillage = {} as VillageDto;

  constructor(
    public readonly list: ListService,
    private districtService: DistrictService,
    private villageService: VillageService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const villageStreamCreator = (query) => this.villageService.getList(query);
    const districtStreamCreator = (query) => this.districtService.getList(query);

    this.list.hookToQuery(districtStreamCreator).subscribe((response) => {
      this.district = response;
    });

    this.list.hookToQuery(villageStreamCreator).subscribe((response) => {
      this.village = response;
    });
  }

  createVillage() {
    this.selectedVillage = {} as VillageDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editVillage(id: string) {
    this.villageService.get(id).subscribe((response) => {
      this.selectedVillage = response;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      code: [this.selectedVillage.code || '', Validators.required],
      nameEng: [this.selectedVillage.nameEng || '', Validators.required],
      nameLao: [this.selectedVillage.nameLao || '', Validators.required],
      descriptionEng: [this.selectedVillage.descriptionEng || '', Validators.required],
      descriptionLao: [this.selectedVillage.descriptionLao || '', Validators.required],
      postalCode: [this.selectedVillage.postalCode || '', Validators.required],
      districtId: [this.selectedVillage.districtDto?.id|| null, Validators.required],
      districtDto: [this.selectedVillage.districtDto || null],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    console.log(this.form.value);

    if (this.selectedVillage.id) {
      this.villageService
        .update(this.selectedVillage.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.villageService.create(this.form.value).subscribe(() => {
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
            this.villageService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }

}
