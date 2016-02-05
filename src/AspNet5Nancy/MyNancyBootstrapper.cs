using Nancy;
using Nancy.Bootstrapper;
using Nancy.Linker;
using Nancy.Routing;
using Nancy.TinyIoc;

namespace AspNet5Nancy
{
    public class MyNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IResourceLinker>((x, overloads) =>
                    new ResourceLinker(x.Resolve<IRouteCacheProvider>(),
                        x.Resolve<IRouteSegmentExtractor>(), x.Resolve<IUriFilter>()));

            base.ConfigureApplicationContainer(container);
        }
    }
}
