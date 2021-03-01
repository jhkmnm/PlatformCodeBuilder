using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using PlatformCodeBuilder.Templates;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.ComponentModel.Design;
using Engine = RazorEngine.Engine;
using Task = System.Threading.Tasks.Task;

namespace PlatformCodeBuilder
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CodeGeneration
    {
        public static DTE2 _dte;

        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("179ac057-32cc-b31d-3f0f-1dd855a12e6f");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGeneration"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private CodeGeneration(AsyncPackage package, OleMenuCommandService commandService)
        {
            InitRazorEngine();
            this.package = package ?? throw new ArgumentNullException("package为空"+nameof(package));
            commandService = commandService ?? throw new ArgumentNullException("commandService为空"+nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);           
        }

        private void InitRazorEngine()
        {
            var config = new TemplateServiceConfiguration
            {
                TemplateManager = new EmbeddedResourceTemplateManager(typeof(Template))
            };
            Engine.Razor = RazorEngineService.Create(config);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static CodeGeneration Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package, DTE2 dte)
        {
            // Switch to the main thread - the call to AddCommand in Command1's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            _dte = dte;
            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new CodeGeneration(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            new Form1(_dte).ShowDialog();
        }
    }
}
