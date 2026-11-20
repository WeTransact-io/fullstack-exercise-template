import { expect, test } from 'vitest'
import { render, screen } from '@testing-library/react'
import App from './App'

// Proves the test setup works. Add your own tests next to your components.
test('renders', () => {
  render(<App />)
  expect(screen.getByRole('heading', { name: 'Usage' })).toBeInTheDocument()
})
