# Part III: Objects to Interchangeable Components

Chapter 10 retains its coffee-register lab. Chapter 11 uses products, order lines, and orders to teach identity, composition, private storage, immutable elements, and rejected-change behavior. Chapter 12 uses discount policies and checkout components to teach substitution, virtual dispatch, interfaces, and test doubles.

Run `dotnet run --project demos/11_object_design/object_design -- --check` and `dotnet run --project demos/12_oop/policy_design -- --check`. All new notebook code cells are standalone; hidden lab/homework solutions retain executed outputs. Students explicitly carry their design decisions forward between connected lab tasks; they do not rely on browser execution state.

Homework transfers concepts to customers, time entries, rosters, expenses, shipping, reports, notifications, and tax rules. Check explanations of ownership and behavioral contracts, not only displayed totals. The intentionally broken policy in homework should run and report a failed contract; it is not an accidental compiler error.

New semantic assignment IDs are `cscs-object-design-preview`, `cscs-object-design-lab`, `cscs-object-design-homework`, `cscs-policy-preview`, `cscs-policy-lab`, and `cscs-policy-homework`. Any course-side assignment registration uses those content identifiers; do not infer an ID from a displayed chapter number.

The original OOP video is retained. New composition video and chapter slides are pending. Advanced operators and database persistence are appendix extensions.
