using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.IO;
 
namespace SaveConverter {
    public partial class SaveConverter : Form {

        readonly byte[] desmumeFooter = new byte[] {
            0x7C, 0x3C, 0x2D, 0x2D, 0x53, 0x6E, 0x69, 0x70, 0x20, 0x61, 0x62, 0x6F, 0x76, 0x65, 0x20, 0x68, // |<--Snip above h
            0x65, 0x72, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x63, 0x72, 0x65, 0x61, 0x74, 0x65, 0x20, 0x61, 0x20, // ere to create a 
            0x72, 0x61, 0x77, 0x20, 0x73, 0x61, 0x76, 0x20, 0x62, 0x79, 0x20, 0x65, 0x78, 0x63, 0x6C, 0x75, // raw sav by exclu
            0x64, 0x69, 0x6E, 0x67, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20, 0x44, 0x65, 0x53, 0x6D, 0x75, 0x4D, // ding this DeSmuM
            0x45, 0x20, 0x73, 0x61, 0x76, 0x65, 0x64, 0x61, 0x74, 0x61, 0x20, 0x66, 0x6F, 0x6F, 0x74, 0x65, // E savedata foote
            0x72, 0x3A, 0x01, 0xF8, 0x07, 0x00, 0x00, 0x00, 0x08, 0x00, 0x06, 0x00, 0x00, 0x00, 0x03, 0x00, // r:.?............
            0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7C, 0x2D, 0x44, 0x45, 0x53, 0x4D, // ..........|-DESM
            0x55, 0x4D, 0x45, 0x20, 0x53, 0x41, 0x56, 0x45, 0x2D, 0x7C                                      // UME SAVE-|
        };

        public SaveConverter() {
            InitializeComponent();

            //this.Size = new System.Drawing.Size(360, 130);
            lbInfo.Visible = true;
            //lbInfo.Location = new System.Drawing.Point(12, 10);
            lbDSInfo.Visible = true;
            //lbDSInfo.Location = new System.Drawing.Point(12, 40);
            btnConvert.Visible = true;
            //btnConvert.Location = new System.Drawing.Point(139, 80);
            btnExit.Visible = true;
            //btnExit.Location = new System.Drawing.Point(265, 80);
        }

        public bool Convert(string file) {
            if (file.EndsWith("dsv")) {
                // Open DesMuME save with filestream and trim the last 122 bytes of the file, which is the desmume footer
                using (var readSave = new FileStream(file, FileMode.Open, FileAccess.Write)) {
                    readSave.SetLength(Math.Max(0, readSave.Length - 122));
                }
                File.Move(file, file.Substring(0, file.Length - 3) + "sav");
                return true;
            }
            else if (file.EndsWith("sav")) {
                // Open  raw save with filestream and append the 122 bytes of the desmume footer
                using (var readSave = new FileStream(file, FileMode.Append, FileAccess.Write)) {
                    readSave.Write(desmumeFooter, 0, desmumeFooter.Length);
                }
                File.Move(file, file.Substring(0, file.Length - 3) + "dsv");
                return true;
            }

            return false;
        }

        private void ConvertFile(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog() {
            Title = "Select .SAV or .DSV to convert",
            Filter = "Save File (*.SAV;*.DSV)|*.sav;*.dsv|All Files (*.*)|*.*",
            Multiselect = false }) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    string saveFile = ofd.FileName;
                    if (File.Exists(saveFile)) {
                        Convert(saveFile);
                    }
                }
                else { return; }
            }
        }

        private void DisposeForm(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void SaveConverter_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void SaveConverter_DragDrop(object sender, DragEventArgs e) {
            string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (draggedFiles.Length > 0) {
                Convert(draggedFiles[0]);
            }
        }
    }
}
