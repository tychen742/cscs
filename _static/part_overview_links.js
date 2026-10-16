// Press convention: the part caption links to its overview; no duplicate TOC row.
(function () {
    function linkPartOverviews() {
        document.querySelectorAll('nav.bd-links .caption-text').forEach(function (caption) {
            if (!/^Part\s+[IVXLCDM]+\./.test(caption.textContent.trim())) return;
            if (caption.querySelector('a')) return;
            const list = caption.closest('p.caption')?.nextElementSibling;
            const item = list?.firstElementChild;
            const overview = item?.querySelector(':scope > a.reference.internal');
            if (!overview || !/\/parts\/part_[^/]+\.html$/.test(new URL(overview.href).pathname)) return;
            const link = document.createElement('a');
            link.href = overview.getAttribute('href');
            link.textContent = caption.textContent;
            link.className = 'part-overview-link';
            if (overview.getAttribute('aria-current') === 'page' || item.classList.contains('current')) {
                link.setAttribute('aria-current', 'page');
            }
            caption.replaceChildren(link);
            // Move navigation to the caption only once its replacement is available.
            item.remove();
        });
    }
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', linkPartOverviews);
    } else {
        linkPartOverviews();
    }
})();
