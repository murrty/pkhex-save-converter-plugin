using System;
using System.Windows.Forms;
using PKHeX.Core;

namespace SaveConverter {
    public class SaveConverterPlugin : IPlugin {

        public string Name => "DesMuME Save Converter";
        public int Priority => 17;
        public ISaveFileProvider SaveFileEditor { get; private set; }

        public void Initialize(params object[] args) {
            Console.WriteLine($"{Name} is starting up");
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            var getMenu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            LoadMenuStrip(getMenu);
        }

        private void LoadMenuStrip(ToolStrip menuStrip) {
            var getItems = menuStrip.Items;
            var getTools = getItems.Find("Menu_Tools", false)[0] as ToolStripDropDownItem;
            AddPluginControl(getTools);
        }

        private void AddPluginControl(ToolStripDropDownItem toolsMenu) {
            var scButton = new ToolStripMenuItem(Name);
            toolsMenu.DropDownItems.Add(scButton);
            scButton.Image = Properties.Resources.shit.ToBitmap();
            scButton.Click += new EventHandler(ShowConverter);
        }

        private void ShowConverter(object sender, EventArgs e) {
            SaveConverter sc = new SaveConverter();
            sc.ShowDialog();
            sc.Dispose();
        }

        public void NotifySaveLoaded() {
            Console.WriteLine($"{Name} NotifySaveLoaded not implemented. Unimportant.");
        }
        public bool TryLoadFile(string filePath) {
            Console.WriteLine($"{Name} TryLoadFile not implemented. Unimportant.");
            return false; // no action taken
        }
    }
}
