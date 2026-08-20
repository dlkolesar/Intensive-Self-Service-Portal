import { ApiDocsModule } from './api-docs.module';

describe('ApiDocsModule', () => {
  let apiDocsModule: ApiDocsModule;

  beforeEach(() => {
    apiDocsModule = new ApiDocsModule();
  });

  it('should create an instance', () => {
    expect(apiDocsModule).toBeTruthy();
  });
});
