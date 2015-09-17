using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Composition;
using Autofac;
using Autofac.Core;

namespace WindowsUI
{
    static class Program
    {
        public static IContainer Container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new Application.Composition.CoreModule());
            builder.RegisterModule(new Application.Composition.ApplicationModule());
            builder.RegisterModule(new Application.Composition.MessagingModule());
            builder.RegisterModule(new PersistenceModule()
            {
                ConnectionStringOrName = "name=ClaimConnectionString"
            });
            builder.RegisterType<Form1>().AsSelf();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            Container = builder.Build();
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var form = Container.Resolve<Form1>();
            System.Windows.Forms.Application.Run(form);
            System.Windows.Forms.Application.ApplicationExit += Application_ApplicationExit;
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Container?.Dispose();
        }
    }
}
