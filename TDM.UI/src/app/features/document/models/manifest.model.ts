import { ManifestItemDto } from "./manifest-item.model";

export class ManifestDto {
    serialNo?: string;
    manifestRegistrationNumber?: string;
    voyageNo?: string;
    noticeNo?: string;
    eta?: Date | string;
    etd?: Date | string;
    shipLine?: string;
    shipAgent?: string;
    shipAgentNationalId?: string;
    vesselName?: string;
    imo?: string;
    terminalCode?: string;
    manifestItems: ManifestItemDto[] = [];
}