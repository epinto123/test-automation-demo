import React from 'react';
import { render, waitFor, fireEvent, screen, configure } from '@testing-library/react';

import BookManager from '../book-manager';

configure({ testIdAttribute: 'data-id' });

describe('BookManager', () => {
  it('renders book entries', async () => {
    render(<BookManager />);

    expect(await screen.findByText('Brave New World')).toBeInTheDocument();
    expect(await screen.findByText('1932')).toBeInTheDocument();
    expect(await screen.findByText('Aldous Huxley')).toBeInTheDocument();
  });

  it('renders no entries when rendered book is deleted', async () => {
    render(<BookManager />);

    fireEvent.click(await waitFor(() => screen.findByTestId('9dd84450-05a2-464c-bb9c-e70729dd4a0a')));

    expect(await screen.findByText('No books currently on record')).toBeInTheDocument();
  });
});
