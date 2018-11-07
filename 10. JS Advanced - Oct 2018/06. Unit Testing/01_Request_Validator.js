function validateRequest(request) {
  const uriPattern = /^(\.*[A-Za-z0-9]+)+$/;
  const messagePattern = /^([^<>\\&'"]+)$/;
  const validMethods = ["GET", "POST", "DELETE", "CONNECT"];
  const validVersions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];

  let validUri = (request.uri === "*" || uriPattern.test(request.uri)) && request.uri;
  let validMessage = (messagePattern.test(request.message) || request.message === "") && request.message !== undefined;

  if (!validMethods.includes(request.method)) {
    throw new Error("Invalid request header: Invalid Method");
  };

  if (!validUri) {
    throw new Error("Invalid request header: Invalid URI");
  };

  if (!validVersions.includes(request.version)) {
    throw new Error("Invalid request header: Invalid Version")
  };

  if (!validMessage) {
    throw new Error("Invalid request header: Invalid Message");
  };

  return request;
}

validateRequest({
  method: 'GET',
  uri: 'svn.public.catalog',
  version: 'HTTP/1.1',
  message: ''
});