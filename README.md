# Full Stack Engineer exercise: starter

Create your own repository from this template ("Use this template"), do the exercise in it, and share the repository with the reviewer account named in your exercise brief. We don't accept zip files or attachments.

## What's here

| Path | What it is |
|---|---|
| `backend/Api` | ASP.NET Core (.NET 10) API with EF Core on in-memory SQLite, the `Subscription` and `MeteringEvent` models, `ICurrentTenant`, and synthetic seed data. |
| `backend/Api.Tests` | xUnit tests. One smoke test proves the app starts. |
| `backend/Api/Task2` | Where your Task 2 code goes. |
| `frontend` | React + TypeScript (Vite) with Vitest and Testing Library. |
| `.github/workflows/ci.yml` | Builds and tests both parts on every push. |

The tenant comes from the `X-Tenant-Id` header, standing in for real sign-in. The frontend's `apiFetch` sends the demo tenant for you.

## Before you run anything

You shouldn't have to trust us blindly. Read this repository first; it takes about five minutes.
- It contains only the files in the table above: no binaries and no install or build scripts.
- No package in `frontend/package-lock.json` runs an install script, and the commands below install with `--ignore-scripts` anyway.
- **You don't need to run it on your machine:** open it in a GitHub Codespace ("Code" → "Codespaces"), which has .NET and Node ready.

## Run it

```bash
cd backend && dotnet test
cd backend/Api && dotnet run                            # http://localhost:5163
cd frontend && npm ci --ignore-scripts && npm run dev   # proxies /api to the backend
cd frontend && npm test
```

## Rules

- **Keep CI green**, and don't edit `.github/workflows/ci.yml`.
- **Dependencies:** if you add one, say why below. No install or build scripts (`postinstall`, custom MSBuild targets), no binaries.
- **Use any tools you like**, AI assistants included. Tell us how you used them.

---

## Your answers

Replace this section. One heading per task, numbered as in the exercise brief, plus anything the brief asks you to note (decisions, trade-offs, what you left out).
