# Blazor Hybrid

Sample Windows Blazor Hybrid solution built with .NET 10.

## Projects

- `src\BlazorHybrid.WinForms` - WinForms host that runs the Blazor UI with `BlazorWebView`
- `src\BlazorHybrid.Shared` - Razor Class Library shared by desktop and future WebAssembly hosts
- `src\BlazorHybrid.ClientScripts` - TypeScript/npm project that builds the JS interop bundle
- `src\BlazorHybrid.Packaging` - Windows Application Packaging Project for MSIX sideloading

## Build

```powershell
dotnet build BlazorHybrid.slnx -c Debug
```

The TypeScript bundle is produced through the shared library build and copied into its static web assets.

## Sideload installer

The GitHub Actions workflow at `.github\workflows\ci-installer.yml` runs once on `windows-latest`, restores the desktop projects, and builds a single sideload bundle that contains both x64 and arm64 packages. It relies on the Visual Studio/MSBuild and Windows SDK tooling preinstalled on the hosted runner and uploads the package artifacts together with the generated signing certificate.
