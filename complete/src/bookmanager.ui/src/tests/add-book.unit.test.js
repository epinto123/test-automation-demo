import React from 'react';
import { render, screen, configure } from '@testing-library/react';
import faker from '@faker-js/faker';

import AddBook from '../add-book';

configure({ testIdAttribute: 'id' });

describe('AddBook', () => {
  it('should render fields to submit book information if modal is opened', async () => {
    const props = {
      title: faker.lorem.sentence(),
      authorFirstName: faker.name.firstName(),
      authorLastName: faker.name.lastName(),
      yearPublished: faker.date.past().getFullYear(),
      show: true,
      handleChange: jest.fn(),
      handleBookSubmit: jest.fn()
    };

    render(<AddBook {...props} />);

    expect(await screen.findByTestId('btitle')).toBeInTheDocument();
    expect(await screen.findByTestId('afirstname')).toBeInTheDocument();
    expect(await screen.findByTestId('alastname')).toBeInTheDocument();
    expect(await screen.findByTestId('byearpublished')).toBeInTheDocument();
  });

  it('should be submitable if all values are provided', async () => {
    const props = {
      title: faker.lorem.sentence(),
      authorFirstName: faker.name.firstName(),
      authorLastName: faker.name.lastName(),
      yearPublished: faker.date.past().getFullYear(),
      show: true,
      handleChange: jest.fn(),
      handleBookSubmit: jest.fn()
    };

    render(<AddBook {...props} />);

    expect(await screen.findByTestId('btitle')).toHaveValue(props.title);
    expect(await screen.findByTestId('afirstname')).toHaveValue(props.authorFirstName);
    expect(await screen.findByTestId('alastname')).toHaveValue(props.authorLastName);
    expect(await screen.findByTestId('byearpublished')).toHaveValue(props.yearPublished);
  });
});
