export enum CargoTypes {
    LiquidBulk = 1,
    GeneralCargo = 2,
    Container = 3,
    BulkCago = 4,
    Cars = 5,
}

export const cargoTypesDropdown = Object.keys(CargoTypes)
.filter((key) => isNaN(Number(key)))
.map((key) => ({
  name: key,
  value: CargoTypes[key as keyof typeof CargoTypes]
}));