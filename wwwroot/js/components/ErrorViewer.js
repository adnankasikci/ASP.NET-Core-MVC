

export function errorHandle(errorName, componentName) {

    var errorState = errorName;
    var errorComponent = document.getElementById(componentName);

    if(errorState){
        errorComponent.classList.remove('hidden');
    } else {
        errorComponent.classList.add('hidden');
    }
}


