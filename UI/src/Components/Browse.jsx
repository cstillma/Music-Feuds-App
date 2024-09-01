// ExampleComponent.jsx
import React, { useEffect, useState } from 'react';
import * as Api from '../Services/ApiCalls'; // Import all exports from ApiCalls.js
import '.././App.css';

function Browse() {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const feudId = 1; // Example ID

  useEffect(() => {
      const fetchDataFromApi = async () => {
          try {
              const result = await Api.fetchFeudById(feudId); // Use the imported function
              //const result = await Api.fetchAllFeuds(); 
              setData(result);
          } catch (err) {
              setError(err);
          }
      };

      fetchDataFromApi();
  }, [feudId]);

  if (error) {
      return <div>Error: {error.message}</div>;
  }

  if (!data) {
      return <div>Loading...</div>;
  }
    return (
      <div>
        <header className="App-header">
          <h1>
            Feuds, Beefs, and Diss Tracks
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