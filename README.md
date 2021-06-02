# ckeditor5-blazor
Its a working version of ckeditor5 with blazor, hopefully will help you to use it quickly in your own application for blazor.

In this solution i am implementing the ckeditor5 with custom upload adapter, along with all available options of ckeditor.
You can easily set your own url to upload to api and return a json response for url to insert into editor for images. 

The software that makes the image upload possible is called an upload adapter. It is a callback that tells the WYSIWYG editor how to send the file to the server. There are two main strategies of getting the image upload to work that you can adopt in your project: We are using second one, which is 
Custom upload adapters – Create your own upload adapter from scratch using the open API architecture of CKEditor 5.

You are going to implement and enable a custom upload adapter. The adapter will use the native XMLHttpRequest to send files returned by the loader to a pre–configured URL on the server, handling the error, abort, load, and progress events fired by the request.

A simple way to call it in Edit Form.

<EditForm Model="@editorOptions">
    <CKEditorBlazor Id="MyEditor" @bind-Value=@editorOptions.InitialText></CKEditorBlazor>
</EditForm>

# Configure UrlToPostImage and enjoy your images to upload directly. 

An advance way to configure url on ckeditor5-blazor

<EditForm Model="@editorOptions">
    <CKEditorBlazor Id="MyEditor1" 
                    @bind-Value=@editorOptions.InitialText 
                    UrlToPostImage="http://localhost:44301/api/qaiser/Upload">
    </CKEditorBlazor>
</EditForm>
