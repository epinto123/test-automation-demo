# Automation Testing 
This project demonstrates how to do automated testing using a simple book manager application. 

# Getting Started
The `lab_01` directory has the project without any automated tests and the `complete` directory provides sample automated
tests. For simplicity, the automation exercise directory will also include the unit test for the backend services.

The project runs automated tests using [selenium](https://www.selenium.dev/) against a dockerized stack containing a UI in ReactJS, a backend using .NET 6, and [docker images for selenium grid server](https://github.com/SeleniumHQ/docker-selenium).

Dependencies
1. NPM
1. Yarn
1. .NET 6.0
1. Docker

# How to run automated Tests

```
yarn install
```

```
yarn test
```

To take a look at the video showing the UI test automation in the ```test/BookManager.Acceptance.Tests/Artifacts``` directory

# How to stand up the book manager application

```
yarn install
```
### To bring up the running container instances
```
yarn docker:bookmanager:up
```

### To shut down the running container instances

```
yarn docker:bookmanager:down
```

***Note: If you are using the application with your browser and not running the acceptance tests, change `REACT_APP_API_URL` in the `docker-compose.testing.yml` file to `http://localhost:5001` or you will get a `cors` error.***

# Exercise

Write automated tests that show a working UI by implementing the following tests

```
Given I want to add a book
When I add a book
Then the book should render on the screen
```

```
Given I want to delete a book
When I delete a book
Then the book should be removed from the screen
```
