namespace MediatorDemo
{
    using Castle.Windsor;
    using Controllers;
    using Installers;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Install(new ApplicationInstaller());

            var controller = container.Resolve<DemoController>();

            controller.RequestPizza();

            // controller.CancelPizzaOrder();
            // controller.RequestPizzaAdvancedWithNotification();
        }
    }
}