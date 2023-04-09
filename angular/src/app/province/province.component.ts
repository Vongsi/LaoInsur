import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ProvinceDto, ProvinceService } from '@proxy/territories/provinces';
import { query } from '@angular/animations';
import { CountryDto, CountryService } from '@proxy/territories/countries';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class ProvinceComponent implements OnInit {

  country = {items: [], totalCount: 0} as PagedResultDto<CountryDto>;
  province = {items: [], totalCount: 0} as PagedResultDto<ProvinceDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedProvince = {} as ProvinceDto;

  constructor(
    public readonly list: ListService,
    private countryService: CountryService,
    private provinceService: ProvinceService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const countryStreamCreator = (query) => this.countryService.getList(query);
    const provinceStreamCreator = (query) => this.provinceService.getList(query);

    this.list.hookToQuery(countryStreamCreator).subscribe((response) => {
      this.country = response;
    });

    this.list.hookToQuery(provinceStreamCreator).subscribe((response) => {
      this.province = response;
    });
  }

  createProvince() {
    this.selectedProvince = {} as ProvinceDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editProvince(id: string) {
    this.provinceService.get(id).subscribe((province) => {
      this.selectedProvince = province;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      code: [this.selectedProvince.code || '', Validators.required],
      nameEng: [this.selectedProvince.nameEng || '', Validators.required],
      nameLao: [this.selectedProvince.nameLao || '', Validators.required],
      descriptionEng: [this.selectedProvince.descriptionEng || '', Validators.required],
      descriptionLao: [this.selectedProvince.descriptionLao || '', Validators.required],
      postalCode: [this.selectedProvince.postalCode || '', Validators.required],
      isO2Codes: [this.selectedProvince.isO2Codes || '', Validators.required],
      isO3Codes: [this.selectedProvince.isO3Codes || '', Validators.required],
      countryId: [this.selectedProvince.countryDto?.id|| null, Validators.required],
      countryDto: [this.selectedProvince.countryDto || null],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedProvince.id) {
      this.provinceService
        .update(this.selectedProvince.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.provinceService.create(this.form.value).subscribe(() => {
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
            this.provinceService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }

}
