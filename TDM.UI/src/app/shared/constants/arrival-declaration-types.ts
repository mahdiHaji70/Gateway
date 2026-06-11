export enum ArrivalDeclarationTypes {
  Load = 1,
  Discharge = 2,
}

export const arrivalDeclarationTypesDropdown = Object.keys(ArrivalDeclarationTypes)
  .filter((key) => isNaN(Number(key)))
  .map((key) => ({
      name: key, // You can replace this with Farsi label if needed
      value: ArrivalDeclarationTypes[key as keyof typeof ArrivalDeclarationTypes],
  }));
