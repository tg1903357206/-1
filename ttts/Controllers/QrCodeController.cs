using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ThoughtWorks.QRCode.Codec;

namespace ttts.Controllers
{
    /// <summary>
    /// 二维码
    /// </summary>
    public class QrCodeController : Controller
    {
        // GET: QrCode
        public ActionResult Index()
        {
            QRCodeEncoder endocder = new QRCodeEncoder();
            //二维码背景颜色
            endocder.QRCodeBackgroundColor = System.Drawing.Color.White;
            //二维码编码方式
            endocder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //每个小方格的宽度
            endocder.QRCodeScale = 10;
            //二维码版本号
            endocder.QRCodeVersion = 5;
            //纠错等级
            endocder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            var person = new { Id = 4, Name = "sss", Gender = 1, Age = 22 };
            //将json川做成二维码
            Bitmap bitmap = endocder.Encode(new JavaScriptSerializer().Serialize(person), System.Text.Encoding.UTF8);
            string strSaveDir = Request.MapPath("/QRcode/");
            if (!Directory.Exists(strSaveDir))
            {
                Directory.CreateDirectory(strSaveDir);
            }
            string strSavePath = Path.Combine(strSaveDir, person.Name + ".png");
            if (!System.IO.File.Exists(strSavePath))
            {
                bitmap.Save(strSavePath);
            }
            ViewBag.img = "/QRcode/" + person.Name + ".png";
            return View();
        }

        public string DeCoder()
        {
            string result = "";
            string strSaveDir = Request.MapPath("/QRcode/");
            if (!Directory.Exists(strSaveDir))
            {
                Directory.CreateDirectory(strSaveDir);
            }
            string strSavePath = Path.Combine(strSaveDir, "sss.png");
            if (System.IO.File.Exists(strSavePath))
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                result = decoder.decode(new ThoughtWorks.QRCode.Codec.Data.QRCodeBitmapImage(new Bitmap(Image.FromFile(strSavePath))));
            }

            return result;
        }

    }
}