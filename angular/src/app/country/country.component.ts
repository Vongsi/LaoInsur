import { ListService, PagedResultDto } from '@abp/ng.core';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { query } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryDto, CountryService } from '@proxy/territories/countries';
import { ContinentDto, ContinentService } from '@proxy/territories/continents';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss'],
  providers: [ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }]
})
export class CountryComponent implements OnInit {

  continent = { items: [], totalCount: 0 } as PagedResultDto<ContinentDto>;
  country = { items: [], totalCount: 0 } as PagedResultDto<CountryDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedCountry = {} as CountryDto;

  constructor(
    public readonly list: ListService,
    private continentService: ContinentService,
    private countryService: CountryService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    //
    const continentStreamCreator = (query) => this.continentService.getList(query);

    this.list.hookToQuery(continentStreamCreator).subscribe((response) => {
      this.continent = response;
    });

    //
    const countryStreamCreator = (query) => this.countryService.getList(query);

    this.list.hookToQuery(countryStreamCreator).subscribe((response) => {
      this.country = response;
    });
  }

  createCountry() {
    this.selectedCountry = {} as CountryDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editCountry(id: string) {
      this.countryService.get(id).subscribe((country) => {
      this.selectedCountry = country;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      code: [this.selectedCountry.code || '', Validators.required],
      nameEng: [this.selectedCountry.nameEng || '', Validators.required],
      nameLao: [this.selectedCountry.nameLao || '', Validators.required],
      descriptionEng: [this.selectedCountry.descriptionEng || '', Validators.required],
      descriptionLao: [this.selectedCountry.descriptionLao || '', Validators.required],
      postalCode: [this.selectedCountry.postalCode || '', Validators.required],
      isO2Codes: [this.selectedCountry.isO2Codes || '', Validators.required],
      isO3Codes: [this.selectedCountry.isO3Codes || '', Validators.required],
      continentId: [this.selectedCountry.continentDto?.id || '', Validators.required],
      continentDto: [this.selectedCountry.continentDto || null],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedCountry.id) {
      this.countryService
        .update(this.selectedCountry.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.countryService.create(this.form.value).subscribe(() => {
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
            this.countryService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }

}
