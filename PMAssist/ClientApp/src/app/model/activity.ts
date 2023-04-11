export interface Activity {
  createdOn: Date;
  closedOn?: Date;
  id?: string;
  linkID?: string;
  what: string;
  type: string;
  client: boolean;
  plan: number;
  totalSpent?: number;
  actual?: number;
  status: string;
}
