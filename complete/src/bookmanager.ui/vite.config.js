import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    host: '0.0.0.0', // Bind to all interfaces for Docker
    port: 5173, // Vite's default port
    open: false // Don't auto-open in Docker
  },
  build: {
    outDir: 'build'
  },
  resolve: {
    extensions: ['.js', '.jsx', '.ts', '.tsx']
  }
})
