using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Nancy;
using Nancy.Linker;

namespace AspNet5Nancy
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule(IResourceLinker linker)
        {
            Get["HelloWorldRoute", "/nancy/demo/{MyQueryParameter:string}"] =
                parameters => new[] {"Hello", "World", (string) parameters.MyQueryParameter};

            Get["FindHelloWorld", "/nancy/findhelloworld"] = parameters => new[]
            {
                linker.BuildAbsoluteUri(Context, "HelloWorldRoute", new {MyQueryParameter = "CodeOpinion"})
            };

            Get["GzipTest", "/nancy/gziptest"] = parameters =>
            {
                return new Response
                {
                    ContentType = "application/json",
                    StatusCode = HttpStatusCode.OK,
                    Contents = stream =>
                    {
                        var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AspNet5Nancy.fakedata.json");
                        using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
                        {
                            var content = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                            stream.Write(content, 0, content.Length);
                        }
                    }
                };
            };
        }
    }
}