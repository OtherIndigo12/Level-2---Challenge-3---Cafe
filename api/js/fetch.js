const Menu_API = "http://localhost:5233/api/Menu/";
const Categories_API = "http://localhost:5233/api/Categories/";
const Items_API = "http://localhost:5233/api/Items/";


export async function getInfo() {
    const response = await fetch(Menu_API);

    if(!response.ok) {
        throw new Error(`Website Failed to Fetch Menu Data: ${response.status}`)
    }

    const data = await response.json();

    console.log("Menu Fetch Successful!")
    return data;
}

export async function getCategories() {
    const response = await fetch(Categories_API);

    if(!response.ok) {
        throw new Error(`Website Failed to Fetch Category Data: ${response.status}`)
    }

    const data = await response.json();

    console.log("Categories Fetch Successful!");
    return data;
}

export async function getItems() {
    const response = await fetch(Items_API);

    if(!response.ok) {
        throw new Error(`Website Failed to Fetch Menu Item Data: ${response.status}`)
    }

    const data = await response.json();

    console.log("Menu Items Fetch Successful!");
    return data;
}