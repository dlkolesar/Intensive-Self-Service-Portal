import { AdObject } from "./adObject";

export enum ADMigrationType { GroupMigration, UserMigration, ComputerMigration }

export class AdMigrationRequest {
    account: number;
    migrationType: ADMigrationType;
    objects: AdObject[];
    options: string;
}
