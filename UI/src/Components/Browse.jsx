import React, { useEffect, useState } from 'react'; // Import necessary hooks from React
import * as Api from '../Services/ApiCalls'; // Import all exports from ApiCalls.js
import '.././App.css';

// Define the Browse component
function Browse() {
  // Declare state variables for storing fetched data and any errors
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const feudId = 1; // Example ID for fetching a specific feud

  // useEffect hook to fetch data when the component mounts or feudId changes
  useEffect(() => {
    // Define an asynchronous function to fetch data from the API
    const fetchDataFromApi = async () => {
      try 
      {
        // Fetch data using the fetchFeudById function from ApiCalls.js
        const result = await Api.fetchFeudById(feudId);
        //const result = await Api.fetchAllFeuds();
        setData(result); // Update the data state with the fetched result
      } 
      catch (err) 
      {
        setError(err); // Update the error state if an error occurs
      }
    };

    fetchDataFromApi();
  }, [feudId]); // Dependency array to re-run the effect when feudId changes

  // Render an error message if an error occurs
  if (error) 
  {
    return <div>Error: {error.message}</div>;
  }

  // Render a loading message while data is being fetched
  if (!data)
  {
    return <div>Loading...</div>;
  }

  // Render the fetched data in table format  
  return (
      <div>
        <header className="App-header">
          <h1>
            Browse Feuds, Artists, or Diss Tracks
          </h1>
          <br></br>
          <h2>{data.feudName}</h2>
          <br></br>
          <table style={{ width: '80%', margin: '0 auto' }}>
            <thead>
              <tr>
                <th>Title</th>
                <th>Artist</th>
                <th>Album</th>
                <th>Release Date</th>
              </tr>
            </thead>
            <tbody>
              {data.feudSongs.map(song => (
                <tr key={song.id}>
                  <td>{song.title}</td>
                  <td>{song.artist}</td>
                  <td>{song.album}</td>
                  <td>{song.releaseDate}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </header>
      </div>
    );
  }
  
  export default Browse;

  /*
SAMPLE JSON RESPONSE:
{
  "id": 1,
  "feudName": "TestFeud",
  "feudSongs": [
    {
      "id": 1,
      "title": "Test Song",
      "artist": "Alysha",
      "album": "Alyshas Best Hits",
      "releaseDate": "8/31/2024"
    },
    {
      "id": 2,
      "title": "Test Song II",
      "artist": "Caleb",
      "album": "Calebs Best Hits",
      "releaseDate": "8/31/2024"
    }
  ]
}
  */