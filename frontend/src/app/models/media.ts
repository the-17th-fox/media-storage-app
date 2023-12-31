export interface MediaDto {
    sizeHorizontal: number;
    sizeVertical: number;
    sizeInKb: number;
    source: string;
    onCloudDrive: boolean;
    likesAmount: number;
    rating: MediaRating;
    moderationStatus: MediaModerationStatus;
    parentMediaId: number;
    mediaType: MediaType;
    isNew: boolean;
}

export enum MediaRating {
    SFW = 100,
    NSFW = 200
}

export enum MediaModerationStatus {
    AwaitingApprove = 100,
	Suspended = 200,
	Approved = 300,
}

export enum MediaType {
    Image = 100,
    Video = 200,
    Gif = 300
}