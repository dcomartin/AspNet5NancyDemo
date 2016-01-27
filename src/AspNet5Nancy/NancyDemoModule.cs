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
        }
    }
}