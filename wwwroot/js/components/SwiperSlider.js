
const progressCircle = document.querySelector(".swiperHomeBanner-autoplay-progress svg");
const progressContent = document.querySelector(".swiperHomeBanner-autoplay-progress span");

    var swiper = new Swiper(".swiperHomeBanner", {
    spaceBetween: 30,
    centeredSlides: true,
    autoplay: {
        delay: 2500,
        disableOnInteraction: false
    },
    pagination: {
        el: ".swiper-pagination",
        clickable: true
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev"
    },
    on: {
        autoplayTimeLeft(s, time, progress) {
            progressCircle.style.setProperty("--progress", 1 - progress);
            progressContent.textContent = `${Math.ceil(time / 1000)}`;
        }
    }
    });