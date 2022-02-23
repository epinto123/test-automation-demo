import React from 'react';
import { Button } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash } from '@fortawesome/free-solid-svg-icons';

function Book(props) {
  const {
    title,
    authorFirstName,
    authorLastName,
    yearPublished,
    id,
    handleBookDeleteClick,
  } = props;

  return (
    <tr>
      <td>{title}</td>
      <td>{authorFirstName} {authorLastName}</td>
      <td>{yearPublished}</td>
      <td>
        <Button id="delete-book-button" data-id={id} variant="danger" onClick={handleBookDeleteClick}>
          <FontAwesomeIcon icon={faTrash} />
        </Button>
      </td>
    </tr>
  );
}

export default Book;
