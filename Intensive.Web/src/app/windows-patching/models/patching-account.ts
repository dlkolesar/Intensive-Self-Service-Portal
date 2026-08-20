
import { AccountData } from '../../lib/account';

export class PatchingAccount extends AccountData {
   optedOut: boolean;
   optInOutDate: Date;
   optInOutTicket: string;
   optedOutOfTicketing: boolean;
   lastRefresh: Date;
   
}
