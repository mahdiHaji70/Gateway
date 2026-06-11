export function getEnumOptions(enumObj: any): { name: string; value: number }[] {
    return Object.keys(enumObj)
    .filter((key) => isNaN(Number(key))) 
    .map((key) => ({
        name: key,  
      value:  enumObj[key as keyof typeof enumObj] as number, 
    }));
}