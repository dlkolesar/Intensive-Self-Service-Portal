// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

import {version} from '../../package.json';


const apiServer = "https://test.api.selfservice.intensive.int";
const apiVersion = "v1";
const azureAppId = 'bb489372-cfa1-4f8a-9fc2-490bd6946395';
const azureTenantId = '570057f4-73ef-41c8-bcbb-08db2fc15c2b';

export const environment = {
  production: true,
  siteTitle: "Intensive Self-Service Portal(TEST)",
  appVersion: version,

//internal api endpoints  
  apiCommon:   apiServer + "/common/" + apiVersion,
  apiAD:       apiServer + "/ad/" + apiVersion,
  apiRSAD:     apiServer + "/edir/" + apiVersion,
  apiWinPatch: apiServer + "/winpatch/" + apiVersion,
  apiAric:     apiServer + "/aric/" + apiVersion,
  apiAuditing: apiServer + "/auditing/" + apiVersion,
  apiCORE:     apiServer + "/core/" + apiVersion,
  apiDocs:     apiServer + "/docs/" + apiVersion,
 
//external API endpoints
  //apiARICEvents: "https://automation.api.rackspacecloud.com/internal/events",
  apiIdentityToken: "https://identity-internal.api.rackspacecloud.com/v2.0/tokens",
  apiIdentitySAML: "https://identity-internal.api.rackspacecloud.com/v2.0/RAX-AUTH/federation/saml/auth/",

  //ADFS: "https://sts.rackspace.com/adfs/ls/idpinitiatedsignon.aspx?RelayState=RPID%3Dtest.selfservice.intensive.int%26RelayState%3D",
  ADFS: "https://myapps.microsoft.com/signin/" + azureAppId + "?tenantId=" + azureTenantId + "&RelayState=",
  apiRackspaceAD: "https://api.identity.rackspace.corp/v1.0/ad",


  //must have the trailing / ========================================v
  winPatchCallbackURL: apiServer + "/aric/" + apiVersion + '/jobs/',

  AdDomains: ["intensive","dfw", "fra", "hkg", "iad", "lon", "ord", "syd", "globalrs"],
  RackerDomains: ["intensive"],
  CustomerDomains: ["dfw", "fra", "hkg", "iad", "lon", "ord", "syd", "globalrs"]
};
