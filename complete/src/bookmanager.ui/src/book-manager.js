import React, { useState, useEffect } from 'react';
import { Table, Button, Container, Row, Col } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

import Book from './book';
import { getBooks, addBook, deleteBook } from './api/book-manager';
import AddBook from './add-book';

function BookManager() {
  const [books, setBooks] = useState([]);
  const [newBook, setNewBook] = useState({
    title: '',
    authorFirstName: '',
    authorLastName: '',
    yearPublished: 0,
  });
  const [show, setShow] = useState(false);

  useEffect(() => {
    getBooks().then(books => setBooks(books))
  }, []);

  const handleBookSubmit = (e) => {
    e.preventDefault();
    const { title, authorFirstName, authorLastName, yearPublished } = newBook;
    addBook({
      title: title,
      authorName: {
        firstName: authorFirstName,
        lastName: authorLastName
      },
      yearPublished: yearPublished,
    }).then(({ id }) => {
      setShow(false);
      setBooks(state => ([...state, { ...newBook, id }]));
      setNewBook(state => ({ ...state, title: '', authorFirstName: '', authorLastName: '', yearPublished: 0 }));
    });
  }

  const handleBookDeleteClick = (e) => {
    const { currentTarget: { dataset } } = e;

    deleteBook(dataset.id).then(() => {
      setBooks(state => {
        const bookIndex = state.findIndex(book => book.id === dataset.id);
        return [...books.slice(0, bookIndex), ...books.slice(bookIndex + 1)];
      });
    });
  }

  const handleChange = (e) => {
    const { target: { value, name } = {} } = e;

    setNewBook({ ...newBook, [name]: value });
  };

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <Container fluid>
      <Row style={{ marginTop: '20px' }}>
        <Col md={10} />
        <Col md={2}>
          <Button id="add-book" onClick={handleShow}><FontAwesomeIcon icon={faPlus} /></Button>
          <AddBook
            show={show}
            handleClose={handleClose}
            {...newBook}
            handleBookSubmit={handleBookSubmit}
            handleChange={handleChange}
            />
        </Col>
      </Row>
      <Row>
        <Col md={1} />
        <Col md={10}>
          {books.length > 0 ? (<Table striped bordered hover style={{ marginTop: '20px' }}>
            <thead>
              <tr style={{ textAlign: 'left' }}>
                <th>Title</th>
                <th>Author's Name</th>
                <th>Year Published</th>
                <th />
              </tr>
            </thead>
            <tbody>
              {books.map(book => (
                <Book
                  key={book.id}
                  {...book}
                  isAdd={false}
                  handleBookDeleteClick={handleBookDeleteClick}
                />))}
            </tbody>
          </Table>) : (<h3>No books currently on record</h3>)}
        </Col>
        <Col md={1} />
      </Row>
    </Container>
  );
}

export default BookManager;
