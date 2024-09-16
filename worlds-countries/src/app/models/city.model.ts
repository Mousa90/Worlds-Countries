export interface City {
    id: number;
    name: string;
    countryId: number;
}

export interface AddCity {
    name: string | undefined;
    countryId: number | undefined;
}