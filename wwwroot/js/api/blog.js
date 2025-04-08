
import { apiRequest } from './apiRequest.js';

export async function blogAdd(formData) {
    try {
        const response = await apiRequest('api/auth/Add', 'POST', formData, "multipart/form-data");
        console.log(response.message);
        alert("Blog başarıyla eklendi!");
        window.location.href = "/admin/blog/show";
    } catch (error) {
        console.error('Hata:', error.message || error);
        alert("Hata oluştu: " + error.message);
    }
}

export async function blogDelete(id) {
    try {
        const response = await apiRequest('api/auth/Delete', 'POST', { blogId: id }, "application/json");
        console.log(response.message);
        alert("Blog başarıyla silindi!");
        window.location.href = "/admin/blog/show";
    } catch (error) {
        console.error('Hata:', error.message || error);
        alert("Hata oluştu: " + error.message);
    }
}

export async function getBlogAll() {
    try {
        const response = await apiRequest('api/auth/BlogAll', 'GET');
        return response;
    } catch (error) {
        console.error('Hata:', error.message || error);
        alert("Hata oluştu: " + error.message);
    }
}

export async function getBlogId(id) {
    console.log("sds"+id);
    try {
        const response = await apiRequest('api/auth/getBlogId', 'POST', { blogId: id }, "application/json");
        return response;
    } catch (error) {
        console.error('Hata:', error.message || error);
        alert("Hata oluştu: " + error.message);
    }
}

export async function blogDetayPrint(id){
    const blogs = await getBlogId(id);
    const blogListContainer = document.getElementById("blogDetay");
    const blogElement = document.createElement("div");

    blogElement.innerHTML = `
                <div class="basis-full lg:basis-7/12 order-0 lg:order-1">
                    <img class="object-cover w-full rounded-xl h-[20rem]"
                        src="${blogs.imagePath}" alt="">
                    <h1 class="text-5xl font-extrabold my-9">
                        ${blogs.title}
                    </h1>
                    <p class="text-gray-500">
                    ${blogs.subtitle}
                    </p>
                    <div class="my-12">
                    ${blogs.content}
                    </div>
                </div>
            `

    blogListContainer.appendChild(blogElement);

}




export async function blogPrint(){
    document.addEventListener("DOMContentLoaded", async () => {
        const blogs = await getBlogAll();

        const blogListContainer = document.getElementById("blogList");

        const popularListContainer = document.getElementById("popularBlogs");


        console.log(blogs);
        blogs.forEach((blog, index) => {
            const blogElement = document.createElement("div");
            blogElement.classList.add("blog-item");

            blogElement.innerHTML = `
            <div class="overflow-hidden rounded-lg shadow-md slideCard group">
                <div class="relative">
                    <img class="w-full object-cover h-[17rem]"
                        src="${blog.imagePath}" alt="${blog.title}">
                    <div
                        class="absolute bottom-0 flex flex-col p-4 text-white duration-500 bg-black bg-opacity-75 start-0 end-0 group-hover:bg-blue-700 group-hover:opacity-75">
                        <span class="text-xl font-extrabold">${blog.title}</span>
                        <a class="space-x-2" href="blog/${blog.id}"><span>Ürün
                                Hakkında Bilgi Edinin</span><i
                                class="duration-500 fas fa-arrow-right group-hover:translate-x-2"></i></a>
                    </div>
                </div>
                <div class="p-4">
                    <p class="text-sm text-justify text-gray-500 line-clamp-4">${blog.subtitle}</p>
                </div>
            </div>
            `;

            const popularBlogElement = document.createElement("div");
            popularBlogElement.classList.add("mt-5");

            popularBlogElement.innerHTML =
            `
                <div class="border border-indigo-100 p-2">
                    <div class="text-start text-sm font-bold">${index + 1} - ${blog.title}</div>
                    <div class="text-sm text-justify text-gray-500 line-clamp-2 mt-2">${blog.subtitle}</div>
                </div>
            `;

            popularListContainer.appendChild(popularBlogElement);
            blogListContainer.appendChild(blogElement);
        });
    });
}
