import React from 'react';
import { render, screen } from '@testing-library/react';
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
      handleBookDeleteClick: jest.fn(),
    };

    render(<table><tbody><Book {...props} /></tbody></table>);

    expect(await screen.findByText(props.title)).toBeInTheDocument();
    expect(await screen.findByText(`${props.authorFirstName} ${props.authorLastName}`)).toBeInTheDocument();
    expect(await screen.findByText(props.yearPublished)).toBeInTheDocument();
  });
});
