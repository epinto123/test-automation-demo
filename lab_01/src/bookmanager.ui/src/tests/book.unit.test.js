import React from 'react';
import { render, waitFor, screen } from '@testing-library/react';
import faker from '@faker-js/faker';

import Book from '../book';

describe('Book', () => {
  it('renders single book details', async () => {
    const props = {
      title: faker.lorem.sentence(),
      authorFirstName: faker.name.firstName(),
      authorLastName: faker.name.lastName(),
      yearPublished: faker.date.past().getFullYear(),
      id: faker.datatype.uuid(),
      handleBookDeleteClick: jest.fn()
    };

    render(<table><tbody><Book {...props} /></tbody></table>);

    await waitFor(() => screen.getByText(props.title));
    await waitFor(() => screen.getByText(props.authorFirstName));
    await waitFor(() => screen.getByText(props.authorLastName));
    await waitFor(() => screen.getByText(props.yearPublished));
  });
});
