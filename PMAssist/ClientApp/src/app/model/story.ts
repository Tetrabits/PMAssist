import { Activity } from "./activity";

export interface Story {
  authToken: string;
  sprintKey: string;
  linkType: string;
  linkKey: string;
  userKey: string;
  activity: Activity;
  spentOn: Date;
  howMuch: string;
}
