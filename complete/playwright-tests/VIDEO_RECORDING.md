# Playwright Video Recording Configuration

## Video Recording Options

Playwright supports several video recording modes:

### 1. **Record All Tests** (Current Configuration)
```javascript
video: {
  mode: 'on',
  size: { width: 1280, height: 720 }
}
```
- Records video for every test run
- Best for debugging and demo purposes
- Larger storage footprint

### 2. **Record Only Failed Tests**
```javascript
video: {
  mode: 'retain-on-failure',
  size: { width: 1280, height: 720 }
}
```
- Only keeps videos when tests fail
- Saves storage space
- Good for CI/CD pipelines

### 3. **Record on First Retry**
```javascript
video: {
  mode: 'on-first-retry',
  size: { width: 1280, height: 720 }
}
```
- Records video only when a test fails and retries
- Minimal storage impact
- Useful for intermittent failures

### 4. **No Video Recording**
```javascript
video: 'off'
```
- Disables video recording entirely
- Fastest execution
- No storage overhead

## Video Output

Videos are saved in:
- **Location**: `test-results/` directory
- **Format**: `.webm` files
- **Naming**: `video.webm` per test
- **Resolution**: Configurable (default: 1280x720)

## Usage Examples

```bash
# Run tests with video recording (headed mode)
yarn test:with-video

# Run tests with video only on failures
yarn test:video-failures-only

# View generated videos in the HTML report
yarn report
```

## Video in HTML Reports

Videos are automatically embedded in the HTML test reports when available. You can:
1. Run tests: `yarn test`
2. Open report: `yarn report` 
3. Click on any test to see screenshots, traces, and videos

## Performance Considerations

- **Video recording adds overhead** (~10-20% slower execution)
- **File sizes**: ~1-5MB per minute of test execution
- **Best practice**: Use `retain-on-failure` in CI/CD for balance of debugging capability and storage efficiency
