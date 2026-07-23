# ckeditor5-blazor

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A working **CKEditor 5** integration for **Blazor** (Server and WebAssembly) with a **custom image upload adapter**.

> **Maintenance status:** community / reference. Open issues from 2021 are still tracked — PRs and fixes are welcome. Not a packaged NuGet product yet.

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
                    UrlToPostImage="https://localhost:44301/api/upload">
    </CKEditorBlazor>
</EditForm>
```

Your upload API should accept the file and return JSON that includes the public image URL CKEditor expects.

## Upload adapter notes

CKEditor image upload is handled by an **upload adapter**. This sample uses a **custom adapter** that posts files to your API and handles progress / error / abort events.

## Known gaps / help wanted

- WebAssembly packaging polish
- Strikethrough / additional plugin examples
- Avoid base64-only uploads when a URL endpoint is configured

See [open issues](https://github.com/qmmughal/ckeditor5-blazor/issues).

## License

[MIT](LICENSE)
