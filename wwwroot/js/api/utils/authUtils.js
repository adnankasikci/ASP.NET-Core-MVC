
export function setToken(token) {
    localStorage.setItem('jwtToken', token);
}

export function getToken() {
    return localStorage.getItem('jwtToken');
}

export function removeToken() {
    localStorage.removeItem('jwtToken');
}

export function isTokenValid() {
    const token = getToken();
    if (!token) return false;

    const decoded = JSON.parse(atob(token.split('.')[1]));
    const expirationDate = new Date(decoded.exp * 1000);
    return expirationDate > new Date();
}

