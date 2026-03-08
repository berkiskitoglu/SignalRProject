using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQRCode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                ViewBag.Error = "Değer boş olamaz";
                return View("Index");
            }

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                    }
                }
            }

            return View("Index");
        }
        [HttpPost]
        public IActionResult DecodeQRCode(IFormFile qrImage)
        {
            if (qrImage == null || qrImage.Length == 0)
            {
                ViewBag.DecodeError = "Dosya seçiniz";
                return View("Index");
            }

            try
            {
                using (var stream = qrImage.OpenReadStream())
                {
                    using (var bitmap = new Bitmap(stream))
                    {
                        var source = new BitmapLuminanceSource(bitmap);
                        var hybridBinarizer = new HybridBinarizer(source);
                        var binaryBitmap = new BinaryBitmap(hybridBinarizer);
                        var reader = new MultiFormatReader();
                        var result = reader.decode(binaryBitmap);

                        if (result != null)
                        {
                            ViewBag.DecodedValue = result.Text;
                        }
                        else
                        {
                            ViewBag.DecodeError = "QR Kod okunamadı";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.DecodeError = "Hata: " + ex.Message;
            }

            return View("Index");
        }
    }
}
