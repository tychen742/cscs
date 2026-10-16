// Press convention: the part caption links to its overview; no duplicate TOC row.
(function () {
    // Populated from the source TOC at installation for themes that omit overview rows.
    const overviewPages = {
    "Part I. Fundamentals": "chapters/parts/part_01_fundamentals.html",
    "Part II. Data and I/O": "chapters/parts/part_02_data_io.html",
    "Part III. Object-Oriented Programming": "chapters/parts/part_03_oop.html",
    "Part IV. Data Abstraction and Linear Structures": "chapters/parts/part_04_data_structures.html",
    "Part V. Trees, Hashing, and Graphs": "chapters/parts/part_05_trees_hashing_graphs.html",
    "Part VI. Algorithm Analysis and Design": "chapters/parts/part_06_algorithm_analysis_design.html",
    "Part VII. Optimization and Computational Limits": "chapters/parts/part_07_optimization_limits.html"
};
    const bookRoot = new URL('../', document.currentScript.src);
    function linkPartOverviews() {
        document.querySelectorAll('nav.bd-links .caption-text').forEach(function (caption) {
            if (!/^Part\s+[IVXLCDM]+[.:]/.test(caption.textContent.trim())) return;
            if (caption.querySelector('a')) return;
            const list = caption.closest('p.caption')?.nextElementSibling;
            const item = list?.firstElementChild;
            const overview = item?.querySelector(':scope > a.reference.internal');
            const isOverview = overview && /\/parts\/part_[^/]+\.html$/.test(new URL(overview.href).pathname);
            const destination = isOverview ? overview.href : overviewPages[caption.textContent.trim()];
            if (!destination) return;
            const link = document.createElement('a');
            link.href = isOverview ? overview.getAttribute('href') : new URL(destination, bookRoot).href;
            link.textContent = caption.textContent;
            link.className = 'part-overview-link';
            if ((isOverview && (overview.getAttribute('aria-current') === 'page' || item.classList.contains('current'))) || new URL(link.href).pathname === window.location.pathname) {
                link.setAttribute('aria-current', 'page');
            }
            caption.replaceChildren(link);
            // Move navigation to the caption only once its replacement is available.
            if (isOverview) item.remove();
        });
    }
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', linkPartOverviews);
    } else {
        linkPartOverviews();
    }
})();
