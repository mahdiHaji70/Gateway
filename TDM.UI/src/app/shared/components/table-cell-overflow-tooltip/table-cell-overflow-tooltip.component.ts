import { CommonModule } from '@angular/common';
import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-table-cell-overflow-tooltip',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './table-cell-overflow-tooltip.component.html',
  styleUrl: './table-cell-overflow-tooltip.component.scss'
})
export class TableCellOverflowTooltipComponent {
  text = '';
  left = 0;
  top = 0;
  private hoveredCell: HTMLTableCellElement | null = null;

  @HostListener('document:pointerover', ['$event'])
  onPointerOver(event: PointerEvent): void {
    const cell = this.getTableCell(event.target);
    if (!cell || cell.scrollWidth <= cell.clientWidth + 1) {
      this.clear();
      return;
    }

    const text = cell.innerText.trim();
    if (!text) {
      this.clear();
      return;
    }

    this.hoveredCell = cell;
    this.text = text;
    this.updatePosition(event);
  }

  @HostListener('document:pointerout', ['$event'])
  onPointerOut(event: PointerEvent): void {
    const fromCell = this.getTableCell(event.target);
    const toCell = this.getTableCell(event.relatedTarget);
    if (fromCell === this.hoveredCell && toCell !== fromCell) {
      this.clear();
    }
  }

  private getTableCell(target: EventTarget | null): HTMLTableCellElement | null {
    return target instanceof Element
      ? target.closest<HTMLTableCellElement>('.p-datatable-table th, .p-datatable-table td')
      : null;
  }

  private updatePosition(event: PointerEvent): void {
    const maxWidth = Math.min(512, window.innerWidth - 16);
    const maxHeight = Math.min(window.innerHeight * 0.6, 320);
    const right = event.clientX + 14;
    const below = event.clientY + 18;
    this.left = right + maxWidth <= window.innerWidth - 8
      ? right
      : Math.max(8, event.clientX - maxWidth - 14);
    this.top = below + maxHeight <= window.innerHeight - 8
      ? below
      : Math.max(8, event.clientY - maxHeight - 18);
  }

  private clear(): void {
    this.hoveredCell = null;
    this.text = '';
  }
}
