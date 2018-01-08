///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using Autofac;
using Sample.IViewModels;
using Xamarin.Forms.Navigation;

namespace Sample.ViewModels
{
    public class ViewModelLocator
    {
        private IContainer _container;

        public ViewModelLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<HomeViewModel>().As<IHomeViewModel>().SingleInstance();
            builder.RegisterType<FirstViewModel>().As<IFirstViewModel>().SingleInstance();
            builder.RegisterType<SecondViewModel>().As<ISecondViewModel>().SingleInstance();
            builder.RegisterType<ThirdViewModel>().As<IThirdViewModel>().SingleInstance();
            builder.RegisterType<FourthViewModel>().As<IFourthViewModel>().SingleInstance();

            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            _container = builder.Build();
        }

        public IHomeViewModel Home
        {
            get
            {
                return _container.Resolve<IHomeViewModel>();
            }
        }

        public IFirstViewModel First
        {
            get
            {
                return _container.Resolve<IFirstViewModel>();
            }
        }

        public ISecondViewModel Second
        {
            get
            {
                return _container.Resolve<ISecondViewModel>();
            }
        }

        public IThirdViewModel Third
        {
            get
            {
                return _container.Resolve<IThirdViewModel>();
            }
        }

        public IFourthViewModel Fourth
        {
            get
            {
                return _container.Resolve<IFourthViewModel>();
            }
        }
    }
}
