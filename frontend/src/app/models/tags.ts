export interface TagDto {
    name: string;
    category: TagCategory
}

export enum TagCategory {
    General = 100,
	Author = 200,
	Character = 300,
	Genre = 400,
	Quality = 500
}