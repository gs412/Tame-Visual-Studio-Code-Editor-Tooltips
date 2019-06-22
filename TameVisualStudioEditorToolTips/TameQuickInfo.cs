namespace TameVisualStudioEditorToolTips {

    using System.ComponentModel.Composition;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(IAsyncQuickInfoSourceProvider))]
    [Name("Tame Quick Info")]
    [Order(Before = "Default Quick Info Presenter")]
    [ContentType("CSharp")]
    [ContentType("Basic")]
    [ContentType("XAML")]
    [ContentType("XML")]
    [ContentType("HTML")]
    [ContentType("CSS")]
    [ContentType("JScript")]
    internal class TameQuickInfo : IAsyncQuickInfoSourceProvider {

        public IAsyncQuickInfoSource TryCreateQuickInfoSource(ITextBuffer textBuffer) {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new CancelingQuickInfoSource());
        }
    }

    internal class CancelingQuickInfoSource : IAsyncQuickInfoSource {

        public CancelingQuickInfoSource() {
        }

        public void Dispose() {
        }

        public async Task<QuickInfoItem> GetQuickInfoItemAsync(IAsyncQuickInfoSession session, CancellationToken cancellationToken) {
            var isKeyDown = false;
            ThreadHelper.JoinableTaskFactory.Run(async delegate {
                // now on the UI thread
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                isKeyDown = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift) || Keyboard.IsKeyDown(Key.LeftCtrl)  || Keyboard.IsKeyDown(Key.RightCtrl);
            });

            // back on background thread
            if (!isKeyDown) {
                _ = session.DismissAsync();
            }
            return await System.Threading.Tasks.Task.FromResult<QuickInfoItem>(null);
        }
    }
}
