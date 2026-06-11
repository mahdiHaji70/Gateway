export enum PlaceTypes {
  OpenArea = 1,
  ClosedArea = 2,
  Sule = 3,
  Silo = 4,
  Hive = 5,
}

export const placeTypesDropdown = Object.keys(PlaceTypes)
.filter((key) => isNaN(Number(key)))
.map((key) => ({
  name: key,
  value: PlaceTypes[key as keyof typeof PlaceTypes]
}));