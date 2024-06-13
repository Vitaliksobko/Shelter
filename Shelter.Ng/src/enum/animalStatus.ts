export enum AnimalStatus {
    Available,
    InProcess,
    Adopted 
}

export function getAnimalStatusOptions() {
    return Object.keys(AnimalStatus).filter(key => isNaN(Number(key)));
}

export function AnimalStatusStringToValue(status: string): string {
    switch (status) {
        case "Available":
            return '0';
        case "InProcess":
            return '1';
        case "Adopted":
            return '2';    
        default:
            return "undefined"
    }
}

export function AnimalStatusValueToString(value: number): string {
    switch (value) {
        case 0:
            return "Available";
        case 1:
            return "InProcess";
        case 2:
            return "Adopted";
        default:
            return "undefined"
    }
}
