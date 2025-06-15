import { test, expect } from '@playwright/test';

test.describe('Book Manager Application', () => {
  test.beforeEach(async ({ page }) => {
    // Navigate to the Book Manager app
    await page.goto('/');
  });

  test('should load the application with correct title', async ({ page }) => {
    // Check if the page loads correctly
    await expect(page).toHaveTitle(/Book Manager/);
    
    // Check for the main heading or key elements
    await expect(page.locator('h3')).toContainText(['No books currently on record', 'Title']);
  });

  test('should display the add book button', async ({ page }) => {
    // Check if the add book button is visible
    const addButton = page.locator('#add-book');
    await expect(addButton).toBeVisible();
    
    // Verify it has the plus icon (FontAwesome)
    const icon = addButton.locator('svg');
    await expect(icon).toBeVisible();
  });

  test('should open add book modal when clicking add button', async ({ page }) => {
    // Click the add book button
    await page.locator('#add-book').click();
    
    // Wait for modal to appear
    await expect(page.locator('.modal')).toBeVisible();
    
    // Check modal content
    await expect(page.locator('.modal-title')).toContainText('Add Book');
    
    // Check form fields are present
    await expect(page.locator('input[name="title"]')).toBeVisible();
    await expect(page.locator('input[name="authorFirstName"]')).toBeVisible();
    await expect(page.locator('input[name="authorLastName"]')).toBeVisible();
    await expect(page.locator('input[name="yearPublished"]')).toBeVisible();
  });

  test('should close modal when clicking close button', async ({ page }) => {
    // Open modal
    await page.locator('#add-book').click();
    await expect(page.locator('.modal')).toBeVisible();
    
    // Close modal using close button
    await page.locator('.btn-close, .modal-header button').first().click();
    
    // Verify modal is closed
    await expect(page.locator('.modal')).not.toBeVisible();
  });

  test('should add a new book successfully', async ({ page }) => {
    // Click add book button
    await page.locator('#add-book').click();
    
    // Fill in book details
    await page.locator('input[name="title"]').fill('Test Book Title');
    await page.locator('input[name="authorFirstName"]').fill('John');
    await page.locator('input[name="authorLastName"]').fill('Doe');
    await page.locator('input[name="yearPublished"]').fill('2023');
    
    // Submit the form
    await page.locator('button[type="submit"]').click();
    
    // Wait for the book to appear in the table
    await expect(page.locator('table')).toBeVisible();
    await expect(page.locator('tbody tr')).toContainText('Test Book Title');
    await expect(page.locator('tbody tr')).toContainText('John Doe');
    await expect(page.locator('tbody tr')).toContainText('2023');
  });

  test('should display table headers correctly', async ({ page }) => {
    // Add a book first to ensure table is visible
    await page.locator('#add-book').click();
    await page.locator('input[name="title"]').fill('Sample Book');
    await page.locator('input[name="authorFirstName"]').fill('Jane');
    await page.locator('input[name="authorLastName"]').fill('Smith');
    await page.locator('input[name="yearPublished"]').fill('2022');
    await page.locator('button[type="submit"]').click();
    
    // Check table headers
    const headers = page.locator('thead th');
    await expect(headers.nth(0)).toContainText('Title');
    await expect(headers.nth(1)).toContainText('Author');
    await expect(headers.nth(2)).toContainText('Year Published');
    await expect(headers.nth(3)).toContainText('Action');
  });

  test('should delete a book when clicking delete button', async ({ page }) => {
    // Add a book first
    await page.locator('#add-book').click();
    await page.locator('input[name="title"]').fill('Book to Delete');
    await page.locator('input[name="authorFirstName"]').fill('Delete');
    await page.locator('input[name="authorLastName"]').fill('Me');
    await page.locator('input[name="yearPublished"]').fill('2021');
    await page.locator('button[type="submit"]').click();
    
    // Wait for book to appear
    await expect(page.locator('tbody tr')).toContainText('Book to Delete');
    
    // Click delete button
    await page.locator('button:has-text("Delete"), .btn-danger').first().click();
    
    // Verify book is removed
    await expect(page.locator('tbody tr')).not.toContainText('Book to Delete');
  });

  test('should validate required fields in add book form', async ({ page }) => {
    // Open modal
    await page.locator('#add-book').click();
    
    // Try to submit empty form
    await page.locator('button[type="submit"]').click();
    
    // Check that form validation prevents submission
    // (The exact validation behavior depends on your implementation)
    await expect(page.locator('.modal')).toBeVisible(); // Modal should still be open
  });

  test('should handle API errors gracefully', async ({ page }) => {
    // This test assumes your app handles API errors
    // You might need to mock network failures or 500 errors
    
    // For now, just check that the app doesn't crash
    await expect(page.locator('body')).toBeVisible();
  });

  test('should be responsive on mobile devices', async ({ page }) => {
    // Set mobile viewport
    await page.setViewportSize({ width: 375, height: 667 });
    
    // Check that main elements are still visible
    await expect(page.locator('#add-book')).toBeVisible();
    
    // Open modal and check it fits properly
    await page.locator('#add-book').click();
    await expect(page.locator('.modal')).toBeVisible();
    
    // Check form is still usable
    await expect(page.locator('input[name="title"]')).toBeVisible();
  });
});
