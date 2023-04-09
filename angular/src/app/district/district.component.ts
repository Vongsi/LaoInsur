import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ProvinceDto, ProvinceService } from '@proxy/territories/provinces';
import { DistrictDto, DistrictService } from '@proxy/territories/districts';

@Component({
  selector: 'app-district',
  templateUrl: './district.component.html',
  styleUrls: ['./district.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class DistrictComponent implements OnInit {

  province = {items: [], totalCount: 0} as PagedResultDto<ProvinceDto>;
  district = {items: [], totalCount: 0} as PagedResultDto<DistrictDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedDistrict = {} as DistrictDto;

  constructor(
    public readonly list: ListService,
    private provinceService: ProvinceService,
    private districtService: DistrictService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const provinceStreamCreator = (query) => this.provinceService.getList(query);
    const districtStreamCreator = (query) => this.districtService.getList(query);

    this.list.hookToQuery(provinceStreamCreator).subscribe((response) => {
      this.province = response;
    });

    this.list.hookToQuery(districtStreamCreator).subscribe((response) => {
      this.district = response;
    });
  }

  createProvince() {
    this.selectedDistrict = {} as DistrictDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editProvince(id: string) {
    this.districtService.get(id).subscribe((district) => {
      this.selectedDistrict = district;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      code: [this.selectedDistrict.code || '', Validators.required],
      nameEng: [this.selectedDistrict.nameEng || '', Validators.required],
      nameLao: [this.selectedDistrict.nameLao || '', Validators.required],
      descriptionEng: [this.selectedDistrict.descriptionEng || '', Validators.required],
      descriptionLao: [this.selectedDistrict.descriptionLao || '', Validators.required],
      postalCode: [this.selectedDistrict.postalCode || '', Validators.required],
      provinceId: [this.selectedDistrict.provinceDto?.id|| null, Validators.required],
      provinceDto: [this.selectedDistrict.provinceDto || null],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedDistrict.id) {
      this.districtService
        .update(this.selectedDistrict.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.districtService.create(this.form.value).subscribe(() => {
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
            this.districtService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }

}
