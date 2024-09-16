export interface Country {
    id: number;
    name: string;
    description: string;
    imageUrl: string;
    flagUrl: string;
}

export interface AddCountry {
    name: string | undefined;
    description: string | undefined;
    imageUrl: string | undefined;
    flagUrl: string | undefined;
}