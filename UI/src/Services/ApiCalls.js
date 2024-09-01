// api.js

// Define the base URL
const BASE_URL = 'http://localhost:5108';

// Function to fetch a feud by ID
export const fetchFeudById = async (id) => {
    const url = `${BASE_URL}/feuds/ui/${id}`; // Construct the URL using the base URL and id
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
};

// Function to fetch all feuds
export const fetchAllFeuds = async () => {
    const url = `${BASE_URL}/feuds`; // Construct the URL using the base URL
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
};