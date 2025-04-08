
document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.dropdownButton').forEach((dropdown) => {
        const dropdownContent = dropdown.querySelector('.dropdownContent');
        const dropdownArrow = dropdown.querySelector('.dropdownArrow');
        const dropdownHead = dropdown.querySelector('.dropdownHead');

        dropdown.addEventListener('click', () => {
            // Tıklanan butonun dropdown içeriğini göster/gizle
            dropdownContent.classList.toggle('hidden');
            dropdownArrow.classList.toggle('rotate-180');
            dropdownHead.classList.toggle('bg-gray-700');

            // Diğer dropdown içeriklerini gizle
            document.querySelectorAll('.dropdownButton').forEach((otherDropdown) => {
                if (otherDropdown !== dropdown) {
                    const otherContent = otherDropdown.querySelector('.dropdownContent');
                    const otherArrow = otherDropdown.querySelector('.dropdownArrow');
                    const otherHead = otherDropdown.querySelector('.dropdownHead');

                    otherContent.classList.add('hidden');
                    otherArrow.classList.remove('rotate-180');
                    otherHead.classList.remove('bg-gray-700');
                }
            });
        });
    });
});