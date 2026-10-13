export class VesselLoadingPermitConfirmation {
  id: string = '';
  terminalCode: string = '';
  isApproved: boolean = false;
  remark: string = '';

  constructor(init?: Partial<VesselLoadingPermitConfirmation>) {
    Object.assign(this, init);
  }
}
