export function toPascalCase(input: string): string {
    return input
        .replace(/([a-z])([A-Z])/g, '$1 $2')
        .split(/[\s-_]+/)
        .map(word => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
        .join(' ');
}