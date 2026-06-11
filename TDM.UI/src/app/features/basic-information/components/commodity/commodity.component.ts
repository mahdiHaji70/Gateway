import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Commodity } from '../../models/commodity.model';

@Component({
  selector: 'app-commodity',
  templateUrl: './commodity.component.html',
  styleUrl: './commodity.component.scss'
})
export class CommodityComponent {
  id?: any;

  form = new FormGroup({
    name: new FormControl<string>(''),
    hsCode: new FormControl<string>('', Validators.pattern(/^\d{8}$/))
  });

  /**
   *
   */
  constructor(private basicInformationService: BasicInformationService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.route.params.subscribe((params: any) => {
      if (params.id) {
        this.id = params.id;
        this.basicInformationService.getById('commodities', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const commodity: Commodity = new Commodity(
      this.form.get('name')?.value!,
      this.form.get('hsCode')?.value!,
      this.id
    );

    const commodityAction$ = this.id
      ? this.basicInformationService.putBasicInformation('commodities', commodity)
      : this.basicInformationService.postBasicInformation('commodities', commodity);

    commodityAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/commodity-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
