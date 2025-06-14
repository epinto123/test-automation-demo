export const getBooks = () => fetch(
  `${import.meta.env.VITE_API_URL || 'http://localhost:5001'}/api/books`,
  {
    method: 'GET',
    mode: 'cors',
    redirect: 'follow',
  },
)
  .then((response) => response.json())
  .then((books) => books.map(({ title, id, authorName: { firstName, lastName }, yearPublished }) => ({
    title,
    id,
    authorFirstName: firstName,
    authorLastName: lastName,
    yearPublished })));

export const addBook = (book) => fetch(
  `${import.meta.env.VITE_API_URL || 'http://localhost:5001'}/api/books`,
  {
    method: 'POST',
    mode: 'cors',
    redirect: 'follow',
    body: JSON.stringify(book),
    headers: {
      'Content-Type': 'application/json',
    },
  },
)
  .then((response) => response.json());

export const deleteBook = (id) => fetch(
  `${import.meta.env.VITE_API_URL || 'http://localhost:5001'}/api/books/${id}`,
  {
    method: 'DELETE',
    mode: 'cors',
    redirect: 'follow',
  },
)
  .then((response) => response.text());

const endpoints = {
  getBooks,
  addBook,
  deleteBook,
};

export default endpoints;
