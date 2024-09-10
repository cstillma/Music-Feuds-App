import React from 'react'; 
import ReactDOM from 'react-dom/client'; // Import the ReactDOM library for rendering React components to the DOM
import './index.css';
import App from './App';
import 'bootstrap/dist/css/bootstrap.min.css';

const root = ReactDOM.createRoot(document.getElementById('root'));  // Create a root element to render the React application
// Render the App component inside the root element, wrapped in React.StrictMode for highlighting potential problems
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

