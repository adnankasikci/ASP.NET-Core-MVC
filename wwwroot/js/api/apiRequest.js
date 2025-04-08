import { fetchAdminData } from "./auth.js";
import { isTokenValid } from "./utils/authUtils.js";

export async function apiRequest(endpoint, method = 'GET', data, contentType) {
    const baseUrl = "http://localhost:5284/";
    const url = `${baseUrl}${endpoint}`;

    const headers = {
        Authorization: `Bearer ${localStorage.getItem('jwtToken')}`
    };

    if (contentType === "application/json") {
        headers["Content-Type"] = "application/json";
    }

    const options = {
        method,
        headers,
        ...(contentType === "application/json" && { body: JSON.stringify(data) }),
        ...(contentType === "multipart/form-data" && { body: data })
    };

    const response = await fetch(url, options);

    if (!response.ok) {
        const errorData = await response.text();
        throw new Error(errorData || "Bir hata oluştu");
    }

    return await response.json();
}


export async function checkAndRedirect() {

    const currentPath = window.location.pathname;
        try {

            var adminData = await fetchAdminData();
            console.log(adminData)
            // if(adminData){
            //     var Adminusername = adminData.Name;
            //     var Adminpassword = adminData.password;
            //     const response = await apiRequest('api/auth/login', 'POST', { username: Adminusername, password: Adminpassword });
            //     console.log(response);
            // }

            if (currentPath.startsWith('/admin') && currentPath !== '/admin/login') {
                var tokenControl = isTokenValid();
                if (!tokenControl) {
                    window.location.href = "/admin/login";
                }
            }
        } catch (error) {
            console.error("API isteği başarısız:", error);
            // window.location.href = "/admin/login";
        }
}