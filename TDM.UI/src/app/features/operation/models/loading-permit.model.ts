export class LoadingPermit {
  id: string;
  terminal: string;
  date: Date;
  serialno: string;
  ownerName: string;
  ownerRepName: string;
  expirationDate: Date;
  terminalCode: string;

  constructor(
    id: string,
    terminal: string,
    date: Date,
    serialno: string,
    ownerName: string,
    ownerRepName: string,
    expirationDate: Date,
    terminalCode: string
  ) {
    this.id = id;
    this.terminal = terminal;
    this.date = date;
    this.serialno = serialno;
    this.ownerName = ownerName;
    this.ownerRepName = ownerRepName;
    this.expirationDate = expirationDate;
    this.terminalCode = terminalCode;
  }
}
