import { defineConfig } from 'vitest/config'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  // The API runs on http://localhost:5163 (dotnet run in backend/Api).
  server: { proxy: { '/api': 'http://localhost:5163' } },
  test: { environment: 'jsdom', setupFiles: './src/test-setup.ts' },
})
