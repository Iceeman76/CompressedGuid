namespace CompressedGuid;

public readonly record struct CompressedGuid
{
    public Guid GuidRepresentaion { get; }
    public string StringRepresentation { get; }

    public CompressedGuid(Guid guid)
    {
        GuidRepresentaion = guid;
        StringRepresentation = Encode(guid);
    }

    public CompressedGuid(string input)
    {
        GuidRepresentaion = Decode(input);
        StringRepresentation = input;
    }

    public static CompressedGuid Empty { get; } = new(Guid.Empty);

    public static CompressedGuid Parse(Guid guid) => new(guid);
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
