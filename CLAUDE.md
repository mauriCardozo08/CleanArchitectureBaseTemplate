# CleanArchitectureBaseTemplate

This repo is a `dotnet new` template (short name `cleanarch`), not an application. This file is excluded from generated solutions; `Backend/CLAUDE.md` is the one that ships with them.

## Working on the template

- `CleanArchitecture` is the template `sourceName`: it is replaced in file contents, file names and folder names. Never write it in a way that breaks once replaced.
- Names must stay valid C# identifiers after replacement with a dotted name like `Acme.Shop`. That is why the DbContext is `AppDbContext`, not `<Name>DbContext`. Namespaces and project names can use the placeholder; class names cannot.
- Do not reference any specific company or organization anywhere (template identity, namespaces, docs).
- Do not commit `bin/` or `obj/`.
- Keep the Sample feature minimal; it only demonstrates the layers end to end.

## Verifying a change

Always test through the real template flow, not just `dotnet build` in this repo:

```bash
dotnet new install .
dotnet new cleanarch -n Acme.Shop -o <scratch-dir>/Acme.Shop
cd <scratch-dir>/Acme.Shop/Backend && dotnet build
dotnet new uninstall <path-to-this-repo>
```

The generated tree must build with 0 errors and contain no leftover `CleanArchitecture` string.

## Conventions

- Commits follow Conventional Commits (`feat:`, `fix:`, `docs:`, `chore:`), short body, no co-author trailers.
- Package versions live only in `Backend/Directory.Packages.props`.
