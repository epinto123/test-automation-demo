import React from 'react';
import { Modal, Button, Form } from 'react-bootstrap';

function AddBook(props) {
  const {
    show,
    handleClose,
    title,
    authorFirstName,
    authorLastName,
    yearPublished,
    handleChange,
    handleBookSubmit,
   } = props;

  return (
    <>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header>
          <Modal.Title>Add a new book</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form id="addBook" onSubmit={handleBookSubmit}>
            <Form.Label>Title</Form.Label>
            <Form.Control
              type="text"
              name="title"
              value={title}
              id="btitle"
              onChange={handleChange}
              required
            />

            <Form.Label>Author First Name</Form.Label>
            <Form.Control
              type="text"
              name="authorFirstName"
              value={authorFirstName}
              id="afirstname"
              onChange={handleChange}
              required
            />

            <Form.Label>Author Last Name</Form.Label>
            <Form.Control
              type="text"
              name="authorLastName"
              value={authorLastName}
              id="alastname"
              onChange={handleChange}
              required
            />

            <Form.Label>Year Published</Form.Label>
            <Form.Control
              type="number"
              name="yearPublished"
              id="byearpublished"
              value={yearPublished}
              onChange={handleChange}
              min={1}
              required
            />
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button id="close-book-modal-button" variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button id="add-book-button" form="addBook" type="submit" variant="primary" data-type="add">Add</Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default AddBook;
