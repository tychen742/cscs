// Sidebar-only labels. Full page headings and reading links remain unchanged.
(function () {
    const pages = {
    "chapters/parts/part_01_fundamentals.html": {
        "label": "Part I Overview",
        "title": "Part I. Fundamentals"
    },
    "chapters/01_context/0100_getting_started.html": {
        "label": "Computing",
        "title": "Computing, Programs, and Responsibility"
    },
    "chapters/01_context/0101_cs_ideas.html": {
        "label": "Problem Solving",
        "title": "Computing and Problem Solving"
    },
    "chapters/01_context/0102_computing_responsibility.html": {
        "label": "Responsibility",
        "title": "Computing and Professional Responsibility"
    },
    "chapters/01_context/0103_program_structure.html": {
        "label": "First C# Program",
        "title": "Your First C# Program and Basic Syntax"
    },
    "chapters/01_context/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Conceptual Review"
    },
    "chapters/02_var_data/0200_variables_types.html": {
        "label": "Variables & Types",
        "title": "Variables, Data Types, and Operators"
    },
    "chapters/02_var_data/0201_variables_types.html": {
        "label": "Variables & State",
        "title": "Variables, Assignment, and State"
    },
    "chapters/02_var_data/0202_types_conversion.html": {
        "label": "Types & Conversion",
        "title": "Types and Conversion"
    },
    "chapters/02_var_data/0203_operators_built_in_methods.html": {
        "label": "Operators & Calls",
        "title": "Operators and Built-In Methods"
    },
    "chapters/02_var_data/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Tracing and Expression Practice"
    },
    "chapters/03_decision/0300_conditionals.html": {
        "label": "Decisions",
        "title": "Decisions"
    },
    "chapters/03_decision/0301_intro_decision.html": {
        "label": "Boolean Logic",
        "title": "Boolean Expressions & Logical Operators"
    },
    "chapters/03_decision/0302_ifstatement.html": {
        "label": "Conditional Selection",
        "title": "Conditional Selection with if and switch"
    },
    "chapters/03_decision/assignments/preview.html": {
        "label": "Preview",
        "title": "Preview Questions"
    },
    "chapters/03_decision/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Decision Practice"
    },
    "chapters/04_iteration/0404_gcd.html": {
        "label": "GCD (Reading)",
        "title": "Greatest Common Divisor"
    },
    "chapters/04_iteration/assignments/preview.html": {
        "label": "Preview",
        "title": "Preview Questions"
    },
    "chapters/04_iteration/assignments/homework_gradecalculation.html": {
        "label": "Grade Calculation",
        "title": "Homework: Grade Calculation"
    },
    "chapters/04_iteration/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Loop Practice"
    },
    "chapters/05_methods/0501_intro_methods.html": {
        "label": "Design & Calls",
        "title": "Designing and Calling Methods"
    },
    "chapters/05_methods/0503_signature_call.html": {
        "label": "Results & Contracts",
        "title": "Returned Results and Method Contracts"
    },
    "chapters/05_methods/0504_strings.html": {
        "label": "String Methods",
        "title": "Strings and Their Methods"
    },
    "chapters/05_methods/0505_summary.html": {
        "label": "Composition & Checks",
        "title": "Composition, Refactoring, and Method Checks"
    },
    "chapters/05_methods/0506_recursive_methods.html": {
        "label": "Recursive Methods (Reading)",
        "title": "Recursive Methods (Supporting Reading)"
    },
    "chapters/05_methods/assignments/preview.html": {
        "label": "Preview",
        "title": "Preview Questions"
    },
    "chapters/05_methods/assignments/homework_gradecalculation2.html": {
        "label": "Grade Functions",
        "title": "Homework: Grade Calculation from Individual Scores"
    },
    "chapters/05_methods/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Methods and String Practice"
    },
    "chapters/06_exceptions_testing/0600_exceptions_testing.html": {
        "label": "Program Reliability",
        "title": "Testing, Debugging, and Error Handling"
    },
    "chapters/06_exceptions_testing/0601_error_handling.html": {
        "label": "Error Handling",
        "title": "Error Handling and Validation"
    },
    "chapters/06_exceptions_testing/0604_software_responsibility.html": {
        "label": "Failure Cases (Optional)",
        "title": "Computing and Society"
    },
    "chapters/06_exceptions_testing/assignments/preview.html": {
        "label": "Preview",
        "title": "Preview Questions"
    },
    "chapters/06_exceptions_testing/assignments/lab.html": {
        "label": "Lab",
        "title": "Lab: Exceptions, Debugging & Testing"
    },
    "chapters/06_exceptions_testing/assignments/unit_testing_walkthrough.html": {
        "label": "Testing Walkthrough",
        "title": "Unit Testing Walkthrough"
    },
    "chapters/parts/part_02_data_io.html": {
        "label": "Part II Overview",
        "title": "Part II. Data and I/O"
    },
    "chapters/07_arrays/0701_onedim.html": {
        "label": "Array Basics",
        "title": "Creating and Accessing Arrays"
    },
    "chapters/07_arrays/0702_array_processing.html": {
        "label": "Array Processing",
        "title": "Processing and Sharing Arrays"
    },
    "chapters/07_arrays/assignments/preview.html": {
        "label": "Preview",
        "title": "Preview Questions"
    },
    "chapters/07_arrays/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Array Practice"
    },
    "chapters/08_collections/0801_collections.html": {
        "label": "Collection Families",
        "title": "Collection Families and Selection"
    },
    "chapters/08_collections/0802_collection_operations.html": {
        "label": "Collection Operations",
        "title": "Collection Operations and Behavior"
    },
    "chapters/08_collections/0805_querying_collections.html": {
        "label": "LINQ (Optional)",
        "title": "Querying Collections with Lambdas and LINQ"
    },
    "chapters/08_collections/assignments/preview.html": {
        "label": "Preview",
        "title": "Preview Questions"
    },
    "chapters/09_files_text/0901_stream_file.html": {
        "label": "File Basics",
        "title": "File Foundations: Reading and Writing"
    },
    "chapters/09_files_text/0902_file_operations.html": {
        "label": "File Workflows",
        "title": "File Workflows, Paths, and Resources"
    },
    "chapters/09_files_text/0904_regex.html": {
        "label": "Regex (Reading)",
        "title": "Regular Expressions"
    },
    "chapters/09_files_text/0905_privacy_security.html": {
        "label": "Privacy (Optional)",
        "title": "Privacy and Security in Code"
    },
    "chapters/09_files_text/assignments/preview.html": {
        "label": "Preview",
        "title": "Preview Questions"
    },
    "chapters/09_files_text/assignments/hw_gradefiles.html": {
        "label": "Grade Files",
        "title": "Homework: Grade File"
    },
    "chapters/09_files_text/assignments/privacy_index.html": {
        "label": "Privacy Practice",
        "title": "Optional Privacy Practice"
    },
    "chapters/09_files_text/assignments/privacy_preview.html": {
        "label": "Privacy Preview",
        "title": "Preview Questions"
    },
    "chapters/09_files_text/assignments/privacy_lab.html": {
        "label": "Privacy Lab",
        "title": "Lab: A Privacy Pass on a Sign-Up Form"
    },
    "chapters/09_files_text/assignments/privacy_homework.html": {
        "label": "Homework",
        "title": "Homework"
    },
    "chapters/09_files_text/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "File Practice"
    },
    "chapters/09_files_text/assignments/help_responses.html": {
        "label": "Response Files",
        "title": "File-Driven Responses"
    },
    "chapters/parts/part_03_oop.html": {
        "label": "Part III Overview",
        "title": "Part III. Object-Oriented Programming"
    },
    "chapters/10_classes/1003_class_instance.html": {
        "label": "Instance Behavior",
        "title": "Instances, State, and Useful Behavior"
    },
    "chapters/10_classes/1004_averager.html": {
        "label": "Averager (Reading)",
        "title": "Averager and Mutable State"
    },
    "chapters/10_classes/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Class Practice"
    },
    "chapters/11_object_design/1100_object_design.html": {
        "label": "Object Design",
        "title": "Object Design and Composition"
    },
    "chapters/11_object_design/1101_objects_references.html": {
        "label": "Object References",
        "title": "References, Identity, and Copying"
    },
    "chapters/11_object_design/1102_value_record_types.html": {
        "label": "Structs & Records",
        "title": "Structs, Records, and Data Models"
    },
    "chapters/11_object_design/1103_composition.html": {
        "label": "Composition",
        "title": "Composition and Object Responsibilities"
    },
    "chapters/11_object_design/1104_testing_collaboration.html": {
        "label": "Collaboration Tests",
        "title": "Testing and Refactoring Collaborating Objects"
    },
    "chapters/11_object_design/1105_nullability.html": {
        "label": "Nullability (Reading)",
        "title": "Nullability and Missing Data"
    },
    "chapters/12_oop/1200_oop_principles.html": {
        "label": "OOP Principles",
        "title": "Inheritance, Interfaces, and Polymorphism"
    },
    "chapters/12_oop/1201_inheritance.html": {
        "label": "Inheritance",
        "title": "Inheritance and Substitution"
    },
    "chapters/12_oop/1202_polymorphism.html": {
        "label": "Polymorphism",
        "title": "Runtime Polymorphism and Abstract Classes"
    },
    "chapters/12_oop/1203_interfaces.html": {
        "label": "Interfaces",
        "title": "Interfaces and Interchangeable Components"
    },
    "chapters/12_oop/1204_oop_examples.html": {
        "label": "OOP Examples (Reading)",
        "title": "OOP Examples and Variations"
    },
    "chapters/12_oop/assignments/additional_practice.html": {
        "label": "Extra Practice",
        "title": "Original OOP Practice"
    },
    "chapters/parts/part_04_data_structures.html": {
        "label": "Part IV Overview",
        "title": "Part IV. Data Abstraction and Linear Structures"
    },
    "chapters/13_abstract_data_types/1300_abstract_data_types.html": {
        "label": "ADTs",
        "title": "Abstract Data Types"
    },
    "chapters/13_abstract_data_types/1302_representations_costs.html": {
        "label": "Representations",
        "title": "Representations and Costs"
    },
    "chapters/13_abstract_data_types/1303_generics.html": {
        "label": "Generics",
        "title": "Generics for Reusable ADTs"
    },
    "chapters/14_arrays_linked_lists/1400_arrays_linked_lists.html": {
        "label": "Linear Lists",
        "title": "Arrays and Linked Lists"
    },
    "chapters/14_arrays_linked_lists/1403_comparison_lab.html": {
        "label": "Comparing Lists",
        "title": "Representation Tradeoffs and Verification"
    },
    "chapters/15_stacks_queues/1500_stacks_queues.html": {
        "label": "Stacks & Queues",
        "title": "Stacks, Queues, and Deques"
    },
    "chapters/15_stacks_queues/1503_applications_lab.html": {
        "label": "Access Policies",
        "title": "Access Policies and Applications"
    },
    "chapters/16_searching_sorting/1600_searching_sorting.html": {
        "label": "Search & Sort",
        "title": "Searching and Basic Sorting"
    },
    "chapters/16_searching_sorting/1601_searching.html": {
        "label": "Searching",
        "title": "Search Contracts and Repeated Queries"
    },
    "chapters/16_searching_sorting/1602_basic_sorting.html": {
        "label": "Insertion Sort",
        "title": "Sorting and Safe Reporting Workloads"
    },
    "chapters/16_searching_sorting/1603_merge_sort.html": {
        "label": "Merge Sort (Reading)",
        "title": "Merge Sort (Supporting Reading)"
    },
    "chapters/parts/part_05_trees_hashing_graphs.html": {
        "label": "Part V Overview",
        "title": "Part V. Trees, Hashing, and Graphs"
    },
    "chapters/17_trees/1700_trees_bst.html": {
        "label": "Trees & BSTs",
        "title": "Trees and Binary Search Trees"
    },
    "chapters/17_trees/1701_tree_structure.html": {
        "label": "Trees & Recursion",
        "title": "Tree Structure and Recursive Models"
    },
    "chapters/17_trees/1702_tree_traversal.html": {
        "label": "Tree Traversal",
        "title": "Tree Traversal, Returned Values, and Costs"
    },
    "chapters/17_trees/1704_tree_lab.html": {
        "label": "Tree Queries & Checks",
        "title": "Tree Queries and Verification"
    },
    "chapters/18_priority_queues/1800_priority_queues.html": {
        "label": "Priority Queues",
        "title": "Priority Queues and Heaps"
    },
    "chapters/18_priority_queues/1801_priority_queues.html": {
        "label": "Priority Queues",
        "title": "Priority Queue Contracts and Heap Shape"
    },
    "chapters/18_priority_queues/1802_heap_implementation.html": {
        "label": "Binary Heaps",
        "title": "Implementing and Checking a Binary Heap"
    },
    "chapters/18_priority_queues/1803_priority_applications.html": {
        "label": "Top-K Selection",
        "title": "Priority Workloads and Top-K Selection"
    },
    "chapters/19_hash_collections/1900_hash_collections.html": {
        "label": "Hash Collections",
        "title": "Hash Collections and Sets"
    },
    "chapters/19_hash_collections/1901_hashing.html": {
        "label": "Hash Tables",
        "title": "Hash Tables, Equality, and Collisions"
    },
    "chapters/19_hash_collections/1902_dictionaries_sets.html": {
        "label": "Dictionaries & Sets",
        "title": "Dictionaries, Sets, and Reconciliation"
    },
    "chapters/19_hash_collections/1903_collection_selection.html": {
        "label": "Choosing Collections",
        "title": "Choosing and Coordinating Collections"
    },
    "chapters/20_graphs/2000_graphs.html": {
        "label": "Graphs",
        "title": "Graphs and Traversal"
    },
    "chapters/20_graphs/2001_graph_vocabulary.html": {
        "label": "Graph Models",
        "title": "Graph Vocabulary and Models"
    },
    "chapters/20_graphs/2002_adjacency_representations.html": {
        "label": "Adjacency",
        "title": "Adjacency Representations"
    },
    "chapters/20_graphs/2003_graph_traversal.html": {
        "label": "BFS & Paths",
        "title": "Breadth-First Search and Paths"
    },
    "chapters/20_graphs/2004_depth_first_components.html": {
        "label": "DFS & Components",
        "title": "Depth-First Search and Components"
    },
    "chapters/parts/part_06_algorithm_analysis_design.html": {
        "label": "Part VI Overview",
        "title": "Part VI. Algorithm Analysis and Design"
    },
    "chapters/21_algorithm_analysis/2100_algorithm_analysis.html": {
        "label": "Analysis",
        "title": "Algorithm Analysis"
    },
    "chapters/21_algorithm_analysis/2102_correctness.html": {
        "label": "Correctness",
        "title": "Correctness and Invariants"
    },
    "chapters/21_algorithm_analysis/2103_recurrences.html": {
        "label": "Recurrences",
        "title": "Recurrences and Recursive Cost"
    },
    "chapters/22_recursion_divide_conquer/2200_recursion_divide_conquer.html": {
        "label": "Recursion",
        "title": "Recursion and Divide-and-Conquer"
    },
    "chapters/22_recursion_divide_conquer/2201_recursion.html": {
        "label": "Recursive Design",
        "title": "Recursive Contracts and Divide-and-Conquer"
    },
    "chapters/22_recursion_divide_conquer/2202_merge_sort_lab.html": {
        "label": "Merge Sort",
        "title": "Stable Merge Sort and Verification"
    },
    "chapters/23_searching_sorting/2300_searching_sorting.html": {
        "label": "Advanced Search & Sort",
        "title": "Advanced Searching and Sorting"
    },
    "chapters/23_searching_sorting/2303_comparison_lab.html": {
        "label": "Algorithm Comparison",
        "title": "Comparing Complete Search and Sort Workloads"
    },
    "chapters/23_searching_sorting/2304_advanced_sorts.html": {
        "label": "Shell Sort (Reading)",
        "title": "Shell Sort and Gap Families"
    },
    "chapters/23_searching_sorting/2305_quicksort.html": {
        "label": "Quicksort (Reading)",
        "title": "Quicksort and Partitioning"
    },
    "chapters/23_searching_sorting/assignments/search_performance.html": {
        "label": "Search (Optional)",
        "title": "Search Performance (Optional)"
    },
    "chapters/parts/part_07_optimization_limits.html": {
        "label": "Part VII Overview",
        "title": "Part VII. Optimization and Computational Limits"
    },
    "chapters/24_greedy_graph_optimization/2400_greedy_graph_optimization.html": {
        "label": "Greedy Algorithms",
        "title": "Greedy Algorithms and Graph Optimization"
    },
    "chapters/24_greedy_graph_optimization/2401_greedy_choice.html": {
        "label": "Greedy Choice",
        "title": "Greedy Choices and Exchange Reasoning"
    },
    "chapters/24_greedy_graph_optimization/2402_spanning_trees_shortest_paths.html": {
        "label": "Spanning Forests",
        "title": "Minimum Spanning Forests and Kruskal"
    },
    "chapters/24_greedy_graph_optimization/2403_shortest_paths.html": {
        "label": "Shortest Paths",
        "title": "Shortest Paths and Dijkstra"
    },
    "chapters/25_dynamic_programming_backtracking/2500_dynamic_programming_backtracking.html": {
        "label": "Dynamic Programming",
        "title": "Dynamic Programming and Backtracking"
    },
    "chapters/25_dynamic_programming_backtracking/2501_memoization_tabulation.html": {
        "label": "Memoization & Tables",
        "title": "Memoization, Tabulation, and Repeated Work"
    },
    "chapters/25_dynamic_programming_backtracking/2502_optimization_models.html": {
        "label": "DP Models",
        "title": "Optimization States and Reconstructed Solutions"
    },
    "chapters/25_dynamic_programming_backtracking/2503_backtracking.html": {
        "label": "Backtracking",
        "title": "Backtracking, Pruning, and Search States"
    },
    "chapters/26_advanced_graphs_strings_limits/2600_advanced_graphs_strings_limits.html": {
        "label": "Strings & Limits",
        "title": "String Matching and Computational Limits"
    },
    "chapters/26_advanced_graphs_strings_limits/2601_shortest_paths_strings.html": {
        "label": "Direct Matching",
        "title": "Direct String Matching and Result Contracts"
    },
    "chapters/26_advanced_graphs_strings_limits/2602_prefix_matching.html": {
        "label": "KMP & Prefixes",
        "title": "Prefix Reuse and KMP"
    },
    "chapters/26_advanced_graphs_strings_limits/2603_limits_project.html": {
        "label": "Computational Limits",
        "title": "Algorithms and Computational Limits"
    },
    "chapters/appendices/command_line.html": {
        "label": "Development Tools",
        "title": "Development Tools Reference"
    },
    "chapters/appendices/development_tools/csharp_setup.html": {
        "label": "C# Setup",
        "title": "C# Setup and Verification"
    },
    "chapters/appendices/development_tools/interactive_language_environments.html": {
        "label": "REPLs",
        "title": "Interactive Language Environments (REPLs)"
    },
    "chapters/appendices/github/professional_practice.html": {
        "label": "Professional Practice",
        "title": "Professional Practice and Attribution"
    },
    "chapters/appendices/project/ai_extension.html": {
        "label": "AI Extension (Optional)",
        "title": "Optional AI Application Extension"
    },
    "chapters/appendices/databases/index.html": {
        "label": "Databases",
        "title": "Databases and Bookstore Inventory"
    },
    "chapters/appendices/graph_representation_workshop.html": {
        "label": "Graph Workshop",
        "title": "Graph Structures Lab"
    },
    "chapters/appendices/operator_overloading.html": {
        "label": "Operator Overloading",
        "title": "Operator Overloading"
    },
    "chapters/appendices/cs2023_alignment.html": {
        "label": "Curriculum Alignment",
        "title": "Curriculum Alignment (IS2020 and CS2023)"
    },
    "chapters/26_advanced_graphs_strings_limits/2601_graph_traversal.html": {
        "label": "Traversal (Reading)",
        "title": ""
    },
    "chapters/16_searching_sorting/1603_workloads.html": {
        "label": "Workloads",
        "title": ""
    },
    "chapters/22_recursion_divide_conquer/2202_divide_conquer.html": {
        "label": "Divide & Conquer",
        "title": ""
    },
    "chapters/25_dynamic_programming_backtracking/2503_optimization_lab.html": {
        "label": "Optimization Lab",
        "title": ""
    }
};
    const captions = {
    "Front Matter": {
        "label": "Front Matter",
        "title": "Front Matter"
    },
    "Part I. Fundamentals": {
        "label": "Part I. Fundamentals",
        "title": "Part I. Fundamentals"
    },
    "Part II. Data and I/O": {
        "label": "Part II. Data and I/O",
        "title": "Part II. Data and I/O"
    },
    "Part III. Object-Oriented Programming": {
        "label": "Part III. OOP",
        "title": "Part III. Object-Oriented Programming"
    },
    "Part IV. Data Abstraction and Linear Structures": {
        "label": "Part IV. Linear ADTs",
        "title": "Part IV. Data Abstraction and Linear Structures"
    },
    "Part V. Trees, Hashing, and Graphs": {
        "label": "Part V. Trees & Graphs",
        "title": "Part V. Trees, Hashing, and Graphs"
    },
    "Part VI. Algorithm Analysis and Design": {
        "label": "Part VI. Algorithm Design",
        "title": "Part VI. Algorithm Analysis and Design"
    },
    "Part VII. Optimization and Computational Limits": {
        "label": "Part VII. Limits",
        "title": "Part VII. Optimization and Computational Limits"
    },
    "Appendices": {
        "label": "Appendices",
        "title": "Appendices"
    },
    "Bibliography": {
        "label": "Bibliography",
        "title": "Bibliography"
    },
    "Index": {
        "label": "Index",
        "title": "Index"
    }
};
    const bookRoot = new URL('../', document.currentScript.src);
    function shortenNavigation() {
        document.querySelectorAll('nav.bd-links a.reference.internal').forEach(function (link) {
            const url = new URL(link.href);
            if (url.origin !== bookRoot.origin) return;
            const key = url.pathname.slice(bookRoot.pathname.length);
            const entry = pages[key];
            const original = link.dataset.navFullTitle || link.textContent.trim();
            link.dataset.navFullTitle = original;
            const number = link.querySelector('.section-number');
            const prefix = number ? number.textContent : (original.match(/^(?:[A-Z]|\d+)(?:\.\d+)*\.\s+/) || [''])[0];
            const title = entry?.title || original.slice(prefix.length).trim();
            link.title = title;
            link.setAttribute('aria-label', prefix + title);
            if (!entry) return;
            link.replaceChildren();
            if (number) link.appendChild(number);
            link.appendChild(document.createTextNode((number ? '' : prefix) + entry.label));
        });
        document.querySelectorAll('nav.bd-links .caption-text').forEach(function (caption) {
            const target = caption.querySelector('a') || caption;
            const original = caption.dataset.navFullTitle || target.textContent.trim();
            caption.dataset.navFullTitle = original;
            const entry = captions[original];
            if (!entry) return;
            target.title = entry.title;
            target.setAttribute('aria-label', entry.title);
            // Keep a part-overview link in place when shortening its caption.
            target.textContent = entry.label;
        });
    }
    if (document.readyState === 'loading') document.addEventListener('DOMContentLoaded', shortenNavigation);
    else shortenNavigation();
})();
