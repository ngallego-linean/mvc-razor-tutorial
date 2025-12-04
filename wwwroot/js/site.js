// Theme toggle functionality
(function() {
    const themeToggle = document.getElementById('themeToggle');
    const themeIcon = document.getElementById('themeIcon');
    const body = document.body;

    // Sun and moon icons
    const sunIcon = '&#9728;';  // ☀
    const moonIcon = '&#9790;'; // ☾

    // Check for saved theme preference or default to light
    const savedTheme = localStorage.getItem('theme') || 'light';

    // Apply saved theme on page load
    if (savedTheme === 'dark') {
        body.setAttribute('data-theme', 'dark');
        themeIcon.innerHTML = sunIcon;
    } else {
        body.removeAttribute('data-theme');
        themeIcon.innerHTML = moonIcon;
    }

    // Toggle theme on button click
    themeToggle.addEventListener('click', function() {
        const currentTheme = body.getAttribute('data-theme');

        if (currentTheme === 'dark') {
            // Switch to light mode
            body.removeAttribute('data-theme');
            localStorage.setItem('theme', 'light');
            themeIcon.innerHTML = moonIcon;
        } else {
            // Switch to dark mode
            body.setAttribute('data-theme', 'dark');
            localStorage.setItem('theme', 'dark');
            themeIcon.innerHTML = sunIcon;
        }
    });
})();

// Tab persistence - remember which tab was active
(function() {
    const tabButtons = document.querySelectorAll('[data-bs-toggle="tab"]');
    const savedTab = localStorage.getItem('activeTab');

    // Restore saved tab on page load
    if (savedTab) {
        const targetTab = document.querySelector(`[data-bs-target="${savedTab}"]`);
        if (targetTab) {
            // Use Bootstrap's tab API
            const tab = new bootstrap.Tab(targetTab);
            tab.show();
        }
    }

    // Save tab selection when changed
    tabButtons.forEach(function(button) {
        button.addEventListener('shown.bs.tab', function(event) {
            const targetId = event.target.getAttribute('data-bs-target');
            localStorage.setItem('activeTab', targetId);
        });
    });
})();
