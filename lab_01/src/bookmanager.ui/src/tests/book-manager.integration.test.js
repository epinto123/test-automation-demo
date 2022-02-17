import React from 'react';
import { render, waitFor, fireEvent, screen, configure } from '@testing-library/react';
import { act } from 'react-dom/test-utils';

import BookManager from '../book-manager';

configure({ testIdAttribute: 'data-id' });

describe('BookManager', () => {
  it('renders book entries', async () => {

    const { getByText } = render(<BookManager />);

    await waitFor(() => getByText(/Brave New World/i));
    await waitFor(() => getByText(/1932/i));
    await waitFor(() => getByText(/Aldous/i));
    await waitFor(() => getByText(/Huxley/i));
  });

  it('renders no entries when rendered book is deleted', async () => {

    const { getByText } = render(<BookManager />);

    await act(async () => {
      fireEvent.click(await waitFor(() => screen.findByTestId('9dd84450-05a2-464c-bb9c-e70729dd4a0a')));
    });

    await waitFor(() => getByText(/No books currently on record/i));
  });
});
