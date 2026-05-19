using System.Collections;
using CompressedGuidNet;

namespace CompressedGuidTests;

[TestFixture]
public class CompressedGuidTests
{
    [TestCaseSource(nameof(TestCases))]
    public void Should_have_correct_string_representation_when_parsed_from_guid(Guid guid, string str)
    {
        var applicationId = CompressedGuid.Parse(guid);

        Assert.That(applicationId.StringRepresentation, Is.EqualTo(str));
    }

    [TestCaseSource(nameof(TestCases))]
    public void Should_have_correct_guid_representation_when_parsed_from_string(Guid guid, string str)
    {
        var applicationId = CompressedGuid.Parse(str);

        Assert.That(applicationId.GuidRepresentation, Is.EqualTo(guid));
    }

    [TestCaseSource(nameof(TestCases))]
    public void Should_override_to_string_when_parsed_from_guid(Guid guid, string str)
    {
        var applicationId = CompressedGuid.Parse(guid);

        Assert.That(applicationId.ToString(), Is.EqualTo(str));
    }

    [TestCaseSource(nameof(TestCases))]
    public void Should_override_to_string_when_parsed_from_string(Guid guid, string str)
    {
        var applicationId = CompressedGuid.Parse(str);

        Assert.That(applicationId.ToString(), Is.EqualTo(str));
    }

    [Test]
    public void Should_be_empty()
    {
        var expected = CompressedGuid.Parse("AAAAAAAAAAAAAAAAAAAAAA");
        Assert.That(CompressedGuid.Empty, Is.EqualTo(expected));
    }

    [Test]
    public void Should_be_equal_when_created_from_guid()
    {
        var guid = Guid.NewGuid();

        var applicationId1 = new CompressedGuid(guid);
        var applicationId2 = new CompressedGuid(guid);

        Assert.That(applicationId1, Is.EqualTo(applicationId2));
    }

    [Test]
    public void Should_be_equal_when_created_from_string()
    {
        var applicationId1 = new CompressedGuid("fph0m5gaKEiXV4Wl2KocEA");
        var applicationId2 = new CompressedGuid("fph0m5gaKEiXV4Wl2KocEA");

        Assert.That(applicationId1, Is.EqualTo(applicationId2));
    }

    [Test]
    public void Should_be_equal_when_created_from_string_and_guid()
    {
        var applicationId1 = new CompressedGuid("fph0m5gaKEiXV4Wl2KocEA");
        var applicationId2 = new CompressedGuid(Guid.Parse("9b74987e-1a98-4828-9757-85a5d8aa1c10"));

        Assert.That(applicationId1, Is.EqualTo(applicationId2));
    }

    [Test]
    public void Should_implicitly_convert_from_string_to_application_id()
    {
        CompressedGuid compressedGuid = "fph0m5gaKEiXV4Wl2KocEA";

        Assert.That(compressedGuid.StringRepresentation, Is.EqualTo("fph0m5gaKEiXV4Wl2KocEA"));
    }

    [Test]
    public void Should_implicitly_convert_from_application_id_to_string()
    {
        var applicationId = CompressedGuid.Parse("fph0m5gaKEiXV4Wl2KocEA");
        string str = applicationId;

        Assert.That(str, Is.EqualTo("fph0m5gaKEiXV4Wl2KocEA"));
    }

    private static IEnumerable TestCases()
    {
        yield return new TestCaseData(Guid.Parse("00000000-0000-0000-0000-000000000000"), "AAAAAAAAAAAAAAAAAAAAAA");
        yield return new TestCaseData(Guid.Parse("9b74987e-1a98-4828-9757-85a5d8aa1c10"), "fph0m5gaKEiXV4Wl2KocEA");
        yield return new TestCaseData(Guid.Parse("c9a646d3-9c61-4cb7-bfcd-ee2522c8f633"), "00amyWGct0y_ze4lIsj2Mw");
        yield return new TestCaseData(Guid.Parse("e3626f90-a8bb-46a2-be97-11b1fdffafec"), "kG9i47uooka-lxGx_f-v7A");
        yield return new TestCaseData(Guid.Parse("f87e143b-8872-4910-95fb-f9a9452f5aa0"), "OxR--HKIEEmV-_mpRS9aoA");
        yield return new TestCaseData(Guid.Parse("abbefee7-6cf4-49cc-85f9-d71c9ce52956"), "5_6-q_RszEmF-dccnOUpVg");
        yield return new TestCaseData(Guid.Parse("820e8dc8-f75f-4fd9-bf40-9f209993888a"), "yI0Ogl_32U-_QJ8gmZOIig");
        yield return new TestCaseData(Guid.Parse("67ee8227-31f3-4d6d-8118-cd8bfb064e1e"), "J4LuZ_MxbU2BGM2L-wZOHg");
        yield return new TestCaseData(Guid.Parse("4e378161-81e9-4fe3-bb66-1bcefc02f410"), "YYE3TumB40-7ZhvO_AL0EA");
        yield return new TestCaseData(Guid.Parse("4e9a9fad-c61f-4077-a3cd-ed6326481221"), "rZ-aTh_Gd0Cjze1jJkgSIQ");
        yield return new TestCaseData(Guid.Parse("e5b2baa3-50e6-4815-9394-3745edefc2fa"), "o7qy5eZQFUiTlDdF7e_C-g");
        yield return new TestCaseData(Guid.Parse("56385e96-d84f-4ff7-aba5-c11f9e436431"), "ll44Vk_Y90-rpcEfnkNkMQ");
        yield return new TestCaseData(Guid.Parse("550202fa-2028-4d66-b4be-c7bf0eca987f"), "-gICVSggZk20vse_DsqYfw");
        yield return new TestCaseData(Guid.Parse("73cc12fd-f4b1-4fca-b35e-b6a3a52d8e09"), "_RLMc7H0yk-zXrajpS2OCQ");
        yield return new TestCaseData(Guid.Parse("91ef70a7-3f95-4c80-a366-1c2987e74bf8"), "p3DvkZU_gEyjZhwph-dL-A");
        yield return new TestCaseData(Guid.Parse("1aca6cc9-e088-4bff-8408-3dfead7c7a42"), "yWzKGojg_0uECD3-rXx6Qg");
    }
}
