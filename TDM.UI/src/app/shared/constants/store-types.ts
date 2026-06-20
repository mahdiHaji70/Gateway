export enum StoreTypes {
  OpenArea = 1,
  ClosedArea = 2,
  Sule = 3,
  Silo = 4,
  Hive = 5,
}

export const storeTypesDropdown = Object.keys(StoreTypes)
.filter((key) => isNaN(Number(key)))
.map((key) => ({
  name: key,
  value: StoreTypes[key as keyof typeof StoreTypes]
}));