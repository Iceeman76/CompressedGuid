namespace CompressedGuid;

/// <summary>
/// Represents a compressed version of a GUID (Globally Unique Identifier).
/// Provides methods to encode a GUID into a shorter string representation and decode it back.
/// The string representation is a Base64-encoded, URL-safe, 22-character string.
/// </summary>
public readonly record struct CompressedGuid
{
    /// <summary>
    /// Gets the original <see cref="Guid"/> representation of the compressed GUID.
    /// This property holds the full 128-bit globally unique identifier (GUID)
    /// that corresponds to the compressed string representation.
    /// </summary>
    public Guid GuidRepresentation { get; }

    /// <summary>
    /// Gets the Base64-encoded compressed string representation of the <see cref="Guid"/>.
    /// This property provides a URL-safe, 22-character string that represents the GUID in a compact format.
    /// </summary>
    public string StringRepresentation { get; }

    public CompressedGuid(Guid guid)
    {
        GuidRepresentation = guid;
        StringRepresentation = Encode(guid);
    }

    public CompressedGuid(string input)
    {
        GuidRepresentation = Decode(input);
        StringRepresentation = input;
    }

    /// <summary>
    /// Gets an instance of <see cref="CompressedGuid"/> that represents an empty GUID.
    /// This property holds a compressed string representation of <see cref="Guid.Empty"/>.
    /// </summary>
    public static CompressedGuid Empty { get; } = new(Guid.Empty);

    /// <summary>
    /// Parses the provided string or Guid into a <see cref="CompressedGuid"/> instance.
    /// This method creates a new <see cref="CompressedGuid"/> object representing the compressed form of the input.
    /// </summary>
    /// <param name="guid">
    /// The <see cref="Guid"/> to be compressed into a <see cref="CompressedGuid"/>.
    /// </param>
    /// <returns>
    /// A <see cref="CompressedGuid"/> representing the compressed version of the provided <see cref="Guid"/>.
    /// </returns>
    public static CompressedGuid Parse(Guid guid) => new(guid);

    /// <summary>
    /// Parses a string representation of a compressed GUID into a <see cref="CompressedGuid"/> instance.
    /// </summary>
    /// <param name="input">The string representation of the compressed GUID,
    /// encoded as a 22-character, URL-safe, Base64 format.</param>
    /// <returns>A <see cref="CompressedGuid"/> instance that represents the provided input.</returns>
    public static CompressedGuid Parse(string input) => new(input);

    private static string Encode(Guid guid)
    {
        var bytes = guid.ToByteArray(bigEndian: false);
        var base64 = Convert.ToBase64String(bytes);
        var encoded = base64.Replace("/", "_").Replace("+", "-");

        return encoded[..22];
    }

    private static Guid Decode(string input)
    {
        var padded = $"{input}==";
        var decoded = padded.Replace("_", "/").Replace("-", "+");
        var bytes = Convert.FromBase64String(decoded);
        var guid = new Guid(bytes);

        return guid;
    }

    public override string ToString() => StringRepresentation;

    public static implicit operator CompressedGuid(string str) => Parse(str);
    public static implicit operator string(CompressedGuid id) => id.ToString();
}
