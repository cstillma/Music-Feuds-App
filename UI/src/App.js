import './App.css';
// Import components used in the routes
import './Components/Navigation'
// import Navigation from './Components/Navigation'; // redundant import?
import Home from './Components/Home';
import About from './Components/About';
import Browse from './Components/Browse';
// Import necessary components from react-router-dom for routing
import { Route, Routes, BrowserRouter } from 'react-router-dom';

// Define the main App component
function App() {
  return (
    <div>
      {/* Render the Navigation component */}
      <Navigation />
      {/* Set up the router */}
      <BrowserRouter>
        <Routes>
          {/* Define the route for the Home component */}
          <Route path="/" element={<Home/>}/>
          {/* Define the route for the About component */}
          <Route path="/About" element={<About/>}/>
          {/* Define the route for the Browse component */}
          <Route path="/Browse" element={<Browse/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

// Export the App component as the default export
export default App;
