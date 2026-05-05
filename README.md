# CompressedGuid

A thread-safe and URL-safe compressed globally unique identifier for .NET.

Converts a standard `Guid` (36 characters) into a compact 22-character Base64-encoded string that is safe to use in URLs, filenames, and other contexts where the standard GUID format is inconvenient.

```
9b74987e-1a98-4828-9757-85a5d8aa1c10  →  fph0m5gaKEiXV4Wl2KocEA
00000000-0000-0000-0000-000000000000  →  AAAAAAAAAAAAAAAAAAAAAA
```

## Usage

```csharp
// From a GUID
CompressedGuid id = CompressedGuid.Parse(Guid.NewGuid());
string shortId = id.StringRepresentation; // e.g. "fph0m5gaKEiXV4Wl2KocEA"

// From a compressed string
CompressedGuid id = CompressedGuid.Parse("fph0m5gaKEiXV4Wl2KocEA");
Guid original = id.GuidRepresentation;

// Implicit conversions
CompressedGuid id = "fph0m5gaKEiXV4Wl2KocEA";
string str = id;

// Empty GUID
CompressedGuid empty = CompressedGuid.Empty; // "AAAAAAAAAAAAAAAAAAAAAA"
```

## API

`CompressedGuid` is a `readonly record struct` — fully immutable and thread-safe.

| Member | Description |
|---|---|
| `Parse(Guid)` | Creates a `CompressedGuid` from a `Guid` |
| `Parse(string)` | Creates a `CompressedGuid` from a 22-character compressed string |
| `GuidRepresentation` | The original `Guid` |
| `StringRepresentation` | The 22-character compressed string |
| `Empty` | Represents `Guid.Empty` (`"AAAAAAAAAAAAAAAAAAAAAA"`) |

## Encoding

GUID bytes are Base64-encoded with URL-safe substitutions (`+` → `-`, `/` → `_`). The trailing `==` padding is dropped, yielding exactly 22 characters.

## Requirements

.NET 10.0
