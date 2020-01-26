using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.IO;
 
namespace SaveConverter {
    public partial class SaveConverter : Form {

        readonly byte[] desmumeFooter = new byte[] {
            0x7C, 0x3C, 0x2D, 0x2D, 0x53, 0x6E, 0x69, 0x70, 0x20, 0x61, // why does it hurt when i pee
            0x62, 0x6F, 0x76, 0x65, 0x20, 0x68, 0x65, 0x72, 0x65, 0x20,
            0x74, 0x6F, 0x20, 0x63, 0x72, 0x65, 0x61, 0x74, 0x65, 0x20,
            0x61, 0x20, 0x72, 0x61, 0x77, 0x20, 0x73, 0x61, 0x76, 0x20,
            0x62, 0x79, 0x20, 0x65, 0x78, 0x63, 0x6C, 0x75, 0x64, 0x69,
            0x6E, 0x67, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20, 0x44, 0x65,
            0x53, 0x6D, 0x75, 0x4D, 0x45, 0x20, 0x73, 0x61, 0x76, 0x65,
            0x64, 0x61, 0x74, 0x61, 0x20, 0x66, 0x6F, 0x6F, 0x74, 0x65,
            0x72, 0x3A, 0x01, 0xF8, 0x07, 0x00, 0x00, 0x00, 0x08, 0x00,
            0x06, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7C, 0x2D, 0x44, 0x45,
            0x53, 0x4D, 0x55, 0x4D, 0x45, 0x20, 0x53, 0x41, 0x56, 0x45,
            0x2D, 0x7C
        };

        public SaveConverter() {
            InitializeComponent();

            this.Size = new System.Drawing.Size(360, 130);
            lbInfo.Visible = true;
            lbInfo.Location = new System.Drawing.Point(12, 10);
            lbDSInfo.Visible = true;
            lbDSInfo.Location = new System.Drawing.Point(12, 40);
            btnConvert.Visible = true;
            btnConvert.Location = new System.Drawing.Point(139, 80);
            btnExit.Visible = true;
            btnExit.Location = new System.Drawing.Point(265, 80);
        }

        private void ConvertFile(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog() {
            Title = "Select .SAV or .DSV to convert",
            Filter = "Save File (*.SAV;*.DSV)|*.sav;*.dsv|All Files (*.*)|*.*",
            Multiselect = false }) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    string saveFile = ofd.FileName;
                    if (File.Exists(saveFile)) {
                        try {
                            if (saveFile.EndsWith("dsv")) {
                                // Open DesMuME save with filestream and trim the last 122 bytes of the file, which is the desmume footer
                                using (var readSave = new FileStream(saveFile, FileMode.Open, FileAccess.Write)) {
                                    readSave.SetLength(Math.Max(0, readSave.Length - 122));
                                }
                                File.Move(saveFile, saveFile.Substring(0, saveFile.Length - 3) + "sav");
                            }
                            else if (saveFile.EndsWith("sav")) {
                                // Open  raw save with filestream and append the 122 bytes of the desmume footer
                                using (var readSave = new FileStream(saveFile, FileMode.Append, FileAccess.Write)) {
                                    readSave.Write(desmumeFooter, 0, desmumeFooter.Length);
                                }
                                File.Move(saveFile, saveFile.Substring(0, saveFile.Length - 3) + "dsv");
                            }


                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                else { return; }
            }
        }

        private void DisposeForm(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
