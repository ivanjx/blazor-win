# Blazor Hybrid

Sample Windows Blazor Hybrid solution built with .NET 10.

## Projects

- `src\BlazorHybrid.WinForms` - WinForms host that runs the Blazor UI with `BlazorWebView`
- `src\BlazorHybrid.Shared` - Razor Class Library shared by desktop and future WebAssembly hosts
- `src\BlazorHybrid.ClientScripts` - TypeScript/npm project that builds the JS interop bundle
- `src\BlazorHybrid.Packaging` - Windows Application Packaging Project for MSIX sideloading

## Build

```powershell
dotnet build BlazorHybrid.sln -c Debug
```

The TypeScript bundle is produced through the shared library build and copied into its static web assets.

## Sideload installer

The GitHub Actions workflow at `.github\workflows\ci-installer.yml` builds the MSIX installer on Windows and uploads the package artifacts for sideloading.

## Signing note

This sample does not store private signing material in the repository. The CI workflow generates a temporary signing certificate during the build so the installer can be produced without checking a PFX into source control.
