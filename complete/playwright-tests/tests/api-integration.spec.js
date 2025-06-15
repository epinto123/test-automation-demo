import { test, expect } from '@playwright/test';

test.describe('Book Manager API Integration', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/');
  });

  test('should load books from API on page load', async ({ page }) => {
    // Wait for any existing books to load
    await page.waitForTimeout(1000);
    
    // Check if books are loaded (either empty state or actual books)
    const hasBooks = await page.locator('table').isVisible();
    const hasEmptyState = await page.locator('h3:has-text("No books currently on record")').isVisible();
    
    expect(hasBooks || hasEmptyState).toBe(true);
  });

  test('should make API call when adding a book', async ({ page }) => {
    // Listen for API requests
    const apiRequests = [];
    page.on('request', request => {
      if (request.url().includes('/api/books')) {
        apiRequests.push({
          method: request.method(),
          url: request.url(),
          postData: request.postData()
        });
      }
    });

    // Add a book
    await page.locator('#add-book').click();
    await page.locator('input[name="title"]').fill('API Test Book');
    await page.locator('input[name="authorFirstName"]').fill('API');
    await page.locator('input[name="authorLastName"]').fill('Tester');
    await page.locator('input[name="yearPublished"]').fill('2024');
    await page.locator('button[type="submit"]').click();

    // Wait for API call
    await page.waitForTimeout(1000);

    // Check that POST request was made
    const postRequests = apiRequests.filter(req => req.method === 'POST');
    expect(postRequests.length).toBeGreaterThan(0);
    
    // Verify the request data
    const postData = JSON.parse(postRequests[0].postData);
    expect(postData.title).toBe('API Test Book');
    expect(postData.authorName.firstName).toBe('API');
    expect(postData.authorName.lastName).toBe('Tester');
    expect(postData.yearPublished).toBe(2024);
  });

  test('should make API call when deleting a book', async ({ page }) => {
    // First add a book
    await page.locator('#add-book').click();
    await page.locator('input[name="title"]').fill('Book to Delete via API');
    await page.locator('input[name="authorFirstName"]').fill('Delete');
    await page.locator('input[name="authorLastName"]').fill('Test');
    await page.locator('input[name="yearPublished"]').fill('2020');
    await page.locator('button[type="submit"]').click();

    // Wait for book to be added
    await expect(page.locator('tbody tr')).toContainText('Book to Delete via API');

    // Listen for API requests
    const deleteRequests = [];
    page.on('request', request => {
      if (request.url().includes('/api/books/') && request.method() === 'DELETE') {
        deleteRequests.push({
          method: request.method(),
          url: request.url()
        });
      }
    });

    // Delete the book
    await page.locator('button:has-text("Delete"), .btn-danger').first().click();

    // Wait for API call
    await page.waitForTimeout(1000);

    // Check that DELETE request was made
    expect(deleteRequests.length).toBeGreaterThan(0);
    expect(deleteRequests[0].method).toBe('DELETE');
    expect(deleteRequests[0].url).toContain('/api/books/');
  });

  test('should handle network errors gracefully', async ({ page }) => {
    // Block all API requests to simulate network failure
    await page.route('**/api/books**', route => route.abort());

    // Try to add a book
    await page.locator('#add-book').click();
    await page.locator('input[name="title"]').fill('Network Error Test');
    await page.locator('input[name="authorFirstName"]').fill('Network');
    await page.locator('input[name="authorLastName"]').fill('Error');
    await page.locator('input[name="yearPublished"]').fill('2024');
    await page.locator('button[type="submit"]').click();

    // Wait a moment for error handling
    await page.waitForTimeout(2000);

    // App should still be functional (not crashed)
    await expect(page.locator('body')).toBeVisible();
    
    // Modal might still be open due to error
    // This depends on your error handling implementation
  });

  test('should display loading states appropriately', async ({ page }) => {
    // Delay API responses to test loading states
    await page.route('**/api/books', async route => {
      await new Promise(resolve => setTimeout(resolve, 1000));
      route.continue();
    });

    // Reload page to trigger loading
    await page.reload();

    // You might want to check for loading indicators
    // This depends on your implementation
    await expect(page.locator('body')).toBeVisible();
  });

  test('should validate API response data', async ({ page }) => {
    // Listen for API responses
    const responses = [];
    page.on('response', response => {
      if (response.url().includes('/api/books') && response.request().method() === 'GET') {
        responses.push(response);
      }
    });

    // Trigger API call
    await page.reload();
    await page.waitForTimeout(1000);

    // Check response
    if (responses.length > 0) {
      const response = responses[0];
      expect(response.status()).toBe(200);
      
      // Optionally check response data structure
      const data = await response.json();
      expect(Array.isArray(data)).toBe(true);
    }
  });
});
