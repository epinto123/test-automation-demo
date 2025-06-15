# Book Manager Playwright Tests

This directory contains end-to-end tests for the Book Manager application using Playwright.

## Prerequisites

1. **Book Manager Application**: Make sure your Book Manager app is running at `http://localhost:3001`
2. **API Backend**: Ensure the API is running and accessible
3. **Node.js**: Version 18 or higher

## Setup

1. Navigate to the playwright-tests directory:
   ```bash
   cd playwright-tests
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Install Playwright browsers:
   ```bash
   npm run install
   ```

## Running Tests

### Basic Test Execution
```bash
# Run all tests
npm test

# Run tests in headed mode (visible browser)
npm run test:headed

# Run tests with UI mode (interactive)
npm run test:ui

# Debug tests step by step
npm run test:debug
```

### Browser-Specific Tests
```bash
# Run only Chrome tests
npm run test:chrome

# Run only Firefox tests
npm run test:firefox

# Run only Safari tests
npm run test:safari

# Run mobile tests
npm run test:mobile
```

### View Test Reports
```bash
# Show HTML report
npm run report
```

## Test Files

### `book-manager.spec.js`
Core functionality tests including:
- Application loading
- Add book functionality
- Delete book functionality
- Form validation
- Modal interactions
- Responsive design

### `api-integration.spec.js`
API integration tests including:
- API request/response verification
- Network error handling
- Loading states
- Data validation

## Test Configuration

The tests are configured in `playwright.config.js` with:
- **Base URL**: `http://localhost:3001`
- **Multiple browsers**: Chrome, Firefox, Safari, Mobile
- **Screenshots**: On failure
- **Traces**: On retry
- **Parallel execution**: Enabled

## Writing New Tests

1. Create new `.spec.js` files in the `tests/` directory
2. Use the Playwright test API:
   ```javascript
   import { test, expect } from '@playwright/test';
   
   test('my test', async ({ page }) => {
     await page.goto('/');
     await expect(page.locator('h1')).toBeVisible();
   });
   ```

## CI/CD Integration

These tests are configured to work in CI environments with:
- Retry logic for flaky tests
- Single worker mode in CI
- Proper error reporting

## Troubleshooting

1. **Tests fail with "page not found"**: Ensure your app is running on `http://localhost:3001`
2. **API tests fail**: Check that your backend API is running and accessible
3. **Browser not found**: Run `npm run install` to install browsers
4. **Timeout issues**: Increase timeouts in `playwright.config.js` if needed

## Using with Playwright MCP

If you have Playwright MCP server configured in VS Code, you can:
1. Use the Playwright extension for better debugging
2. Generate tests using Playwright codegen
3. View test results in VS Code

## Best Practices

1. **Page Object Model**: Consider creating page objects for complex interactions
2. **Test Data**: Use factories or fixtures for test data
3. **Cleanup**: Ensure tests clean up after themselves
4. **Assertions**: Use specific assertions for better error messages
5. **Waiting**: Use `expect()` with auto-waiting instead of `waitForTimeout()`
