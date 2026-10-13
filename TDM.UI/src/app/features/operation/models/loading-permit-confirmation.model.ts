export class LoadingPermitConfirmation {
  permitId: string = '';
  terminalCode: string = '';
  isApproved: boolean = false;
  description: string = '';

  constructor(init?: Partial<LoadingPermitConfirmation>) {
    Object.assign(this, init);
  }
}
