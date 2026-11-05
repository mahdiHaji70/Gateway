import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { DeclarationService } from '../../../services/declaration.service';
import { DeclarationFull } from '../../../models/declaration-full.model';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownOption } from '../../../../../shared/models/drop-down-option-model';
import { BasicInformationService } from '../../../../basic-information/services/basic-information.service';
import { showApiError } from '../../../../../shared/services/api-error-handler.service';

@Component({
  selector: 'app-declaration-list',
  templateUrl: './declaration-list.component.html',
  styleUrl: './declaration-list.component.scss'
})
export class DeclarationListComponent {
  declarations: DeclarationFull[] = [];
  totalRecords = 0;
  pageSize = 10;
  currentPage = 1;
  showFilters = false;
  trafficOptions: DropdownOption[] = [];
  consigneeOptions: DropdownOption[] = [];
  consigneeRepOptions: DropdownOption[] = [];

  filtersForm = new FormGroup({
    search: new FormControl<string>(''),
    dateFrom: new FormControl<Date | null>(null),
    dateTo: new FormControl<Date | null>(null),
    traffic: new FormControl<DropdownOption | null>(null),
    consignee: new FormControl<DropdownOption | null>(null),
    consigneeRep: new FormControl<DropdownOption | null>(null)
  });

  /**
   *
   */
  constructor(private router: Router,
    private messageService: MessageService,
    private declarationService: DeclarationService,
    private basicInformationService: BasicInformationService) {
  }

  ngOnInit() {
  }

  loadDeclarations(pageNumber: number = this.currentPage, pageSize: number = this.pageSize) {
    this.currentPage = pageNumber;
    this.pageSize = pageSize;

    const filters = this.getSelectedFilters();
    this.declarationService.getDeclarations(pageNumber, pageSize, filters).subscribe({
      next: (res: any) => {
        this.totalRecords = res.data.totalCount;
        this.declarations = res.data.items.map((item: any) => 
          new DeclarationFull(item.id!, item.number, item.date, item.startDate, item.endDate, item.trafficId,
            item.trafficName, item.consigneeId, item.consigneeName, item.description, item.ipasDeclarationNo,
            item.consigneeRepId, item.consigneeRepName));
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  toggleFilters() {
    this.showFilters = !this.showFilters;
    if (this.showFilters) {
      if (!this.trafficOptions.length) this.loadTrafficOptions();
      if (!this.consigneeOptions.length) this.loadCompanyOptions('consignee');
      if (!this.consigneeRepOptions.length) this.loadCompanyOptions('consigneeRep');
    }
  }

  loadTrafficOptions(search: string = '') {
    this.basicInformationService.getLookup('Traffics', search).subscribe({
      next: (res: any) => {
        this.trafficOptions = (res.data?.items || []).map((item: any) => new DropdownOption(item.id, item.name));
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  loadCompanyOptions(target: 'consignee' | 'consigneeRep', search: string = '') {
    this.basicInformationService.getLookup('Companies', search).subscribe({
      next: (res: any) => {
        const options = (res.data?.items || []).map((item: any) => new DropdownOption(item.id, item.name));
        if (target === 'consignee') this.consigneeOptions = options;
        else this.consigneeRepOptions = options;
      },
      error: (error: any) => showApiError(this.messageService, error)
    });
  }

  applyFilters() {
    this.loadDeclarations(1, this.pageSize);
  }

  clearFilters() {
    this.filtersForm.reset({ search: '', dateFrom: null, dateTo: null, traffic: null, consignee: null, consigneeRep: null });
    this.loadDeclarations(1, this.pageSize);
  }

  private getSelectedFilters() {
    const values = this.filtersForm.getRawValue();
    return {
      search: values.search || undefined,
      trafficId: values.traffic?.id,
      consigneeId: values.consignee?.id,
      consigneeRepId: values.consigneeRep?.id,
      dateFrom: values.dateFrom,
      dateTo: values.dateTo
    };
  }

  onPageChange(event: any) {
    const pageNumber = Math.floor(event.first / event.rows) + 1;
    this.loadDeclarations(pageNumber, event.rows);
  }

  onAdd() {
    this.router.navigate(['/document/declaration']);
  }

  onEdit(id: any) {
    this.router.navigate(['/document/declaration', id]);
  }
}
