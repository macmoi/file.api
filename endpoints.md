# Endpoints

## Get users

METHOD: **GET**
```bash
https://localhost:5001/api/user
```
```json
[
  {
    "id": 7,
    "name": "Edward",
    "lastName": "Norton",
    "attachmentResources": null
  },
  {
    "id": 8,
    "name": "Edward",
    "lastName": "Pinate",
    "attachmentResources": null
  },
  {
    "id": 9,
    "name": "Scarlett",
    "lastName": "Johanson",
    "attachmentResources": null
  },
  //...
]
```

## Upload attachment

METHOD: **POST**
Content-Type: Multipart-Form/data
Params: 
    fileName (String).
    file: .pdf, txt, jpg, png, doc, etc... (Maximum 256 KB)
    userId: Associated userId

```bash
https://localhost:5001/api/user/{userId}
```

Response
```json
{
  "id": 6,
  "fileName": "testing",
  "file":"W1N1biBNYXIgMDEgMDg6Mzg6MjkuNTYyNzU5IDIwMjBdIFttcG1fcHJlZm9yazpub3RpY2VdIFtwaWQgMTQyM10gQUgwMDE2MzogQXBhY2hlLzIuNC4yOSAoVWJ1bnR1KSBtb2RfZmNnaWQvMi4zLjkgY29uZmlndXJlZCAtLSByZXN1bWluZyBub3JtYWwgb3BlcmF0aW9ucwpbU3VuIE1hciAwMSAwODozODoyOS41NjI3OTAgMjAyMF0gW2NvcmU6bm90aWNlXSBbcGlkIDE0MjNdIEFIMDAwOTQ6IENvbW1hbmQgbGluZTogJy91c3Ivc2Jpbi9hcGFjaGUyJwo=",
  "user": null
}
```

Possible Error codes:
- Error 400: Bad request: Message: **Maximum file size (256 KB)**
- Error 400: Bad request: Message: **No user Id param**

## Get attachment

METHOD: **GET**

```bash
https://localhost:5001/api/attachment/{attachmentId}
```

Response:
```json
{
  "id": 1,
  "fileName": "testing",
  "file": "W1NhdCBGZWIgMjkgMDQ6MDk6NTguMjYwODkxIDIwMjBdIFttcG1fcHJlZm9yazpub3RpY2VdIFtwaWQgMTUzNl0gQUgwMDE2MzogQXBhY2hlLzIuNC4yOSAoVWJ1bnR1KSBtb2RfZmNnaWQvMi4zLjkgY29uZmlndXJlZCAtLSByZXN1bWluZyBub3JtYWwgb3BlcmF0aW9ucwpbU2F0IEZlYiAyOSAwNDowOTo1OC4yNjA5MTMgMjAyMF0gW2NvcmU6bm90aWNlXSBbcGlkIDE1MzZdIEFIMDAwOTQ6IENvbW1hbmQgbGluZTogJy91c3Ivc2Jpbi9hcGFjaGUyJwo=",
  "user": null
}
```

Possible error codes:
- Error 404 Bad request: **missing param Id**