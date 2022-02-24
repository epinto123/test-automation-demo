export const getBooks = () => fetch(
  `${process.env.REACT_APP_API_URL}/api/books`,
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
  `${process.env.REACT_APP_API_URL}/api/books`,
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
  `${process.env.REACT_APP_API_URL}/api/books/${id}`,
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
