// Write your JavaScript here.
import { getInfo, getCategories, getItems} from "./fetch.js";

const loadMessage = document.getElementById("status");

const restaurantData = (data) => {

    const menuData = data[0];
    document.getElementById("room").textContent = menuData.address;
    document.getElementById("date").textContent = menuData.hours;
    document.getElementById("phone").textContent = menuData.phone;

    document.getElementById("restaurant-name").textContent = menuData.name.toUpperCase();
    document.getElementById("tagline").textContent = menuData.tagline;

    document.getElementById("footer-name").textContent = menuData.name.toUpperCase();
    document.getElementById("footer-info").textContent =  menuData.address + " " + menuData.hours + " " + menuData.phone;
}

const CategoriesData = (data) => {

    const cData = data;
    document.getElementById("boot-up-nav").textContent = cData[0].name;
    document.getElementById("main-functions-nav").textContent = cData[1].name;
    document.getElementById("sweet-syntax-nav").textContent = cData[2].name; 
    document.getElementById("fuel-nav").textContent = cData[3].name;

    document.getElementById("boot-up").textContent = cData[0].name;
    document.getElementById("Id-1").textContent = "0" + cData[0].id;

    document.getElementById("main-functions").textContent = cData[1].name;
    document.getElementById("Id-2").textContent = "0" + cData[1].id;

    document.getElementById("sweet-syntax").textContent = cData[2].name;
    document.getElementById("Id-3").textContent = "0" + cData[2].id;

    document.getElementById("fuel").textContent = cData[3].name;
    document.getElementById("Id-4").textContent = "0" + cData[3].id;

}

const itemsData = (data) => {
    const iData = data;

    //Fries
    document.getElementById("fries-img").src = `./images/hello-world-fries.jpg`;
    document.getElementById("fries").textContent = iData[0].name;
    document.getElementById("price1").textContent = "$" + iData[0].price + ".00";
    document.getElementById("desc1").textContent = iData[0].description;
    document.getElementById("tag1").textContent = iData[0].tag.toUpperCase();

    //Bug Bites
    document.getElementById("bites-img").src = `./images/bug-bites.jpg`;
    document.getElementById("bug-bites").textContent = iData[1].name;
    document.getElementById("price2").textContent = "$" + iData[1].price + ".00";
    document.getElementById("desc2").textContent = iData[1].description;
    document.getElementById("tag2").textContent = iData[1].tag.toUpperCase();

    //Nachos
    document.getElementById("nachos-img").src = `./images/array-of-nachos.jpg`;
    document.getElementById("nachos").textContent = iData[2].name;
    document.getElementById("price3").textContent = "$" + iData[2].price + ".00";
    document.getElementById("desc3").textContent = iData[2].description;
    document.getElementById("tag3").textContent = iData[2].tag.toUpperCase();

    //Burger
    document.getElementById("burger-img").src = `./images/full-stack-burger.jpg`;
    document.getElementById("burger").textContent = iData[3].name;
    document.getElementById("price4").textContent = "$" + iData[3].price + ".00";
    document.getElementById("desc4").textContent = iData[3].description;
    document.getElementById("tag4").textContent = iData[3].tag.toUpperCase();

    //Ramen
    document.getElementById("ramen-img").src = `./images/recursive-ramen.jpg`;
    document.getElementById("ramen").textContent = iData[4].name;
    document.getElementById("price5").textContent = "$" + iData[4].price + ".00";
    document.getElementById("desc5").textContent = iData[4].description;
    document.getElementById("tag5").textContent = iData[4].tag.toUpperCase();

    //Boolean Bowl
    document.getElementById("bowl-img").src = `./images/boolean-bowl.jpg`;
    document.getElementById("bowl").textContent = iData[5].name;
    document.getElementById("price6").textContent = "$" + iData[5].price + ".00";
    document.getElementById("desc6").textContent = iData[5].description;
    document.getElementById("tag6").textContent = iData[5].tag.toUpperCase();

    //Pi
    document.getElementById("pi-img").src = `./images/pepperoni-pi.jpg`;
    document.getElementById("pi").textContent = iData[6].name;
    document.getElementById("price7").textContent = "$" + iData[6].price + ".00";
    document.getElementById("desc7").textContent = iData[6].description;
    document.getElementById("tag7").textContent = iData[6].tag.toUpperCase();

    //Cookies
    document.getElementById("cookie-img").src = `./images/cookie-session.jpg`;
    document.getElementById("cookie").textContent = iData[7].name;
    document.getElementById("price8").textContent = "$" + iData[7].price + ".00";
    document.getElementById("desc8").textContent = iData[7].description;
    document.getElementById("tag8").textContent = iData[7].tag.toUpperCase();

    //Pancakes
    document.getElementById("pancakes-img").src = `./images/stack-overflow-pancakes.jpg`;
    document.getElementById("pancakes").textContent = iData[8].name;
    document.getElementById("price9").textContent = "$" + iData[8].price + ".00";
    document.getElementById("desc9").textContent = iData[8].description;
    document.getElementById("tag9").textContent = iData[8].tag.toUpperCase();

    //Loops
    document.getElementById("loops-img").src = `./images/infinite-loops.jpg`;
    document.getElementById("loops").textContent = iData[9].name;
    document.getElementById("price10").textContent = "$" + iData[9].price + ".00";
    document.getElementById("desc10").textContent = iData[9].description;
    document.getElementById("tag10").textContent = iData[9].tag.toUpperCase();

    //Java
    document.getElementById("java-img").src = `./images/java.jpg`;
    document.getElementById("java").textContent = iData[10].name;
    document.getElementById("price11").textContent = "$" + iData[10].price + ".00";
    document.getElementById("desc11").textContent = iData[10].description;
    document.getElementById("tag11").textContent = iData[10].tag.toUpperCase();

    //Bubble
    document.getElementById("bubble-img").src = `./images/bubble-sort-boba.jpg`;
    document.getElementById("bubble").textContent = iData[11].name;
    document.getElementById("price12").textContent = "$" + iData[11].price + ".00";
    document.getElementById("desc12").textContent = iData[11].description;
    document.getElementById("tag12").textContent = iData[11].tag.toUpperCase();

    
}

async function fetchPage() {
    const menuStuff = await getInfo();
    restaurantData(menuStuff);

    const categoryStuff = await getCategories();
    CategoriesData(categoryStuff);

    const itemsStuff = await getItems();
    itemsData(itemsStuff);

    loadMessage.classList.add("hidden");
}
    
fetchPage();
