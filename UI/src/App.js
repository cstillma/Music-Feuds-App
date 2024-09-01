import './App.css';
import './Components/Navigation'
import Navigation from './Components/Navigation';
import Home from './Components/Home';
import About from './Components/About';
import Browse from './Components/Browse';
import { Route, Routes, BrowserRouter } from 'react-router-dom';

function App() {
  return (
    <div>
      <Navigation />
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home/>}/>
          <Route path="/About" element={<About/>}/>
          <Route path="/Browse" element={<Browse/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
