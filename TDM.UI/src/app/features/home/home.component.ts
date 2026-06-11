import { Component } from '@angular/core';
import { HomeService } from './services/home.service';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { ChartModule } from 'primeng/chart';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  providers: [HomeService],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  stores: any;
  chartData: any;
  chartData2: any;
  chartOptions: any;
  chartOptions2: any;
  /**
   *
   */
  constructor(private homeService: HomeService) {
    this.chartData = {
      labels: Array.from({ length: 20 }, (_, i) => `Day ${i + 1}`),
      datasets: [
        {
          label: 'Weight (kg)',
          data: Array.from({ length: 20 }, () => Math.floor(Math.random() * 10)),
          backgroundColor: '#42A5F5',
          borderColor: '#1E88E5',
          borderWidth: 1,
        },
      ],
    };

    this.chartData2 = {
      labels: Array.from({ length: 7 }, (_, i) => `Day ${i + 1}`),
      datasets: [
        {
          label: 'Weight (kg)',
          data: Array.from({ length: 7 }, () => Math.floor(Math.random() * 4)),
          backgroundColor: '#42A5F5',
          borderColor: '#1E88E5',
          borderWidth: 1,
        },
      ],
    };

    this.chartOptions = {
      responsive: true,
      plugins: {
        legend: { display: true, position: 'top' },
      },
      scales: {
        y: { beginAtZero: true, title: { display: true, text: 'Weight (kg)' } },
        x: {
          title: { display: true, text: 'Day of Month' }
        },
      },
    };

    this.chartOptions2 = {
      responsive: true,
      plugins: {
        legend: { display: true, position: 'top' },
      },
      scales: {
        y: { beginAtZero: true, title: { display: true, text: 'Ton (ton)' } },
        x: {
          title: { display: true, text: 'Days of Discharge' }
        },
      },
    };
  }

  ngOnInit() {
    this.stores = this.homeService.getStores();
  }
}
