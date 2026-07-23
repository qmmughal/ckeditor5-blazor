# ckeditor5-blazor

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A working **CKEditor 5** integration for **Blazor** (Server and WebAssembly) with a **custom image upload adapter**.

> **Maintenance status:** community / reference. Open issues from 2021 are still tracked — PRs and fixes are welcome. Not a packaged NuGet product yet — see [Support this project](#support-this-project) below.

## Features

- Blazor component wrapper around CKEditor 5
- Custom upload adapter (XMLHttpRequest) with configurable `UrlToPostImage`
- Two-way bind with `@bind-Value` inside `EditForm`

## Quick start

```bash
git clone https://github.com/qmmughal/ckeditor5-blazor.git
cd ckeditor5-blazor
# Open ckeditor5blazor.sln in Visual Studio / Rider, or:
dotnet build ckeditor5blazor.sln
dotnet run --project ckeditor5blazor
```

### Sample image upload API

This repo now includes `Controllers/UploadController.cs` — a minimal endpoint the custom adapter can call:

- **Method / route:** `POST /api/Upload`
- **Form field:** `upload` (multipart)
- **Response JSON:** `{ "url": "https://host/uploads/filename.ext" }`

The demo page points `UrlToPostImage` at `/api/Upload`. Files are saved under `wwwroot/uploads/`.

```csharp
[HttpPost]
public async Task<IActionResult> Post(IFormFile upload)
{
    // save file under wwwroot/uploads, then:
    return Ok(new { url = $"{Request.Scheme}://{Request.Host}/uploads/{storedName}" });
}
```

### Basic usage

```razor
<EditForm Model="@editorOptions">
    <CKEditorBlazor Id="MyEditor" @bind-Value=@editorOptions.InitialText>
    </CKEditorBlazor>
</EditForm>
```

### With image upload URL

```razor
<EditForm Model="@editorOptions">
    <CKEditorBlazor Id="MyEditor1"
                    @bind-Value=@editorOptions.InitialText
                    UrlToPostImage="/api/Upload">
    </CKEditorBlazor>
</EditForm>
```

Your upload API should accept the file and return JSON that includes the public image URL CKEditor expects.

## Upload adapter notes

CKEditor image upload is handled by an **upload adapter**. This sample uses a **custom adapter** that posts files to your API and handles progress / error / abort events.

## Known gaps / help wanted

- **WebAssembly:** sample is Blazor Server today; a dedicated WASM host is not in the solution yet
- **Strikethrough:** not included in the bundled `ckeditor.js` ClassicEditor build — needs a custom CKEditor rebuild + toolbar item
- Paste/`imageInsert` can still embed base64 images even when `UrlToPostImage` is set

See [open issues](https://github.com/qmmughal/ckeditor5-blazor/issues).

## Support this project

This is the most-used repo in the account (multi-year issue history, real adopters) but it isn't a packaged NuGet product yet. A `FUNDING.yml` is in place so a GitHub Sponsors button will appear here once [sponsors is enabled](https://github.com/qmmughal) on the account — sponsorship is earmarked for turning this into a maintained, versioned NuGet release instead of a clone-and-copy sample.

## License

[MIT](LICENSE)
