import { rest } from 'msw';

import { books } from '../test-data';

const addResponse = (_, res, ctx) => res(ctx.json(books));
const deleteResponse = (_, res, ctx) => res(ctx.text(''));

export const handlers = [
  rest.get('/api/books', addResponse),
  rest.delete('/api/books/*', deleteResponse)
];

export default {
  handlers,
};
