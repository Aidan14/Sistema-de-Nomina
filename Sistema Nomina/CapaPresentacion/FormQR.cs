using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormQR : Form
    {
        string QRText;

        public FormQR(string _QRText)
        {
            InitializeComponent();
            QRText = _QRText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormQR_Load(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrBarcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            picBox.Image = qrBarcode.Draw(QRText, 300);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            picBox.Image.Save(path+"\\" + "QREmpleado " + QRText + ".jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
