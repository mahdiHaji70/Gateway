export enum ContactTypes {
    Person = 1,
    Company = 2,
    Tourist = 3,
}

export const contactTypesDropdown = Object.keys(ContactTypes)
.filter((key) => isNaN(Number(key)))
.map((key) => ({
  name: key,
  value: ContactTypes[key as keyof typeof ContactTypes]
}));