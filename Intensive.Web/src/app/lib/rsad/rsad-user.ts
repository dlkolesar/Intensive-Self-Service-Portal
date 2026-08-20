 export class rsadUser {
    server: string;
    timestamp: string;
    data: Data;
  }
  export class Data {
    badLogonCount: number;
    businessCategory: string;
    c: string;
    co: string;
    contingentWorker: string;
    continuousServiceDateStr: string;
    CORE_contactID: string;
    CORE_crmID: string;
    CORE_employeeID: string;
    costCenter: string;
    costCenterDescription: string;
    costCenterL1: string;
    costCenterL2: string;
    costCenterL3: string;
    costCenterL4: string;
    countryCode: string;
    department: string;
    departmentNumber: string;
    directSupervisorEmail: string;
    division: string;
    employeeID: string;
    employeeStatus: string;
    employeeType: string;
    ExponentHRID: string;
    gidNumber: number;
    givenName: string;
    ipPhone: string;
    isAccountEnabled: boolean;
    isAccountLockedOut: boolean;
    isManager: boolean;
    jobCode: string;
    l: string;
    lastBadPasswordAttempt: string;
    lastLogon: string;
    lastLogonTimeStamp: string;
    loginShell: string;
    mail: string;
    managementLevel: string;
    manager: Manager;
    managerWorkforceID: string;
    mobile: string;
    notary: boolean;
    passwordLastSet: string;
    passwordNeverExpires: boolean;
    photo: string;
    physicalDeliveryOfficeName: string;
    Strength1: string;
    Strength2: string;
    Strength3: string;
    Strength4: string;
    Strength5: string;
    supportTeam: string;
    surname: string;
    telephone: string;
    thumbnailPhoto: string;
    timezone: string;
    title: string;
    uid: string;
    uidNumber: string;
    unixHomeDirectory: string;
    userPrincipalName: string;
    workforceID: string;
    workShift: string;
    workStartDate: string;
    cn: string;
    displayName: string;
    distinguishedName: string;
    memberOf?: (rsadObject)[] | null;
    name: string;
    objectClass?: (string)[] | null;
    objectSID: string;
    samAccountName: string;
    userAccountControl: string;
    whenChanged: string;
    whenCreated: string;
  }
  export class Manager {
    distinguishedName: string;
    name: string;
    samAccountName: string;
    uid: string;
  }
  export class rsadObject {
    distinguishedName: string;
    name: string;
  }
  