// Import necessary components from react-bootstrap for creating a responsive navigation bar
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

// Define the Navigation component
function Navigation() {
  return (
    // Create a Navbar component with a light background and expand on large screens
    <Navbar bg="light" expand="lg">
      <Container>
        {/* Navbar brand that acts as a link to the home page */}
        <Navbar.Brand href="/">Feuds, Beefs, and Diss Tracks</Navbar.Brand>
        {/* Toggle button for collapsing the navbar on smaller screens */}
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        {/* Collapsible part of the navbar */}
        <Navbar.Collapse id="basic-navbar-nav">
          {/* Nav component to hold the navigation links */}
          <Nav className="me-auto">
            {/* Links to the other pages */}
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="About">About</Nav.Link>
            <Nav.Link href="Browse">Browse</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default Navigation;