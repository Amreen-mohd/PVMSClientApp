var backdrop = document.querySelector(".backdrop");
var modal = document.querySelector(".modal");
var modalNoButton = document.querySelector(".modal__action--negative");
var selectPlanButtons = document.querySelectorAll(".plan button");
var toggleButton = document.querySelector(".toggle-button");
var mobileNav = document.querySelector(".mobile-nav");
var ctaButton = document.querySelector(".main-nav__item--cta");
var avatar = document.querySelector(".dropdown-toggle");
var dropdownMenu = document.querySelector(".dropdown-menu");

avatar.addEventListener("click", function () {
    dropdownMenu.classList.add("open");
    backdrop.style.display = "block";
    setTimeout(function () {
        backdrop.classList.add("open");
    }, 10);
});

//document.addEventListener("DOMContentLoaded", function () {
//    const toggle = document.querySelector(".dropdown-toggle");
//    const menu = document.querySelector(".dropdown-menu");

//    toggle.addEventListener("click", function (event) {
//        event.preventDefault(); // Prevent the link from being followed
//        menu.style.display = menu.style.display === "block" ? "none" : "block";
//    });

//    // Close the menu when clicking outside
//    document.addEventListener("click", function (event) {
//        if (!toggle.contains(event.target) && !menu.contains(event.target)) {
//            menu.style.display = "none";
//        }
//    });
//});



// console.dir(backdrop.style['background-image']);

// console.dir(backdrop);
for (var i = 0; i < selectPlanButtons.length; i++) {
    selectPlanButtons[i].addEventListener("click", function () {
        // modal.style.display = "block";
        // backdrop.style.display = "block";
        // modal.className = 'open'; // This will actually overwrite the complete class list
        modal.classList.add("open");
        backdrop.style.display = "block";
        setTimeout(function () {
            backdrop.classList.add("open");
        }, 10);
    });
}

backdrop.addEventListener("click", function () {
    // mobileNav.style.display = 'none';
    mobileNav.classList.remove("open");
    closeModal();
});

if (modalNoButton) {
    modalNoButton.addEventListener("click", closeModal);
}

function closeModal() {
    //   backdrop.style.display = "none";
    //   modal.style.display = "none";
    if (modal) {
        modal.classList.remove("open");
    }
    backdrop.classList.remove("open");
    setTimeout(function () {
        backdrop.style.display = "none";
    }, 200);
}

toggleButton.addEventListener("click", function () {
    // mobileNav.style.display = 'block';
    // backdrop.style.display = 'block';
    mobileNav.classList.add("open");
    backdrop.style.display = "block";
    setTimeout(function () {
        backdrop.classList.add("open");
    }, 10);
});

ctaButton.addEventListener('animationstart', function (event) {
    console.log('Animation started', event);
})

ctaButton.addEventListener('animationend', function (event) {
    console.log('Animation ended', event);
})

ctaButton.addEventListener('animationiteration', function (event) {
    console.log('Animation iteration', event);
})
