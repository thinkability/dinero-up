using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using think.dinero_up.ShellExtension.Clients;
using think.dinero_up.ShellExtension.Exceptions;

namespace think.dinero_up.ShellExtension
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".pdf")]
    [COMServerAssociation(AssociationType.FileExtension, ".jpg", ".jpeg")]
    public class DineroUploadExtension : SharpContextMenu
    {
        private readonly DineroClient _dineroClient = new DineroClient();
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var imgFile = assembly.GetManifestResourceStream("think.dinero_up.ShellExtension.Assets.dinero-logo.png");

            var menu = new ContextMenuStrip();

            var uploadItem = new ToolStripMenuItem
            {
                Text = "Upload til Dinero",
                Image = Image.FromStream(imgFile)
            };

            uploadItem.Click += (sender, args) =>
            {
                var selectedFiles = SelectedItemPaths.Select(s => new FileInfo(s));

                foreach (var file in selectedFiles.AsParallel())
                {
                    try
                    {
                        _dineroClient.UploadVoucher(file);
                        MessageBox.Show(null, $"Filen \"{file.Name}\" blev uploaded til Dinero :)", "Succes");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, $"Filen \"{file.Name}\" kunne ikke uploades.{Environment.NewLine}{ex.Message}", "Fejl");
                    }
                }
            };

            menu.Items.Add(uploadItem);

            return menu;
        }
    }
}