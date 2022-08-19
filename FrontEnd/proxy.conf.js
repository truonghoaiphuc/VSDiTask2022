const { env } = require("process");

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_HTTPS_URLS
  ? env.ASPNETCORE_HTTPS_URLS.split(";")[0]
  : "https://localhost:7218";

console.log("> proxy target: " + target);

const PROXY_CONFIG = [
  {
    context: ["/api"],
    target: target,
    secure: false,
  },
];

module.exports = PROXY_CONFIG;
