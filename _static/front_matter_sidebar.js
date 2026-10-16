// Keep front matter in the reading sequence while simplifying sidebar navigation.
(function () {
    function simplifyFrontMatter() {
        document.querySelectorAll('nav.bd-links p.caption').forEach(function (caption) {
            if (caption.textContent.trim() !== 'Front Matter') return;
            caption.classList.add('front-matter-sidebar-hidden');
            caption.hidden = true;
        });
        document.querySelectorAll('nav.bd-links li > a.reference.internal').forEach(function (link) {
            const pathname = new URL(link.href, document.baseURI).pathname;
            if (!/(?:^|\/)(?:title[_-]page|chapter[_-]topics)\.html$/.test(pathname)) return;
            const item = link.parentElement;
            item.classList.add('front-matter-sidebar-hidden');
            item.hidden = true;
        });
    }
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', simplifyFrontMatter);
    } else {
        simplifyFrontMatter();
    }
})();
