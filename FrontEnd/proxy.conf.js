const { env } = require("process");

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_HTTPS_URLS
  ? env.ASPNETCORE_HTTPS_URLS.split(";")[0]
  : "https://localhost:7217";

console.log("> proxy target: " + target);

const PROCY_CONFIG = [
  {
    context: ["/api"],
    target: "https://localhost:7217",
    secure: false,
  },
];

module.exports = PROCY_CONFIG;
