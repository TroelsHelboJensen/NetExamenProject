[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnitTestingMockUps.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(UnitTestingMockUps.App_Start.NinjectWebCommon), "Stop")]

namespace UnitTestingMockUps.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Models.Repository;
    using Interface;
    using Models.Entity;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // To Bind the Repositories
            kernel.Bind<IProgressRepository>().To<ProgressRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ICategoryRepository<CategoryModel>>().To<CategoryRepository>();
            kernel.Bind<ICategoryRepository<CategoryHeaderModel>>().To<CategoryHeaderRepository>();
        }        
    }
}
