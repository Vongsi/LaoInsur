import { ListService, PagedResultDto } from '@abp/ng.core';
import { query } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { ContinentDto, ContinentService } from '@proxy/territories/continents';

import { FormGroup, FormBuilder, Validators } from '@angular/forms'; // add this

// added this line
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-continent',
  templateUrl: './continent.component.html',
  styleUrls: ['./continent.component.scss'],
  providers: [ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }]
})
export class ContinentComponent implements OnInit {
  continent = { items: [], totalCount: 0 } as PagedResultDto<ContinentDto>;

  selectedContinent = {} as ContinentDto; // declare ContinentDto

  form: FormGroup; // add this line

  isModalOpen = false; // add this line

  constructor(public readonly list: ListService, private continentService: ContinentService, private fb: FormBuilder, private confirmation: ConfirmationService) { }

  ngOnInit(): void {
    const continentStreamCreator = (query) => this.continentService.getList(query);

    this.list.hookToQuery(continentStreamCreator).subscribe((response) => {
      this.continent = response;
    });
  }

  // add new method
  createContinent() {
    this.selectedContinent = {} as ContinentDto; // reset the selected book
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

  // Add editBook method
  editContinent(id: string) {
    this.continentService.get(id).subscribe((continent) => {
      this.selectedContinent = continent;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  // Add a delete method
  deleteContinent(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.continentService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      iSO2Codes: [this.selectedContinent.isO2Codes || '', Validators.required],
      nameEng: [this.selectedContinent.nameEng || '', Validators.required],
      nameLao: [this.selectedContinent.nameLao || '', Validators.required],
      descriptionEng: [this.selectedContinent.descriptionEng || '', Validators.required],
      descriptionLao: [this.selectedContinent.descriptionLao || '', Validators.required],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedContinent.id ? this.continentService.update(this.selectedContinent.id, this.form.value)
      : this.continentService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
