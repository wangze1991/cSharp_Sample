using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
namespace web.sample.Controllers
{
    public class UploadController : Controller
    {
        /// <summary>
        ///  allowedExtensions: ['gif', 'png', 'jpg', 'jpeg', 'pdf', 'rar', 'zip'],
        /// </summary>
        private static readonly string[] IMG_EXTENSION = { ".gif", ".png", ".jpg", ".jpeg" };
        // GET: Upload
        public ActionResult Index()
        {
            return View();

        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            try
            {
                if (file == null)
                {
                    return Fail("没有上传图片");
                }
                if (string.IsNullOrWhiteSpace(file.FileName))
                {
                    return Fail("图片没有名称");
                }
                string extension = Path.GetExtension(file.FileName);
                if (IMG_EXTENSION.Any(x => x.Equals(Path.GetExtension(file.FileName), StringComparison.CurrentCultureIgnoreCase))==false)
                {
                    return Fail("图片格式不符合要求");
                }
                string basePath = Server.MapPath(@"~/upload");
                if (Directory.Exists(basePath) == false)
                {
                    Directory.CreateDirectory(basePath);
                }
                Guid fileName = Guid.NewGuid();
                string newFilePath = Path.Combine(basePath, fileName.ToString() + Path.GetExtension(file.FileName));
                using (Stream imageStream = file.InputStream)
                {
                    getThumImage(imageStream, 85L, 2, newFilePath);
                }
                return Success("上传成功");
            }
            catch (Exception ex)
            {
                return Fail("上传失败");
            }
            finally
            {

            }

        }

        [NonAction]
        public ActionResult Success(string msg, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Content(string.Format(@"{{""isSuccess"":true,""msg"":""{0}""}}", msg), "text/html", Encoding.UTF8);
        }
        [NonAction]
        public ActionResult Fail(string msg, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Content(string.Format(@"{{""isSuccess"":false,""msg"":""{0}""}}", msg), "text/html", Encoding.UTF8);//IE8 返回不认识application/json，所以只能返回text/html
        }


        #region getThumImage
        /**/
        /// <summary>  
        /// 生成缩略图  http://blog.csdn.net/qq_16542775/article/details/51792149
        /// </summary>  
        /// <param name="sourceFile">原始图片文件</param>  
        /// <param name="quality">质量压缩比</param>  
        /// <param name="multiple">收缩倍数</param>  
        /// <param name="outputFile">输出文件名</param>  
        /// <returns>成功返回true,失败则返回false</returns>  
        public static bool getThumImage(Stream imageStream, long quality, int multiple, String outputFile)
        {
            try
            {
                //TODO如果图片过大，则进行收缩倍数                                                                                                                                                                                                                                                                                          
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(imageStream);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion getThumImage

        /**/
        /// <summary>  
        /// 获取图片编码信息  
        /// </summary>  
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }


    }
}