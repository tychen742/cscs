# UI helper import demonstration

**Inventory role:** Demo. Namespace/helper-file import and validated integer input.

This is the original CS1 helper-file workflow, adapted to the current .NET SDK. Run `dotnet run` in this folder, enter an integer, and inspect the two source files. `Program.cs` imports the `IntroCSCS` namespace defined by `ui.cs`. The helper file has no Main, so it does not add a second entry point. PromptInt retries malformed integers and reports exhausted input. Method design follows in Chapter 5.
