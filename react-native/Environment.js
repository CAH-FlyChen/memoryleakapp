const ENV = {
  dev: {
    apiUrl: 'http://localhost:44390',
    oAuthConfig: {
      issuer: 'http://localhost:44390',
      clientId: 'MemoryLeakTest_App',
      clientSecret: '1q2w3e*',
      scope: 'MemoryLeakTest',
    },
    localization: {
      defaultResourceName: 'MemoryLeakTest',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44390',
    oAuthConfig: {
      issuer: 'http://localhost:44390',
      clientId: 'MemoryLeakTest_App',
      clientSecret: '1q2w3e*',
      scope: 'MemoryLeakTest',
    },
    localization: {
      defaultResourceName: 'MemoryLeakTest',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
