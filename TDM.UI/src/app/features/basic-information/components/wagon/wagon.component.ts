import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BasicInformationService } from '../../services/basic-information.service';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Wagon } from '../../models/wagon.model';

@Component({
  selector: 'app-wagon',
  templateUrl: './wagon.component.html',
  styleUrl: './wagon.component.scss'
})
export class WagonComponent {
id?: any;

  form = new FormGroup({
    code: new FormControl<string>('')
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
        this.basicInformationService.getById('Wagon', this.id).subscribe((res: any) => {
          this.form.patchValue(res.data);
        });
      }

    });

  }

  onSubmit(): void {
    if (!this.form.valid) {
      return;
    }

    const wagon: Wagon = new Wagon(
      this.form.get('code')?.value!,
      this.id
    );

    const wagonAction$ = this.id
      ? this.basicInformationService.putBasicInformation('Wagon', wagon)
      : this.basicInformationService.postBasicInformation('Wagon', wagon);

    wagonAction$
      .subscribe({
        next: (res: any) => {
          this.messageService.add({ severity: 'success', summary: `Successfully ${this.id ? 'updated' : 'added'}` });
          this.router.navigate(['/wagon-list'])
        },
        error: (error: any) => {
          this.messageService.add({ severity: 'error', summary: 'Operation failed', detail: error.message });
        }
      }
      );
  }
}
