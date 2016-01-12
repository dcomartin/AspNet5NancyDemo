using Nancy;

namespace AspNet5Nancy
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            Get["/nancy/demo"] = parameters => new string[] { "Hello", "World" };
        }
    }
}
