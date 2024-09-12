// Define the base URL for the API
const BASE_URL = 'http://localhost:5108';

// Function to fetch a feud by ID
export const fetchFeudById = async (id) => {
    const url = `${BASE_URL}/feuds/ui/${id}`; // Construct the URL using the base URL and id
    try 
    {
        const response = await fetch(url); // Make an HTTP GET request to the constructed URL
        // Check if the response is not OK (status code is not in the range 200-299)
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`); // Throw an error with the status code
        }
        const data = await response.json(); // Parse the response body as JSON
        return data; // Return the parsed data
    } 
    catch (error) 
    {
        console.error('Error fetching data: ', error); // Log any errors that occur during the fetch or parsing
        throw error; // Rethrow the error to be handled by the caller
    }
};

// Function to fetch all feuds
export const fetchAllFeuds = async () => {
    const url = `${BASE_URL}/feuds`; // Construct the URL using the base URL
    try 
    {
        const response = await fetch(url); // Make an HTTP GET request to the constructed URL
        // Check if the response is not OK (status code is not in the range 200-299)
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`); // Throw an error with the status code
        }
        const data = await response.json(); // Parse the response body as JSON
        return data; // Return the parsed data
    } 
    catch (error) 
    {
        console.error('Error fetching data: ', error); // Log any errors that occur during the fetch or parsing
        throw error; // Rethrow the error to be handled by the caller
    }
};