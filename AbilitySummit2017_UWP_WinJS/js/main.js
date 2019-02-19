
document.getElementById('nameSortButton').addEventListener("click", clickSort);
document.getElementById('ageSortButton').addEventListener("click", clickSort);
document.getElementById('locationSortButton').addEventListener("click", clickSort);

function clickSort() {

    nameSortState.style.display = "none";
    ageSortState.style.display = "none";
    locationSortState.style.display = "none";

    // FIX SORT ACCESSIBILITY:
    // Use the UIA FullDescription property to convey information
    // about which column is the current soprt column.

    nameSortButton.setAttribute("aria-describedby", "");
    ageSortButton.setAttribute("aria-describedby", "");
    locationSortButton.setAttribute("aria-describedby", "");

    var id = window.event.srcElement.getAttribute("id");

    if (id == "nameSortButton") {
        nameSortState.style.display = "block";
        nameSortState.setAttribute("aria-hidden", "true");
        nameSortButton.setAttribute("aria-describedby", "SortDescription");
    }
    else if (id == "ageSortButton") {
        ageSortState.style.display = "block";
        ageSortState.setAttribute("aria-hidden", "true");
        ageSortButton.setAttribute("aria-describedby", "SortDescription");
    }
    else {
        locationSortState.style.display = "block";
        locationSortState.setAttribute("aria-hidden", "true");
        locationSortButton.setAttribute("aria-describedby", "SortDescription");
    }

    // Note: Edge doesn't raise a UIA PropertyChangedEvent for the FullDescription 
    // change made indirectly through the above action. So customers using Narrator 
    // must move away from and back to the header button, (or issue some specific 
    // Narrator keyboard shortcut,) in order to learn of their attempt to change the 
    // sort order was successful.
}
