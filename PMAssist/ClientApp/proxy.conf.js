const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:31549';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/authorize",
      "/leaveinformation",
      "/leaveinformation/addevent",
      "/leaveinformation/deleteevent",
      "/leaveinformation/getleaves",
      "/scrum",
      "/scrum/getscrumkey",
      "/scrum/getsprint",
      "/scrum/getsprintbykey",
      "/story",
      "/story/addactivity",
      "/story/updateactivity",
      "/project",
      "/project/getscrumkey",
      "/user"
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
