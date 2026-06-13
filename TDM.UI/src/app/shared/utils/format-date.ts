export function formatDate(date: Date): string {
    if (date) {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
        const day = String(date.getDate()).padStart(2, '0');

        return `${year}-${month}-${day}`;
    }
    return '';
}

export function formatUTCDate(date: Date): string {
    if (date) {
        return new Date(Date.UTC(
              date.getFullYear(),
              date.getMonth(),
              date.getDate(),
              0, 0, 0, 0
            )).toISOString();        
    }
    return '';
}