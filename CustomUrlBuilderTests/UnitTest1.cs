using System.Text;
using System.Web;

namespace CustomUrlBuilderTests;

public class Tests
{
    public class CustomUrlBuilder
    {
        private readonly Dictionary<string, string> parameters;
        private readonly List<string> paths;

        private string baseUrl = string.Empty;
        private string fragment = string.Empty;

        public CustomUrlBuilder()
        {
            parameters = new Dictionary<string, string>();
            paths = new List<string>();
        }

        public CustomUrlBuilder(string baseUrl) : this()
        {
            this.baseUrl = baseUrl;
        }

        public CustomUrlBuilder(string baseUrl, string fragment) : this(baseUrl)
        {
            this.fragment = fragment;
        }

        public CustomUrlBuilder SetBaseUrl(string baseUrl)
        {
            this.baseUrl = baseUrl;

            return this;
        }

        public CustomUrlBuilder AddParameter(string name, bool encode = true)
        {
            if (encode)
            {
                name = HttpUtility.UrlEncode(name);
            }

            parameters.Add(name, null);

            return this;
        }

        public CustomUrlBuilder AddParameter(string name, string value, bool encodeName = true, bool encodeValue = true)
        {
            if (encodeName)
            {
                name = HttpUtility.UrlEncode(name);
            }

            if (encodeValue)
            {
                value = HttpUtility.UrlEncode(value);
            }

            parameters.Add(name, value);

            return this;
        }

        public CustomUrlBuilder AddPath(string name, bool encode = true)
        {
            if (encode)
            {
                name = HttpUtility.UrlEncode(name);
            }

            paths.Add(name);

            return this;
        }

        public CustomUrlBuilder SetFragment(string fragment, bool encode = true)
        {
            if (encode)
            {
                fragment = HttpUtility.UrlEncode(fragment);
            }

            this.fragment = fragment;

            return this;
        }

        public override string ToString()
        {
            var pathsStr = string.Join("/", paths);

            var paramsStr = string.Join("&", parameters.Select(x =>
            {
                if (string.IsNullOrWhiteSpace(x.Value))
                {
                    return x.Key;
                }
                else
                {
                    return string.Join("=", new[] { x.Key, x.Value });
                }
            }));

            var sb = new StringBuilder(baseUrl);

            if (!string.IsNullOrWhiteSpace(pathsStr))
            {
                if (sb.Length > 0)
                {
                    sb.Append("/");
                }

                sb.Append(pathsStr);
            }

            if (!string.IsNullOrWhiteSpace(paramsStr))
            {
                sb.Append("?");
                sb.Append(paramsStr);
            }

            if (!string.IsNullOrWhiteSpace(fragment))
            {
                sb.Append("#");
                sb.Append(fragment);
            }

            return sb.ToString();
        }
    }

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Test1()
    {
        var urlBuilder = new CustomUrlBuilder()
            .AddPath("leistungen")
            .AddPath("rechtsberatung")
            .SetFragment("wochenplan");

        var result = urlBuilder.ToString();

        Console.WriteLine(result);
    }
}