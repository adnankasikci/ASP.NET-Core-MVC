import { errorHandle } from '../components/ErrorViewer.js';
import { apiRequest } from './apiRequest.js';
import { setToken, removeToken, isTokenValid } from './utils/authUtils.js';

export async function login(username, password) {
    try {
        console.log(username);
        const response = await apiRequest('api/auth/login', 'POST',  {username, password}, "application/json");
        const { token } = response;
        setToken(token);

        if(token){
            window.location.href = "/admin"
        } else {
            errorHandle(true, "errorMessage");
        }

    } catch (error) {
        errorHandle(true, "errorMessage");
        console.error('Login Hatası:', error.message || error);
        throw error;
    }
}

export function logout() {
    removeToken();
    window.location.href = "/admin/login";
}


export function checkTokenValidity() {
    return isTokenValid();
}

export async function fetchAdminData() {
    const token = localStorage.getItem('jwtToken');
    if (!token) {
        return null;
    }

    const parts = token.split('.');
    if (parts.length !== 3) {
        throw new Error('Geçersiz JWT token formatı');
    }

    const payload = parts[1];
    const decoded = JSON.parse(atob(payload));

    return decoded;
}




